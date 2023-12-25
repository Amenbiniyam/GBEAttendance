using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PositionCreate : System.Web.UI.Page
{
   PositionDAL DA = new PositionDAL();
   MainDAL MAD = new MainDAL();
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
                int maxID = 1;
                DataSet max = DA.selectPosMAx();
                string maxS = max.Tables[0].Rows[0][0].ToString();
                if (maxS != "")
                {
                    maxID = int.Parse(max.Tables[0].Rows[0][0].ToString()) + 1;
                }
                txtID.Text = maxID.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DA.InsertPosition(int.Parse(txtID.Text), txtPositionName.Text, txtDescription.Text);
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                lblMSG.Text = "Position Information Saved Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                DA.saveUserLog(Session["userId"].ToString(), "Save New POsition", txtPositionName.Text, DateTime.Now);
                //    string userName = Session["userId"].ToString();
                // DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Position Name";
                }
                else if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Position ID";
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
            Response.Redirect("PositionHome.aspx");
        }
        protected void butClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("PositionCreate.aspx");
        }
}
