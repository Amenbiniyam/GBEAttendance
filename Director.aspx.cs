using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Director : System.Web.UI.Page
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["userId"] == null)
        {
            Response.Redirect("LogIn.aspx");
        }
        if (!IsPostBack)
        {
            lblMSG.Text = "";
            try
            {

                DataSet ds = da.selectDepAut();
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            
        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

        }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
            
        lblMSG.Text = "";
        try
        {
            DataSet ds = new DataSet();
            DataTable tab = new DataTable();

            tab.Columns.Add("EmpID");
            tab.Columns.Add("AutID");            
            // DataTable dt = new DataTable();
            for (int j = 0; j < GridView1.Rows.Count; j++)
            {
                DataRow dr;
                GridViewRow row = GridView1.Rows[j];
                dr = tab.NewRow();
                for (int i = 0; i < 2; i++)
                {
                 //   EmpID, AutID
                    if (i == 0)
                    {
                      TextBox txtEmpId = (TextBox)GridView1.Rows[j].FindControl("txtEmpId");
                        dr[i] = txtEmpId.Text;
                    }
                    else if (i == 1)
                    {

                        TextBox txtAud = (TextBox)GridView1.Rows[j].FindControl("txtAud");
                        dr[i] = txtAud.Text;
                    }
                 
                    //dr[i] = row.Cells[i].Text.TrimStart();
                }

                tab.Rows.Add(dr);
            }

            //SqlBulkCopy sbc = new SqlBulkCopy(targetConnStr);
            //sbc.DestinationTableName = "yourDestinationTable";
            //sbc.WriteToServer(dt);
            //sbc.Close();
            ds.Tables.Add(tab);

            da.deleteDepAut();
            da.saveDepAut(ds);
            lblMSG.Text = "Information Saved Successfully !!!!";
            lblMSG.ForeColor = System.Drawing.Color.DarkGreen;

        }
        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

        }
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}