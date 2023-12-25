using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


  
    public class EmployeeDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public EmployeeDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
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
            String sqlcomm = "SELECT Id,DepartmentName,Department_Id from Departments order by  DepartmentName  ";
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
            String sqlcomm = "SELECT  EmpId, FirstName + '  ' + MiddleName + '  ' + LastName AS Full_Name from viewEmployee where Id='" + depId + "'  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }


       
        //EmpId, FirstName, MiddleName, LastName, Gender, DateOfBirth, Position_Id, Telephone, Address, MobileNumber, MotherName, Photo, HiredDate, 
        //                 EmploymentType, EndDate

        public void InsertEmployee(int EmpId, string FirstName, string MiddleName, string LastName, string Gender, DateTime DateOfBirth, int Position_Id, string Telephone, string Address, string MobileNumber, string Photo, DateTime HiredDate, string EmploymentType, string EndDate, double salary, string FP, string empSatus)
        {
            //DateTime dt=DateTime.Now;
            //if(EndDate=="")
            //{
            //}
            //else
            //{
            //      dt=DateTime.Parse(EndDate);
            //}
            Sqlconn.Open();
            string sql = "insert into Employees (EmpId, FirstName, MiddleName, LastName, Gender, DateOfBirth, Position_Id, Telephone, Address, MobileNumber,Photo, HiredDate,EmploymentType, EndDate,RegisterTime,salary,FP,empSatus)" +
                    " values('" + EmpId + "','" + FirstName + "','" + MiddleName + "','" + LastName + "','" + Gender + "','" + DateOfBirth + "','" + Position_Id + "','" + Telephone + "','" + Address + "','" + MobileNumber + "','" + Photo + "','" + HiredDate + "','" + EmploymentType + "','" + EndDate + "','" + DateTime.Now + "','" + salary + "','" + FP + "','" + empSatus + "' )";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateEmployee(string EmpId, string FirstName, string MiddleName, string LastName, string Gender, DateTime DateOfBirth, int Position_Id, string Telephone, string Address, string MobileNumber, string Photo, DateTime HiredDate, string EmploymentType, string EndDate, string salary, string FP, string empSatus)
        {
            //DateTime dt=DateTime.Now;
            //if(EndDate=="")
            //{
            //}
            //else
            //{
            //      dt=DateTime.Parse(EndDate);
            //}
            Sqlconn.Open();
            string sql = "update  Employees set   FirstName='" + FirstName + "', MiddleName='" + MiddleName + "', LastName='" + LastName + "', Gender='" + Gender + "', DateOfBirth='" + DateOfBirth + "', Position_Id='" + Position_Id + "', Telephone='" + Telephone + "', Address='" + Address + "', MobileNumber='" + MobileNumber + "',Photo='" + Photo + "', HiredDate='" + HiredDate + "',EmploymentType='" + EmploymentType + "', EndDate='" + EndDate + "',salary='" + salary + "',FP='" + FP + "',empSatus='" + empSatus + "' where EmpId='" + EmpId + "'";
                  
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        public void InsertDepartment(string DepartmentName,string Description,int Department_Id)
        {
            Sqlconn.Open();
            string sql = "insert into Departments ( DepartmentName, Description, Department_Id)" +
                    " values('" + DepartmentName + "','" + Description + "','" + Department_Id + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateDepartment(int Id,string DepartmentName,string Description,int Department_Id)
        {
          
            Sqlconn.Open();
            String sqlcomm = "update Departments set DepartmentName='" + DepartmentName + "',Description='" + Description + "',Department_Id='" + Department_Id + "' where ID=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deleteEmployee(int Id)
        {

            string sql = "delete from Employees where EmpId=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();

        }
        public void deleteDepartmentPosition(int Id)
        {

            string sql = "delete from DepartmentPositions where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
          
        public void InsertEmployeeTimetable(int timeTableID,string empID,DateTime startDate,string endDate,string type,string FP)
        {
            Sqlconn.Open();
            string sql = "insert into employeeTimeTable ( timeTableID, empID, startDate, endDate, type,FP)" +
                    " values('" + timeTableID + "','" + empID + "','" + startDate + "','" + endDate + "','" + type + "','"+FP+"')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void deleteEmployeeTimetable(int timeTableID, int empID)
        {

            string sql = "delete  employeeTimeTable where empID='" + empID + "' and  timeTableID='" + timeTableID + "'";
            Sqlconn.Close();
            Sqlconn.Open();
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
    }
