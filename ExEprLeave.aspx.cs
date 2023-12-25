using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExEprLeave : System.Web.UI.Page
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
                butSave.Visible = true;
             //   Panel3.Visible = false;
              
            }
        }

      
        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {

                da.saveExpLeave(int.Parse(txtEmpId.Text));
             
             //   DA.InsertHoliday(txtNAme.Text,DateTime.Parse(txtDAte.Text),txtDesc.Text,radCycle.SelectedValue,ddlType.SelectedItem.Text);

                    // string autNAme = Session["userId"].ToString();
                   //  DA.InsertEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text);

                    ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                lblMSG.Text = "Employee Information Saved Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
                GridView1.DataBind();
                    //string userName = Session["userId"].ToString();
                    //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
               

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                //if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                //{
                //    lblMSG.Text = "Error:" + "Duplicate Employee/Schedule";
                //}
                //else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                //{
                //    lblMSG.Text = "Error:" + "Duplicate Employee/Schedule";
                //}
                //else
                //{
                    lblMSG.Text = "Error:" + ex.Message;
                //}
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Machine.aspx");
        }

       
        protected void Delete(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                //txtComNameDelete.Text = row.Cells[1].Text;
                //lblDelID.Text = row.Cells[0].Text;
            
                ////   txtCustomerID.ReadOnly = true;

                //popupDelete.Show();
                da.deleteExpLeave(Int32.Parse(row.Cells[0].Text));
                GridView1.DataBind();


            }
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
              
               // Response.Redirect("Machine.aspx");
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
            Response.Redirect("Machine.aspx");
        }

    

    

 

      }
