using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentHome : System.Web.UI.Page
{
       DepartmentDAL DA = new DepartmentDAL();
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
            if (!this.IsPostBack)
            {
             

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {


                Session["depId"] = Int32.Parse(row.Cells[0].Text);
                Session["depName"] = row.Cells[1].Text;
                Session["depDescription"] = row.Cells[2].Text.Trim();
                DataSet ds = DA.selectDEPTree(Int32.Parse(row.Cells[0].Text));
               // txtParentID.Text = ds.Tables[0].Rows[0][0].ToString();
                Session["depParId"] = ds.Tables[0].Rows[0][0].ToString();

                Session["depParName"] = row.Cells[3].Text.Trim();


                //   txtCustomerID.ReadOnly = true;
                Response.Redirect("DepartmentEdit.aspx");


                
                
              //  lblID.Text = row.Cells[0].Text;
             
              //  txtDepName.Text = row.Cells[1].Text;
              //  txtDesc.Text = row.Cells[2].Text;
              ////  txtParentID.Text = row.Cells[3].Text;
               
              // // lblParID.Text = ds.Tables[0].Rows[0][0].ToString();
               
              //  //   txtCustomerID.ReadOnly = true;

              //  popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
               
                try
                {
                    DA.deleteDepartment(Int32.Parse( row.Cells[0].Text));
                    DA.saveUserLog(Session["userId"].ToString(), "Delete Departement", "", DateTime.Now);
                    Response.Redirect("DepartmentHome.aspx");
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
            Response.Redirect("DepartmentCreate.aspx");
        }

        

  

    }
