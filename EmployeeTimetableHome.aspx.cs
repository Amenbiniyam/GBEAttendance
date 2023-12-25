using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeTimetableHome : System.Web.UI.Page
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

        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Edit(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            // Company com = new Company();

            Session["empIdT"] = row.Cells[0].Text;
            Session["empNameT"] = row.Cells[1].Text;



            //   txtCustomerID.ReadOnly = true;
            Response.Redirect("EmployeeTimetableEdit.aspx");
            //popup.Show();
        }
    }
    protected void Delete(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
        {
            //txtComNameDelete.Text = row.Cells[1].Text;

            //lblDelID.Text = row.Cells[0].Text;
            //lblDelTime.Text = row.Cells[6].Text;
            //   txtCustomerID.ReadOnly = true;

            DA.deleteEmployeeTimetable(Int32.Parse(row.Cells[6].Text), Int32.Parse(row.Cells[0].Text));
            GridView1.DataBind();
           // Response.Redirect("EmployeeTimetableHome.aspx");
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
        Response.Redirect("EmployeeTimetableCreate.aspx");
    }

    protected void butDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //DA.deleteEmployeeTimetable(Int32.Parse(lblDelTime.Text),Int32.Parse(lblDelID.Text));
            //DA.deleteEmployee(Int32.Parse(row.Cells[0].Text));
            //GridView1.DataBind();
            //Response.Redirect("EmployeeTimetableHome.aspx");
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
        GridView1.DataBind();

        //ddlPosition.Items.Clear();

        //ddlPosition.Items.Add("---");
        //ddlPosition.AppendDataBoundItems = true;
        //DataSet ds = DA.selectPositionDEP(Int32.Parse(lblParID.Text));

        //ddlPosition.DataSource = ds;
        //this.ddlPosition.DataTextField = "PositionName";
        //this.ddlPosition.DataValueField = "Id";

        //ddlPosition.DataBind();
    }
}