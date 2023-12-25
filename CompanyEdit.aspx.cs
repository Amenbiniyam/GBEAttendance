using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CompanyEdit : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                fillEdit();
            }
        }
        public void fillEdit()
        {
            lblID.Text = Session["comId"].ToString().Replace("&nbsp;", "");
            txtCompanyName.Text = Session["CompanyName"].ToString().Replace("&nbsp;", "");
            txtDescription.Text = Session["Description"].ToString().Replace("&nbsp;", "");
            txtAddress.Text = Session["Address"].ToString().Replace("&nbsp;", "");
            txtTele.Text = Session["Telephone"].ToString().Replace("&nbsp;", "");
            txtEmail.Text = Session["Email"].ToString().Replace("&nbsp;", "");
            txtFAx.Text = Session["Fax"].ToString().Replace("&nbsp;", "");
            txtWebsite.Text = Session["Website"].ToString().Replace("&nbsp;", "");
        
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DA.updateCompany(Int32.Parse(lblID.Text), txtCompanyName.Text, txtDescription.Text, txtAddress.Text, txtTele.Text, txtEmail.Text, txtFAx.Text, txtWebsite.Text);
                DA.saveUserLog(Session["userId"].ToString(), "Edit Company", "Update Company", DateTime.Now);
                Response.Redirect("CompanyHome.aspx");
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyHome.aspx");
        }
    }
