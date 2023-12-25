using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class getData : System.Web.UI.Page
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
        if (!this.IsPostBack)
        {
            ddlMchNo.Items.Add("All");
            ddlMchNo.AppendDataBoundItems = true;
            DataSet ds = da.selectMachineAll();

            ddlMchNo.DataSource = ds;
            this.ddlMchNo.DataTextField = "Description";
            this.ddlMchNo.DataValueField = "ID";

            ddlMchNo.DataBind();

        }
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        lblMSG.Text = "";
        try
        {

            if (ddlMchNo.SelectedItem.Text == "All")
            {

                lblMSG.Text = "";
                lblMSG1.Text = "";
                string error = "";
                DataSet ds = da.selectMachineAll();
                DataTable dt = new DataTable();
                DataTable dtN = new DataTable();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                    WebService sample = new WebService();
                    //  ATT.localhost.Service sample = new ATT.localhost.Service();
                    dt = sample.getData(int.Parse(ds.Tables[0].Rows[i][1].ToString()), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());
                    if (dt.Rows.Count == 0)
                    {
                        error = error + ",Machine_No-" + ds.Tables[0].Rows[i][1].ToString() + "-is not connected";
                    }
                    dtN.Merge(dt);

                }
                lblMSG.Text = error;
                DataTable dtS = da.saveData(dtN);
                lblMSG1.Text = dtS.Rows.Count.ToString() + " Rows Successfully Saved!!!!!";
            }
            else
            {
                lblMSG.Text = "";
                lblMSG1.Text = "";
                string error = "";
                DataSet ds = da.selectMachinebyID(Int32.Parse(ddlMchNo.SelectedValue));
                DataTable dt = new DataTable();
                DataTable dtN = new DataTable();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    WebService sample = new WebService();
                    //  ATT.localhost.Service sample = new ATT.localhost.Service();
                    dt = sample.getData(int.Parse(ds.Tables[0].Rows[i][1].ToString()), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());
                    if (dt.Rows.Count == 0)
                    {
                        error = error + ",Machine_Name-" + ds.Tables[0].Rows[i][4].ToString() + "-is not connected";
                    }
                    dtN.Merge(dt);

                }
                lblMSG.Text = error;
                DataTable dtS = da.saveData(dtN);
                lblMSG1.Text = dtS.Rows.Count.ToString() + " Rows Successfully Saved!!!!!";


            }


        }
        catch (Exception ex)
        {
            lblMSG.Text = "Error:" + ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;

        }
    }

    protected void ddlMchNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMSG.Text = "";
        lblMSG1.Text = "";
    }









}