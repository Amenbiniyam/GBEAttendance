using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class DepLeaveBalance: System.Web.UI.Page
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

                selectLeave();
                


            }
        }
       


       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentHome.aspx");
        }

      


       
       

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
               

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void selectLeave()
        {
            try
            {

                lblMSG.Text = "";
                MainDAL daM = new MainDAL();
                DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
                DataSet dsL = DAL.AllLeaveTypeALBAL(empId);
                //ddlLeave.Items.Clear();
                //ddlLeave.Items.Add("---");
                //ddlLeave.AppendDataBoundItems = true;
                ddlLeave.DataSource = dsL;
                this.ddlLeave.DataTextField = "Name";
                this.ddlLeave.DataValueField = "Id";
                ddlLeave.DataBind();
                DataSet dsDays = DAL.selectDays(empId);
               

            }

            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
     

       
     

   
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        





        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void fillBAl()
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            MainDAL daM = new MainDAL();
            //EmpId	Full_Name	Leave_Name	LeaveBalance	LeaveTaken	Date	LeaveEntitlement

            DataTable dtAll=new DataTable();
            dtAll.Columns.Add("Id");
            dtAll.Columns.Add("EmpId");
            dtAll.Columns.Add("Full_Name");
            dtAll.Columns.Add("Leave_Name");
            dtAll.Columns.Add("LeaveBalance");
            dtAll.Columns.Add("LeaveTaken");
            dtAll.Columns.Add("Date");
            dtAll.Columns.Add("LeaveEntitlement");
            dtAll.Columns.Add("ExpirableLeaveAfter-30-Days");
           
            //DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            //int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());   
           // 

            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            DataSet dsd = DA.selectEmpDep(Int32.Parse(emp.Tables[0].Rows[0][0].ToString()));
            int depId = Int32.Parse(dsd.Tables[0].Rows[0][0].ToString());
            DataTable dep = new DataTable();
            dep = DA.selectDepEmp(depId).Tables[0];

            for (int f = 0; f < dep.Rows.Count; f++)
            {
                int empId = Int32.Parse(dep.Rows[f][0].ToString());
                DataSet ds = DAL.selectEmployeeLevaeBalTYpe(empId, ddlLeave.SelectedItem.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet dsIn = DAL.INLeaveType(ddlLeave.SelectedItem.ToString());
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
                        TimeSpan LEC = DateTime.Parse(txtStartDate.Text) - DHired;
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


                        DataSet dsLR = DAL.sumLeave(empId, int.Parse(ddlLeave.SelectedValue.ToString()), "Authorized");
                        ds.Tables[0].Columns.Add("LeaveTaken");
                        string tak = dsLR.Tables[0].Rows[0][0].ToString();

                        DataSet dsLRU = DAL.sumLeave(empId, int.Parse(ddlLeave.SelectedValue.ToString()), "Unauthorized");
                        //ds.Tables[0].Columns.Add("Leave Entitlement");
                        // string takU = dsLRU.Tables[0].Rows[0][0].ToString();

                        if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                        {
                            taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                        }

                        //if (dsLRU.Tables[0].Rows.Count != 0 && takU != "")
                        //{
                        //    untaken = double.Parse(dsLRU.Tables[0].Rows[0][0].ToString());

                        //}

                        ds.Tables[0].Rows[0][5] = DateTime.Parse(txtStartDate.Text).ToString("dd-MMM-yyyy");
                        bal = bal - taken;
                        ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                        ds.Tables[0].Rows[0][7] = taken.ToString();
                        ds.Tables[0].Rows[0][6] = (LECount - leaveEnti) + leaveEnti;
                        ds.Tables[0].Columns.Add("ExpirableLeaveAfter-30-Days");
                        ds.Tables[0].Rows[0]["ExpirableLeaveAfter-30-Days"] = fillBAlEXP(empId);

                        //DataRow row = dtAll.NewRow();
                        //row = ds.Tables[0].Rows[0];
                        dtAll.ImportRow(ds.Tables[0].Rows[0]);

                    }
                    else
                    {

                    }
                }
                else
                {
                    DataSet dsTaken = DAL.selectEmpTakenTYpe(empId, ddlLeave.SelectedItem.ToString());
                    grvDetail.DataSource = dsTaken;
                    grvDetail.DataBind();

                }
            }
            grvDetail.DataSource = dtAll;
            grvDetail.DataBind();
            grvDetail.Visible = true;
           
        }
     
        protected void butView_Click(object sender, ImageClickEventArgs e)
        {

            try
            {
            fillBAl();
           
                       
                                                                          

                }

                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
            }


        public double fillBAlEXP(int empId)
        {
            int leaveId = 13;
            string LeaveTYpe = "Annual Leave";
            DateTime date = DateTime.Parse(txtStartDate.Text);
            date = date.AddDays(30);
            //lblMSG.Text = "";
            //mesgPN.BackColor = System.Drawing.Color.White;
            MainDAL daM = new MainDAL();
            //   DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            // int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
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

                    TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
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
                    double exp = (double.Parse(ds.Tables[0].Rows[0][7].ToString()) * 2) - 1;
                    double tExp = double.Parse(ds.Tables[0].Rows[0][4].ToString()) - exp;
                    //tExp = tExp - 1;
                    //if (tExp < 0)
                    //    lblEXP.Text = "0" + " " + "Days";
                    //else
                    //{
                    //    tExp = Math.Round(tExp, 2); ;
                    //    lblEXP.Text = tExp.ToString() + " " + "Days";
                    //}

                    tExp = Math.Round(tExp, 2);
                    if (tExp < 0) 
                    {
                         return 0;
                    }
                    else
                    {
                    return tExp;
                    }


                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }



        }

        }
        




