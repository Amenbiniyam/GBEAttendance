using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CompanyHome : System.Web.UI.Page
{
    CompanyDAL DA = new CompanyDAL();
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
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
               // Company com = new Company();

                Session["comId"] = Int32.Parse(row.Cells[0].Text);
                Session["CompanyName"] = row.Cells[1].Text;
                Session["Description"] = row.Cells[2].Text.Trim();
                Session["Address"] = row.Cells[3].Text;
                Session["Telephone"] = row.Cells[4].Text;
                Session["Email"] = row.Cells[5].Text;
                Session["Fax"] = row.Cells[6].Text;
                Session["Website"] = row.Cells[7].Text;

             

                //   txtCustomerID.ReadOnly = true;
                Response.Redirect("CompanyEdit.aspx");
                //popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                try
                {
                    
              
                    DA.deleteCompany(Int32.Parse(row.Cells[0].Text));
                    DA.saveUserLog(Session["userId"].ToString(), "Delete Company", "Delete Company", DateTime.Now);
                    Response.Redirect("CompanyHome.aspx");
                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }



            }
        }
 
        protected void butEdit_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CompanyCreate.aspx");
        }

       
    }
