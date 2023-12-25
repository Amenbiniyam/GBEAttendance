using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace AttendanceAndLeaveManagementSystem
{
    public partial class NewUser2 : System.Web.UI.Page
    {

        MainDAL da = new MainDAL();
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
            mesgPN.BackColor = System.Drawing.Color.White;
            try
            {
                da.saveUser(txtUserId.Text.ToLower(), txtConPassword.Text,Int32.Parse(ddlRole.SelectedValue),Int32.Parse(txtEmpId.Text),txtEmail.Text);
               
               // string userName = Session["userId"].ToString();
              //  da.saveUserLog(userName, "save User", txtUserId.Text, DateTime.Now);
                da.saveUserLog(Session["userId"].ToString(), "Save New USer", txtUserId.Text.ToLower(), DateTime.Now);
                GridView2.DataBind();
                mesgPN.BackColor = System.Drawing.Color.LightGreen;
                lblMSG.Text = "User Information Saved Successfully !!!!";
                lblMSG.ForeColor = System.Drawing.Color.DarkGreen;
               

            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate User Id";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate EMP ID";
                }
                else if (exM.StartsWith("The INSERT statement conflicted with the FOREIGN KEY") == true)
                {
                    lblMSG.Text = "Error:" + "EMP-ID not exist";
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
            Response.Redirect("NewUser.aspx");
        }

        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

               int Id = Int32.Parse(row.Cells[0].Text);
               lblID.Text = Id.ToString();
               txtUserId.Text = row.Cells[1].Text;
               txtEmpId.Text = row.Cells[3].Text;
               txtEmail.Text = row.Cells[3].Text;
               txtEmail.Text = row.Cells[4].Text;
              // ddlRole.SelectedItem.Value = row.Cells[2].Text;

               ddlRole.SelectedIndex = ddlRole.Items.IndexOf(ddlRole.Items.FindByText(row.Cells[2].Text));


               //txtDAte.Text = row.Cells[2].Text;
              // radCycle.SelectedItem.Selected=;
             
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
                    da.deleteUser(Int32.Parse(row.Cells[0].Text));
                    da.saveUserLog(Session["userId"].ToString(), "Delete USer", row.Cells[0].Text, DateTime.Now);
                    Response.Redirect("NewUser.aspx");
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
            Response.Redirect("NewUser.aspx");
        }






        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void butUpdate_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            try
            {
                da.updateUser(txtUserId.Text,txtPassword.Text,Int32.Parse(ddlRole.SelectedValue),Int32.Parse(txtEmpId.Text),Int32.Parse(lblID.Text),txtEmail.Text);
                da.saveUserLog(Session["userId"].ToString(), "USer Update", txtUserId.Text, DateTime.Now);
                Response.Redirect("NewUser.aspx");
            }
            catch (Exception ex)
            {
                mesgPN.BackColor = System.Drawing.Color.LightPink;
                string exM = ex.Message;
                if (exM.StartsWith("Violation of PRIMARY KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate User Id";
                }
                else if (exM.StartsWith("Violation of UNIQUE KEY") == true)
                {
                    lblMSG.Text = "Error:" + "Duplicate EMP ID";
                }
                else if (exM.StartsWith("The INSERT statement conflicted with the FOREIGN KEY") == true)
                {
                    lblMSG.Text = "Error:" + "EMP-ID not exist";
                }


                else
                {
                    lblMSG.Text = "Error:" + ex.Message;
                }
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;

            }
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
                int k = txtName.Text.IndexOf(" ");
                string FName = txtName.Text.Substring(k+1, 1);
                string NAme = txtName.Text.Substring(0, k);
                txtUserId.Text = NAme + FName;
                int dr = txtName.Text.IndexOf("=");
                int id = Int32.Parse(txtName.Text.Substring(++dr));
                txtEmpId.Text = id.ToString();

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridView1.Visible = true;
            try
            {

                int dr = TextBox1.Text.IndexOf("=");
                int id = Int32.Parse(TextBox1.Text.Substring(++dr));
                DataSet Ds=da.UserData(id);
                GridView1.DataSource = Ds;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
        }
}
}
