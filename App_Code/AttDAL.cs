using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


  
    public class AttDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);

        public static String connStrSql1 = WebConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;
        public SqlConnection Sqlconn1 = new SqlConnection(connStrSql1);
        public AttDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
       
       
        public DataSet MAXDATA()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = " select   MAX(convert(datetime,date)) ,max(convert(datetime,time)) from tblData where date=(select MAX(convert(datetime,date)) from tblData) ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet UaLeaveTotal(int empId,string status)
        {
            Sqlconn.Close();
            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "  select count(NoOfDaysRequested),ProgressStatus from LeaveRequests where CurrentApprover='" + empId + "' and ProgressStatus='" + status + "' group by ProgressStatus ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

        public DataSet selectPositionDEP(int Department)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Id,PositionName FROM  depPosition1 where DepID='" + Department + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

        public DataSet selectDEPTree(int Department)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Department_Id from Departments where Id='" + Department + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectDepTreeAll()
        {
          
            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Id,DepartmentName,Department_Id from Departments  order by  DepartmentName";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectEmployee(string empId)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT * from viewEmployee where EmpId='" + empId + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

       


        public DataSet selectEmployeeDEP(int depId)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT  EmpId, FirstName + '  ' + MiddleName + '  ' + LastName AS Full_Name from viewEmployee where Id='" + depId + "' Order by  Full_Name ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }


       
        //EmpId, FirstName, MiddleName, LastName, Gender, DateOfBirth, Position_Id, Telephone, Address, MobileNumber, MotherName, Photo, HiredDate, 
        //                 EmploymentType, EndDate

        public DataSet selectEmployeeSCH(string empId,DateTime date)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = " select timeTableID,onDutyTime,early,absent,late,workday,type,FullName,dayType,FP from AttEmpSchd where empId='" + empId + "' and " +
                             " (startDate <= '" + date + "') AND (convert(datetime,endDate) >= '" + date + "' or endDate='')  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectSCHoliDay(int month,int dateN,DateTime date,int titID,string workDay,string type)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "select * from timeHoliday where ((month_part='" + month + "' and DAte_part='" + dateN + "' and cyclePerYear='Yes') or (Date='" + date + "')) and ((WorkDay='" + workDay + "' and DayType='" + type + "') or (Date='" + date + "' and WorkDay='1.0')) and   timeTableID='" + titID + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectSCWeekDAy(string Date,int titID)
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
        public DataSet selectLeaveEMPAUT(DateTime Date, int empId, string type)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "select Leave_Name from empLeaveReport where Date='" + Date + "' and empId='" + empId + "' and type='" + type + "' and Status  in ('Authorized')";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectLeaveEMP(DateTime Date, int empId,string type)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "select Leave_Name from empLeaveReport where Date='" + Date + "' and empId='" + empId + "' and type='" + type + "' and Status not in ('Reversal Authorized','Rejected','System Reject')";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
    
//         public DataSet selectSCTime(string empId,DateTime date,DateTime fromTime,DateTime toTime)
//        {
//            Sqlconn1.Close();
//            Sqlconn1.Open();
//            DataSet ds = new DataSet();
////          SELECT     CAST(Date AS time)
////FROM         test
////WHERE     (CAST(Date AS DATE) = '2016-10-01') AND 

////(CAST(Date AS time) between '14:40:00' and '14:55:00')


//            String sqlcomm = " SELECT CAST(punch_time AS time) FROM iclock_transaction WHERE (emp_code = '" + empId + "') AND (CAST(punch_time AS DATE) = '" + date + "') and (CAST(punch_time AS time) between '" + fromTime.TimeOfDay + "' and '" + toTime.TimeOfDay + "')";
//            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn1);
//            SqlDataAdapter da = new SqlDataAdapter(cmd);
//            da.Fill(ds);
//            Sqlconn1.Close();
//            return ds;
//        }

     
public DataSet selectSCTime(string empId, DateTime date, DateTime fromTime, DateTime toTime)
        {

            Sqlconn1.Open();
            DataSet ds = new DataSet();
            String sqlcomm = " SELECT  CONVERT(time,time) as time FROM acc_monitor_log WHERE (pin = '" + empId + "') AND (CONVERT(date,time) = '" + date + "') and (CONVERT(time,time) between '" + fromTime.TimeOfDay + "' and '" + toTime.TimeOfDay + "')";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn1.Close();
            return ds;
        }



        public DataSet selectATTDAta(string empId,DateTime fromDate,DateTime fromTo)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT empId,CONVERT(VARCHAR(11),CONVERT(datetime,date), 106) AS Date,time FROM tblData WHERE empId = '" + empId + "'  and (CONVERT(datetime,date) between '" + fromDate + "' and '" + fromTo + "') order by Date";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }


     public DataSet selectDepEmp(int depID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = " SELECT EmpId,DepartmentName FROM viewEmployee WHERE ID='" + depID + "'";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet selectDepEmpIND(string empID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = " SELECT EmpId,DepartmentName FROM viewEmployee WHERE EmpId='" + empID + "'";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }
     public DataSet selectDepEmpALL()
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = " SELECT EmpId,DepartmentName FROM viewEmployee ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
     }

     public DataSet selectEmpDep(int empID)
     {

         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = " SELECT Id FROM viewEmployee where EmpId='"+empID+"' ";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;
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
     public DataSet selectEmployeeALLDEP(string  depName)
     {
         String sqlcomm ="";
         if(depName=="Debub Global  Bank")
         {
           sqlcomm="SELECT EmpId, FirstName, MiddleName, LastName, Gender, DateOfBirth, Telephone, Address, MobileNumber,HiredDate, EmploymentType, EndDate,PositionName, DepartmentName,RegisterTime, salary from viewEmployee ";
         }
         else 
         {
         sqlcomm="SELECT EmpId, FirstName, MiddleName, LastName, Gender, DateOfBirth, Telephone, Address, MobileNumber,HiredDate, EmploymentType, EndDate,PositionName, DepartmentName,RegisterTime, salary from viewEmployee where DepartmentName='" + depName + "'";

         }

         

         Sqlconn.Open();
         DataSet ds = new DataSet();
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
     
     public DataSet selectALLEMP(int empId)
     {
         Sqlconn.Close();
         Sqlconn.Open();
         DataSet ds = new DataSet();
         String sqlcomm = " select EmpId,FirstName+' '+MiddleName+' '+LastName as FullName,DepartmentName,HiredDate,salary from viewEmployee where  EmpId='" + empId + "'";
         SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         da.Fill(ds);
         Sqlconn.Close();
         return ds;

     }


       
    }
