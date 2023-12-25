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
using System.Net.Mail;
public partial class UnauthorizedData : System.Web.UI.Page
{
    LeaveDAL da = new LeaveDAL();
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
                    if (role == 5)
                    {
                        DataSet dsAUT = daM.selectEmpAut(depID, "'2'");
                        int empIDU = Int32.Parse(dsAUT.Tables[0].Rows[0][0].ToString());
                        da.UpdateLeaveReqCuuAPP(id, empIDU, empId);
                       
                        MainDAL DA = new MainDAL();
                      //  int autId = Int32.Parse(ddlSubmitTo.SelectedValue);
                        DataSet dsA = DA.UserMail(empIDU);
                        string autMail = dsA.Tables[0].Rows[0][0].ToString();
                      //  MailMessage msg = new MailMessage();
                      //  msg.To.Add(new MailAddress(autMail));
                      ////  msg.From = new MailAddress("leave.request@Debub Global bank.com");
                      /////  msg.Subject = "Leave Request";

                       // DataSet dsNAme = DA.selectFullNAme(empId);
                        // lblFullNAme.Text = dsNAme.Tables[0].Rows[0][0].ToString();
                       // msg.Body = "Please authorize leave request from " + row.Cells[4].ToString()+" <br /> Address : http://10.1.1.140/AttendanceAndLeave/Login.aspx";
                      //  msg.IsBodyHtml = true;

                        //SmtpClient client = new SmtpClient();
                        //client.UseDefaultCredentials = false;
                        //client.Credentials = new System.Net.NetworkCredential("leave.request@Debub Global bank.com", "P@ssw0rd");
                        //client.Port = 25; // You can use Port 25 if 587 is blocked (mine is!)
                        //client.Host = "mail.Debub Global bank.com";
                        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //client.EnableSsl = false;
                        //try
                        //{
                        //    client.Send(msg);
                        //    // lblMSG.Text = "Out Look Message Sent Succesfully";
                        //}
                        //catch (Exception ex)
                        //{
                        //    lblMSG.Text = "Leave Request authorized Email Not Sent Error:" + ex.Message;
                        //    lblMSG.ForeColor = System.Drawing.Color.Red;
                        //}
                        
                    }
                    else if (role == 2)
                    {
                        try
                        {

                            double AUTBAL = 0;
                            if (row.Cells[8].Text == "&nbsp;")
                            {
                                using (TransactionScope ts = new TransactionScope())
                                {
                                    AUTBAL = double.Parse(row.Cells[7].Text);
                                    da.UpdateLeaveReqProg(id, empId, "Authorized", AUTBAL);
                                    da.UpdateLeaveReqDetailProg(id, "Authorized");
                                    ts.Complete();
                                }
                            }
                            else
                            {
                                using (TransactionScope ts = new TransactionScope())
                                {
                                    da.UpdateLeaveReqProgA(id, empId, "Authorized");
                                    da.UpdateLeaveReqDetailProg(id, "Authorized");
                                    ts.Complete();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMSG.Text =  ex.Message;
                            lblMSG.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }
            }
        }
        da.saveUserLog(Session["userId"].ToString(), "Save LEave Request Una", lblID.Text, DateTime.Now);
             
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
             lblID.Text = rowM.Cells[2].Text;
             DataSet ds = da.LeaveRequestDetail(Int32.Parse(rowM.Cells[2].Text), Int32.Parse(rowM.Cells[3].Text), "Unauthorized");
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
        grvView.Visible = true;  

        }

        
    
    protected void Delete(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            try
            {
                da.UpdateLeaveRequestMAin(Int32.Parse(row.Cells[2].Text), "Rejected");
                da.UpdateLeaveRequestDetaN(Int32.Parse(row.Cells[2].Text), "Rejected");
                fillBAl();
              
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
                da.saveUserLog(Session["userId"].ToString(), "UPdate LEave Request Una", lblID.Text, DateTime.Now);
             
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
        ds = da.UnLeaveRequest(empId, "Unauthorized");
        DataSet userRol = daM.selectEmpAutRole(empId);
        int role = Int32.Parse(userRol.Tables[0].Rows[0][0].ToString());
        if (role == 2)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i][10].ToString() == "")
                {
                    ds.Tables[0].Rows[i][10] = "Direct Request";
                }
                else
                {
                    MainDAL DA = new MainDAL();
                    DataSet dsNAme = DA.selectFullNAme(Int32.Parse(ds.Tables[0].Rows[i][10].ToString()));
                    string REV = dsNAme.Tables[0].Rows[0][0].ToString();
                    ds.Tables[0].Rows[i][10] = REV;
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


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
