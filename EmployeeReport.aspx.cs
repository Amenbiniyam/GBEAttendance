using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class EmployeeReport : System.Web.UI.Page
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
                //ddlLeave.Items.Clear();
               // ddlLeave.Items.Add("---");
              
              
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
                else
                {
                    DataSet ds = DA.selectEmployeeALLDEP(txtDep.Text);
                    ds.Tables[0].Columns.Add("CompanyName");
                    ds.Tables[0].Columns.Add("Desc");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i][16] = "Debub Global  Bank S.C.";                      
                        ds.Tables[0].Rows[i][17] = "Employee Information Report";

                    }

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

        
}
