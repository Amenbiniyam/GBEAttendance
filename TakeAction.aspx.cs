using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Transactions;

public partial class TakeAction : System.Web.UI.Page
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
                if (txtEndDate.Text != "")
                {
                    if (DateTime.Parse(txtHiredDate.Text) > DateTime.Parse(txtEndDate.Text))
                    {
                        lblMSG.Text = "Error:" + " start date must be earlier than End date ";
                        lblMSG.ForeColor = System.Drawing.Color.Red;
                    }
                }



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
            lblMSG.Text="";
            try
            {
                if (txtDep.Text == "" )
                {
                    lblMSG.Text = "Please Select Department from the Tree ";
                    ReportViewer1.Visible = false;
                }
                else if (DateTime.Parse(txtHiredDate.Text).Date > DateTime.Parse(txtEndDate.Text).Date)
                {
                    lblMSG.Text = "Error:" + " From date must be earlier than End date ";
                    ReportViewer1.Visible = false;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
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
                    string empId = "";
                    //if (txtDep.Text == "")
                    //{
                    //    empId = txtEmpId.Text;
                    //}
                    //else
                    //{
                    DataTable dep = new DataTable();
                        if (txtDep.Text == "Debub Global  Bank")
                        {
                            dep = DA.selectDepEmpALL().Tables[0];
                        }
                        else if(txtDep.Text!="")
                        {
                            dep = DA.selectDepEmp(int.Parse(lblParID.Text)).Tables[0];
                        }

                        for (int f=0; f <= dep.Rows.Count; f++)
                        {
                            if(dep.Rows.Count==0)
                            {
                                //empId = txtEmpId.Text;
                                //dep = DA.selectDepEmpIND(empId).Tables[0];
                            }
                            else if(f==dep.Rows.Count)
                            {
                             break;
                            }
                            else
                            {
                            empId = dep.Rows[f][0].ToString();
                            }
                              DataSet dsFP = daM.FP(Int32.Parse(empId));
                              if (dsFP.Tables[0].Rows[0][0].ToString() == "NO")
                              {


                              }
                              else
                              {
                          //  DateTime date = DateTime.Parse(txtHiredDate.Text);
                            DateTime date = DateTime.Parse(txtHiredDate.Text);
                            if (date < DateTime.Parse("01-Feb-2016"))
                            {
                                date = DateTime.Parse("01-Feb-2016");
                            }


                            DateTime dateEnd = DateTime.Parse(txtEndDate.Text);
                            double coun = (dateEnd - date).TotalDays;
                            double k = 0;
                            while (k <= coun)
                            {
                                if (k > 0)
                                    date = date.AddDays(1);
                                DataSet dsSCH = DA.selectEmployeeSCH(empId, date);
                                int count = dsSCH.Tables[0].Rows.Count - 1;
                                int dateM = date.Day;
                                int month = date.Month;
                                string dayN = date.DayOfWeek.ToString();
                                for (int i = 0; i < dsSCH.Tables[0].Rows.Count; i++)
                                {
                                    DataRow row = dt.NewRow();
                                    row["CompanyName"] = "Debub Global  Bank S.C.";
                                    row["DateF"] = txtHiredDate.Text;
                                    row["DateT"] = txtEndDate.Text;
                                    row["Desc"] = "Attendance Report";

                                    row["empID"] = empId;
                                    row["Department"] = dep.Rows[f][1].ToString();
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
                                    DataSet leave = DA.selectLeaveEMPAUT(date, Int32.Parse(empId), dsSCH.Tables[0].Rows[i][8].ToString());
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
                                    if (dayN == "Saturday" && dateT.TimeOfDay.ToString() == "13:00:00" && dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                                    {
                                        dateT = dateT.AddHours(-1);

                                    }
                                    DateTime dateFR = dateT.AddMinutes(0 - int.Parse(dsSCH.Tables[0].Rows[i][2].ToString()));
                                    DateTime dateTO = dateT.AddMinutes(int.Parse(dsSCH.Tables[0].Rows[i][3].ToString()));
                                    int dateL = int.Parse(dsSCH.Tables[0].Rows[i][4].ToString());
                                  //  txtDep.Text = dateFR.ToString() + dateTO.ToString();
                                    DataSet dsTime = DA.selectSCTime(empId, date, dateFR, dateTO);
                                    if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or"  && dsSCH.Tables[0].Rows[i][9].ToString() == "Yes")
                                    {
                                        if (dsTime.Tables[0].Rows.Count > 0)
                                        {
                                            row["Time"] = dsTime.Tables[0].Rows[0][0].ToString();
                                            DateTime timeSt = DateTime.Parse(dsTime.Tables[0].Rows[0][0].ToString());
                                           
                                            if (timeSt.TimeOfDay <= (dateT.AddMinutes(dateL).TimeOfDay))
                                            {
                                                row["Status"] = "ON TIME";
                                                row["Late_Minute"] = 0;
                                                //if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                                //{
                                                //    row["Late_Minute"] = 0;
                                                //}
                                                //else
                                                //{
                                                //    row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                                //}
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
                                    else if (dsSCH.Tables[0].Rows[i][6].ToString() == "And" && dsSCH.Tables[0].Rows[i][9].ToString() == "Yes")
                                    {

                                        if (dsTime.Tables[0].Rows.Count > 0)
                                        {
                                            row["Time"] = dsTime.Tables[0].Rows[0][0].ToString();
                                            DateTime timeSt = DateTime.Parse(dsTime.Tables[0].Rows[0][0].ToString());
                                            if (timeSt.TimeOfDay <= (dateT.AddMinutes(dateL).TimeOfDay))
                                            {
                                                row["Status"] = "ON TIME";
                                                row["Late_Minute"] = 0;
                                                //if ((timeSt.TimeOfDay - dateT.TimeOfDay) < DateTime.Parse("00:00:00").TimeOfDay)
                                                //{
                                                   
                                                //}
                                                //else
                                                //{
                                                //    row["Late_Minute"] = (timeSt.TimeOfDay - dateT.TimeOfDay).ToString();
                                                //}
                                                
                                                    
                                                   
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
                                    else
                                    {
                                        if (dsSCH.Tables[0].Rows[i][6].ToString() == "Or")
                                        {
                                            row["Status"] = " Attendance not required";
                                            dt.Rows.Add(row);
                                            break;
                                        }
                                        else
                                        {
                                            row["Status"] = " Attendance not required";
                                            dt.Rows.Add(row);
                                        }

                                        //  goto weta;


                                    }
                                weta: ;
                                }
                                k++;
                            }
                        }
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
                        dtR.Columns.Add("Late_Minute");
                        dtR.Columns.Add("CompanyName");
                        dtR.Columns.Add("DateF");
                        dtR.Columns.Add("DateT");
                        dtR.Columns.Add("Desc");
                        string status = "";
                        //if (ddlStatus.SelectedItem.ToString() != "---")
                        //{
                            string stType = "UNJUSTIFIED ABSENCE";
                            status = "Status=" + "'" + stType + "'";
                            DataRow[] dtRow = dt.Select(status);
                            foreach (DataRow row in dtRow)
                            {
                                dtR.ImportRow(row);
                            }


                            takeAction(dtR);
                          //  mesgPN.BackColor = System.Drawing.Color.LightGreen;
                            lblMSG.Text = "Employee Information Saved Successfully !!!!";
                            lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                        //ReportViewer1.Visible = true;
                        //ReportDataSource datasource = new ReportDataSource("DataSet1", dtR);
                        //ReportViewer1.LocalReport.DataSources.Clear();
                        //ReportViewer1.LocalReport.DataSources.Add(datasource);
                        //ReportViewer1.LocalReport.Refresh();


                    }
                
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        public void takeAction(DataTable dt)
        {
            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
            using (TransactionScope ts = new TransactionScope())
            {
                DataSet dsA = DAL.selectIdUna(DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                DataSet dsNO = DAL.selectFPUna(DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                DAL.UpdateLeaveRequestMAinSystem(DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                //DataSet ds = DAL.maxLeaveRequest();
                //int leReId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                {
                    DAL.UpdateLeaveRequestDetaSystem(Int32.Parse(dsA.Tables[0].Rows[j][0].ToString()));

                }
             
                for (int k = 0; k < dsNO.Tables[0].Rows.Count; k++)
                {
                   // DataSet dsLR=DAL.
                    DAL.InsertLeaveRequestsISS(Int32.Parse(dsNO.Tables[0].Rows[k][0].ToString()), DateTime.Parse(dsNO.Tables[0].Rows[k][1].ToString()), DateTime.Parse(dsNO.Tables[0].Rows[k][1].ToString()), double.Parse(dsNO.Tables[0].Rows[k][2].ToString()), 13, "Authorized", empId, 0, double.Parse(dsNO.Tables[0].Rows[k][2].ToString()), "System");
                    DataSet dsNOU = DAL.maxLeaveRequest();
                    int leReIdNO = Int32.Parse(dsNOU.Tables[0].Rows[0][0].ToString());
                    DAL.InsertLeaveRequestsDetail(Int32.Parse(dsNO.Tables[0].Rows[k][0].ToString()), leReIdNO, DateTime.Parse(dsNO.Tables[0].Rows[k][1].ToString()), double.Parse(dsNO.Tables[0].Rows[k][2].ToString()), dsNO.Tables[0].Rows[k][3].ToString(), "Authorized");
                    DA.saveUserLog(Session["userId"].ToString(), "Action Taken Leave ISsue", dsNO.Tables[0].Rows[k][0].ToString(), DateTime.Now);


                }
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    int empIdN = Int32.Parse(dt.Rows[i][0].ToString());
                        //DataSet dsA = DAL.selectIdUna(DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                        //DAL.UpdateLeaveRequestMAinSystem(DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                        ////DataSet ds = DAL.maxLeaveRequest();
                        ////int leReId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                        //for (int j = 0; j < dsA.Tables[0].Rows.Count; j++)
                        //{
                        //    DAL.UpdateLeaveRequestDetaSystem(Int32.Parse(dsA.Tables[0].Rows[j][0].ToString()));
                                           
                        //}
                        DAL.InsertLeaveRequestsISS(Int32.Parse(dt.Rows[i][0].ToString()), DateTime.Parse(dt.Rows[i][2].ToString()), DateTime.Parse(dt.Rows[i][2].ToString()), double.Parse(dt.Rows[i][5].ToString()), 13, "Authorized", empId, 0, double.Parse(dt.Rows[i][5].ToString()), "System");
                        DataSet ds = DAL.maxLeaveRequest();
                        int leReId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                        DAL.InsertLeaveRequestsDetail(Int32.Parse(dt.Rows[i][0].ToString()), leReId, DateTime.Parse(dt.Rows[i][2].ToString()), double.Parse(dt.Rows[i][5].ToString()), dt.Rows[i][6].ToString(), "Authorized");
                        DA.saveUserLog(Session["userId"].ToString(), "Action Taken Leave ISsue", dt.Rows[i][0].ToString(), DateTime.Now);


                        
                    }
               // }
                ts.Complete();
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
}
