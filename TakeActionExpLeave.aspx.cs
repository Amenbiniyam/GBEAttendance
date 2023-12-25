using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Transactions;

public partial class TakeActionExpLeave : System.Web.UI.Page
{
       AttDAL DA = new AttDAL();
       LeaveDAL DAL = new LeaveDAL();
       MainDAL daM=new MainDAL();
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
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);
                DataSet dsL = DAL.AllLeaveTypeEmpALL();
                //ddlLeave.Items.Clear();
               // ddlLeave.Items.Add("---");
                //ddlStatus.AppendDataBoundItems = true;
                //ddlStatus.DataSource = dsL;
                //this.ddlStatus.DataTextField = "Name";
                //this.ddlStatus.DataValueField = "Id";
                //ddlStatus.DataBind();
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                ////if (txtEndDate.Text != "")
                ////{
                ////    if (DateTime.Parse(txtHiredDate.Text) > DateTime.Parse(txtEndDate.Text))
                ////    {
                ////        lblMSG.Text = "Error:" + " start date must be earlier than End date ";
                ////        lblMSG.ForeColor = System.Drawing.Color.Red;
                ////    }
                ////}



                //int count = chkTimeTable.Items.Count;
                //int i = 0;
                //while (i < count)
                //{

                //    if (chkTimeTable.Items[i].Selected == true)
                //    {
                //        if (chkEmployee.Items[0].Selected == true)
                //        {
                //            int empCount = chkEmployee.Items.Count;
                //            int j = 1;
                //            while (j < empCount)
                //            {
                //                DA.InsertEmployeeTimetable(int.Parse(chkTimeTable.Items[i].Value), chkEmployee.Items[j].Value, DateTime.Parse(txtHiredDate.Text), txtEndDate.Text, ddlType.SelectedItem.Text);
                //                j++;
                //            }
                //        }
                //        else
                //        {

                //            int empCount = chkEmployee.Items.Count;
                //            int j = 1;
                //            while (j < empCount)
                //            {
                //                if(chkEmployee.Items[j].Selected==true)
                //                {
                //                    DA.InsertEmployeeTimetable(int.Parse(chkTimeTable.Items[i].Value), chkEmployee.Items[j].Value, DateTime.Parse(txtHiredDate.Text), txtEndDate.Text, ddlType.SelectedItem.Text);
                //                }
                //                j++;
                //            }
                        
                //        }
                       
                //    }

                //    i++;
                //}







                //TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(txtDOB.Text);
                //TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                //if (ddlPosition.SelectedItem.Text == "--Select Department--" || ddlPosition.SelectedItem.Text == "---")
                //{
                //    lblMSG.Text = "Error:" + "Please Select Position";
                //    lblMSG.ForeColor = System.Drawing.Color.Red;
                
                //}
                //else if (timeSpan.Days < tmeeSpan1.Days)
                //{

                //    lblMSG.Text = "Error:" + " Employee Age must be > 18 ";
                //    lblMSG.ForeColor = System.Drawing.Color.Red;
                //}
                //else if (ddlEmploymentType.SelectedItem.Text == "Contract" && txtEndDate.Text=="")
                //{
                //    lblMSG.Text = "Error:" + " Please Insert End Date ";
                //    lblMSG.ForeColor = System.Drawing.Color.Red;
                //}
                //else if (txtEndDate.Text != "")
                //{
                //    if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                //    {
                //        lblMSG.Text = "Error:" + " Hired date must be earlier than End date ";
                //        lblMSG.ForeColor = System.Drawing.Color.Red;
                //    }
                //    else
                //    {

                //        string fileName = txtEmpId.Text + ".JPEG";
                //        string path = "Photo" + "\\" + fileName;

                //        // string autNAme = Session["userId"].ToString();
                //        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                //        DA.InsertEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text);
                //        Response.Redirect("EmployeeHome.aspx");
                //    }
                //}
                //else
                //{


                //    string fileName = txtEmpId.Text + ".JPEG";
                //    string path = "Photo" + "\\" + fileName;

                //    // string autNAme = Session["userId"].ToString();
                //    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                //    DA.InsertEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text);

                //    ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                //    Response.Redirect("EmployeeHome.aspx");
                //    //string userName = Session["userId"].ToString();
                //    //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
                //}

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentHome.aspx");
        }

        private void PopulateMenuDataTable(DataTable dt)
        {
            treeDepa.CollapseAll();
            CreateTreeViewDataTable(dt, 0, null);
        }



        private void CreateTreeViewDataTable(DataTable dt, int parentID, TreeNode parentNode)
        {
            DataRow[] drs = dt.Select("Department_Id = " + parentID.ToString());
            foreach (DataRow i in drs)
            {
                TreeNode newNode = new TreeNode(i["DepartmentName"].ToString(), i["Id"].ToString());
                if (parentNode == null)
                {
                    treeDepa.Nodes.Add(newNode);
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                }
                CreateTreeViewDataTable(dt, Convert.ToInt32(i["Id"]), newNode);
            }
            treeDepa.CollapseAll();
        }

        protected void treeDepa_SelectedNodeChanged(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            ////txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();
            txtDep.Text = treeDepa.SelectedNode.Text.ToString();

           // DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));

         

           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string empIdAll = "";
            lblMSG.Text="";
            try
            {
                if (txtDep.Text == "")
                {
                    lblMSG.Text = "Please Select Department from the Tree ";
                    ReportViewer1.Visible = false;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("empID");
                    dt.Columns.Add("Date");
                    string empId = "";
                    DataTable dep = new DataTable();
                    if (txtDep.Text == "Debub Global  Bank")
                    {
                        dep = DA.selectDepEmpALL().Tables[0];
                    }
                    else if (txtDep.Text != "")
                    {
                        dep = DA.selectDepEmp(int.Parse(lblParID.Text)).Tables[0];
                    }

                    for (int f = 0; f <= dep.Rows.Count; f++)
                    {
                        if (dep.Rows.Count == 0)
                        {
                            //empId = txtEmpId.Text;
                            //dep = DA.selectDepEmpIND(empId).Tables[0];
                        }
                        else if (f == dep.Rows.Count)
                        {
                            break;
                        }
                        else
                        {
                            empId = dep.Rows[f][0].ToString();
                            //empId = "8000";
                            double exCoun = fillBAlEXP(Int16.Parse(empId));
                           // double exCoun = 0.5;
                            DateTime date = DateTime.Parse(txtHiredDate.Text);
                            double days=0;
                            DataSet dsDays = DAL.selectDays(int.Parse(empId));
                              DataTable DTExp =new DataTable();
                            if (exCoun >= 0.5)
                            { 
                                if(exCoun>=0.5 && exCoun<1 && double.Parse(dsDays.Tables[0].Rows[0][0].ToString()) == 0.5 )
                                {
                                   days=0.5;
                                   DTExp  = selectDate(Int16.Parse(empId), date.AddDays(-1), exCoun, days);
                                }
                                else if (exCoun >= 1  )
                                {
                                    days = 1;
                                    DTExp = selectDate(Int16.Parse(empId), date.AddDays(-1), exCoun, days);
                                }

                                 takeAction(DTExp, Int16.Parse(empId));

                                empIdAll = empIdAll + "-"+empId.ToString()+"=>"+exCoun.ToString();

                            }
                        }
                    }

                    empIdAll = empIdAll;
                    lblMSG.Text = "Expired Leave Information Saved Successfully !!!!";
                    lblMSG.ForeColor = System.Drawing.Color.DarkGreen;

                }
              

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        public void takeAction(DataTable dt,int empIdN)
        {
            DataSet dsEE = daM.selectExpLeave(empIdN);
            int chk = 0;
            if (dsEE.Tables[0].Rows.Count > 0 )
            {
                if (dsEE.Tables[0].Rows[0][0].ToString() == "")
                {
                    chk = 0;
                }
                else
                {
                    chk = 1;
                }

            }
            if(chk==0)
            {

                DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
                using (TransactionScope ts = new TransactionScope())
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (dt.Rows[i][3].ToString() == "Yes")
                        {

                            DAL.InsertLeaveRequestsISS(empIdN, DateTime.Parse(dt.Rows[i][0].ToString()), DateTime.Parse(dt.Rows[i][0].ToString()), double.Parse(dt.Rows[i][1].ToString()), 13, "Authorized", empId, fillBAl(empIdN), double.Parse(dt.Rows[i][1].ToString()), "System Expired Leave");
                            DataSet ds = DAL.maxLeaveRequest();
                            int leReId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                            DAL.InsertLeaveRequestsDetail(empIdN, leReId, DateTime.Parse(dt.Rows[i][0].ToString()), double.Parse(dt.Rows[i][1].ToString()), dt.Rows[i][2].ToString(), "Authorized");
                            DA.saveUserLog(Session["userId"].ToString(), "Action Taken Expired Leave", dt.Rows[i][0].ToString(), DateTime.Now);

                        }

                    }

                    ts.Complete();
                }
            }
        
        
        }

        //protected void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    lblMSG.Text = "";
        //    try
        //    {

        //        int dr = txtName.Text.IndexOf("=");
        //        int id = Int32.Parse(txtName.Text.Substring(++dr));
        //        txtEmpId.Text = id.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMSG.Text = "Error:" + ex.Message;
        //        lblMSG.ForeColor = System.Drawing.Color.Red;

        //    }
        //}

        public double fillBAlEXP(int empId)
        {
            int leaveId = 13;
            string LeaveTYpe = "Annual Leave";
            DateTime date = DateTime.Parse(txtHiredDate.Text);

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
                    return tExp;


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


        public DataTable selectDate(int empId,DateTime date,double count,double days)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Day");
            dt.Columns.Add("Type");
            dt.Columns.Add("Status");
            count = Math.Round(count);
          //  int empId = Int32.Parse(ddlEmp.SelectedValue);
          //  DateTime date = DateTime.Parse(txtStartDate.Text);
            double k = 0;
          //  int jump = int.Parse(txtJump.Text);
            double jCount = 0;
            int sd = 0;
            while (k < count)
            {
                if (sd > 0)
                    date = date.AddDays(-1);
                sd++;
                DataSet dsSCH = DAL.selectEmployeeSCHLeave(empId, date);
                if (dsSCH.Tables[0].Rows.Count == 0)
                    break;
                //   int count = dsSCH.Tables[0].Rows.Count - 1;
                int dateM = date.Day;
                int month = date.Month;
                string dayN = date.DayOfWeek.ToString();
               // double days = double.Parse(ddlDays.SelectedItem.ToString());
                int j = 0;
                for (int i = 0; i < dsSCH.Tables[0].Rows.Count; i++)
                {
                    j++;
                    DataRow row = dt.NewRow();
                    if (k == count)
                        break;
                    DataSet dsLeav = DAL.selectEmployeeSCHLeave(13);
                    if (dsLeav.Tables[0].Rows[0][0].ToString() == "No")
                    {
                        DataSet holiday = DAL.selectSCHoliDay(month, dateM, date, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()));
                        if (holiday.Tables[0].Rows.Count > 0)
                        {
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = holiday.Tables[0].Rows[0][5].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            dt.Rows.Add(row);
                            if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                            {
                                //if (k == 0)
                                //   k = k + 1;
                                //dt.Rows.Add(row);
                               // jCount = jCount ;
                                break;
                            }
                            else
                            {
                                //if (k == 0)
                                //    k = k + 0.5;
                                goto weta;
                            }

                        }
                        DataSet weekend = DAL.selectSCWeekDAy(dayN, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()));
                        if (weekend.Tables[0].Rows.Count == 0)
                        {
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = "Weekend";
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            dt.Rows.Add(row);
                            if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                            {
                                //if (k == 0)
                                //  k = k + 1;
                                //dt.Rows.Add(row);
                                //jCount = jCount ;
                                break;
                            }
                            else
                            {
                                //if (k == 0)
                                //    k = k + 0.5;
                                goto weta;
                            }


                        }



                    }
                    DataSet leave = DA.selectLeaveEMP(date, empId, dsSCH.Tables[0].Rows[i][4].ToString());
                    if (leave.Tables[0].Rows.Count > 0)
                    {


                        row["Date"] = date.ToString("dd-MMM-yy");
                        row["Day"] = leave.Tables[0].Rows[0][0].ToString();
                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                        dt.Rows.Add(row);
                       // waring = waring + " * " + date.ToString("dd-MMM-yy");

                        if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                        {
                            //if (k == 0)
                            //    k = k + 1;
                            //dt.Rows.Add(row);
                            //jCount = jCount ;
                            break;
                        }
                        else
                        {
                            //if (k == 0)
                            //    k = k + 0.5;
                            goto weta;
                        }




                    }

                    if (jCount <= 0)
                    {
                        if (dsSCH.Tables[0].Rows.Count == j)
                        {
                           // jCount = jCount ;
                        }

                        if (days == 1.0 && dsSCH.Tables[0].Rows[i][2].ToString() == "And")
                        {
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            row["Status"] = "Yes";
                            k = k + 0.5;

                        }
                        else if (days == 0.5 && "Morning" == dsSCH.Tables[0].Rows[i][3].ToString())
                        {
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            row["Status"] = "Yes";
                            k = k + 0.5;
                        }
                        if (dsSCH.Tables[0].Rows[i][2].ToString() == "Or")
                        {
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            row["Status"] = "Yes";
                            k = k + 1;
                            dt.Rows.Add(row);
                          //  jCount = jCount ;
                            break;


                        }

                        row["Date"] = date.ToString("dd-MMM-yy");
                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();

                    }
                    else
                    {
                        if (dsSCH.Tables[0].Rows[i][2].ToString() == "Or")
                        {
                            jCount--;
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                            dt.Rows.Add(row);
                            break;
                        }
                        else if (dsSCH.Tables[0].Rows[i][2].ToString() == "And")
                        {
                            jCount = jCount - 0.5;
                            row["Date"] = date.ToString("dd-MMM-yy");
                            row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                            row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                        }


                    }

                    //DateTime dateT = DateTime.Parse(dsSCH.Tables[0].Rows[i][1].ToString());
                    //DateTime dateFR = dateT.AddMinutes(0 - int.Parse(dsSCH.Tables[0].Rows[i][2].ToString()));
                    //DateTime dateTO = dateT.AddMinutes(int.Parse(dsSCH.Tables[0].Rows[i][3].ToString()));
                    //int dateL = int.Parse(dsSCH.Tables[0].Rows[i][4].ToString());
                    //DataSet dsTime = DA.selectSCTime(empId, date, dateFR, dateTO);
                    dt.Rows.Add(row);

                weta: ;
                }

            }
            return dt;
        }

        public double fillBAl(int empId)
        {
            int leaveId = 13;
            string LeaveTYpe = "Annual Leave";
            DateTime date = DateTime.Parse(txtHiredDate.Text);

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
                   // double exp = (double.Parse(ds.Tables[0].Rows[0][7].ToString()) * 2) - 1;
                    double tExp = double.Parse(ds.Tables[0].Rows[0][4].ToString()) ;
                    //tExp = tExp - 1;
                    //if (tExp < 0)
                    //    lblEXP.Text = "0" + " " + "Days";
                    //else
                    //{
                    //    tExp = Math.Round(tExp, 2); ;
                    //    lblEXP.Text = tExp.ToString() + " " + "Days";
                    //}

                    tExp = Math.Round(tExp, 2);
                    return tExp;


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
