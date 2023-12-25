using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Data;

public partial class TimeTableHome : System.Web.UI.Page
{
   HolidayDAL DA = new HolidayDAL();
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

                Session["timeId"] = Int32.Parse(row.Cells[0].Text);
                

             

                //   txtCustomerID.ReadOnly = true;
                Response.Redirect("TimeTableEdit.aspx");
                //popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                //txtComNameDelete.Text = row.Cells[1].Text;

                //lblDelID.Text = row.Cells[0].Text;
                ////   txtCustomerID.ReadOnly = true;

                //popupDelete.Show();


                try
                {

                    using (TransactionScope ts = new TransactionScope())
                    {
                        DA.deleteTimeTables(Int32.Parse(row.Cells[0].Text));
                        DA.deleteTimeTableHoliday(Int32.Parse(row.Cells[0].Text));
                        DA.deleteTimeTableWeek(Int32.Parse(row.Cells[0].Text));


                        ts.Complete(); // was ts.Consistent = true; in beta 2
                    }

                    DA.saveUserLog(Session["userId"].ToString(), "Delete  Time Table", row.Cells[0].Text, DateTime.Now);
             
                    Response.Redirect("TimeTableHome.aspx");
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
            Response.Redirect("TimeTableCreate.aspx");
        }

      
    }
