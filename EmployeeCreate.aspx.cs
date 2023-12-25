using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class EmployeeCreate : System.Web.UI.Page
{
     EmployeeDAL DA = new EmployeeDAL();
     MainDAL MAD = new MainDAL();
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
                TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(txtDOB.Text);
                TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                if (ddlPosition.SelectedItem.Text == "--Select Department--" || ddlPosition.SelectedItem.Text == "---")
                {
                    lblMSG.Text = "Error:" + "Please Select Position";
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    mesgPN.BackColor = System.Drawing.Color.LightPink;
                
                }
                else if (timeSpan.Days < tmeeSpan1.Days)
                {

                    lblMSG.Text = "Error:" + " Employee Age must be > 18 ";
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    mesgPN.BackColor = System.Drawing.Color.LightPink;
                }
                else if (ddlEmploymentType.SelectedItem.Text == "Contract" && txtEndDate.Text=="")
                {
                    lblMSG.Text = "Error:" + " Please Insert End Date ";
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    mesgPN.BackColor = System.Drawing.Color.LightPink;
                }
                else if (txtEndDate.Text != "")
                {
                    if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                    {
                        lblMSG.Text = "Error:" + " Hired date must be earlier than End date ";
                        lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                        mesgPN.BackColor = System.Drawing.Color.LightPink;
                    }
                    else
                    {

                        string fileName = txtEmpId.Text + ".JPEG";
                        string path = "~\\Photo" + "\\" + fileName;

                        // string autNAme = Session["userId"].ToString();
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                        DA.InsertEmployee(Int32.Parse(txtEmpId.Text), txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text,double.Parse(txtSalary.Text),ddlFP.SelectedItem.Text,ddlEmpSta.SelectedItem.Text);
                        mesgPN.BackColor = System.Drawing.Color.LightGreen;
                        lblMSG.Text = "Employee Information Saved Successfully !!!!";
                        lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                        DA.saveUserLog(Session["userId"].ToString(), "New Employee Saved", "", DateTime.Now);
                    }
                }
                else
                {


                    string fileName = txtEmpId.Text + ".JPEG";
                    string path = "~\\Photo" + "\\" + fileName;

                    // string autNAme = Session["userId"].ToString();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                    DA.InsertEmployee(Int32.Parse(txtEmpId.Text), txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text,double.Parse(txtSalary.Text),ddlFP.SelectedItem.Text,ddlEmpSta.SelectedItem.Text);

                    ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                    mesgPN.BackColor = System.Drawing.Color.LightGreen;
                    lblMSG.Text = "Employee Information Saved Successfully !!!!";
                    lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                    //string userName = Session["userId"].ToString();
                    //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
                }

            }
            catch (SqlException ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)   
                {
                    lblMSG.Text = "Error:" + "Duplicate EMP ID";
                }
                else if(exM.StartsWith("Violation of UNIQUE KEY") == true )
                {
                    lblMSG.Text = "Error:" + "Duplicate Full Name";
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
            Response.Redirect("EmployeeHome.aspx");
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
            txtDepName.Text = treeDepa.SelectedNode.Text;
            ddlPosition.Items.Clear();
           
            ddlPosition.Items.Add("---");
            ddlPosition.AppendDataBoundItems = true;
            DataSet ds = DA.selectPositionDEP(Int32.Parse(lblParID.Text));

            ddlPosition.DataSource = ds;
            this.ddlPosition.DataTextField = "PositionName";
            this.ddlPosition.DataValueField = "Id";

            ddlPosition.DataBind();
        }

        protected void ddlEmploymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmploymentType.SelectedItem.Text == "Contract")
            {
                lblEndDAte.Visible = true;
                txtEndDate.Visible = true;
                ImageButton3.Visible = true;
            }
            else
            {

                lblEndDAte.Visible = false;
                txtEndDate.Visible = false;
                ImageButton3.Visible = false;
            }

        }
        protected void butClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeCreate.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
}
