using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Transactions;

public partial class TimeTableEdit : System.Web.UI.Page
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
                int Id = int.Parse(Session["timeId"].ToString());
                fillData(Id);
                //DataSet ds = DA.selectDepTreeAll();
                //DataTable dt = ds.Tables[0];
                //PopulateMenuDataTable(dt);
              
            }
        }
        public void fillData(int ID)
        {
            DataSet ds = DA.selectTimeTable(ID);
            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtonDutyTime.Text = ds.Tables[0].Rows[0][2].ToString();
            txtEarly.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAbsent.Text = ds.Tables[0].Rows[0][5].ToString();
            txtLAte.Text = ds.Tables[0].Rows[0][6].ToString();
            ddlWorkday.Items.Clear();
            if (decimal.Parse(ds.Tables[0].Rows[0][3].ToString() )== 1)
            {

                ddlWorkday.Items.Add("1");
                ddlWorkday.Items.Add("0.5");
                lblDayType.Visible = false;
                ddlDayType.Visible = false;
               
            }
            else
            {
                ddlWorkday.Items.Add("0.5");
                ddlWorkday.Items.Add("1");
                ddlDayType.Items.Clear();
                if (ds.Tables[0].Rows[0][7].ToString() == "Morning")
                {
                    lblDayType.Visible = true;
                    ddlDayType.Visible = true;
                    ddlDayType.Items.Add("Morning");
                    ddlDayType.Items.Add("Afternoon");

                }
                else
                {
                    lblDayType.Visible = true;
                    ddlDayType.Visible = true;
                    ddlDayType.Items.Add("Afternoon");
                    ddlDayType.Items.Add("Morning");
                }
               
               
            }

            DataSet weekD = DA.selectweekDays();

            chkWeekDAys.DataSource = weekD;
            chkWeekDAys.DataTextField = "Name";
            chkWeekDAys.DataValueField = "Id";
            chkWeekDAys.DataBind();


            // chkHoliday.DataSource=
            // chkHoliday.Items.FindByText("Fasika").Selected = true;
            DataSet dsD = DA.selectTimeTableWeek(ID);
            for (int i = 0; i < dsD.Tables[0].Rows.Count; i++)
            {
                int count = int.Parse(dsD.Tables[0].Rows[i][0].ToString());
                chkWeekDAys.Items.FindByValue(count.ToString()).Selected = true;


            }



            DataSet HOD = DA.selectHoliday();

            chkHoliday.DataSource = HOD;
            chkHoliday.DataTextField = "HolidayName";
            chkHoliday.DataValueField = "Id";
            chkHoliday.DataBind();


           // chkHoliday.DataSource=
           // chkHoliday.Items.FindByText("Fasika").Selected = true;
            DataSet dsH = DA.selectTimeTableHoliday(ID);
            for (int i = 0; i < dsH.Tables[0].Rows.Count; i++)
            {
                int count = int.Parse(dsH.Tables[0].Rows[i][0].ToString());
                chkHoliday.Items.FindByValue(count.ToString()).Selected = true;


            }



          // radGender.Items.FindByText(ds.Tables[0].Rows[0][4].ToString()).Selected = true;
       

        
        }
      
        protected void Button3_Click(object sender, EventArgs e)
        {
        
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    string dayTYpe = "Fullday";
                    if (ddlWorkday.SelectedItem.Text == "0.5")
                    {
                        dayTYpe = ddlDayType.SelectedItem.Text;
                    }
                    DA.updateTimeTables(int.Parse(Session["timeId"].ToString()), txtName.Text, DateTime.Parse(txtonDutyTime.Text), Decimal.Parse(ddlWorkday.Text), int.Parse(txtEarly.Text), int.Parse(txtAbsent.Text), int.Parse(txtLAte.Text), dayTYpe);
                   // int ID = DA.selectMaxId();

                    DA.deleteTimeTableHoliday(int.Parse(Session["timeId"].ToString()));
                    DA.deleteTimeTableWeek(int.Parse(Session["timeId"].ToString()));

                    int count = chkWeekDAys.Items.Count;
                    int i = 0;
                    while (i < count)
                    {

                        if (chkWeekDAys.Items[i].Selected == true)
                        {

                            DA.InsertTimeTablesWeekDAys(int.Parse(Session["timeId"].ToString()), Int32.Parse(chkWeekDAys.Items[i].Value));
                        }

                        i++;
                    }

                    int countj = chkHoliday.Items.Count;
                    int j = 0;
                    while (j < countj)
                    {

                        if (chkHoliday.Items[j].Selected == true)
                        {

                            DA.InsertTimeTablesHoliday(int.Parse(Session["timeId"].ToString()), Int32.Parse(chkHoliday.Items[j].Value));
                        }

                        j++;
                    }


                    ts.Complete(); // was ts.Consistent = true; in beta 2
                }
                DA.saveUserLog(Session["userId"].ToString(), "Edite  Time Table", txtName.Text, DateTime.Now);
             
                Response.Redirect("TimeTableHome.aspx");
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
}
