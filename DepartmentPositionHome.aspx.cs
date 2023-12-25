using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DepartmentPositionHome : System.Web.UI.Page
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
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {

                try
                {
                    DA.deleteDepartmentPosition(Int32.Parse(row.Cells[0].Text));
                    DA.saveUserLog(Session["userId"].ToString(), "Department/Position Information Deleted", "", DateTime.Now);
                    GridView2.DataBind();
                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }


              
            }
        }
   

        protected void butEdit_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentPositionCreate.aspx");
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
           // txtParentDepartment.Text = treeDepa.SelectedNode.Text.ToString();
            lblDepID.Text = treeDepa.SelectedNode.Text;
            GridView2.DataBind();


        }
}
