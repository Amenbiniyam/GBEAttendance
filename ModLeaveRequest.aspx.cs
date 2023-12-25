using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class ModLeaveRequest : System.Web.UI.Page
    {
        AttDAL DA = new AttDAL();
        LeaveDAL DAL = new LeaveDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Session["userId"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            if (!this.IsPostBack)
            {
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);

               


            }
        }


      

     

        private void PopulateMenuDataTable(DataTable dt)
        {
            treeDepa.CollapseAll();
            CreateTreeViewDataTable(dt, 0, null);
        }



        private void CreateTreeViewDataTable(DataTable dt, int parentID, TreeNode parentNode)
        {
            DataRow[] drs = dt.Select("Department_Id = " + parentID.ToString());
            foreach (DataRow i in drs)
            {
                TreeNode newNode = new TreeNode(i["DepartmentName"].ToString(), i["Id"].ToString());
                if (parentNode == null)
                {
                    treeDepa.Nodes.Add(newNode);
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                }
                CreateTreeViewDataTable(dt, Convert.ToInt32(i["Id"]), newNode);
            }
            treeDepa.CollapseAll();
        }

        protected void treeDepa_SelectedNodeChanged(object sender, EventArgs e)
        {
           
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();
            DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));
            ddlEmp.Items.Clear();

            ddlEmp.Items.Add("---");
            ddlEmp.AppendDataBoundItems = true;
            ddlEmp.DataSource = ds;
            this.ddlEmp.DataTextField = "Full_Name";
            this.ddlEmp.DataValueField = "EmpId";

            ddlEmp.DataBind();
           




        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {

                Response.Redirect("ModLeaveRequest.aspx");
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblMSG.Text = "";

                mesgPN.BackColor = System.Drawing.Color.White;

                if (ddlEmp.SelectedItem.Text == "--Select Department--" || ddlEmp.SelectedItem.Text == "---")
                {
                    lblMSG.Text = "Error:" + "Please Select Employee";
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    mesgPN.BackColor = System.Drawing.Color.LightPink;

                }
                else
                {


                    fillBAl();
                  
                }
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void fillGrid()
        {
            DataSet ds = DAL.selectEmployeeLevaeBal(int.Parse(ddlEmp.SelectedValue.ToString()));
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.Visible = true;
            grvView.Visible = false;
        
        }


     
        protected void Edit(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            using (GridViewRow rowM = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                lblID.Text = rowM.Cells[1].Text;
                DataSet ds = DAL.LeaveRequestDetail(Int32.Parse(rowM.Cells[1].Text), Int32.Parse(rowM.Cells[2].Text), "Authorized");
                grvView.DataSource = ds;
                grvView.DataBind();



                foreach (GridViewRow row in grvView.Rows)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    chkRow.Checked = true;
                    row.BackColor = System.Drawing.Color.Salmon;
                }

            }
            Panel3.Visible = true;
            grvView.Visible = true;

        }



        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                try
                {

                    if (row.Cells[9].Text == "System" || row.Cells[9].Text == "System Expired Leave")
                    {
                        DAL.UpdateLeaveRequestMAin(Int32.Parse(row.Cells[1].Text), "Rejected Unauthorized");
                        DAL.UpdateLeaveRequestDetaN(Int32.Parse(row.Cells[1].Text), "Rejected Unauthorized");
                        fillBAl();

                    }
                    else
                    {
                        DAL.UpdateLeaveRequestMAin(Int32.Parse(row.Cells[1].Text), "Rejected");
                        DAL.UpdateLeaveRequestDetaN(Int32.Parse(row.Cells[1].Text), "Rejected");
                        fillBAl();
                    }

                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }



            }
        }





        
        public void fillBAl()
        {
            lblMSG.Text = "";
            int empId = Int32.Parse(ddlEmp.SelectedValue.ToString());
            DataSet ds = new DataSet();
            ds = DAL.LeaveReversal(empId, "Authorized");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Panel3.Visible = false;



        }

        





        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void butUpdate_Click(object sender, EventArgs e)
        {
            

        lblMSG.Text = "";
        try
        {
             using (TransactionScope ts = new TransactionScope())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Day");
                dt.Columns.Add("Type");
                dt.Columns.Add("Date");

                DataTable dtU = new DataTable();
                dtU.Columns.Add("Id");


                foreach (GridViewRow row in grvView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {

                            DataRow row1 = dt.NewRow();
                            row1["Id"] = row.Cells[1].Text;
                            row1["Day"] = row.Cells[2].Text; 
                            row1["Type"] = row.Cells[3].Text;
                            row1["Date"] = row.Cells[4].Text; 
                            dt.Rows.Add(row1);

                        }
                        else
                        {
                            DataRow row1U = dtU.NewRow();
                            row1U["Id"] = row.Cells[1].Text; ;
                            dtU.Rows.Add(row1U);
                        }
                    }
                }
                int count = dt.Rows.Count;
                DateTime strDAte = DateTime.Parse(dt.Rows[0][3].ToString());
                DateTime endDAte = DateTime.Parse(dt.Rows[count - 1][3].ToString());
                int i = 0;
                double days = 0;
                while (i < count)
                {
                    days = days + double.Parse(dt.Rows[i][1].ToString());
                    i++;
                }
                
                DAL.UpdateLeaveRequests(Int32.Parse(lblID.Text),strDAte,endDAte,days);

                int counUT = dtU.Rows.Count;
                int j = 0;
                while (j < counUT)
                {
                    DAL.deleteLeaveRequestDeta(Int32.Parse(dtU.Rows[j][0].ToString()));
                    j++;
                }

                //DAL.InsertLeaveSetting(Int32.Parse(ddlEmp.SelectedValue),Int32.Parse(ddlLeave.SelectedValue),double.Parse(txtJump.Text),DateTime.Parse(txtStartDate.Text));
                DA.saveUserLog(Session["userId"].ToString(), "Update Leave ISsue", "", DateTime.Now);
                 fillBAl();

                grvView.DataSource = dt;
                grvView.DataBind();



                foreach (GridViewRow row in grvView.Rows)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    chkRow.Checked = true;
                    row.BackColor = System.Drawing.Color.Salmon;
                }




                ts.Complete();
            }
        }

        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

        }
    
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillBAl();
        }

        protected void grvView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}



