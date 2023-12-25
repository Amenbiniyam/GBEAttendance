using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


    public class LeaveDAL
    {
        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public LeaveDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void InsertLeaveType(string Name, string MaximumAmount, string GenderType, string IncreamentalValue, string Consecutive, string ALAccrue, string SickLeave)
        {
            Sqlconn.Open();
            string sql = "insert into LeaveTypes (   Name, MaximumAmount, GenderType, IncreamentalValue, Consecutive, ALAccrue,SickLeave)" +
                    " values('" + Name + "','" + MaximumAmount + "','" + GenderType + "', '" + IncreamentalValue + "','" + Consecutive + "','" + ALAccrue + "','" + SickLeave + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateLeaveType(int Id, string Name, string MaximumAmount, string GenderType, string IncreamentalValue, string Consecutive, string ALAccrue, string SickLeave)
        {

            Sqlconn.Open();
            String sqlcomm = "update LeaveTypes set Name='" + Name + "',MaximumAmount='" + MaximumAmount + "',GenderType='" + GenderType + "',IncreamentalValue='" + IncreamentalValue + "',Consecutive='" + Consecutive + "',ALAccrue='" + ALAccrue + "',SickLeave='" + SickLeave + "' where Id=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deleteLeaveType(int Id)
        {

            string sql = "delete from LeaveTypes where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        // Employee_Id, LeaveType_Id, LeaveBalance, Date

        public void InsertLeaveSetting(int Employee_Id,int  LeaveType_Id,double LeaveBalance,DateTime Date,double leaveEn)
        {
            Sqlconn.Open();
            string sql = "insert into EmployeeLeaveSettings (Employee_Id, LeaveType_Id, LeaveBalance, Date,LeaveEntitlement)" +
                    " values('" + Employee_Id + "','" + LeaveType_Id + "','" + LeaveBalance + "', '" + Date + "','" + leaveEn + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateLeaveSetting(int Id, int Employee_Id, int LeaveType_Id, double LeaveBalance, DateTime Date, double leaveEn)
        {

            Sqlconn.Open();
            String sqlcomm = "update EmployeeLeaveSettings set Employee_Id='" + Employee_Id + "',LeaveType_Id='" + LeaveType_Id + "',LeaveBalance='" + LeaveBalance + "',Date='" + Date + "',LeaveEntitlement='" + leaveEn + "' where Id=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deleteLeaveSetting(int Id)
        {

            string sql = "delete from EmployeeLeaveSettings where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public DataSet selectEmployeeLevaeBal(int empId)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  * from  empLeaveSetting where EmpId='" + empId + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectEmployeeLevaeBalTYpe(int empId,string leaveName)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  * from  empLeaveSetting where EmpId='" + empId + "' and  Leave_Name='" + leaveName + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectEmpLevaeBal(int empId, string leaveName)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  Id, Employee_Id, Full_Name, Leave_Name, Date_From, Date_To,NoOfDaysRequested, NoOfDaysAUT, Una_NO_Days, ProgressStatus,"+
                      "NoOfDaysReversal from  empLeaveBal where Employee_Id='" + empId + "' and  Leave_Name='" + leaveName + "' order by Id desc ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectCuuAPP(int id)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  CurrentApprover from LeaveRequests where  Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectCuuAPPNew(int id)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  CurrentApprover,ReviewBy from LeaveRequests where  Id='" + id + "'";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet SumUnLeaveReq(int empId)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = " select SUM(NoOfDaysRequested) from LeaveRequests where Employee_Id='" + empId + "' and ProgressStatus='Unauthorized'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }



      
        public DataSet selectEmpTakenTYpe(int empId,string leaveName)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  * from  empLeaveTaken where EmpId='" + empId + "' and  Leave_Name='" + leaveName + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

     public DataSet AllLeaveType()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  Id, Name from  LeaveTypes order by Id ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

     public DataSet AllLeaveTypeEmp(int empId)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "SELECT  Id, Name from  LeaveTypes where GenderType in (select gender from employees where empId='"+empId+"') or GenderType='both'order by Name ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet AllLeaveTypeALBAL(int empId)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "SELECT  Id, Name from  LeaveTypes where  Id='4'order by Name ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet AllLeaveTypeEmpALL()
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "SELECT  Id, Name from  LeaveTypes order by Name ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
      //  select IncreamentalValue from LeaveTypes where Name='Anual Leave' 
     public DataSet INLeaveType(string leaveType)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select IncreamentalValue from LeaveTypes where Name='"+leaveType+"' ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet INLeaveTypeID(int leaveID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select IncreamentalValue from LeaveTypes where Id='" + leaveID + "' ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     } 


      public DataSet sumLWP(int empID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select sum(NoOfDaysRequested)-sum(ISNULL(NoOfDaysReversal, 0 )) from LeaveRequests where LeaveType_Id in (select Id from LeaveTypes where ALAccrue='NO') and Employee_Id='" + empID + "' and ProgressStatus='Authorized'  ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
      public DataSet sumSick(int empID)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select sum(NoOfDaysRequested)-sum(NoOfDaysReversal) from LeaveRequests where LeaveType_Id in (select Id from LeaveTypes where SickLeave='Yes') and Employee_Id='" + empID + "'  ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet empHDAte(int empID)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select HiredDate from Employees where  EmpId='" + empID + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet sumLeaveBal(int empID, int leaveID, string status,DateTime date)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  COALESCE (SUM(Bal), 0) AS Bal from viewLeaveBAl where LeaveType_Id ='" + leaveID + "' and Employee_Id='" + empID + "' and  Status='" + status + "' and Date<='" + date + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet sumLeave(int empID,int leaveID,string status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  COALESCE (SUM(Bal), 0) AS Bal from viewLeaveBAl where LeaveType_Id ='" + leaveID + "' and Employee_Id='" + empID + "' and  Status='" + status + "'  ";
     
        //  String sqlcomm = "select COALESCE(SUM(NoOfDaysAUT),0)-COALESCE(SUM(NoOfDaysReversal),0) from LeaveRequests where LeaveType_Id ='" + leaveID + "' and Employee_Id='" + empID + "' and  ProgressStatus='" + status + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet sumLeaveDate(int empID, int leaveID, string status,DateTime date)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select sum(NoOfDaysRequested) from LeaveRequests where LeaveType_Id ='" + leaveID + "' and Employee_Id='" + empID + "' and  ProgressStatus='" + status + "' and RequestDateTo='"+date+"' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet selectDays(int empID)
      {
        
          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = " select DISTINCT(workday) from AttEmpSchd where empID='" + empID + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet selectEmployeeSCHLeave(int empId, DateTime date)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = " select timeTableID,workday,type,dayType,dayType from AttEmpSchd where empId='" + empId + "' and " +
                           " (startDate <= '" + date + "') AND (convert(datetime,endDate) >= '" + date + "' or endDate='')  ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet selectEmployeeSCHLeave(int Id)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select Consecutive from LeaveTypes where id='" + Id + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
       //select MaximumAmount from LeaveTypes where id='4'

      public DataSet selectMAxAmountLeave(int Id)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select MaximumAmount from LeaveTypes where id='" + Id + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }


      public DataSet selectSCHoliDay(int month, int dateN, DateTime date, int titID)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select * from timeHoliday where ((month_part='" + month + "' and DAte_part='" + dateN + "' and cyclePerYear='Yes') or (Date='" + date + "')) and timeTableID='" + titID + "' ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet selectSCWeekDAy(string Date, int titID)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select * from timeWeek where Name='" + Date + "' and timeTableID='" + titID + "'";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }

      public DataSet maxLeaveRequest()
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select max(Id) from LeaveRequests ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }

      public void InsertLeaveRequests(int Employee_Id, DateTime RequestDateFrom, DateTime RequestDateTo, double NoOfDaysRequested, int LeaveType_Id, string ProgressStatus, int CurrentApprover, double Balance,string reason)
        {
            Sqlconn.Open();
            string sql = "insert into LeaveRequests ( Employee_Id, RequestDateFrom, RequestDateTo, NoOfDaysRequested,LeaveType_Id,ProgressStatus,CurrentApprover,Balance,reason)" +
                    " values('" + Employee_Id + "','" + RequestDateFrom + "','" + RequestDateTo + "', '" + NoOfDaysRequested + "','" + LeaveType_Id + "','" + ProgressStatus + "','" + CurrentApprover + "','" + Balance + "','"+reason+"')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
      public void InsertLeaveRequestsISS(int Employee_Id, DateTime RequestDateFrom, DateTime RequestDateTo, double NoOfDaysRequested, int LeaveType_Id, string ProgressStatus, int CurrentApprover, double Balance, double NoOfDaysAUT, string reason)
      {
          Sqlconn.Open();
          string sql = "insert into LeaveRequests ( Employee_Id, RequestDateFrom, RequestDateTo, NoOfDaysRequested,LeaveType_Id,ProgressStatus,CurrentApprover,Balance,NoOfDaysAUT,reason)" +
                  " values('" + Employee_Id + "','" + RequestDateFrom + "','" + RequestDateTo + "', '" + NoOfDaysRequested + "','" + LeaveType_Id + "','" + ProgressStatus + "','" + CurrentApprover + "','" + Balance + "','" + NoOfDaysAUT + "','" + reason + "')";
          SqlCommand cmd = new SqlCommand(sql, Sqlconn);
          cmd.ExecuteNonQuery();
          Sqlconn.Close();
      }


      public void InsertLeaveRequestsDetail(int empId, int LeaveRequestID, DateTime Date, double Days, string Type, string status)
        {
            Sqlconn.Open();
            string sql = "insert into LeaveRequestDetail ( empId,LeaveRequestID, Date, Days, Type,status)" +
                    " values('" + empId + "',  '" + LeaveRequestID + "','" + Date + "','" + Days + "', '" + Type + "','" + status + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        
        //empLeaveReport
      public DataSet leaveReportTeller(string depId, DateTime stDAte, DateTime enDAte)
      {

          // empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "";
          if (depId != "")
          {

              sqlcomm = "SELECT  EmpId,Full_Name,SUM(Days) AS NoOfDays,Status,DepartmentName,LeaveType FROM viewLeaveTeller WHERE     (Status IN ('Authorized', 'Reversal Unauthorized', 'Unauthorized', 'Reversal Authorized')) and (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "') and Position_Id in ('154','155','7','239','240','262') and LeaveType_Id not in('10','12') and DepartmentName='" + depId + "'  " +
                         " GROUP BY EmpId,Status, Full_Name,DepartmentName,LeaveType";


          }
          else 
          {
              sqlcomm = "SELECT  EmpId, Full_Name, SUM(Days) AS NoOfDays,Status,DepartmentName,LeaveType FROM viewLeaveTeller WHERE     (Status IN ('Authorized', 'Reversal Unauthorized', 'Unauthorized', 'Reversal Authorized')) and (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "') and Position_Id in ('154','155','7','239','240','262') and LeaveType_Id not in('10','12')   " +
                         " GROUP BY EmpId,Status, Full_Name,DepartmentName,LeaveType";
          }
        
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet leaveReport(string empId, string depId, DateTime stDAte, DateTime enDAte)
      {

         // empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "";
          if (empId == "" && depId == "")
          {


              sqlcomm = "select empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status,Reason from empLeaveReport where (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "')  order by Full_Name,CONVERT(DATETIME, Date, 103),Leave_Name ";
          }
          else if(empId == "" || depId != "")
          {
              sqlcomm = "select empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status,Reason from empLeaveReport  where   DepartmentName='" + depId + "' and (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "') order by Full_Name,CONVERT(DATETIME, Date, 103),Leave_Name ";
          }
          else if (empId != "" || depId == "")
          {
              sqlcomm = "select empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status,Reason from empLeaveReport where empID='" + Int32.Parse(empId) + "' and (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "')  order by Full_Name,CONVERT(DATETIME, Date, 103),Leave_Name ";
          }
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet leaveReportEMPDate(string empId,DateTime stDAte,DateTime enDAte)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "";
          sqlcomm = "select empID,Full_Name,Leave_Name,CONVERT(VARCHAR(11),Date, 106) AS Date,Days,Type,DepartmentName,status,Reason,CurrentApprover from empLeaveReport where empID='" + Int32.Parse(empId) + "' and (CONVERT(datetime,Date) between '" + stDAte + "' and '" + enDAte + "') order by Full_Name,CONVERT(DATETIME, Date, 103),Leave_Name ";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet LeaveReversal(int empId, string status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  Id, EmpId, FullName,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From,CONVERT(VARCHAR(11), Date_To, 106) AS Date_To, NoOfDaysRequested,NoOfDaysAUT,Name AS Leave_Name,Reason from empLeave where EmpId='" + empId + "'  and ProgressStatus='" + status + "' order by Id desc";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet LeaveReversalNEW(int empId, string status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  Id, EmpId, FullName,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From,CONVERT(VARCHAR(11), Date_To, 106) AS Date_To, NoOfDaysRequested,NoOfDaysAUT,Name AS Leave_Name from empLeave where EmpId='" + empId + "'  and ProgressStatus='" + status + "' and Reason!='System'";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet UnLeaveRequest(int empId,string status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  Id, EmpId, FullName,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From,CONVERT(VARCHAR(11), Date_To, 106) AS Date_To, NoOfDaysRequested,NoOfDaysAUT,Name AS Leave_Name,Balance,Reason,ReviewBy from empLeave where CurrentApprover='" + empId + "'  and ProgressStatus='" + status + "'";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet UnLeaveRequestRV(int empId, string status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  Id, EmpId, FullName,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From,CONVERT(VARCHAR(11), Date_To, 106) AS Date_To, NoOfDaysRequested,NoOfDaysAUT,Name AS Leave_Name,NoOfDaysReversal,ReviewBy,Reason from empLeave where CurrentApprover='" + empId + "'  and ProgressStatus='" + status + "'";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
      public DataSet UnLeaveRequestRVNuru()
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select  Id, EmpId, FullName,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From,CONVERT(VARCHAR(11), Date_To, 106) AS Date_To, NoOfDaysRequested,NoOfDaysAUT,Name AS Leave_Name,NoOfDaysReversal,ReviewBy,Reason from empLeave where ProgressStatus in ('Rejected Unauthorized')";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }
     public DataSet LeaveRequestDetail(int LeaveRequestID,int empId,string Status)
      {

          Sqlconn.Open();
          DataSet ds = new DataSet();
          String sqlcomm = "select   Id, Days, Type, CONVERT(VARCHAR(11), Date, 106) AS Date from LeaveRequestDetail where empId='" + empId + "'  and LeaveRequestID='" + LeaveRequestID + "' and status='" + Status + "' order by Id";
          SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
          SqlDataAdapter da = new SqlDataAdapter(cmd);
          da.Fill(ds);
          Sqlconn.Close();
          return ds;
      }

     public void UpdateLeaveRequestsREV(int id, DateTime RequestDateFrom, DateTime RequestDateTo, double NoOfDaysRequested, int CurrentApprover, string ProgressStatus)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set CurrentApprover='" + CurrentApprover + "', ProgressStatus='" + ProgressStatus + "',NoOfDaysReversal='" + NoOfDaysRequested + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveRequestsREV(int id, double NoOfDaysRequested, int CurrentApprover, string ProgressStatus)
      {
          Sqlconn.Open();
          string sql = "update LeaveRequests set CurrentApprover='" + CurrentApprover + "', ProgressStatus='" + ProgressStatus + "', NoOfDaysReversal='" + NoOfDaysRequested + "' where Id='" + id + "'";
          SqlCommand cmd = new SqlCommand(sql, Sqlconn);
          cmd.ExecuteNonQuery();
          Sqlconn.Close();
      }
     public void UpdateLeaveRequests(int id, DateTime RequestDateFrom, DateTime RequestDateTo, double NoOfDaysRequested)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set RequestDateFrom='" + RequestDateFrom + "', RequestDateTo='" + RequestDateTo + "', NoOfDaysAUT='" + NoOfDaysRequested + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void deleteLeaveRequestDeta(int id)
     {
         Sqlconn.Open();
         string sql = "delete LeaveRequestDetail where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveRequestMAinRVE(int id, string status, double NoOfDaysReversal)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set ProgressStatus='" + status + "', NoOfDaysReversal='" + NoOfDaysReversal + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveRequestMAin(int id, string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set ProgressStatus='" + status + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveRequestDetaN(int id, string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='" + status + "' where LeaveRequestID='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
   

     public DataSet selectIdUna(DateTime startDate,DateTime endDAte)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select  Id  from LeaveRequests where  ProgressStatus='Unauthorized' and  RequestDateFrom  between '" + startDate + "' and '" + endDAte + "'"; 
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet selectFPUna(DateTime startDate, DateTime endDAte)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select  empId,Date,Days,Type,LeaveRequestID  from empLeaveReport where  status='Unauthorized' and FP='NO' and Date  between '" + startDate + "' and '" + endDAte + "'";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }

     public void UpdateLeaveRequestMAinSystem(DateTime startDate,DateTime endDAte)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set ProgressStatus='System Reject' where ProgressStatus='Unauthorized' and  RequestDateFrom  between '" + startDate + "' and '" + endDAte + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveRequestDetaSystem(int id)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='System Reject'  where status='Unauthorized' and LeaveRequestID='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }



     public void DeleteLeaveRequestMAin(int id)
     {
         Sqlconn.Open();
         string sql = "delete LeaveRequests  where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void DeleteLeaveRequestDetaN(int id)
     {
         Sqlconn.Open();
         string sql = "delete LeaveRequestDetail  where LeaveRequestID='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     

     public void UpdateLeaveRequestDeta(int id,string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='" + status + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqCuuAPP(int id,int CurrentApprover,int revBY)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set CurrentApprover='" + CurrentApprover + "',ReviewBy='" + revBY + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqProgRV(int id, int CurrentApprover, string ProgressStatus)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set CurrentApprover='" + CurrentApprover + "', ProgressStatus='" + ProgressStatus + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqDetailProgRV(int id, string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='" + status + "' where LeaveRequestID='" + id + "' and status='Reversal Unauthorized'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqDetailProgRVNuru(int id, string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='" + status + "' where LeaveRequestID='" + id + "' and status='Rejected Unauthorized'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }



     public void UpdateLeaveReqProg(int id,int CurrentApprover,string ProgressStatus,double NoOfDaysAUT )
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set NoOfDaysAUT='" +NoOfDaysAUT + "',  CurrentApprover='" + CurrentApprover + "', ProgressStatus='" + ProgressStatus + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqDetailProg(int id, string status)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequestDetail set status='" + status + "' where LeaveRequestID='" + id + "' and status='Unauthorized'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void UpdateLeaveReqProgA(int id, int CurrentApprover, string ProgressStatus)
     {
         Sqlconn.Open();
         string sql = "update LeaveRequests set  CurrentApprover='" + CurrentApprover + "', ProgressStatus='" + ProgressStatus + "' where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void DELLeaveRequestDeta(int LeaveRequestID)
     {
         Sqlconn.Open();
         string sql = "delete LeaveRequestDetail where LeaveRequestID='" + LeaveRequestID + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void DELdeleteLeaveRequest(int id)
     {
         Sqlconn.Open();
         string sql = "delete LeaveRequests where Id='" + id + "'";
         SqlCommand cmd = new SqlCommand(sql, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public void saveUserLog(String username, String action, string refNo, DateTime date)
     {
         Sqlconn.Close();
         Sqlconn.Open();
         //  string ecPassword = EnryptString(password);
         String sqlcomm = "INSERT INTO tblLog(UserName,action,refNo,date)values('" + username + "','" + action + "','" + refNo + "','" + date + "')";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         cmd.ExecuteNonQuery();
         Sqlconn.Close();
     }
     public DataSet LeaveBalDetail(int empId, string leaveName)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select  Id,Full_Name, Leave_Name, Date_From, Date_To, Balance, NoOfDaysRequested, NoOfDaysAUT, Una_NO_Days,NoOfDaysReversal, ProgressStatus from empLeaveBal where Employee_Id='" + empId + "' and  Leave_Name='" + leaveName + "' ORDER BY Id DESC ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet LeaveSetting(DateTime startDate,DateTime endDAte)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "select EmpId, FullNAme, Name, LeaveBalance, CONVERT(VARCHAR(11),Date, 106) AS Date from viewLeaveSetting  where Date  between '" + startDate + "' and '" + endDAte + "'ORDER BY Date";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }

     public DataSet LeaveALLEMP(DateTime startDate, DateTime endDAte,string depNAme,string EmpId)
     {
         String sqlcomm = "";
         if (depNAme != "")
         {
             if (depNAme == "Debub Global  Bank")
             {
                 sqlcomm = "select FullName,EmpId, CONVERT(VARCHAR(11), Date_From, 106) AS Date_From , CONVERT(VARCHAR(11), Date_To, 106) as Date_To ,NoOfDaysRequested, Name,ProgressStatus, NoOfDaysAUT, Balance, DepartmentName from empLeave where Date_From  between '" + startDate + "' and '" + endDAte + "' ORDER BY DepartmentName";
             }
             else
             {
                 sqlcomm = "select FullName,EmpId,CONVERT(VARCHAR(11), Date_From, 106) AS Date_From , CONVERT(VARCHAR(11), Date_To, 106) as Date_To , NoOfDaysRequested, Name,ProgressStatus, NoOfDaysAUT, Balance, DepartmentName from empLeave where Date_From  between '" + startDate + "' and '" + endDAte + "' and DepartmentName='" + depNAme + "' ORDER BY DepartmentName";
    
             }
         }
         else
         {
             sqlcomm = "select FullName,EmpId, CONVERT(VARCHAR(11), Date_From, 106) AS Date_From , CONVERT(VARCHAR(11), Date_To, 106) as Date_To , NoOfDaysRequested, Name,ProgressStatus, NoOfDaysAUT, Balance, DepartmentName from empLeave where Date_From  between '" + startDate + "' and '" + endDAte + "' and EmpId='" + EmpId + "' ORDER BY DepartmentName";

         }



         Sqlconn.Open();
         DataSet ds = new DataSet();
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
    public DataSet LeaveDetail(int ID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = "SELECT     CONVERT(VARCHAR(11), Date, 106) AS Date, Days, Type, status FROM    LeaveRequestDetail WHERE   LeaveRequestID = '" + ID + "'";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
    public DataSet selectLeaveEntitlement(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select LeaveEntitlement FROM   EmployeeLeaveSettings where  Employee_Id='" + empId + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
        
    }
