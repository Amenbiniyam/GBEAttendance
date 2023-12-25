using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Transactions;

public partial class RevUnauthorizedData : System.Web.UI.Page
{
    LeaveDAL da = new LeaveDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["userId"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        if (!IsPostBack)
        {

          fillBAl();

           
        }
    }
    protected void butUaAll_Click(object sender, EventArgs e)
    {
        
            MainDAL daM=new MainDAL();
            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());     
            AttDAL dalA=new AttDAL();
            DataSet dsDep = dalA.selectEmpDep(empId);
            int depID = Int32.Parse(dsDep.Tables[0].Rows[0][0].ToString());           
            DataSet userRol = daM.selectEmpAutRole(empId);
            int role = Int32.Parse(userRol.Tables[0].Rows[0][0].ToString());
           
            
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    int id = Int32.Parse(row.Cells[2].Text);
                    if ((role == 5 || role == 2)  && ((row.Cells[12].Text == "System") || (row.Cells[12].Text == "System Expired Leave")))
                    {
                        da.UpdateLeaveReqProgRV(id, empId, "Authorized");
                        da.UpdateLeaveReqDetailProgRVNuru(id, "Reversal Authorized");
                        da.saveUserLog(Session["userId"].ToString(), "Leave Revrsal Authorized", empId.ToString(), DateTime.Now);
                    
                    }
                    else if (role == 5 && ((row.Cells[12].Text != "System") || (row.Cells[12].Text != "System Expired Leave")))
                    {
                        DataSet dsAUT = daM.selectEmpAut(depID, "'2'");
                        int empIDU = Int32.Parse(dsAUT.Tables[0].Rows[0][0].ToString());
                        da.UpdateLeaveReqCuuAPP(id, empIDU, empId);
                        
                    }
                    else if (role == 2)
                    {
                        //double AUTBAL = 0;
                        //if (row.Cells[8].Text == "")
                        //{
                           // AUTBAL = double.Parse(row.Cells[8].Text);
                            da.UpdateLeaveReqProgRV(id, empId, "Authorized");
                            da.UpdateLeaveReqDetailProgRV(id, "Reversal Authorized");
                            da.saveUserLog(Session["userId"].ToString(), "Leave Revrsal Authorized", empId.ToString(), DateTime.Now);
                        //}
                        //else
                        //{
                        //    da.UpdateLeaveReqProgRV(id, empId, "A");
                        //    da.UpdateLeaveReqDetailProg(id, "RVA");
                        //}
                    }

                }
            }
        }
        fillBAl();
       // butUpdate.Visible = false;
        grvView.Visible = false;
    }
    protected void Edit(object sender, EventArgs e)
    {
        lblMSG.Text = "";
        mesgPN.BackColor = System.Drawing.Color.White;
        using (GridViewRow rowM = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
             lblID.Text = rowM.Cells[2].Text;
             DataSet ds = da.LeaveRequestDetail(Int32.Parse(rowM.Cells[2].Text), Int32.Parse(rowM.Cells[3].Text), "Reversal Unauthorized");
             grvView.DataSource=ds;
             grvView.DataBind();


      
                    foreach (GridViewRow row in grvView.Rows)
                    {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            chkRow.Checked = true;
                            row.BackColor = System.Drawing.Color.Salmon;
                    }

                }
        //butUpdate.Visible = true;
        grvView.Visible = true;  

        }

        
    
    protected void Delete(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            try
            {
                da.UpdateLeaveRequestMAinRVE(Int32.Parse(row.Cells[2].Text), "Authorized", 0);
                DataSet ds = da.LeaveRequestDetail(Int32.Parse(row.Cells[2].Text), Int32.Parse(row.Cells[3].Text), "Reversal Unauthorized");
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    da.UpdateLeaveRequestDeta(Int32.Parse(ds.Tables[0].Rows[i][0].ToString()), "Authorized");
                
                }

                fillBAl();
                grvView.DataBind();
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }



        }
    }





    protected void Button3_Click(object sender, EventArgs e)
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
                
                da.UpdateLeaveRequests(Int32.Parse(lblID.Text),strDAte,endDAte,days);

                int counUT = dtU.Rows.Count;
                int j = 0;
                while (j < counUT)
                {
                    da.deleteLeaveRequestDeta(Int32.Parse(dtU.Rows[j][0].ToString()));
                    j++;
                }

                //DAL.InsertLeaveSetting(Int32.Parse(ddlEmp.SelectedValue),Int32.Parse(ddlLeave.SelectedValue),double.Parse(txtJump.Text),DateTime.Parse(txtStartDate.Text));
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
    public void fillBAl()
    {
        try
        {
            MainDAL daM = new MainDAL();
            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
            DataSet ds = new DataSet();
            if (empId == 39 || empId == 201)
            {
                ds = da.UnLeaveRequestRVNuru();
            }
            else
            {

            ds = da.UnLeaveRequestRV(empId, "Reversal Unauthorized");
            }
            DataSet userRol = daM.selectEmpAutRole(empId);
            int role = Int32.Parse(userRol.Tables[0].Rows[0][0].ToString());
            if (role == 4)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][9].ToString() == "")
                    {
                        ds.Tables[0].Rows[i][9] = "Direct Request";
                    }
                    else
                    {
                        MainDAL DA = new MainDAL();
                        DataSet dsNAme = DA.selectFullNAme(empId);
                        string REV = dsNAme.Tables[0].Rows[0][0].ToString();
                        ds.Tables[0].Rows[i][9] = REV;
                    }
                }
            }
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

        }

    }


}
