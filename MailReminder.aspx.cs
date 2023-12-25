using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Transactions;

using System.Net.Mail;

public partial class MailReminder : System.Web.UI.Page
{
       AttDAL DA = new AttDAL();
       LeaveDAL DAL = new LeaveDAL();
    MainDAL daM=new MainDAL();
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
                MainDAL da = new MainDAL();
                DataSet dsMU = da.selectUnMail();
                grvData.DataSource = dsMU;
                grvData.DataBind();
              
            }
        }

      
     

        protected void Button4_Click(object sender, EventArgs e)
        {

            try
            {
                   using (TransactionScope ts = new TransactionScope())
                   {
                int count = 0;
                MainDAL da = new MainDAL();
                DataSet dsMU = da.selectUnMail();
                for (int i = 0; i < dsMU.Tables[0].Rows.Count; i++)
                {

              
                  //  DataSet dsA = da.UserMail(Int16.Parse(dsMU.Tables[0].Rows[i][0].ToString()));
                    string autMail = dsMU.Tables[0].Rows[i][0].ToString();
                   //string autMail = "samuel.kuma@Debub Global bank.com";
                    MailMessage msg = new MailMessage();
                    msg.To.Add(new MailAddress(autMail));
                    msg.From = new MailAddress("leave.request@Debub Global bank.com");
                    msg.Subject = "Unauthorized Leave Request Reminder";

                  //  DataSet dsNAme = da.selectFullNAme(empId);
                    // lblFullNAme.Text = dsNAme.Tables[0].Rows[0][0].ToString();
                    msg.Body = "There is Unauthorized Leave Request in your domain, Please Authorize It  " + " <br /> Address : http://10.1.1.140/AttendanceAndLeave/Login.aspx";
                    msg.IsBodyHtml = true;

                    SmtpClient client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("leave.request@Debub Global bank.com", "P@ssw0rd");
                    client.Port = 25; // You can use Port 25 if 587 is blocked (mine is!)
                    client.Host = "mail.Debub Global bank.com";
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = false;

                    client.Send(msg);
                    count++;
                  
               }
                lblMSG.Text =count+ "-Out Look Message Sent Succesfully";
                ts.Complete();
                   
            }
            }


            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
     
}
