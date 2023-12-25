using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
            Session["userId"] = null;
    }
   
   
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string userName = da.selectUser(this.Login1.UserName.ToLower());
        if (userName == this.Login1.UserName.ToLower())
        {
            String password = da.selectUserInformation(this.Login1.UserName);
            if (String.Compare(password, this.Login1.Password, false) == 0)
            {

                String role = da.selectUserRole(this.Login1.UserName);
                Session["role"] = role;
                Session["userId"] = this.Login1.UserName.ToLower();

                if (Int32.Parse(role) == 3 || Int32.Parse(role)==4)
                {
                    Response.Redirect("empDashboard.aspx");
                }
                else if (Int32.Parse(role) == 1)
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("AutDashboard.aspx");
                }
            }
        }
    }
}