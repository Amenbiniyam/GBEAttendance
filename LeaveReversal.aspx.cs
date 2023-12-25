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

public partial class LeaveReversal : System.Web.UI.Page
{
    LeaveDAL da = new LeaveDAL();
    AttDAL DA = new AttDAL();
    MainDAL mda = new MainDAL();
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
          submit();

           
        }
    }
    public void submit()
    {
        lblMSG.Text = "";
        try
        {
            MainDAL daM = new MainDAL();
            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
            AttDAL dalA = new AttDAL();
            DataSet dsDep = dalA.selectEmpDep(empId);
            int depID = Int32.Parse(dsDep.Tables[0].Rows[0][0].ToString());

            DataSet userRol = daM.selectEmpAutRole(empId);
            int role = Int32.Parse(userRol.Tables[0].Rows[0][0].ToString());

            if (role != 5 && role != 2)
            {
                ddlSubmitTo.Visible = true;
                lblSum.Visible = true;
                DataSet dsAUT = daM.selectEmpAut(depID, "'5','2'");
                ddlSubmitTo.DataSource = dsAUT;
                this.ddlSubmitTo.DataTextField = "FullNAme";
                this.ddlSubmitTo.DataValueField = "empId";
                ddlSubmitTo.DataBind();
            }
            else if (role == 5)
            {
                ddlSubmitTo.Visible = true;
                lblSum.Visible = true;
                DataSet dsAUT = daM.selectEmpAut(depID, "'2'");
                ddlSubmitTo.DataSource = dsAUT;
                this.ddlSubmitTo.DataTextField = "FullNAme";
                this.ddlSubmitTo.DataValueField = "empId";
                ddlSubmitTo.DataBind();
            }
            else if (role == 2)
            {
                ddlSubmitTo.Visible = true;
                lblSum.Visible = true;

                DataSet dsAut = mda.selectDepAut(empId);
                int depAID = Int32.Parse(dsAut.Tables[0].Rows[0][0].ToString());
                DataSet dsNAme = mda.selectFullNAme(depAID);
                ddlSubmitTo.DataSource = dsNAme;
                this.ddlSubmitTo.DataTextField = "FullNAme";
                this.ddlSubmitTo.DataValueField = "empId";
                ddlSubmitTo.DataBind();

            }
           



        }


        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

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
                    if (role == 5)
                    {
                        DataSet dsAUT = daM.selectEmpAut(depID, "'2'");
                        int empIDU = Int32.Parse(dsAUT.Tables[0].Rows[0][0].ToString());
                        da.UpdateLeaveReqCuuAPP(id, empIDU, empId);
                        
                    }
                    else if (role == 2)
                    {
                        double AUTBAL = 0;
                        if (row.Cells[8].Text == "")
                        {
                            AUTBAL = double.Parse(row.Cells[8].Text);
                            da.UpdateLeaveReqProg(id, empId, "Authorized", AUTBAL);
                        }
                        else
                        {
                            da.UpdateLeaveReqProgA(id, empId, "Authorized");
                        }
                    }

                }
            }
        }
        DA.saveUserLog(Session["userId"].ToString(), "Save Leave Revrsal", "", DateTime.Now);
                      
        fillBAl();
        butUpdate.Visible = false;
        grvView.Visible = false;
    }
    protected void Edit(object sender, EventArgs e)
    {
        lblMSG.Text = "";
        mesgPN.BackColor = System.Drawing.Color.White;
        using (GridViewRow rowM = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
             lblID.Text = rowM.Cells[1].Text;
             DataSet ds = da.LeaveRequestDetail(Int32.Parse(rowM.Cells[1].Text), Int32.Parse(rowM.Cells[2].Text), "Authorized");
             grvView.DataSource=ds;
             grvView.DataBind();


      
                    foreach (GridViewRow row in grvView.Rows)
                    {
                            CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                            chkRow.Checked = true;
                            row.BackColor = System.Drawing.Color.Salmon;
                    }

                }
        butUpdate.Visible = true;
        butCAl.Visible = true;
        grvView.Visible = true;  

        }

        
    
    protected void Delete(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            try
            {
                da.DELdeleteLeaveRequest(Int32.Parse(row.Cells[2].Text));
                da.DELLeaveRequestDeta(Int32.Parse(row.Cells[2].Text));

              
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

                //DataTable dtU = new DataTable();
                //dtU.Columns.Add("Id");


                foreach (GridViewRow row in grvView.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {

                            

                        }
                        else
                        {
                            DataRow row1 = dt.NewRow();
                            row1["Id"] = row.Cells[1].Text;
                            row1["Day"] = row.Cells[2].Text; 
                            row1["Type"] = row.Cells[3].Text;
                            row1["Date"] = row.Cells[4].Text; 
                            dt.Rows.Add(row1);
                        }
                    }
                }
                int count = dt.Rows.Count;
                int i = 0;
                double days = 0;
                while (i < count)
                {
                    days = days + double.Parse(dt.Rows[i][1].ToString());
                    i++;
                }
                //if (dt.Rows.Count != 0)
                //{
                  
                    DateTime strDAte = DateTime.Parse(dt.Rows[0][3].ToString());
                    DateTime endDAte = DateTime.Parse(dt.Rows[count - 1][3].ToString());
                    
                 if(count>0)
                 {
                     da.UpdateLeaveRequestsREV(Int32.Parse(lblID.Text), strDAte, endDAte, days, Int32.Parse(ddlSubmitTo.SelectedValue), "Reversal Unauthorized");
                     int j = 0;
                     while (j < count)
                     {
                         da.UpdateLeaveRequestDeta(Int32.Parse(dt.Rows[j][0].ToString()), "Reversal Unauthorized");
                         j++;
                     }
                }

                //DAL.InsertLeaveSetting(Int32.Parse(ddlEmp.SelectedValue),Int32.Parse(ddlLeave.SelectedValue),double.Parse(txtJump.Text),DateTime.Parse(txtStartDate.Text));
                fillBAl();


                //grvView.DataSource = dt;
                grvView.DataBind();



                //foreach (GridViewRow row in grvView.Rows)
                //{
                //    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                //    chkRow.Checked = true;
                //    row.BackColor = System.Drawing.Color.Salmon;
                //}




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
        MainDAL daM = new MainDAL();
        DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
        int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
        DataSet ds = new DataSet();
        ds = da.LeaveReversalNEW(empId, "Authorized");
        GridView1.DataSource = ds;
        GridView1.DataBind();



    }


    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("LeaveReversal.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
