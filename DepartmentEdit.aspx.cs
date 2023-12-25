using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentEdit : System.Web.UI.Page
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
                fillEdit();
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);
              
            }
        }

      
        public void fillEdit()
        {


            //   Session["depId"] = Int32.Parse(row.Cells[0].Text);
            //Session["depName"] = row.Cells[1].Text;
            //Session["depDescription"] = row.Cells[2].Text.Trim();
            //DataSet ds = DA.selectDEPTree(Int32.Parse(lblID.Text));
            //// txtParentID.Text = ds.Tables[0].Rows[0][0].ToString();
            //Session["depParId"] = ds.Tables[0].Rows[0][0].ToString();


            lblID.Text = Session["depId"].ToString().Replace("&nbsp;", "");
            txtDepartmentName.Text = Session["depName"].ToString().Replace("&nbsp;", "");
            txtDescription.Text = Session["depDescription"].ToString().Replace("&nbsp;", "");
            lblParID.Text = Session["depParId"].ToString().Replace("&nbsp;", "");
            txtParentDepartment.Text = Session["depParName"].ToString().Replace("&nbsp;", "");
       

        }
      
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                DA.updateDepartment(Int32.Parse(lblID.Text), txtDepartmentName.Text, txtDescription.Text, Int32.Parse(lblParID.Text));
                DA.saveUserLog(Session["userId"].ToString(), "Update Department", "", DateTime.Now);
                Response.Redirect("DepartmentHome.aspx");
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
            txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();

        
        }
    }
