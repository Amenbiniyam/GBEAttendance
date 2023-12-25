using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

    public partial class LeaveRequest : System.Web.UI.Page
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
                DataSet ds = DA.selectDepTreeAll();
                DataTable dt = ds.Tables[0];
                PopulateMenuDataTable(dt);

               


            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            try
            {

                if (ddlEmp.SelectedItem.Text == "--Select Department--" || ddlEmp.SelectedItem.Text == "---")
                {
                    lblMSG.Text = "Error:" + "Please Select Employee";
                    lblMSG.ForeColor = System.Drawing.Color.Red;

                }
                else
                {
                    MainDAL daM = new MainDAL();
                    DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
                    int empId = Int32.Parse(emp.Tables[0].Rows[0][0].ToString());  
                    using (TransactionScope ts = new TransactionScope())
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Date");
                        dt.Columns.Add("Day");
                        dt.Columns.Add("Type");


                        foreach (GridViewRow row in grvView.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                                if (chkRow.Checked)
                                {

                                    DataRow row1 = dt.NewRow();
                                    row1["Date"] = row.Cells[1].Text;
                                    row1["Day"] = row.Cells[2].Text; ;
                                    row1["Type"] = row.Cells[3].Text; ;
                                    dt.Rows.Add(row1);

                                }
                            }
                        }
                        int count = dt.Rows.Count;
                        DateTime endDAte = DateTime.Parse(dt.Rows[count - 1][0].ToString());
                        int i = 0;
                        double days = 0;
                        while (i < count)
                        {
                            days = days + double.Parse(dt.Rows[i][1].ToString());
                            i++;
                        }

                        double bal = 0;
                        if (Int32.Parse(ddlLeave.SelectedValue) == 13)
                        {
                            bal = Convert.ToDouble(lblBal.Text);
                        }

                        DAL.InsertLeaveRequestsISS(Int32.Parse(ddlEmp.SelectedValue), DateTime.Parse(txtStartDate.Text), endDAte, days, Int32.Parse(ddlLeave.SelectedValue), "Authorized", empId, bal, days,"Leave Issue");
                        DataSet ds = DAL.maxLeaveRequest();
                        int leReId = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                        int j = 0;
                        while (j < count)
                        {
                            DAL.InsertLeaveRequestsDetail(Int32.Parse(ddlEmp.SelectedValue), leReId, DateTime.Parse(dt.Rows[j][0].ToString()), double.Parse(dt.Rows[j][1].ToString()), dt.Rows[j][2].ToString(), "Authorized");
                            j++;
                        }
                        if (Int32.Parse(ddlLeave.SelectedValue) == 13)
                        {
                            fillBAlAL();
                        }
                        else
                        {

                            fillBAl();
                        }
                        DA.saveUserLog(Session["userId"].ToString(), "Leave ISsue", ddlEmp.SelectedItem.Text, DateTime.Now);
                        //DAL.InsertLeaveSetting(Int32.Parse(ddlEmp.SelectedValue),Int32.Parse(ddlLeave.SelectedValue),double.Parse(txtJump.Text),DateTime.Parse(txtStartDate.Text));
                       // fillBAl();

                        ts.Complete();
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
            Response.Redirect("DepartmentHome.aspx");
        }

        private void PopulateMenuDataTable(DataTable dt)
        {
            treeDepa.CollapseAll();
            CreateTreeViewDataTable(dt, 0, null);
        }



        private void CreateTreeViewDataTable(DataTable dt, int parentID, TreeNode parentNode)
        {
            DataRow[] drs = dt.Select("Department_Id = " + parentID.ToString());
            foreach (DataRow i in drs)
            {
                TreeNode newNode = new TreeNode(i["DepartmentName"].ToString(), i["Id"].ToString());
                if (parentNode == null)
                {
                    treeDepa.Nodes.Add(newNode);
                }
                else
                {
                    parentNode.ChildNodes.Add(newNode);
                }
                CreateTreeViewDataTable(dt, Convert.ToInt32(i["Id"]), newNode);
            }
            treeDepa.CollapseAll();
        }

        protected void treeDepa_SelectedNodeChanged(object sender, EventArgs e)
        {
           
            lblParID.Text = treeDepa.SelectedNode.Value.ToString();
            DataSet ds = DA.selectEmployeeDEP(int.Parse(lblParID.Text));
            ddlEmp.Items.Clear();

            ddlEmp.Items.Add("---");
            ddlEmp.AppendDataBoundItems = true;
            ddlEmp.DataSource = ds;
            this.ddlEmp.DataTextField = "Full_Name";
            this.ddlEmp.DataValueField = "EmpId";

            ddlEmp.DataBind();
            ddlLeave.Items.Clear();




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
        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblMSG.Text = "";
                mesgPN.BackColor = System.Drawing.Color.White;

                if (ddlEmp.SelectedItem.Text == "--Select Department--" || ddlEmp.SelectedItem.Text == "---")
                {
                    lblMSG.Text = "Error:" + "Please Select Employee";
                    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                    mesgPN.BackColor = System.Drawing.Color.LightPink;

                }
                else
                {

                    lblMSG.Text = "";
                    DataSet dsL = DAL.AllLeaveTypeEmp(int.Parse(ddlEmp.SelectedValue.ToString()));
                    ddlLeave.Items.Clear();
                    ddlLeave.Items.Add("---");
                    ddlLeave.AppendDataBoundItems = true;
                    ddlLeave.DataSource = dsL;
                    this.ddlLeave.DataTextField = "Name";
                    this.ddlLeave.DataValueField = "Id";
                    ddlLeave.DataBind();

                    DataSet dsDays = DAL.selectDays(int.Parse(ddlEmp.SelectedValue.ToString()));
                    // DataSet dsDays = DAL.selectDays(int.Parse(ddlEmp.SelectedValue.ToString()));
                    if (double.Parse(dsDays.Tables[0].Rows[0][0].ToString()) == 0.5)
                    {
                        ddlDays.Items.Clear();
                        ddlDays.Items.Add("---");
                        ddlDays.Items.Add("0.5");
                        ddlDays.Items.Add("1.0");
                        //ddlDays.AppendDataBoundItems = true;
                        //ddlDays.DataSource = dsDays;
                        //this.ddlDays.DataTextField = "workday";
                        //this.ddlDays.DataValueField = "workday";
                        //ddlDays.DataBind();
                    }
                    else
                    {
                        ddlDays.Items.Clear();
                        ddlDays.Items.Add("1.0");
                    }
                    //DataSet ds = DAL.selectEmployeeLevaeBal(int.Parse(ddlEmp.SelectedValue.ToString()));
                    //GridView1.DataSource = ds;
                    //GridView1.DataBind();
                    //butSave.Visible = true;
                    //Panel3.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void fillGrid()
        {
            DataSet ds = DAL.selectEmployeeLevaeBal(int.Parse(ddlEmp.SelectedValue.ToString()));
            grvDetail.DataSource = ds;
            grvDetail.DataBind();
            grvDetail.Visible = true;
            grvView.Visible = false;
        
        }

       
        protected void Edit(object sender, EventArgs e)
        {
            using (GridViewRow row = (GridViewRow)((ImageButton)sender).Parent.Parent)
            {
                // Company com = new Company();

                int Id = Int32.Parse(row.Cells[0].Text);
                lblID.Text = Id.ToString();
                txtJump.Text = row.Cells[4].Text;
                txtStartDate.Text = row.Cells[5].Text;
                ddlLeave.ClearSelection();
                ddlLeave.Items.FindByText(row.Cells[3].Text).Selected = true;
            
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
                //txtComNameDelete.Text = row.Cells[3].Text;
                //lblDelID.Text = row.Cells[0].Text;
            
                ////   txtCustomerID.ReadOnly = true;

                //popupDelete.Show();
            }
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //DAL.deleteLeaveSetting(Int32.Parse(lblDelID.Text));
                fillGrid();
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
        protected void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               // DAL.updateLeaveSetting(Int32.Parse(lblID.Text),Int32.Parse(ddlEmp.SelectedValue), Int32.Parse(ddlLeave.SelectedValue), double.Parse(txtJump.Text), DateTime.Parse(txtStartDate.Text));
                fillGrid();
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlLeave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(ddlLeave.SelectedValue) == 13)
            {
              //  grveDeatial.Visible = false;
                fillBAlAL();

            }
            else
            {
               // grveDeatial.Visible = false;
                fillBAl();
            }

        }
        public void fillBAl()
        {
            MainDAL daM = new MainDAL();
           // DataSet emp = daM.selectEmpIDUser(Session["userId"].ToString());
            int empId = int.Parse(ddlEmp.SelectedValue.ToString());
            DataSet ds = DAL.selectEmpLevaeBal(empId, ddlLeave.SelectedItem.ToString());

            grvDetail.DataSource = ds;
            grvDetail.DataBind();
            grvDetail.Visible = true;
            // grveDeatial.Visible = true;
            grvView.Visible = false;
            butSave.Visible = false;


        }
        public void fillBAlAL()
        {
            try
            {
                lblMSG.Text = "";
                mesgPN.BackColor = System.Drawing.Color.White;
                DataSet ds = DAL.selectEmployeeLevaeBalTYpe(int.Parse(ddlEmp.SelectedValue.ToString()), ddlLeave.SelectedItem.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet dsIn = DAL.INLeaveType(ddlLeave.SelectedItem.ToString());
                    DataSet dsLWP = DAL.sumLWP(int.Parse(ddlEmp.SelectedValue.ToString()));
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
                        DataSet DSHDAte = DAL.empHDAte(int.Parse(ddlEmp.SelectedValue.ToString()));
                        DateTime DHired = DateTime.Parse(DSHDAte.Tables[0].Rows[0][0].ToString());
                        TimeSpan LEC = DateTime.Now - DHired;
                        DateTime setDate = DateTime.Parse(ds.Tables[0].Rows[0][5].ToString());
                        TimeSpan LEC1 = setDate - DHired;
                        double leaveEnti = 0;
                        DataSet leaveEnta = DA.selectLeaveEntitlement(Int32.Parse(ddlEmp.SelectedValue));
                        if (leaveEnta.Tables[0].Rows.Count > 0)
                        {
                            leaveEnti = double.Parse(leaveEnta.Tables[0].Rows[0][0].ToString());
                        }

                        double LE = LEC.Days;
                        double LE1 = LEC1.Days;

                        double LECount = leaveEnti;
                        double LECount1 = leaveEnti;

                        double caBal = 0;
                        double caBal1 = 0;
                        while (LE > 0)
                        {
                            if (LE > 730)
                            {
                                caBal = caBal + LECount;
                                LECount = LECount + INV;
                                if (LECount > 30)
                                {
                                    LECount = 30;
                                }
                                LE = LE - 730;

                            }
                            else
                            {
                                if (LECount > 30)
                                {
                                    LECount = 30;
                                }
                                caBal = caBal + ((LE * LECount) / 365);
                                LE = LE - 730;
                            }


                        }
                        while (LE1 > 0)
                        {
                            if (LE1 > 730)
                            {
                                caBal1 = caBal1 + LECount1;
                                LECount1 = LECount1 + INV;
                                if (LECount1 > 30)
                                {
                                    LECount1 = 30;
                                }
                                LE1 = LE1 - 730;

                            }
                            else
                            {
                                if (LECount1 > 30)
                                {
                                    LECount1 = 30;
                                }
                                caBal1 = caBal1 + ((LE1 * LECount1) / 365);
                                LE1 = LE1 - 730;
                            }


                        }
                        double taken = 0;
                        double untaken = 0;
                        double bal = (caBal - caBal1) + (double.Parse(ds.Tables[0].Rows[0][4].ToString()));


                        DataSet dsLR = DAL.sumLeave(int.Parse(ddlEmp.SelectedValue.ToString()), int.Parse(ddlLeave.SelectedValue.ToString()), "Authorized");
                        ds.Tables[0].Columns.Add("LeaveTaken");
                        string tak = dsLR.Tables[0].Rows[0][0].ToString();

                        DataSet dsLRU = DAL.sumLeave(int.Parse(ddlEmp.SelectedValue.ToString()), int.Parse(ddlLeave.SelectedValue.ToString()), "Unauthorized");
                        ds.Tables[0].Columns.Add("Unauthorized Leave Request ");
                        string takU = dsLRU.Tables[0].Rows[0][0].ToString();

                        if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                        {
                            taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                        }

                        if (dsLRU.Tables[0].Rows.Count != 0 && takU != "")
                        {
                            untaken = double.Parse(dsLRU.Tables[0].Rows[0][0].ToString());

                        }

                        ds.Tables[0].Rows[0][5] = DateTime.Now.ToString("dd-MMM-yyyy");
                        bal = bal - taken;
                        ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                        ds.Tables[0].Rows[0][7] = taken.ToString();
                        ds.Tables[0].Rows[0][8] = untaken.ToString();
                        ds.Tables[0].Rows[0][6] = (LECount - leaveEnti) + leaveEnti;
                        grvDetail.DataSource = ds;
                        grvDetail.DataBind();
                        grvDetail.Visible = true;
                        grvView.Visible = false;
                        butSave.Visible = false;

                        lblBal.Text = Math.Round(bal, 2).ToString();




                        //double taken = 0;
                        //double bal =(caBal-caBal1)+(double.Parse(ds.Tables[0].Rows[0][4].ToString())) ;                


                        //DataSet dsLR = DAL.sumLeave(int.Parse(ddlEmp.SelectedValue.ToString()), int.Parse(ddlLeave.SelectedValue.ToString()));
                        //ds.Tables[0].Columns.Add("LeaveTaken");
                        //string tak = dsLR.Tables[0].Rows[0][0].ToString();
                        //if (dsLR.Tables[0].Rows.Count != 0 && tak != "")
                        //{
                        //    taken = double.Parse(dsLR.Tables[0].Rows[0][0].ToString());

                        //}
                        //ds.Tables[0].Rows[0][5] = DateTime.Now.ToString("dd-MMM-yyyy");
                        //bal = bal - taken;
                        //ds.Tables[0].Rows[0][4] = Math.Round(bal, 2);
                        //ds.Tables[0].Rows[0][6] = taken.ToString();
                        //grvDetail.DataSource = ds;
                        //grvDetail.DataBind();
                        //grvDetail.Visible = true;
                        //grvView.Visible = false;
                        //butSave.Visible = false;
                    }
                    else
                    {

                    }
                }
                else
                {
                    DataSet dsTaken = DAL.selectEmpTakenTYpe(int.Parse(ddlEmp.SelectedValue.ToString()), ddlLeave.SelectedItem.ToString());
                    grvDetail.DataSource = dsTaken;
                    grvDetail.DataBind();

                }
            }
            catch (Exception ex)
            {
                lblMSG.Text = "Error:" + ex.Message;
                lblMSG.ForeColor = System.Drawing.Color.Red;
            }
            //butSave.Visible = true;
            //Panel3.Visible = false;
        }
        protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMSG.Text = "";
            mesgPN.BackColor = System.Drawing.Color.White;
            if (ddlDays.SelectedItem.ToString() == "0.5")
            {
                ddlDateType.Visible = true;
            }
            else
            {
                ddlDateType.Visible = false;
            }

        }
        protected void butView_Click(object sender, ImageClickEventArgs e)
        {

           
            lblMSG.Text="";
            mesgPN.BackColor = System.Drawing.Color.White;
            double count = double.Parse(txtNoDays.Text);
            double dec = Math.Floor(count);
            double diff = count - dec;

            if (ddlEmp.SelectedItem.Text == "--Select Department--" || ddlEmp.SelectedItem.Text =="---")
            {
                lblMSG.Text = "Error:" + "Please Select Employee";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;

            }

            else if (ddlLeave.SelectedItem.Text == "-Select Leave Type-" || ddlLeave.SelectedItem.Text =="---" )
            {
                lblMSG.Text = "Error:" + "Please Select Leave Type";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;

            }
            else if (ddlLeave.SelectedItem.Text == "-Select Leave Type-" || ddlLeave.SelectedItem.Text == "---")
            {
                lblMSG.Text = "Error:" + "Please Select Leave Type";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;

            }
            else if (diff != 0.5 && diff != 0)
            {
                lblMSG.Text = "Error:" + " Decimal Value must be .5 ";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;
            }
            else if (ddlDays.SelectedItem.Text=="---")
            {
                lblMSG.Text = "Error:" + " Please select Days";
                lblMSG.ForeColor = System.Drawing.Color.DarkRed;
                mesgPN.BackColor = System.Drawing.Color.LightPink;
            }
            //else if (diff != 0.5 && diff == 0)
            //{
            //    lblMSG.Text = "Error:" + " Decimal Value must be .5 ";
            //    lblMSG.ForeColor = System.Drawing.Color.DarkRed;
            //    mesgPN.BackColor = System.Drawing.Color.LightPink;
            //}
            else
            {

                double max = count * (double.Parse(ddlDays.SelectedValue.ToString()));
                try
                {

                    DataSet daxDS = DAL.selectMAxAmountLeave(Int32.Parse(ddlLeave.SelectedValue));
                    if (daxDS.Tables[0].Rows[0][0].ToString() != "" && max > double.Parse(daxDS.Tables[0].Rows[0][0].ToString()))
                    {

                        lblMSG.Text = "Error: " + ddlLeave.SelectedItem.ToString() + " " + "Max Date =" + daxDS.Tables[0].Rows[0][0].ToString();
                        lblMSG.ForeColor = System.Drawing.Color.Red;
                        butSave.Visible = false;
                        grvView.Visible = false;

                    }
                    else
                    {

                        string waring = "";
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Date");
                        dt.Columns.Add("Day");
                        dt.Columns.Add("Type");
                        dt.Columns.Add("Status");
                        int empId = Int32.Parse(ddlEmp.SelectedValue);
                        DateTime date = DateTime.Parse(txtStartDate.Text);
                        double k = 0;
                        int jump = int.Parse(txtJump.Text);
                        double jCount = 0;
                        int sd = 0;
                        while (k < count)
                        {
                            if (sd > 0)
                                date = date.AddDays(1);
                            sd++;
                            DataSet dsSCH = DAL.selectEmployeeSCHLeave(empId, date);
                            if (dsSCH.Tables[0].Rows.Count == 0)
                                break;
                            //   int count = dsSCH.Tables[0].Rows.Count - 1;
                            int dateM = date.Day;
                            int month = date.Month;
                            string dayN = date.DayOfWeek.ToString();
                            double days = double.Parse(ddlDays.SelectedItem.ToString());
                            int j = 0;
                            for (int i = 0; i < dsSCH.Tables[0].Rows.Count; i++)
                            {
                                j++;
                                DataRow row = dt.NewRow();
                                if (k == count)
                                    break;
                                DataSet dsLeav = DAL.selectEmployeeSCHLeave(Int32.Parse(ddlLeave.SelectedValue));
                                if (dsLeav.Tables[0].Rows[0][0].ToString() == "No")
                                {
                                    DataSet holiday = DAL.selectSCHoliDay(month, dateM, date, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()));
                                    if (holiday.Tables[0].Rows.Count > 0)
                                    {
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = holiday.Tables[0].Rows[0][5].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        dt.Rows.Add(row);
                                        if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                                        {
                                            //if (k == 0)
                                            //   k = k + 1;
                                            //dt.Rows.Add(row);
                                            jCount = jCount + jump;
                                            break;
                                        }
                                        else
                                        {
                                            //if (k == 0)
                                            //    k = k + 0.5;
                                            goto weta;
                                        }

                                    }
                                    DataSet weekend = DAL.selectSCWeekDAy(dayN, int.Parse(dsSCH.Tables[0].Rows[i][0].ToString()));
                                    if (weekend.Tables[0].Rows.Count == 0)
                                    {
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = "Weekend";
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        dt.Rows.Add(row);
                                        if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                                        {
                                            //if (k == 0)
                                            //  k = k + 1;
                                            //dt.Rows.Add(row);
                                            jCount = jCount + jump;
                                            break;
                                        }
                                        else
                                        {
                                            //if (k == 0)
                                            //    k = k + 0.5;
                                            goto weta;
                                        }


                                    }
                                   


                                }
                                DataSet leave = DA.selectLeaveEMP(date, empId, dsSCH.Tables[0].Rows[i][4].ToString());
                                if (leave.Tables[0].Rows.Count > 0)
                                {


                                    row["Date"] = date.ToString("dd-MMM-yy");
                                    row["Day"] = leave.Tables[0].Rows[0][0].ToString();
                                    row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                    dt.Rows.Add(row);
                                    waring = waring + " * " + date.ToString("dd-MMM-yy");

                                    if (dsSCH.Tables[0].Rows[i][4].ToString() == "Fullday")
                                    {
                                        //if (k == 0)
                                        //    k = k + 1;
                                        //dt.Rows.Add(row);
                                        jCount = jCount + jump;
                                        break;
                                    }
                                    else
                                    {
                                        //if (k == 0)
                                        //    k = k + 0.5;
                                        goto weta;
                                    }




                                }

                                if (jCount <= 0)
                                {
                                    if (dsSCH.Tables[0].Rows.Count == j)
                                    {
                                        jCount = jCount + jump;
                                    }

                                    if (days == 1.0 && dsSCH.Tables[0].Rows[i][2].ToString() == "And")
                                    {
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        row["Status"] = "Yes";
                                        k = k + 0.5;

                                    }
                                    else if (days == 0.5 && ddlDateType.SelectedItem.ToString() == dsSCH.Tables[0].Rows[i][3].ToString())
                                    {
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        row["Status"] = "Yes";
                                        k = k + 0.5;
                                    }
                                    if (dsSCH.Tables[0].Rows[i][2].ToString() == "Or")
                                    {
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        row["Status"] = "Yes";
                                        k = k + 1;
                                        dt.Rows.Add(row);
                                        jCount = jCount + jump;
                                        break;


                                    }

                                    row["Date"] = date.ToString("dd-MMM-yy");
                                    row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                    row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();

                                }
                                else
                                {
                                    if (dsSCH.Tables[0].Rows[i][2].ToString() == "Or")
                                    {
                                        jCount--;
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                        dt.Rows.Add(row);
                                        break;
                                    }
                                    else if (dsSCH.Tables[0].Rows[i][2].ToString() == "And")
                                    {
                                        jCount = jCount - 0.5;
                                        row["Date"] = date.ToString("dd-MMM-yy");
                                        row["Day"] = dsSCH.Tables[0].Rows[i][1].ToString();
                                        row["Type"] = dsSCH.Tables[0].Rows[i][3].ToString();
                                    }


                                }

                                //DateTime dateT = DateTime.Parse(dsSCH.Tables[0].Rows[i][1].ToString());
                                //DateTime dateFR = dateT.AddMinutes(0 - int.Parse(dsSCH.Tables[0].Rows[i][2].ToString()));
                                //DateTime dateTO = dateT.AddMinutes(int.Parse(dsSCH.Tables[0].Rows[i][3].ToString()));
                                //int dateL = int.Parse(dsSCH.Tables[0].Rows[i][4].ToString());
                                //DataSet dsTime = DA.selectSCTime(empId, date, dateFR, dateTO);
                                dt.Rows.Add(row);

                            weta: ;
                            }

                        }

                        grvView.DataSource = dt;
                        grvView.DataBind();
                        grvDetail.Visible = false;
                        grvView.Visible = true;
                        butSave.Visible = true;
                      
                        int countCH = 0;
                        foreach (GridViewRow row in grvView.Rows)
                        {
                            string name = row.Cells[4].Text;
                            string day = row.Cells[2].Text;
                             string AL=row.Cells[1].Text;
                            //DataRowView rowView = (DataRowView)grvView.Rows[0].DataItem;
                            //string name = rowView["Status"].ToString();
                            grvView.HeaderRow.Cells[4].Visible = false;
                            row.Cells[4].Visible = false;
                            if (name == "Yes")
                            {
                                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                                chkRow.Checked = true;
                                row.BackColor = System.Drawing.Color.Salmon;
                                countCH++;
                            }
                            if (day != "0.5" && day != "1.0")
                            {
                                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                                chkRow.Visible = false;
                                //if (day == "Annual Leave")
                                //{
                                //    waring = waring + " * " + AL;
                                //}

                            }

                        }
                        if (waring != "")
                        {
                            lblMSG.Text = "Warring!!!!  Leave Taken for these days " + waring;
                            lblMSG.ForeColor = System.Drawing.Color.DarkGoldenrod;
                            mesgPN.BackColor = System.Drawing.Color.LightYellow;
                              

                        }
                        if (countCH == 0)
                        {
                            butSave.Visible = false;
                        }

                    }
                }

                catch (Exception ex)
                {
                    lblMSG.Text = "Error:" + ex.Message;
                    lblMSG.ForeColor = System.Drawing.Color.Red;
                }
            }

        
        }
        protected void grvView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvView.PageIndex = e.NewPageIndex;
            grvView.DataBind();
        }
}



