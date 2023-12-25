using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


  
    public class CompanyDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public CompanyDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
        public void InsertCompany(string CompanyName,string Description,string Address,string Telephone,string Email,string Fax,string Website)
        {
            Sqlconn.Open();
            string sql = "insert into Companies ( CompanyName, Description, Address, Telephone, Email, Fax, Website)" +
                    " values('" + CompanyName + "','" + Description + "','" + Address + "', '" + Telephone + "','" + Email + "','" + Fax + "','" + Website + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateCompany(int Id,string CompanyName, string Description, string Address, string Telephone, string Email, string Fax, string Website)
        {
          
            Sqlconn.Open();
            String sqlcomm = "update Companies set CompanyName='" + CompanyName + "',Description='" + Description + "',Address='" + Address + "',Telephone='" + Telephone + "',Email='" + Email + "',Fax='" + Fax + "',Website='" + Website + "' where ID=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deleteCompany(int Id)
        {

            string sql = "delete from Companies where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();

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
