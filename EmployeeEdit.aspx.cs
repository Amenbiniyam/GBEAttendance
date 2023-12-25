using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeEdit : System.Web.UI.Page
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
            imgEmp.ImageUrl = "";
            DataSet ds = DA.selectDepTreeAll();
            DataTable dt = ds.Tables[0];
            PopulateMenuDataTable(dt);
            string empId = Session["empId"].ToString();
            fillData(empId);

        }
    }
    public void fillData(string empID)
    {
        DataSet ds = DA.selectEmployee(empID);
        txtEmpId.Text = empID;
        txtFName.Text = ds.Tables[0].Rows[0][1].ToString();
        txtMiddleName.Text = ds.Tables[0].Rows[0][2].ToString();
        txtLastName.Text = ds.Tables[0].Rows[0][3].ToString();

        radGender.Items.FindByText(ds.Tables[0].Rows[0][4].ToString()).Selected = true;
        // .SelectedItem.Text = ds.Tables[0].Rows[0][4].ToString();

        txtDOB.Text = ds.Tables[0].Rows[0][5].ToString();

        txtTele.Text = ds.Tables[0].Rows[0][6].ToString();
        txtAddress.Text = ds.Tables[0].Rows[0][7].ToString();
        txtMobNo.Text = ds.Tables[0].Rows[0][8].ToString();
        txtSalary.Text = ds.Tables[0].Rows[0][18].ToString();
        imgEmp.ImageUrl = ds.Tables[0].Rows[0][9].ToString();

        //ddlEmploymentType.Items.Add("Permanent");
        //ddlEmploymentType.Items.Add("Contract");
        txtHiredDate.Text = ds.Tables[0].Rows[0][10].ToString();
        //  ddlEmploymentType.SelectedItem.Text = ds.Tables[0].Rows[0][11].ToString();

        if (ds.Tables[0].Rows[0][11].ToString() == "Contract")
        {

            ddlEmploymentType.Items.Add("Contract");
            ddlEmploymentType.Items.Add("Permanent");
            lblEndDAte.Visible = true;
            txtEndDate.Visible = true;
            ImageButton3.Visible = true;
        }
        else
        {
            ddlEmploymentType.Items.Add("Permanent");
            ddlEmploymentType.Items.Add("Contract");
            lblEndDAte.Visible = false;
            txtEndDate.Visible = false;
            ImageButton3.Visible = false;
        }


        txtEndDate.Text = ds.Tables[0].Rows[0][12].ToString();
        //    ddlPosition.SelectedItem.Text = ds.Tables[0].Rows[0][13].ToString();
        //  ddlPosition.SelectedValue.Replace(ds.Tables[0].Rows[0][13].ToString(), ds.Tables[0].Rows[0][16].ToString());

        // lblParID.Text = treeDepa.SelectedNode.Value.ToString();

        ddlPosition.Items.Clear();

        ddlPosition.Items.Add("---");
        ddlPosition.AppendDataBoundItems = true;
        DataSet dsd = DA.selectPositionDEP(Int32.Parse(ds.Tables[0].Rows[0][15].ToString()));

        ddlPosition.DataSource = dsd;
        this.ddlPosition.DataTextField = "PositionName";
        this.ddlPosition.DataValueField = "Id";

        ddlPosition.DataBind();
        ddlPosition.Items.FindByValue(ds.Tables[0].Rows[0][16].ToString()).Selected = true;

        ddlFP.Items.FindByText(ds.Tables[0].Rows[0][19].ToString()).Selected = true;
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
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
            else if (timeSpan.Days < tmeeSpan1.Days)
            {

                lblMSG.Text = "Error:" + " Employee Age must be > 18 ";
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }
            else if (ddlEmploymentType.SelectedItem.Text == "Contract" && txtEndDate.Text == "")
            {
                lblMSG.Text = "Error:" + " Please Insert End Date ";
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }
            else if (txtEndDate.Text != "")
            {
                if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                {
                    lblMSG.Text = "Error:" + " Hired date must be earlier than End date ";
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (ddlEmploymentType.SelectedItem.Text == "Permanent")
                        txtEndDate.Text = "";
                    string fileName = txtEmpId.Text + ".JPEG";
                    string path = "~\\Photo" + "\\" + fileName;

                    // string autNAme = Session["userId"].ToString();
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                    DA.updateEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text,txtSalary.Text,ddlFP.SelectedItem.Text,ddlEmpSta.SelectedItem.Text);
                    DA.saveUserLog(Session["userId"].ToString(), "Employee Updated", "", DateTime.Now);
                    Response.Redirect("EmployeeHome.aspx");
                }
            }
            else
            {

                if (ddlEmploymentType.SelectedItem.Text == "Permanent")
                    txtEndDate.Text = "";
                string fileName = txtEmpId.Text + ".JPEG";
                string path = "~\\Photo" + "\\" + fileName;

                // string autNAme = Session["userId"].ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Photo/" + fileName));
                DA.updateEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text,txtSalary.Text,ddlFP.SelectedItem.Text,ddlEmpSta.SelectedItem.Text);

                ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                Response.Redirect("EmployeeHome.aspx");
                //string userName = Session["userId"].ToString();
                DA.saveUserLog(Session["userId"].ToString(), "Employee Updated", txtEmpId.Text, DateTime.Now);
                //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
            }

        }
        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

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
}