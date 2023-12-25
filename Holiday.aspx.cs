using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Holiday : System.Web.UI.Page
{
       HolidayDAL DA = new HolidayDAL();
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
                butSave.Visible = true;
                Panel3.Visible = false;
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                string dayTYpe = "Fullday";
                if (ddlWorkDAy.SelectedItem.Text == "0.5")
                {
                    dayTYpe = ddlDayType.SelectedItem.Text;
                }

                DA.InsertHoliday(txtNAme.Text, DateTime.Parse(txtDAte.Text), txtDesc.Text, radCycle.SelectedValue, ddlWorkDAy.SelectedItem.Text, dayTYpe);

                    // string autNAme = Session["userId"].ToString();
                   //  DA.InsertEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text);

                    ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                DA.saveUserLog(Session["userId"].ToString(), "New Holiday", txtNAme.Text, DateTime.Now);
                Response.Redirect("Holiday.aspx");
                    //string userName = Session["userId"].ToString();
                  //  DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
               
         

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Holiday.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

                int Id = Int32.Parse(row.Cells[0].Text);
                lblID.Text = Id.ToString();
               
               txtNAme.Text = row.Cells[1].Text;
               txtDesc.Text = row.Cells[3].Text.ToString().Replace("&nbsp;", ""); ;
               txtDAte.Text = row.Cells[2].Text;
              // radCycle.SelectedItem.Selected=;
               radCycle.Items.FindByText(row.Cells[4].Text).Selected = true;
            //  ddlType.Items.FindByText(row.Cells[5].Text).Selected = true;

               if (row.Cells[5].Text == "1.0")
               {
                   ddlWorkDAy.Items.Clear();
                   ddlWorkDAy.Items.Add("1.0");
                   ddlWorkDAy.Items.Add("0.5");
                   lblDayType.Visible = false;
                   ddlDayType.Visible = false;

               }
               else
               {
                   ddlWorkDAy.Items.Clear();
                   ddlWorkDAy.Items.Add("0.5");
                   ddlWorkDAy.Items.Add("1.0");
                   lblDayType.Visible = true;
                   ddlDayType.Visible = true;
                   if (row.Cells[6].Text == "Morning")
                   {
                                       
                       ddlDayType.Items.Clear();
                       ddlDayType.Items.Add("Morning");
                       ddlDayType.Items.Add("Afternoon");
                      
                   }
                   else
                   {
                       ddlDayType.Items.Clear();
                       ddlDayType.Items.Add("Afternoon");
                       ddlDayType.Items.Add("Morning");
                       
                   
                   }


               }

               butSave.Visible = false;
               Panel3.Visible = true;
                //   txtCustomerID.ReadOnly = true;
               // Response.Redirect("Holiday.aspx");
                //popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                try
                {
                    DA.deleteHoliday(Int32.Parse(row.Cells[0].Text));
                    DA.saveUserLog(Session["userId"].ToString(), "Delete Holiday", txtNAme.Text, DateTime.Now);
                    Response.Redirect("Holiday.aspx");
                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                string dayTYpe = "Fullday";
                if (ddlWorkDAy.SelectedItem.Text == "0.5")
                {
                    dayTYpe = ddlDayType.SelectedItem.Text;
                }

                DA.updateHoliday(Int32.Parse(lblID.Text), txtNAme.Text, DateTime.Parse(txtDAte.Text), txtDesc.Text, radCycle.SelectedValue, ddlWorkDAy.SelectedItem.Text, dayTYpe);

                DA.saveUserLog(Session["userId"].ToString(), "Update Holiday", txtNAme.Text, DateTime.Now);
                Response.Redirect("Holiday.aspx");
               


            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Holiday.aspx");
        }






        protected void radCycle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlWorkDAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWorkDAy.SelectedItem.Text == "0.5")
            {
                lblDayType.Visible = true;
                ddlDayType.Visible = true;
            }
            else
            {
                lblDayType.Visible = false;
                ddlDayType.Visible = false;
            }
        }
}
