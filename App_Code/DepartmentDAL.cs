using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


  
    public class DepartmentDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public DepartmentDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
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
            String sqlcomm = "SELECT Id,DepartmentName,Department_Id from Departments order by  DepartmentName ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }


        public void InsertDepartmentPOsition(int Department_Id,int Position_Id)
        {
            Sqlconn.Open();
            string sql = "insert into DepartmentPositions ( Department_Id, Position_Id)" +
                    " values('" + Department_Id + "','" + Position_Id + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        public void InsertDepartment(int depID,string DepartmentName,string Description,int Department_Id)
        {
            Sqlconn.Open();
            string sql = "insert into Departments (Id,DepartmentName, Description, Department_Id)" +
                    " values('" + depID + "','" + DepartmentName + "','" + Description + "','" + Department_Id + "')";
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
        public void deleteDepartment(int Id)
        {

            string sql = "delete from Departments where Id=" + Id + "";

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

        }

        public DataSet selectDEPMAx()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT MAX(Id) from Departments";
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
    }
