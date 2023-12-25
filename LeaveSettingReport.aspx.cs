using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class EmpAttReport : System.Web.UI.Page
{
       AttDAL DA = new AttDAL();
       LeaveDAL DAL = new LeaveDAL();
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

         



     

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text="";
            try
            {
                if (DateTime.Parse(txtHiredDate.Text).Date > DateTime.Parse(txtEndDate.Text).Date)
                {
                    lblMSG.Text = "Error:" + " From date must be earlier than End date ";
                    ReportViewer1.Visible = false;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    DataSet ds = DAL.LeaveSetting(DateTime.Parse(txtHiredDate.Text),DateTime.Parse(txtEndDate.Text));
                    ds.Tables[0].Columns.Add("CompanyName");
                    ds.Tables[0].Columns.Add("DateF");
                    ds.Tables[0].Columns.Add("DateT");
                    ds.Tables[0].Columns.Add("Desc");
                    for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        ds.Tables[0].Rows[i][5]="Debub Global  Bank S.C.";
                        ds.Tables[0].Rows[i][6]=txtHiredDate.Text;
                        ds.Tables[0].Rows[i][7]=txtEndDate.Text;
                        ds.Tables[0].Rows[i][8]="Leave Report";
                          
                    }

                    ReportViewer1.Visible = true;
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    ReportViewer1.LocalReport.Refresh();


                }
            }

            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }

       
}
