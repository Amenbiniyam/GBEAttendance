using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack == false)
        {
            if ((Request.UserAgent.IndexOf("AppleWebKit") > 0) || (Request.UserAgent.IndexOf("Unknown") > 0) || (Request.UserAgent.IndexOf("Chrome") > 0))
            {
                Request.Browser.Adapters.Clear();
            }


            string k = "1";
            string userID = "sam";
            DataSet emp = da.selectEmpIDUser("sam");
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
            DataSet dsNAme = da.selectFullNAme(empId);
            // lblFullNAme.Text = dsNAme.Tables[0].Rows[0][0].ToString();
            DataSet ds = da.selectMenu(k);


          

            //HtmlGenericControl liN = new HtmlGenericControl("li");
            //menu.Controls.Add(liN);
            //liN.Attributes.Add("class", "treeview");

            //HtmlGenericControl anchornN = new HtmlGenericControl("a");
            //anchornN.Attributes.Add("href", "#");
            //anchornN.InnerText = "PLease God";
            //liN.Controls.Add(anchornN);

            //HtmlGenericControl ipk = new HtmlGenericControl("i");
            //ipk.Attributes.Add("class", "fa fa-angle-left pull-right");
            //anchornN.Controls.Add(ipk);

            //HtmlGenericControl UL = new HtmlGenericControl("ul");
            //UL.Attributes.Add("class", "treeview-menu");
            //liN.Controls.Add(UL);

            //HtmlGenericControl liN1 = new HtmlGenericControl("li");
            //UL.Controls.Add(liN1);
              
           

            //HtmlGenericControl anchornN1 = new HtmlGenericControl("a");
            //anchornN1.Attributes.Add("href", "index.html");
            //anchornN1.Attributes.Add("class", "fa fa-circle-o");
            //anchornN1.InnerText = "  "+"Please God";
            //liN1.Controls.Add(anchornN1);



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




                //HtmlGenericControl li = new HtmlGenericControl("li");
                //menu.Controls.Add(li);


                //HtmlGenericControl anchorn = new HtmlGenericControl("a");
                //anchorn.Attributes.Add("href", "");
                //anchorn.InnerText = ds.Tables[0].Rows[i][0].ToString();
                //li.Controls.Add(anchorn);


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

                    //HtmlGenericControl UL = new HtmlGenericControl("UL");
                    //// UL.InnerText = "samuel";
                    //li.Controls.Add(UL);



                    //HtmlGenericControl li2 = new HtmlGenericControl("li");
                    //UL.Attributes.Add("class", " fa fa-circle-o");
                    //UL.Controls.Add(li2);



                    //HtmlGenericControl anchor = new HtmlGenericControl("a");
                    //anchor.Attributes.Add("href", dsC.Tables[0].Rows[j][4].ToString());
                    //anchor.InnerText = dsC.Tables[0].Rows[j][1].ToString();



                    //li2.Controls.Add(anchor);



                    // Menu1.Items[i].ChildItems.Add(new MenuItem(dsC.Tables[0].Rows[j][1].ToString(), "", "", dsC.Tables[0].Rows[j][4].ToString()));

                }










                //HtmlGenericControl UL = new HtmlGenericControl("UL");
                //// UL.InnerText = "samuel";
                //li.Controls.Add(UL);



                //HtmlGenericControl li2 = new HtmlGenericControl("li");
                //UL.Controls.Add(li2);

                //HtmlGenericControl li3 = new HtmlGenericControl("li");
                //UL.Controls.Add(li3);

                //HtmlGenericControl anchor = new HtmlGenericControl("a");
                //anchor.Attributes.Add("href", "AttReport.aspx");
                //anchor.InnerText = "Att Report";

                //HtmlGenericControl anchor1 = new HtmlGenericControl("a");
                //anchor1.Attributes.Add("href", "page.htm");
                //anchor1.InnerText = "TabX1";

                //li3.Controls.Add(anchor);
                //li2.Controls.Add(anchor1);

            }


        }
           
    }
}
