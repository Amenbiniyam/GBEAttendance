using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeForm : System.Web.UI.Page
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
        DataSet ds = da.selectMenu("sam");


        //DataTable dt = new DataTable();
        //dt.Columns.Add("Date");
        //dt.Columns.Add("link");
        
       

        //DataRow row = dt.NewRow();
        //row["Date"] = "Company Information";
        //row["link"] = "~/CompanyHome.aspx";
        //dt.Rows.Add(row);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {


            Menu1.Items.Add(new MenuItem(ds.Tables[0].Rows[i][0].ToString(), "", "", ds.Tables[0].Rows[i][2].ToString()));
        }
           
    }
}