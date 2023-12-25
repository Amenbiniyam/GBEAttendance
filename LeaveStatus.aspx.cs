using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using Microsoft.Reporting.WebForms;

public partial class LeaveStatus : System.Web.UI.Page
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

                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);
                DataSet dsL = DAL.AllLeaveTypeEmpALL();
                


            }
        }
       


       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentHome.aspx");
        }

      


       
       

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text="";
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
        public DataTable selectAL(DateTime date,int empId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Bal");
            dt.Columns.Add("Ent");
            dt.Columns.Add("BAsic");
            dt.Columns.Add("Taken");
                DataSet dsIn=DAL.INLeaveType("Annual Leave");
                DataSet dsLWP = DAL.sumLWP(empId);
                DataSet ds = DAL.selectEmployeeLevaeBal(empId);
                string tak1 = dsIn.Tables[0].Rows[0][0].ToString();


                if ((dsIn.Tables[0].Rows.Count != 0 && tak1 != "") && ds.Tables[0].Rows.Count>0)
                {
                    double INV = double.Parse(dsIn.Tables[0].Rows[0][0].ToString());
                    double SLWP = 0;
                  
                        string SLW = dsLWP.Tables[0].Rows[0][0].ToString();
                        if (SLW != "")
                        {
                            SLWP = double.Parse(SLW);
                        }
                   
                    TimeSpan timeSpan = date- Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
                    //TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                    double WD = timeSpan.Days;
                    WD = WD - SLWP;
                    DataSet DSHDAte=DAL.empHDAte(empId);
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

                    double caBal=0;
                    double caBal1 = 0;
                    while (LE > 0)
                    {
                        if(LE > 730)
                        {
                          caBal=caBal+LECount;
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
                            caBal=caBal+((LE * LECount) / 365);
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
                    double bal =(caBal-caBal1)+(double.Parse(ds.Tables[0].Rows[0][4].ToString())) ;


                    DataSet dsLR = DAL.sumLeave(empId, int.Parse("13"), "Authorized");
                    ds.Tables[0].Columns.Add("LeaveTaken");
                    string tak = dsLR.Tables[0].Rows[0][0].ToString();

                    DataSet dsLRU = DAL.sumLeave(empId, int.Parse("13"), "Unauthorized");
                    if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                    {
                        taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                    }
                    bal = bal - taken;
                    ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                    ds.Tables[0].Rows[0][7] = taken.ToString();
                    ds.Tables[0].Rows[0][6] = (LECount - leaveEnti) + leaveEnti;
                     
                    DataRow row = dt.NewRow();
                    row["Bal"]= Math.Round(bal, 2);
                    row["Ent"] = (LECount - leaveEnti) + leaveEnti;
                    row["BAsic"] = caBal;
                    row["Taken"] = taken.ToString();
                    dt.Rows.Add(row);
                    
                }
                else
                {
                   
                }
                return dt;
        
        }
        public void fillBAl()
        {
            lblMSG.Text = "";
            //mesgPN.BackColor = System.Drawing.Color.White;
            try
            {
                 if (txtDep.Text == "" && txtEmpId.Text == "")
                {
                    lblMSG.Text = "Please Insert Employee ID or Select Department from the Tree ";
                    ReportViewer1.Visible = false;
                }
                else if (DateTime.Parse(txtFrom.Text).Date > DateTime.Parse(txtTo.Text).Date)
                {
                    lblMSG.Text = "Error:" + " From date must be earlier than End date ";
                    ReportViewer1.Visible = false;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
          
                        DataTable dt = new DataTable();
                        dt.Columns.Add("EmpId");
                        dt.Columns.Add("FullName");
                        dt.Columns.Add("Department");
                        dt.Columns.Add("DateOfHire");
                        dt.Columns.Add("LeaveEntitledTo");
                        dt.Columns.Add("NetALFrom");
                        dt.Columns.Add("AccLeaveFromTo");
                        dt.Columns.Add("LeaveTakenFromTo");
                        dt.Columns.Add("NetALTo");
                        dt.Columns.Add("SickLTakenFomTo");
                        dt.Columns.Add("salary");
                        dt.Columns.Add("LeaveINBirr");
                        dt.Columns.Add("ExpLeave");
                        dt.Columns.Add("CompanyName");
                        dt.Columns.Add("DateF");
                        dt.Columns.Add("DateT");
                        dt.Columns.Add("Desc");
                        string empId = "";
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
                                empId = txtEmpId.Text;
                                dep = DA.selectDepEmpIND(empId).Tables[0];
                            }
                            else if(f==dep.Rows.Count)
                            {
                             break;
                            }
                            else
                            {
                            empId = dep.Rows[f][0].ToString();
                            }


                                DataSet dsALL = DA.selectALLEMP(Int32.Parse(empId));          
                              
                                string tak1 = dsALL.Tables[0].Rows[0][0].ToString();
                                if (dsALL.Tables[0].Rows.Count != 0 && tak1 != "")
                                {
                                    DataRow row = dt.NewRow();
                                    row["EmpId"] = dsALL.Tables[0].Rows[0][0].ToString();
                                    row["FullName"] = dsALL.Tables[0].Rows[0][1].ToString();
                                    row["Department"] = dsALL.Tables[0].Rows[0][2].ToString();
                                    row["DateOfHire"] = dsALL.Tables[0].Rows[0][3].ToString();
                                    row["salary"] = dsALL.Tables[0].Rows[0][4].ToString();
                                    row["CompanyName"] = "Debub Global  Bank S.C.";
                                    row["DateF"] = txtFrom.Text;
                                    row["DateT"] = txtTo.Text;
                                    row["Desc"] = "Leave Status Report";

                                    MainDAL daM = new MainDAL();
                                    DataTable From = fillBAlNew(Int32.Parse(empId), DateTime.Parse(txtFrom.Text),13 );
                                    DataTable To = fillBAlNew(Int32.Parse(empId), DateTime.Parse(txtTo.Text), 13);
                                    double sick = 0;
                                    DataSet DSick = DAL.sumSick(Int32.Parse(empId));
                                    string tak = DSick.Tables[0].Rows[0][0].ToString();
                                    if (DSick.Tables[0].Rows.Count != 0 && tak != "")
                                    {
                                        sick = Math.Round(double.Parse(DSick.Tables[0].Rows[0][0].ToString()), 2);
                                    }
                                    row["LeaveEntitledTo"] = To.Rows[0][2].ToString();
                                    row["NetALFrom"] = From.Rows[0][0].ToString();
                                    row["AccLeaveFromTo"] = Math.Round((double.Parse(To.Rows[0][0].ToString()) - double.Parse(From.Rows[0][0].ToString())), 2) + (Math.Round((double.Parse(To.Rows[0][1].ToString()) - double.Parse(From.Rows[0][1].ToString())), 2));
                                    row["LeaveTakenFromTo"] = Math.Round((double.Parse(To.Rows[0][1].ToString()) - double.Parse(From.Rows[0][1].ToString())), 2);
                                    row["NetALTo"] = To.Rows[0][0].ToString();
                                    row["SickLTakenFomTo"] = Math.Round((double.Parse(To.Rows[0][3].ToString()) - double.Parse(From.Rows[0][3].ToString())), 2); ;
                                    double salary = double.Parse(dsALL.Tables[0].Rows[0][4].ToString());
                                    salary = salary / 22;
                                    row["LeaveINBirr"] = Math.Round((double.Parse(To.Rows[0][0].ToString()) * salary), 2);
                                    double ent = double.Parse(To.Rows[0][1].ToString());
                                    double bal=double.Parse(To.Rows[0][0].ToString());
                                    double entN=double.Parse(To.Rows[0][2].ToString());
                                    double exp=bal-(entN+(entN-1));
                                    double expL = Math.Round(exp, 2);
                                    if(expL<0)
                                    {
                                        expL=0;
                                    }
                                   
                                    row["ExpLeave"] = expL;

                                    dt.Rows.Add(row);
                                }
            
            }
            ReportViewer1.Visible = true;
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
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
     
        protected 
        void butView_Click(object sender, ImageClickEventArgs e)
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
            ////txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();
            txtDep.Text = treeDepa.SelectedNode.Text.ToString();

            // DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));




        }


        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {

                int dr = txtName.Text.IndexOf("=");
                int id = Int32.Parse(txtName.Text.Substring(++dr));
                txtEmpId.Text = id.ToString();
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }


        public DataTable fillBAlNew(int empID,DateTime date,int leaveType  )
        {
            lblMSG.Text = "";
            DataTable dt = new DataTable();
            dt.Columns.Add("Bal");
            dt.Columns.Add("Taken");
            dt.Columns.Add("LeaveEntitled");
            dt.Columns.Add("Sick");
            //mesgPN.BackColor = System.Drawing.Color.White;
            MainDAL daM = new MainDAL();
           // DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            DataSet ds = DAL.selectEmployeeLevaeBalTYpe(empID, "Annual Leave");
        
            DataSet dsIn = DAL.INLeaveTypeID(leaveType);
            DataSet dsLWP = DAL.sumLWP(empID);
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
                    DataSet DSHDAte = DAL.empHDAte(empID);
                    DateTime DHired = DateTime.Parse(DSHDAte.Tables[0].Rows[0][0].ToString());
                    TimeSpan LEC = date - DHired;
                    DateTime setDate = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
                    TimeSpan LEC1 = setDate - DHired;
                    double leaveEnti = 0;
                    DataSet leaveEnta = DA.selectLeaveEntitlement(empID);
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


                    DataSet dsLR = DAL.sumLeaveBal(empID, leaveType, "Authorized", date);
                    ds.Tables[0].Columns.Add("LeaveTaken");
                    string tak = dsLR.Tables[0].Rows[0][0].ToString();

                    // DataSet dsLRU = DAL.sumLeave(empId, int.Parse(ddlLeave.SelectedValue.ToString()), "Unauthorized");
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

                   // ds.Tables[0].Rows[0][5] = DateTime.Parse(txtStartDate.Text).ToString("dd-MMM-yyyy");
                    bal = bal - taken;
                    DataRow row = dt.NewRow();
                    row[0] = Math.Round(bal, 2);
                    row[1] = taken.ToString();
                    ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                    ds.Tables[0].Rows[0][7] = taken.ToString();
                    row[2] = (LECount - leaveEnti) + leaveEnti;
                    DataSet Sick = DAL.sumLeaveBal(empID, 14, "Authorized", date);
                    row[3] = Sick.Tables[0].Rows[0][0].ToString();
                    dt.Rows.Add(row);

                }
                else
                {

                }

                return dt;

            //butSave.Visible = true;
            //Panel3.Visible = false;
        }
}
        




