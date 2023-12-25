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


public partial class ChangePassword : System.Web.UI.Page
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["userId"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            String password = da.selectPassword(Session["userId"].ToString());
            if (password != this.txtOldPassword.Text)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                lblMSG.Text = "Error:" + "Old Password Not Correct";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                

            }
            else
            {
                da.changePassword(this.txtPassword.Text, Session["userId"].ToString());
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                da.saveUserLog(Session["userId"].ToString(),"Password Changed","Password Chanaged", DateTime.Now);
                lblMSG.Text = "Password Changed Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;

            }
        }
        catch (Exception ex)
        {
               lblMSG.Text = "Error:" + ex.Message;
               lblMSG.ForeColor = System.Drawing.Color.DarkRed;

        }

    }
   
}
