using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PositionEdit : System.Web.UI.Page
{
    PositionDAL DA = new PositionDAL();
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
                fillEdit();
            }
        }
        public void fillEdit()
        {


                    lblID.Text = Session["posId"].ToString().Replace("&nbsp;", "");
            txtDescription.Text = Session["posDescription"].ToString().Replace("&nbsp;", "");
            txtPositionName.Text = Session["posName"].ToString().Replace("&nbsp;", "");
        

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DA.updatePosition(Int32.Parse(lblID.Text), txtPositionName.Text, txtDescription.Text);
                DA.saveUserLog(Session["userId"].ToString(), "Update POsition", txtPositionName.Text, DateTime.Now);
                Response.Redirect("PositionHome.aspx");
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PositionHome.aspx");
        }
    }
