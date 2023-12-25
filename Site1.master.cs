using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Site1 : System.Web.UI.MasterPage
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!this.IsPostBack)
         {
            if ((Request.UserAgent.IndexOf("AppleWebKit") > 0) || (Request.UserAgent.IndexOf("Unknown") > 0) || (Request.UserAgent.IndexOf("Chrome") > 0))
            {
                Request.Browser.Adapters.Clear();
            }


            string k = Session["role"].ToString();
            string userID = Session["userId"].ToString();
            DataSet emp = da.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
            DataSet dsNAme = da.selectFullNAme(empId);
            lblFullNAme.Text = dsNAme.Tables[0].Rows[0][0].ToString();
            DataSet ds = da.selectMenu(k);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                HtmlGenericControl liN = new HtmlGenericControl("li");
                menu.Controls.Add(liN);
                liN.Attributes.Add("class", "treeview");

                HtmlGenericControl anchornN = new HtmlGenericControl("a");
                anchornN.Attributes.Add("href", "#");
                anchornN.InnerText = ds.Tables[0].Rows[i][0].ToString();
                liN.Controls.Add(anchornN);

                HtmlGenericControl ipk = new HtmlGenericControl("i");
                ipk.Attributes.Add("class", "fa fa-angle-left pull-right");
                anchornN.Controls.Add(ipk);
                DataSet dsC = da.selectMenuChild(k, ds.Tables[0].Rows[i][0].ToString());
                if (dsC.Tables[0].Rows.Count > 1)
                {
                    //  li.Attributes.Add("class", "fa fa-angle-left pull-right");
                }

                for (int j = 0; j < dsC.Tables[0].Rows.Count; j++)
                {
                    HtmlGenericControl UL = new HtmlGenericControl("ul");
                    UL.Attributes.Add("class", "treeview-menu");
                    liN.Controls.Add(UL);

                    HtmlGenericControl liN1 = new HtmlGenericControl("li");
                    UL.Controls.Add(liN1);



                    HtmlGenericControl anchornN1 = new HtmlGenericControl("a");
                    anchornN1.Attributes.Add("href", dsC.Tables[0].Rows[j][4].ToString());
                    anchornN1.Attributes.Add("class", "fa fa-circle-o");
                    anchornN1.InnerText = "  " + dsC.Tables[0].Rows[j][1].ToString();
                    liN1.Controls.Add(anchornN1);

                }
            }

            
            //select * from viewMenuRole 
            //select DISTINCT parnt from viewMenuRole where RoleId='2'

            //select * from viewMenuRole where RoleId='2' and parnt='Report'
            
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    Menu1.Items.Add(new MenuItem(ds.Tables[0].Rows[i][0].ToString()));
                //    DataSet dsC=da.selectMenuChild(k,ds.Tables[0].Rows[i][0].ToString());
                //    for(int j=0;j<dsC.Tables[0].Rows.Count;j++)
                //    {
                //       Menu1.Items[i].ChildItems.Add(new MenuItem(dsC.Tables[0].Rows[j][1].ToString(), "", "", dsC.Tables[0].Rows[j][4].ToString()));
                    
                //    }

                //}



            }
        
           
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["userId"] = null;
        Response.Redirect("Login.aspx");
    }
}
