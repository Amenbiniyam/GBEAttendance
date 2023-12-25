using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class TimeTableCreate : System.Web.UI.Page
{
     HolidayDAL DA = new HolidayDAL();
       
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
                //DataSet ds = DA.selectDepTreeAll();
                //DataTable dt = ds.Tables[0];
                //PopulateMenuDataTable(dt);
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
        
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    string dayTYpe="Fullday";
                    if (ddlWorkday.SelectedItem.Text == "0.5")
                    {
                        dayTYpe = ddlDayType.SelectedItem.Text;
                    }
                    DA.InsertTimeTables(txtName.Text, DateTime.Parse(txtonDutyTime.Text), Decimal.Parse(ddlWorkday.Text), int.Parse(txtEarly.Text), int.Parse(txtAbsent.Text), int.Parse(txtLAte.Text), dayTYpe);
                    int ID = DA.selectMaxId();



                    int count = chkWeekDAys.Items.Count;
                    int i = 0;
                    while (i < count)
                    {

                        if (chkWeekDAys.Items[i].Selected == true)
                        {

                            DA.InsertTimeTablesWeekDAys(ID, Int32.Parse(chkWeekDAys.Items[i].Value));
                        }

                        i++;
                    }

                    int countj = chkHoliday.Items.Count;
                    int j = 0;
                    while (j < countj)
                    {

                        if (chkHoliday.Items[j].Selected == true)
                        {

                            DA.InsertTimeTablesHoliday(ID, Int32.Parse(chkHoliday.Items[j].Value));
                        }

                        j++;
                    }


                    ts.Complete(); // was ts.Consistent = true; in beta 2
                }
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                lblMSG.Text = "Time Table Information Saved Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                DA.saveUserLog(Session["userId"].ToString(), "NEw  Time Table", txtName.Text, DateTime.Now);
               // Response.Redirect("TimeTableHome.aspx");
                //string userName = Session["userId"].ToString();
                //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Name";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Name";
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
            Response.Redirect("TimeTableHome.aspx");
        }





        protected void ddlWorkday_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWorkday.SelectedItem.Text == "0.5")
            {
                lblDayType.Visible = true;
                ddlDayType.Visible = true;
            }
            else
            {
                lblDayType.Visible = false;
                ddlDayType.Visible = false;
            }
        }
        protected void butClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("TimeTableCreate.aspx");
        }
}
