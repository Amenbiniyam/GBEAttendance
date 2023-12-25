using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeTimetableEdit : System.Web.UI.Page
{
   
        HolidayDAL DA = new HolidayDAL();

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
                fillData();

            }
        }
        public void fillData()
        {


            txtFullName.Text = Session["empNameT"].ToString();
            lblParID.Text = Session["empIdT"].ToString();
            //  DataSet ds = DA.selectTimeTableEmployee(lblParID.Text);

            //    radGender.Items.FindByText(ds.Tables[0].Rows[0][4].ToString()).Selected = true;
            // .SelectedItem.Text = ds.Tables[0].Rows[0][4].ToString();


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                if (txtEndDate.Text != "")
                {
                    if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                    {
                        lblMSG.Text = "Error:" + " start date must be earlier than End date ";
                        lblMSG.ForeColor = System.Drawing.Color.Red;
                    }
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
            Response.Redirect("EmployeeTimetableHome.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

                //int Id = Int32.Parse(row.Cells[0].Text);
                lblId.Text = row.Cells[0].Text;

                // Session["CompanyName"].ToString().Replace("&nbsp;", "");

                txtHiredDate.Text = row.Cells[2].Text;
                txtEndDate.Text = row.Cells[3].Text.Replace("&nbsp;", "");

                //  ddlType.Items.FindByText(row.Cells[5].Text).Selected = true;

                if (row.Cells[4].Text == "And")
                {
                    ddlType.Items.Clear();
                    ddlType.Items.Add("And");
                    ddlType.Items.Add("Or");

                }
                else
                {
                    ddlType.Items.Clear();
                    ddlType.Items.Add("Or");
                    ddlType.Items.Add("And");

                }
                if (row.Cells[5].Text == "Yes")
                {
                    ddlFP.Items.Clear();
                    ddlFP.Items.Add("Yes");
                    ddlFP.Items.Add("No");

                }
                else
                {
                    ddlFP.Items.Clear();
                    ddlFP.Items.Add("No");
                    ddlFP.Items.Add("Yes");

                }
                butUpdate.Enabled = true;

                // Response.Redirect("Holiday.aspx");
                //popup.Show();
            }
        }
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                //txtComNameDelete.Text = row.Cells[1].Text;
                //lblDelID.Text = row.Cells[0].Text;

                ////   txtCustomerID.ReadOnly = true;

                //popupDelete.Show();

                DA.deleteTimeTablesEmp(int.Parse(row.Cells[0].Text));
                DA.saveUserLog(Session["userId"].ToString(), "Time Table Delete", row.Cells[0].Text, DateTime.Now);
                Response.Redirect("EmployeeTimetableEdit.aspx");
            }
        }


        protected void butUpdate_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                if (txtEndDate.Text != "")
                {
                    if (DateTime.Parse(txtHiredDate.Text) >= DateTime.Parse(txtEndDate.Text))
                    {
                        lblMSG.Text = "Error:" + " start date must be earlier than End date ";
                        lblMSG.ForeColor = System.Drawing.Color.Red;
                    }
                }
                DA.updateTimeTablesEmp(int.Parse(lblId.Text), DateTime.Parse(txtHiredDate.Text), txtEndDate.Text, ddlType.SelectedItem.Text,ddlFP.SelectedItem.Text);
                GridView2.DataBind();
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                lblMSG.Text = "Employee/TimeTable Information Updated Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                DA.saveUserLog(Session["userId"].ToString(), "Time Table Edite",lblId.Text, DateTime.Now);
         
                
            }

            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;
            }





        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                //DA.deleteTimeTablesEmp(int.Parse(lblDelID.Text));
                //Response.Redirect("EmployeeTimetableEdit.aspx");
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
    }
