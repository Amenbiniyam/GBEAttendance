using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class EmpLeaveBalance: System.Web.UI.Page
    {
        AttDAL DA = new AttDAL();
        LeaveDAL DAL = new LeaveDAL();
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

                selectLeave();
                


            }
        }
       


       

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentHome.aspx");
        }

      


       
       

        protected void Button4_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {
               

            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void selectLeave()
        {
            try
            {

                lblMSG.Text = "";
                MainDAL daM = new MainDAL();
                DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());
                DataSet dsL = DAL.AllLeaveTypeALBAL(empId);
                //ddlLeave.Items.Clear();
                //ddlLeave.Items.Add("---");
                //ddlLeave.AppendDataBoundItems = true;
                ddlLeave.DataSource = dsL;
                this.ddlLeave.DataTextField = "Name";
                this.ddlLeave.DataValueField = "Id";
                ddlLeave.DataBind();
                DataSet dsDays = DAL.selectDays(empId);
               

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

        





        protected void ddlCons_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void fillBAl()
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            MainDAL daM = new MainDAL();
            DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());   
            DataSet ds = DAL.selectEmployeeLevaeBalTYpe(empId,ddlLeave.SelectedItem.ToString());
          
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataSet dsIn=DAL.INLeaveType(ddlLeave.SelectedItem.ToString());
                DataSet dsLWP = DAL.sumLWP(empId);
                if (dsIn.Tables[0].Rows.Count > 0)
                {
                    double INV = double.Parse(dsIn.Tables[0].Rows[0][0].ToString());
                    double SLWP = 0;
                  
                        string SLW = dsLWP.Tables[0].Rows[0][0].ToString();
                        if (SLW != "")
                        {
                            SLWP = double.Parse(SLW);
                        }
                   
                    TimeSpan timeSpan = DateTime.Now - Convert.ToDateTime(ds.Tables[0].Rows[0][5]);
                    //TimeSpan tmeeSpan1 = DateTime.Now - DateTime.Now.AddYears(-18);
                    double WD = timeSpan.Days;
                    WD = WD - SLWP;
                    DataSet DSHDAte=DAL.empHDAte(empId);
                    DateTime DHired = DateTime.Parse(DSHDAte.Tables[0].Rows[0][0].ToString());
                    TimeSpan LEC = DateTime.Parse(txtStartDate.Text) - DHired;
                    DateTime setDate = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
                    TimeSpan LEC1 = setDate - DHired;
                    double leaveEnti = 0;
                    DataSet leaveEnta = DA.selectLeaveEntitlement(empId);
                    if (leaveEnta.Tables[0].Rows.Count > 0)
                    {
                        leaveEnti = double.Parse(leaveEnta.Tables[0].Rows[0][0].ToString());
                    }
             
                    double LE = LEC.Days;
                    double LE1 = LEC1.Days;

                    double LECount = leaveEnti;
                    double LECount1 = leaveEnti;

                    double caBal=0;
                    double caBal1 = 0;
                    while (LE > 0)
                    {
                        if(LE > 730)
                        {
                          caBal=caBal+LECount;
                          LECount = LECount + INV;
                          if (LECount > 35)
                          {
                              LECount = 35;
                          }
                          LE = LE - 730;

                        }
                        else
                        {
                            if (LECount > 35)
                            {
                                LECount = 35;
                            }
                            caBal=caBal+((LE * LECount) / 365);
                            LE = LE - 730;
                        }
                        
                       
                    }
                    while (LE1 > 0)
                    {
                        if (LE1 > 730)
                        {
                            caBal1 = caBal1 + LECount1;
                            LECount1 = LECount1 + INV;
                            if (LECount1 > 35)
                            {
                                LECount1 = 35;
                            }
                            LE1 = LE1 - 730;

                        }
                        else
                        {
                            if (LECount1 > 35)
                            {
                                LECount1 = 35;
                            }
                            caBal1 = caBal1 + ((LE1 * LECount1) / 365);
                            LE1 = LE1 - 730;
                        }


                    }



                    double taken = 0;
                    double untaken = 0;
                    double bal =(caBal-caBal1)+(double.Parse(ds.Tables[0].Rows[0][4].ToString())) ;


                    DataSet dsLR = DAL.sumLeaveBal(empId, int.Parse(ddlLeave.SelectedValue.ToString()), "Authorized", DateTime.Parse(txtStartDate.Text));
                    ds.Tables[0].Columns.Add("LeaveTaken");
                    string tak = dsLR.Tables[0].Rows[0][0].ToString();

                   // DataSet dsLRU = DAL.sumLeave(empId, int.Parse(ddlLeave.SelectedValue.ToString()), "Unauthorized");
                    //ds.Tables[0].Columns.Add("Leave Entitlement");
                   // string takU = dsLRU.Tables[0].Rows[0][0].ToString();

                    if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                    {
                        taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                    }

                    //if (dsLRU.Tables[0].Rows.Count != 0 && takU != "")
                    //{
                    //    untaken = double.Parse(dsLRU.Tables[0].Rows[0][0].ToString());

                    //}

                    ds.Tables[0].Rows[0][5] = DateTime.Parse(txtStartDate.Text).ToString("dd-MMM-yyyy");
                    bal = bal - taken;
                    ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                    ds.Tables[0].Rows[0][7] = taken.ToString();
                    ds.Tables[0].Rows[0][6] = (LECount - leaveEnti) + leaveEnti;
                    grvDetail.DataSource = ds;
                    grvDetail.DataBind();
                    grvDetail.Visible = true;
                    
                }
                else
                {
                   
                }
            }
            else
            {
                DataSet dsTaken = DAL.selectEmpTakenTYpe(empId, ddlLeave.SelectedItem.ToString());
                grvDetail.DataSource = dsTaken;
                grvDetail.DataBind();
            
            }


            //butSave.Visible = true;
            //Panel3.Visible = false;
        }
     
        protected void butView_Click(object sender, ImageClickEventArgs e)
        {
            lblMSG.Text = "";
            lblMSG.ForeColor = System.Drawing.Color.White;
            try
            {

                DateTime date = DateTime.Parse(txtStartDate.Text);

                if(date<DateTime.Parse("01-Jan-2016"))
                {
                    lblMSG.Text = "Error:Date must be greater than Dec 31/2015";
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
            fillBAl();
                }
           
                       
                                                                          

                }

                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
            }

        
        }
        




