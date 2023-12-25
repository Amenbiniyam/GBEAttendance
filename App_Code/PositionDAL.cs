using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;


  
    public class PositionDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public PositionDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
        public DataSet selectPosMAx()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT MAX(Id) from Positions";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public void InsertPosition(int ID, string PositionName, string Description)
        {
            Sqlconn.Open();
            string sql = "insert into Positions (Id, PositionName, Description)" +
                    " values('"+ID+"' ,'" + PositionName + "','" + Description + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updatePosition(int Id, string PositionName, string Description)
        {
          
            Sqlconn.Open();
            String sqlcomm = "update Positions set PositionName='" + PositionName + "',Description='" + Description + "' where ID=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deletePosition(int Id)
        {

            string sql = "delete from Positions where Id=" + Id + "";

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
