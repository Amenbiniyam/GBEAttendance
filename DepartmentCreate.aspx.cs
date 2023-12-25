using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentCreate : System.Web.UI.Page
{
    DepartmentDAL DA = new DepartmentDAL();
       
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
                int maxID = 0;
                DataSet max = DA.selectDEPMAx();
                if (max.Tables[0].Rows.Count != 0)
                {
                    maxID = int.Parse(max.Tables[0].Rows[0][0].ToString())+1;
                }
                txtID.Text = maxID.ToString();
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
               

                    DA.InsertDepartment(Int32.Parse(txtID.Text),txtDepartmentName.Text, txtDescription.Text, Int32.Parse(lblParID.Text));
                    mesgPN.BackColor = System.Drawing.Color.LightGreen;
                    lblMSG.Text = "Department Information Saved Successfully !!!!";
                    lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                    DA.saveUserLog(Session["userId"].ToString(), "Department Create ", "", DateTime.Now);
                    treeDepa.Nodes.Clear();
                    DataSet ds = DA.selectDepTreeAll();
                    DataTable dt = ds.Tables[0];
                    PopulateMenuDataTable(dt);
                    
                //string userName = Session["userId"].ToString();
                //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Department Name";
                }
                else if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Department ID";
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
            txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();

        
        }
        protected void butClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentCreate.aspx");
        }
}
