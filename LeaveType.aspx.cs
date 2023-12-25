using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace AttendanceAndLeaveManagementSystem
{
    public partial class LeaveType : System.Web.UI.Page
    {
       
        LeaveDAL da=new LeaveDAL();
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


                da.InsertLeaveType(txtNAme.Text,txtMaxAmount.Text,radCycle.SelectedItem.Text,txtIncValue.Text,ddlCons.SelectedItem.Text,ddlALAcc.SelectedItem.Text,ddlSickLeave.SelectedItem.Text);
             //   DA.InsertHoliday(txtNAme.Text,DateTime.Parse(txtDAte.Text),txtMaxAmount.Text,radCycle.SelectedValue,ddlCons.SelectedItem.Text);

                    // string autNAme = Session["userId"].ToString();
                   //  DA.InsertEmployee(txtEmpId.Text, txtFName.Text, txtMiddleName.Text, txtLastName.Text, radGender.SelectedItem.Text, DateTime.Parse(txtDOB.Text), Int32.Parse(ddlPosition.SelectedValue), txtTele.Text, txtAddress.Text, txtMobNo.Text, path, DateTime.Parse(txtHiredDate.Text), ddlEmploymentType.SelectedItem.Text, txtEndDate.Text);

                    ////DA.InsertDepartment(txtDepartmentName.Text,txtDescription.Text,Int32.Parse(lblParID.Text));
                da.saveUserLog(Session["userId"].ToString(), "Save Leave TYpe", "", DateTime.Now);
      
                Response.Redirect("LeaveType.aspx");
                    //string userName = Session["userId"].ToString();
                    //DA.saveUserLog(userName, "New Application Saved", id + 1.ToString(), DateTime.Now);
               

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else
                {
                    lblMSG.Text = "Error:" + ex.Message;
                }
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveType.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

                int Id = Int32.Parse(row.Cells[0].Text);
                lblID.Text = Id.ToString();
               txtNAme.Text = row.Cells[1].Text;
               txtMaxAmount.Text = row.Cells[2].Text.ToString().Replace("&nbsp;", "");
               //txtDAte.Text = row.Cells[2].Text;
              // radCycle.SelectedItem.Selected=;
               radCycle.ClearSelection();
               radCycle.Items.FindByText(row.Cells[3].Text).Selected = true;
               txtIncValue.Text = row.Cells[4].Text.ToString().Replace("&nbsp;", "");
            //  ddlType.Items.FindByText(row.Cells[5].Text).Selected = true;

               if (row.Cells[5].Text == "Yes")
               {
                   ddlCons.Items.Clear();
                   ddlCons.Items.Add("Yes");
                   ddlCons.Items.Add("No");

               }
               else
               {
                   ddlCons.Items.Clear();
                   ddlCons.Items.Add("No");
                   ddlCons.Items.Add("Yes");

               }
               if (row.Cells[6].Text == "Yes")
               {
                   ddlALAcc.Items.Clear();
                   ddlALAcc.Items.Add("Yes");
                   ddlALAcc.Items.Add("No");

               }
               else
               {
                   ddlALAcc.Items.Clear();
                   ddlALAcc.Items.Add("No");
                   ddlALAcc.Items.Add("Yes");

               }
               if (row.Cells[7].Text == "Yes")
               {
                   ddlSickLeave.Items.Clear();
                   ddlSickLeave.Items.Add("Yes");
                   ddlSickLeave.Items.Add("No");

               }
               else
               {
                   ddlSickLeave.Items.Clear();
                   ddlSickLeave.Items.Add("No");
                   ddlSickLeave.Items.Add("Yes");

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
                    da.deleteLeaveType(Int32.Parse(row.Cells[0].Text));
                    da.saveUserLog(Session["userId"].ToString(), "Leave TYpe", "", DateTime.Now);
                    Response.Redirect("LeaveType.aspx");
                }
                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

    
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeaveType.aspx");
        }






        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                da.updateLeaveType(Int32.Parse(lblID.Text),txtNAme.Text,txtMaxAmount.Text,radCycle.SelectedItem.Text,txtIncValue.Text,ddlCons.SelectedItem.Text,ddlALAcc.SelectedItem.Text,ddlSickLeave.SelectedItem.Text);
                da.saveUserLog(Session["userId"].ToString(), "Update Leave TYpe", "", DateTime.Now);
                Response.Redirect("LeaveType.aspx");
            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate Leav Type Name";
                }
                else
                {
                    lblMSG.Text = "Error:" + ex.Message;
                }
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }
}
}
