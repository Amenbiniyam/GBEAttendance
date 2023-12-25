using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using AttendanceAndLeaveManagementSystem;

public partial class DepLeaveReport : System.Web.UI.Page
{
    LeaveDAL DAL = new LeaveDAL();
    AttDAL DA = new AttDAL();
    MainDAL daM = new MainDAL();
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
                DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                DataSet dsd = DA.selectEmpDep(Int32.Parse(emp.Tables[0].Rows[0][0].ToString()));

                DataSet empDS = DA.selectEmployeeDEP(Int32.Parse(dsd.Tables[0].Rows[0][0].ToString()));

                ddlEmployee.Items.Clear();
                ddlEmployee.Items.Add("---");
                ddlEmployee.AppendDataBoundItems = true;
                ddlEmployee.DataSource = empDS;
                this.ddlEmployee.DataTextField = "Full_Name";
                this.ddlEmployee.DataValueField = "EmpId";
                ddlEmployee.DataBind();
              
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
                    DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                    DataSet dsd = DA.selectEmpDep(Int32.Parse(emp.Tables[0].Rows[0][0].ToString()));
                    int depId = Int32.Parse(dsd.Tables[0].Rows[0][0].ToString());
                    DataTable dep = new DataTable();
                    string depName = "";
                    string empId = "";
                    if (ddlEmployee.SelectedItem.Text == "---")
                    {
                        dep = DA.selectDepEmp(depId).Tables[0];
                        depName = dep.Rows[0][1].ToString();
                    }
                    else
                    {
                        empId = ddlEmployee.SelectedValue.ToString();
                    }



                       DataSet ds = DAL.leaveReport(empId, depName, DateTime.Parse(txtHiredDate.Text), DateTime.Parse(txtEndDate.Text));
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
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

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}
