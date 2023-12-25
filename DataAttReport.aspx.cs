using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class DataAttReport : System.Web.UI.Page
{
       AttDAL DA = new AttDAL();
       LeaveDAL DAL = new LeaveDAL();
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
              //  PopulateMenuDataTable(dt);
                DataSet dsL = DAL.AllLeaveTypeEmpALL();
                //ddlLeave.Items.Clear();
               // ddlLeave.Items.Add("---");
               
              
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

        //private void PopulateMenuDataTable(DataTable dt)
        //{
        //    treeDepa.CollapseAll();
        //    CreateTreeViewDataTable(dt, 0, null);
        //}



        //private void CreateTreeViewDataTable(DataTable dt, int parentID, TreeNode parentNode)
        //{
        //    DataRow[] drs = dt.Select("Department_Id = " + parentID.ToString());
        //    foreach (DataRow i in drs)
        //    {
        //        TreeNode newNode = new TreeNode(i["DepartmentName"].ToString(), i["Id"].ToString());
        //        if (parentNode == null)
        //        {
        //            treeDepa.Nodes.Add(newNode);
        //        }
        //        else
        //        {
        //            parentNode.ChildNodes.Add(newNode);
        //        }
        //        CreateTreeViewDataTable(dt, Convert.ToInt32(i["Id"]), newNode);
        //    }
        //    treeDepa.CollapseAll();
        //}

        //protected void treeDepa_SelectedNodeChanged(object sender, EventArgs e)
        //{
        //    ////txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
        //    lblParID.Text = treeDepa.SelectedNode.Value.ToString();
        //    txtDep.Text = treeDepa.SelectedNode.Text.ToString();

        //   // DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));

         

           
        //}

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text="";
            try
            {
                //if (txtDep.Text == "" && txtEmpId.Text == "")
                //{
                //    lblMSG.Text = "Please Insert Employee ID or Select Department from the Tree ";
                //    ReportViewer1.Visible = false;
                //}
                 if (DateTime.Parse(txtHiredDate.Text).Date > DateTime.Parse(txtEndDate.Text).Date)
                {
                    lblMSG.Text = "Error:" + " From date must be earlier than End date ";
                    ReportViewer1.Visible = false;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("empID");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("Time");
                    dt.Columns.Add("CompanyName");
                    dt.Columns.Add("DateF");
                    dt.Columns.Add("DateT");
                    dt.Columns.Add("Desc");
                    string empId = "";
                    // DataTable dep = new DataTable();
                    //    if (txtDep.Text == "Debub Global  Bank")
                    //    {
                    //        dep = DA.selectDepEmpALL().Tables[0];
                    //    }
                    //    else if(txtDep.Text!="")
                    //    {
                    //        dep = DA.selectDepEmp(int.Parse(lblParID.Text)).Tables[0];
                    //    }

                    //    for (int f=0; f < dep.Rows.Count; f++)
                    //    {
                    //        if(dep.Rows.Count==0)
                    //        {
                                  empId = txtEmpId.Text;
                                  DataSet dsTime = DA.selectATTDAta(empId,DateTime.Parse(txtHiredDate.Text),DateTime.Parse(txtEndDate.Text));
                                     for(int i=0;i<dsTime.Tables[0].Rows.Count;i++)
                                     {
                                        DataRow row=dt.NewRow();
                                        row["empID"] = dsTime.Tables[0].Rows[i][0];
                                        row["Date"] = dsTime.Tables[0].Rows[i][1];
                                        row["Time"] = dsTime.Tables[0].Rows[i][2];
                                        row["CompanyName"] = "Debub Global  Bank S.C.";
                                        row["DateF"] = txtHiredDate.Text;
                                        row["DateT"] = txtEndDate.Text;
                                        row["Desc"] = "Attendance Data Report";
                                      
                                        dt.Rows.Add(row);
                                     }
                               
                            //}
                            //else
                            //{
                            //        empId = dep.Rows[f][0].ToString();
                            //        DataSet dsTime1 = DA.selectATTDAta(empId,DateTime.Parse(txtHiredDate.Text),DateTime.Parse(txtEndDate.Text));
                            //        for(int i=0;i<dsTime1.Tables[0].Rows.Count;i++)
                            //        {
                            //            DataRow row=dt.NewRow();
                            //            row["empID"] = dsTime1.Tables[0].Rows[i][0];
                            //            row["Date"] = dsTime1.Tables[0].Rows[i][1];
                            //            row["Time"] = dsTime1.Tables[0].Rows[i][2];
                            //            row["CompanyName"] = "Debub Global  Bank S.C.";
                            //            row["DateF"] = txtHiredDate.Text;
                            //            row["DateT"] = txtEndDate.Text;
                            //            row["Desc"] = "Attendance Data Report";
                            //            row["empID"] = empId;
                                        
                            //            dt.Rows.Add(row);
                            //         }
                                
                            //}
                            //f++;
                        //}
                       
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
}
