using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompanyCreate : System.Web.UI.Page
{
    CompanyDAL DA = new CompanyDAL();
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

            DA.InsertCompany(txtCompanyName.Text, txtDescription.Text, txtAddress.Text, txtTele.Text, txtEmail.Text, txtFAx.Text, txtWebsite.Text);
            mesgPN.BackColor = System.Drawing.Color.LightGreen;
            lblMSG.Text = "Company Information Saved Successfully !!!!";
            lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
            DA.saveUserLog(Session["userId"].ToString(), "NEw Company Created", "NEw Company Created", DateTime.Now);
            
            //Response.Redirect("CompanyHome.aspx");
            //    string userName = Session["userId"].ToString();
            // DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);

        }
        catch (Exception ex)
        {
            mesgPN.BackColor = System.Drawing.Color.LightPink;
            string exM=ex.Message;
            if (exM.StartsWith("Violation of UNIQUE KEY") == true)
            {
                lblMSG.Text = "Error:" + "Duplicate Company Name";
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
        Response.Redirect("CompanyHome.aspx");
    }
    protected void butClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyCreate.aspx");
    }
}