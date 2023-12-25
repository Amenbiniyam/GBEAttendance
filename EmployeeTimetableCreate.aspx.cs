using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeTimetableCreate : System.Web.UI.Page
{
    EmployeeDAL DA = new EmployeeDAL();
       
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
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                int l=0;
                if (txtEndDate.Text != "")
                {
                    if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                    {
                        l++;
                        mesgPN.BackColor = System.Drawing.Color.LightPink;
                        lblMSG.Text = "Error: start date must be earlier than End date";
                        lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                if(l==0)
                {


                    int count = chkTimeTable.Items.Count;
                    int i = 0;
                    int k = 0;
                    while (i < count)
                    {

                        if (chkTimeTable.Items[i].Selected == true)
                        {
                            if (chkEmployee.Items[0].Selected == true)
                            {
                                int empCount = chkEmployee.Items.Count;
                                int j = 1;
                                while (j < empCount)
                                {
                                    k++;
                                    DA.InsertEmployeeTimetable(int.Parse(chkTimeTable.Items[i].Value), chkEmployee.Items[j].Value, DateTime.Parse(txtHiredDate.Text), txtEndDate.Text, ddlType.SelectedItem.Text,ddlFP.SelectedItem.Text);
                                    j++;
                                }
                            }
                            else
                            {

                                int empCount = chkEmployee.Items.Count;
                                int j = 1;

                                while (j < empCount)
                                {
                                    if (chkEmployee.Items[j].Selected == true)
                                    {
                                        k++;
                                        DA.InsertEmployeeTimetable(int.Parse(chkTimeTable.Items[i].Value), chkEmployee.Items[j].Value, DateTime.Parse(txtHiredDate.Text), txtEndDate.Text, ddlType.SelectedItem.Text,ddlFP.SelectedItem.Text);
                                        DA.saveUserLog(Session["userId"].ToString(), "Employee/Time table Created", chkTimeTable.Items[i].Value, DateTime.Now);
                                    }
                                    j++;
                                }


                            }

                        }

                        i++;
                    }

                    if (k == 0)
                    {
                        mesgPN.BackColor = System.Drawing.Color.LightPink;
                        lblMSG.Text = "Error:Please Select Employee/Time Table";
                        lblMSG.ForeColor = System.Drawing.Color.DarkRed;

                    }
                    else
                    {
                        mesgPN.BackColor = System.Drawing.Color.LightGreen;
                        lblMSG.Text = "Employee/TimeTable Information Saved Successfully !!!!";
                        lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                    }

                }

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
               // Response.Redirect("EmployeeTimetableHome.aspx");
            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Employee/Schedule";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Employee/Schedule";
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
            Response.Redirect("EmployeeTimetableHome.aspx");
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

            DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));

            chkEmployee.Items.Clear();
            chkEmployee.Items.Add("ALL");
            chkEmployee.AppendDataBoundItems = true;

            chkEmployee.DataSource = ds;
            chkEmployee.DataTextField = "Full_Name";
            chkEmployee.DataValueField = "empId";
            chkEmployee.DataBind();

           
        }

        protected void butClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeTimetableCreate.aspx");
        }
}
