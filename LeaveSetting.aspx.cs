using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class LeaveSetting : System.Web.UI.Page
    {
        AttDAL DA = new AttDAL();
        LeaveDAL DAL = new LeaveDAL();
        MainDAL MAD = new MainDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (Session["userId"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                var name = this.AppRelativeVirtualPath;
                string path = name.Substring(2);
                string k = Session["role"].ToString();
                string userID = Session["userId"].ToString();
                DataSet ds = MAD.selectMenuRole(k, path);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("LogIn.aspx");

                }




            }
            if (!this.IsPostBack)
            {
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);

                DataSet dsL = DAL.AllLeaveType();
                ddlLeave.DataSource = dsL;
                this.ddlLeave.DataTextField = "Name";
                this.ddlLeave.DataValueField = "Id";

                ddlLeave.DataBind();


            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            try
            {

                if (ddlEmp.SelectedItem.Text == "--Select Department--" || ddlEmp.SelectedItem.Text == "---")
                {
                    lblMSG.Text = "Error:" + "Please Select Employee";
                    mesgPN.BackColor = System.Drawing.Color.LightPink;
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {

                DAL.InsertLeaveSetting(Int32.Parse(ddlEmp.SelectedValue),Int32.Parse(ddlLeave.SelectedValue),double.Parse(txtBalce.Text),DateTime.Parse(txtEndDate.Text),double.Parse(txtLeaveEntai.Text));
                DA.saveUserLog(Session["userId"].ToString(), "Save Leave Insert", "", DateTime.Now);
      
                    fillGrid();
                }

             

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else
                {
                    lblMSG.Text = "Error:" + ex.Message;
                }
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentHome.aspx");
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
                Response.Redirect("LeaveSetting.aspx");

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = DAL.selectEmployeeLevaeBal(int.Parse(ddlEmp.SelectedValue.ToString()));
            GridView1.DataSource = ds;
            GridView1.DataBind();
            butSave.Visible = true;
            Panel3.Visible = false;
        }

        public void fillGrid()
        {
            DataSet ds = DAL.selectEmployeeLevaeBal(int.Parse(ddlEmp.SelectedValue.ToString()));
            GridView1.DataSource = ds;
            GridView1.DataBind();
        
        }

       
        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

                int Id = Int32.Parse(row.Cells[0].Text);
                lblID.Text = Id.ToString();
                txtBalce.Text = row.Cells[4].Text;
                txtEndDate.Text = row.Cells[5].Text;
                txtLeaveEntai.Text = row.Cells[6].Text;
                ddlLeave.ClearSelection();
                ddlLeave.Items.FindByText(row.Cells[3].Text).Selected = true;
            
                butSave.Visible = false;
                Panel3.Visible = true;
                //   txtCustomerID.ReadOnly = true;
                // Response.Redirect("Holiday.aspx");
                //popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                try
                {
                    DAL.deleteLeaveSetting(Int32.Parse(row.Cells[0].Text));
                    fillGrid();
                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

      
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        





        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.updateLeaveSetting(Int32.Parse(lblID.Text),Int32.Parse(ddlEmp.SelectedValue), Int32.Parse(ddlLeave.SelectedValue), double.Parse(txtBalce.Text), DateTime.Parse(txtEndDate.Text),double.Parse(txtLeaveEntai.Text));
                fillGrid();
            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else
                {
                    lblMSG.Text = "Error:" + ex.Message;
                }
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}


