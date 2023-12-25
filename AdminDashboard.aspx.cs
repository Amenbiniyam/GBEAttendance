using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Dashboard : System.Web.UI.Page
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
                try
                {
                    fillBAl();
                    fillATT();
                    fillData();
                    fillBAlEXP();
                }
                catch (Exception ex)
                {
                  //  mesgPN.BackColor = System.Drawing.Color.LightPink;
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
     
    }
    public void fillBAl()
    {
        int leaveId=13;
        string LeaveTYpe = "Annual Leave";
        DateTime date = DateTime.Now;

        //lblMSG.Text = "";
        //mesgPN.BackColor = System.Drawing.Color.White;
        MainDAL daM = new MainDAL();
        DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
        int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
        DataSet ds = DAL.selectEmployeeLevaeBalTYpe(empId, LeaveTYpe);
        double leaveEnti = 0;
        DataSet leaveEnta = DA.selectLeaveEntitlement(empId);
        if (leaveEnta.Tables[0].Rows.Count > 0)
        {
            leaveEnti = double.Parse(leaveEnta.Tables[0].Rows[0][0].ToString());
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet dsIn = DAL.INLeaveType(LeaveTYpe);
            DataSet dsLWP = DAL.sumLWP(empId);
            if (dsIn.Tables[0].Rows.Count > 0)
            {
                double INV = double.Parse(dsIn.Tables[0].Rows[0][0].ToString());
                double SLWP = 0;

                string SLW = dsLWP.Tables[0].Rows[0][0].ToString();
                if (SLW != "")
                {
                    SLWP = double.Parse(SLW);
                }

                TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
                //TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                double WD = timeSpan.Days;
                WD = WD - SLWP;
                DataSet DSHDAte = DAL.empHDAte(empId);
                DateTime DHired = DateTime.Parse(DSHDAte.Tables[0].Rows[0][0].ToString());
                TimeSpan LEC = date- DHired;
                DateTime setDate = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
                TimeSpan LEC1 = setDate - DHired;


                double LE = LEC.Days;
                double LE1 = LEC1.Days;

                double LECount = leaveEnti;
                double LECount1 = leaveEnti;

                double caBal = 0;
                double caBal1 = 0;
                while (LE > 0)
                {
                    if (LE > 730)
                    {
                        caBal = caBal + LECount;
                        LECount = LECount + INV;
                        if (LECount > 33)
                        {
                            LECount = 35;
                        }
                        LE = LE - 730;

                    }
                    else
                    {
                        if (LECount > 35)
                        {
                            LECount = 35;
                        }
                        caBal = caBal + ((LE * LECount) / 365);
                        LE = LE - 730;
                    }


                }
                while (LE1 > 0)
                {
                    if (LE1 > 730)
                    {
                        caBal1 = caBal1 + LECount1;
                        LECount1 = LECount1 + INV;
                        if (LECount1 > 35)
                        {
                            LECount1 = 35;
                        }
                        LE1 = LE1 - 730;

                    }
                    else
                    {
                        if (LECount1 > 35)
                        {
                            LECount1 = 35;
                        }
                        caBal1 = caBal1 + ((LE1 * LECount1) / 365);
                        LE1 = LE1 - 730;
                    }


                }



                double taken = 0;
                double untaken = 0;
                double bal = (caBal - caBal1) + (double.Parse(ds.Tables[0].Rows[0][4].ToString()));


                DataSet dsLR = DAL.sumLeave(empId, leaveId, "Authorized");
                ds.Tables[0].Columns.Add("LeaveTaken");
                string tak = dsLR.Tables[0].Rows[0][0].ToString();

                DataSet dsLRU = DAL.sumLeave(empId, leaveId, "Unauthorized");
                ds.Tables[0].Columns.Add("Leave Entitlement");
                // string takU = dsLRU.Tables[0].Rows[0][0].ToString();

                if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                {
                    taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                }

                //if (dsLRU.Tables[0].Rows.Count != 0 && takU != "")
                //{
                //    untaken = double.Parse(dsLRU.Tables[0].Rows[0][0].ToString());

                //}

                ds.Tables[0].Rows[0][5] = date.ToString("dd-MMM-yyyy");
                bal = bal - taken;
                ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                ds.Tables[0].Rows[0][6] = taken.ToString();
                ds.Tables[0].Rows[0][7] = (LECount - leaveEnti) + leaveEnti;
                lblBal.Text = ds.Tables[0].Rows[0][4].ToString();
                lblTaken.Text = ds.Tables[0].Rows[0][6].ToString();
                lblEnit.Text = ds.Tables[0].Rows[0][7].ToString();
                double exp = double.Parse(ds.Tables[0].Rows[0][7].ToString()) * 2;
                double tExp = double.Parse(ds.Tables[0].Rows[0][4].ToString()) - exp;
                //tExp = tExp - 1;
                //lblEXP.Text = tExp.ToString() + " " + "Days";

                tExp = tExp - 1;
                //if (tExp < 0)
                //    lblEXP.Text = "0" + " " + "Days";
                //else
                //{
                //    tExp = Math.Round(tExp, 2); ;
                //    lblEXP.Text = tExp.ToString() + " " + "Days";
                //}

                DataSet dsU = DAL.SumUnLeaveReq(empId);
                if (dsU.Tables[0].Rows[0][0].ToString() != "")
                {
                    lblUNa.Text = dsU.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    lblUNa.Text = "0";
                }

            }
            else
            {

            }
        }
        else
        {
            DataSet dsTaken = DAL.selectEmpTakenTYpe(empId, LeaveTYpe);
            lblBal.Text = dsTaken.Tables[0].Rows[0][4].ToString();
            lblTaken.Text = dsTaken.Tables[0].Rows[0][6].ToString();
            lblEnit.Text = dsTaken.Tables[0].Rows[0][7].ToString();

        }


        //butSave.Visible = true;
        //Panel3.Visible = false;
    }

    public void fillBAlEXP()
    {
        int leaveId = 13;
        string LeaveTYpe = "Annual Leave";
        DateTime date = DateTime.Now.AddDays(30);

        //lblMSG.Text = "";
        //mesgPN.BackColor = System.Drawing.Color.White;
        MainDAL daM = new MainDAL();
        DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
        int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
        DataSet ds = DAL.selectEmployeeLevaeBalTYpe(empId, LeaveTYpe);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataSet dsIn = DAL.INLeaveType(LeaveTYpe);
            DataSet dsLWP = DAL.sumLWP(empId);
            if (dsIn.Tables[0].Rows.Count > 0)
            {
                double INV = double.Parse(dsIn.Tables[0].Rows[0][0].ToString());
                double SLWP = 0;

                string SLW = dsLWP.Tables[0].Rows[0][0].ToString();
                if (SLW != "")
                {
                    SLWP = double.Parse(SLW);
                }

                TimeSpan timeSpan = DateTime.Now.AddDays(30) -Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
                //TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                double WD = timeSpan.Days;
                WD = WD - SLWP;
                DataSet DSHDAte = DAL.empHDAte(empId);
                DateTime DHired = DateTime.Parse(DSHDAte.Tables[0].Rows[0][0].ToString());
                TimeSpan LEC = date - DHired;
                DateTime setDate = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
                TimeSpan LEC1 = setDate - DHired;
                double leaveEnti = 0;
                DataSet leaveEnta = DA.selectLeaveEntitlement(empId);
                if (leaveEnta.Tables[0].Rows.Count > 0)
                {
                    leaveEnti = double.Parse(leaveEnta.Tables[0].Rows[0][0].ToString());
                }

                double LE = LEC.Days;
                double LE1 = LEC1.Days;

                double LECount = leaveEnti;
                double LECount1 = leaveEnti;

                double caBal = 0;
                double caBal1 = 0;
                while (LE > 0)
                {
                    if (LE > 730)
                    {
                        caBal = caBal + LECount;
                        LECount = LECount + INV;
                        if (LECount > 35)
                        {
                            LECount = 35;
                        }
                        LE = LE - 730;

                    }
                    else
                    {
                        if (LECount > 35)
                        {
                            LECount = 35;
                        }
                        caBal = caBal + ((LE * LECount) / 365);
                        LE = LE - 730;
                    }


                }
                while (LE1 > 0)
                {
                    if (LE1 > 730)
                    {
                        caBal1 = caBal1 + LECount1;
                        LECount1 = LECount1 + INV;
                        if (LECount1 > 35)
                        {
                            LECount1 = 35;
                        }
                        LE1 = LE1 - 730;

                    }
                    else
                    {
                        if (LECount1 > 35)
                        {
                            LECount1 = 35;
                        }
                        caBal1 = caBal1 + ((LE1 * LECount1) / 365);
                        LE1 = LE1 - 730;
                    }


                }



                double taken = 0;
                double untaken = 0;
                double bal = (caBal - caBal1) + (double.Parse(ds.Tables[0].Rows[0][4].ToString()));


                DataSet dsLR = DAL.sumLeave(empId, leaveId, "Authorized");
                ds.Tables[0].Columns.Add("LeaveTaken");
                string tak = dsLR.Tables[0].Rows[0][0].ToString();

                DataSet dsLRU = DAL.sumLeave(empId, leaveId, "Unauthorized");
                ds.Tables[0].Columns.Add("Leave Entitlement");
                // string takU = dsLRU.Tables[0].Rows[0][0].ToString();

                if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                {
                    taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                }

                //if (dsLRU.Tables[0].Rows.Count != 0 && takU != "")
                //{
                //    untaken = double.Parse(dsLRU.Tables[0].Rows[0][0].ToString());

                //}

                ds.Tables[0].Rows[0][5] = date.ToString("dd-MMM-yyyy");
                bal = bal - taken;
                ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                ds.Tables[0].Rows[0][6] = taken.ToString();
                ds.Tables[0].Rows[0][7] = (LECount - leaveEnti) + leaveEnti;
                //  lblBal.Text = ds.Tables[0].Rows[0][4].ToString();
                // lblTaken.Text = ds.Tables[0].Rows[0][6].ToString();
                // lblEnit.Text = ds.Tables[0].Rows[0][7].ToString();
                double exp = (double.Parse(ds.Tables[0].Rows[0][7].ToString()) * 2)-1;
                double tExp = double.Parse(ds.Tables[0].Rows[0][4].ToString()) - exp;
               // tExp = tExp - 1;
                if (tExp < 0)
                    lblEXP.Text = "0" + " " + "Days";
                else
                {
                    tExp = Math.Round(tExp, 2); ;
                    lblEXP.Text = tExp.ToString() + " " + "Days";
                }




            }
            else
            {

            }
        }
        else
        {


        }


        //butSave.Visible = true;
        //Panel3.Visible = false;
    }


    public void fillATT()
    {
        //lblMSG.Text = "";
        DateTime date = DateTime.Now.AddDays(-31);
       // DateTime date = DateTime.Parse("01-Feb-2016");
        DateTime dateEnd = DateTime.Now.AddDays(-1);
        try
        {
            
                DataTable dt = new DataTable();
                dt.Columns.Add("empID");
                dt.Columns.Add("Full_Name");
                dt.Columns.Add("Date");
                dt.Columns.Add("Time");
                dt.Columns.Add("Status");
                dt.Columns.Add("Days");
                dt.Columns.Add("Type");
                dt.Columns.Add("Department");
                dt.Columns.Add("Late_Minute");
                dt.Columns.Add("CompanyName");
                dt.Columns.Add("DateF");
                dt.Columns.Add("DateT");
                dt.Columns.Add("Desc");
                MainDAL daM = new MainDAL();
                DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
                string userID = Session["userId"].ToString();
                DataTable dep = new DataTable();
                dep = DA.selectDepEmpIND(empId.ToString()).Tables[0];


                double coun = (dateEnd - date).TotalDays;
                double k = 0;
                while (k <= coun)
                {
                    if (k > 0)
                        date = date.AddDays(1);
                    DataSet dsSCH = DA.selectEmployeeSCH(empId.ToString(), date);
                    int count = dsSCH.Tables[0].Rows.Count - 1;
                    int dateM = date.Day;
                    int month = date.Month;
                    string dayN = date.DayOfWeek.ToString();
                    for (int i = 0; i < dsSCH.Tables[0].Rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["empID"] = empId;
                        row["Department"] = dep.Rows[0][1].ToString();
                        row["Date"] = date.ToString("dd-MMM-yy");
                        row["Days"] = dsSCH.Tables[0].Rows[i][5].ToString();
                        row["Type"] = dsSCH.Tables[0].Rows[i][8].ToString();
                        row["Full_Name"] = dsSCH.Tables[0].Rows[i][7].ToString();
                        DataSet holiday = DA.selectSCHoliDay(month, dateM, date, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()), dsSCH.Tables[0].Rows[i][5].ToString(), dsSCH.Tables[0].Rows[i][8].ToString());
                        if (holiday.Tables[0].Rows.Count > 0)
                        {
                            row["Status"] = holiday.Tables[0].Rows[0][5].ToString();
                            dt.Rows.Add(row);
                            if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                            {
                                break;
                            }
                            else
                            {
                                goto weta;
                            }

                        }
                        DataSet weekend = DA.selectSCWeekDAy(dayN, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()));
                        if (weekend.Tables[0].Rows.Count == 0)
                        {
                            row["Status"] = "Weekend";
                            dt.Rows.Add(row);
                            if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                            {
                                break;
                            }
                            else
                            {
                                goto weta;
                            }

                        }
                        DataSet leave = DA.selectLeaveEMPAUT(date, Int32.Parse(empId.ToString()), dsSCH.Tables[0].Rows[i][8].ToString());
                        if (leave.Tables[0].Rows.Count > 0)
                        {



                            row["Status"] = leave.Tables[0].Rows[0][0].ToString();
                            dt.Rows.Add(row);
                            if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                            {
                                break;
                            }
                            else
                            {
                                goto weta;
                            }

                        }
                        DateTime dateT = DateTime.Parse(dsSCH.Tables[0].Rows[i][1].ToString());
                        DateTime dateFR = dateT.AddMinutes(0 - int.Parse(dsSCH.Tables[0].Rows[i][2].ToString()));
                        DateTime dateTO = dateT.AddMinutes(int.Parse(dsSCH.Tables[0].Rows[i][3].ToString()));
                        int dateL = int.Parse(dsSCH.Tables[0].Rows[i][4].ToString());
                        DataSet dsTime = DA.selectSCTime(empId.ToString(),date.Date,dateFR, dateTO);

                        if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                        {
                            if (dsTime.Tables[0].Rows.Count > 0)
                            {
                                row["Time"] = dsTime.Tables[0].Rows[0][0].ToString();
                                DateTime timeSt = DateTime.Parse(dsTime.Tables[0].Rows[0][0].ToString());
                                if (timeSt.TimeOfDay <= (dateT.AddMinutes(dateL).TimeOfDay))
                                {
                                    row["Status"] = "ON TIME";
                                    if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                    {
                                        row["Late_Minute"] = 0;
                                    }
                                    else
                                    {
                                        row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                    }
                                }
                                else if (((dateT.AddMinutes(dateL).TimeOfDay) < timeSt.TimeOfDay) && (timeSt.TimeOfDay < dateTO.TimeOfDay))
                                {
                                    row["Status"] = "LATE COMER";
                                    if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                    {
                                        row["Late_Minute"] = 0;
                                    }
                                    else
                                    {
                                        row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                    }
                                }
                                else
                                {
                                    row["Status"] = "UNJUSTIFIED ABSENCE";
                                }

                                dt.Rows.Add(row);
                                break;

                            }
                            else if (count == i)
                            {
                                row["Status"] = "UNJUSTIFIED ABSENCE";

                                dt.Rows.Add(row);
                                break;
                            }
                        }
                        else
                        {

                            if (dsTime.Tables[0].Rows.Count > 0)
                            {
                                row["Time"] = dsTime.Tables[0].Rows[0][0].ToString();
                                DateTime timeSt = DateTime.Parse(dsTime.Tables[0].Rows[0][0].ToString());
                                if (timeSt.TimeOfDay <= (dateT.AddMinutes(dateL).TimeOfDay))
                                {
                                    row["Status"] = "ON TIME";
                                    if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                    {
                                        row["Late_Minute"] = 0;
                                    }
                                    else
                                    {
                                        row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                    }
                                }
                                else if (((dateT.AddMinutes(dateL).TimeOfDay) < timeSt.TimeOfDay) && (timeSt.TimeOfDay < dateTO.TimeOfDay))
                                {
                                    row["Status"] = "LATE COMER";
                                    if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                    {
                                        row["Late_Minute"] = 0;
                                    }
                                    else
                                    {
                                        row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                    }
                                }
                                else
                                {
                                    row["Status"] = "UNJUSTIFIED ABSENCE";
                                }

                            }
                            else
                            {
                                row["Status"] = "UNJUSTIFIED ABSENCE";
                            }
                            dt.Rows.Add(row);
                        }
                    weta: ;
                    }
                    k++;
                }

                DataTable dtR = new DataTable();
                dtR.Columns.Add("empID");
                dtR.Columns.Add("Full_Name");
                dtR.Columns.Add("Date");
                dtR.Columns.Add("Time");
                dtR.Columns.Add("Status");
                dtR.Columns.Add("Days");
                dtR.Columns.Add("Type");
                dtR.Columns.Add("Department");
                dtR.Columns.Add("CompanyName");
                dtR.Columns.Add("DateF");
                dtR.Columns.Add("DateT");
                dtR.Columns.Add("Desc");
               // string status = "";
                int late=0;
                int onTim=0;
                int unf=0;
                for (int e = 0; e < dt.Rows.Count; e++)
                {
                    if (dt.Rows[e]["Status"].ToString() == "ON TIME")
                    {
                        onTim++;
                    }
                    else if (dt.Rows[e]["Status"].ToString() == "LATE COMER")
                    {
                        late++;
                    }
                    else if (dt.Rows[e]["Status"].ToString() == "UNJUSTIFIED ABSENCE")
                    {
                        unf++;
                    }
                }
                lblONtime.Text = onTim.ToString();
                lblLate.Text = late.ToString();
                lblUNJ.Text = unf.ToString();
               


            }
        

        catch (Exception ex)
        {
           
        }

    }

    public void fillData()
    {
        DataSet ds = DA.MAXDATA();
        DateTime date = DateTime.Parse(ds.Tables[0].Rows[0][0].ToString());
        DateTime time = DateTime.Parse(ds.Tables[0].Rows[0][1].ToString());
        maxDAte.Text = date.ToString("dd-MMM-yyyy");
        maxTime.Text = time.TimeOfDay.ToString();
     
    }
     
}