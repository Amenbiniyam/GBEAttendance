using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


  
    public class HolidayDAL
    {

        public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        public SqlConnection Sqlconn = new SqlConnection(connStrSql);
        public HolidayDAL()
	    {
		//
		// TODO: Add constructor logic here
		//
	    }
        public DataSet selectHoliday()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Id,HolidayName FROM  Holidays  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public void InsertHoliday(string HolidayName, DateTime Date, string Description, string CyclePerYear,string workDay, string DayType)
        {
            Sqlconn.Open();
            string sql = "insert into Holidays (  HolidayName, Date, Description, CyclePerYear,WorkDay,DayType)" +
                    " values('" + HolidayName + "','" + Date + "','" + Description + "', '" + CyclePerYear + "','" + workDay + "','" + DayType + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void updateHoliday(int Id, string HolidayName, DateTime Date, string Description, string CyclePerYear, string workDay, string DayType)
        {
          
            Sqlconn.Open();
            String sqlcomm = "update Holidays set HolidayName='" + HolidayName + "',Date='" + Date + "',Description='" + Description + "',CyclePerYear='" + CyclePerYear + "',WorkDay='" + workDay + "',DayType='"+DayType+"' where ID=" + Id + "";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();

        }
        public void deleteHoliday(int Id)
        {

            string sql = "delete from Holidays where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        public void InsertTimeTables(string Name, DateTime onDutyTime, decimal workday, int early, int absent, int late, string dayType)
        {
            Sqlconn.Open();
            string sql = "insert into TimeTables ( Name, onDutyTime, workday, early, absent, late,dayType)" +
                    " values('" + Name + "','" + onDutyTime + "','" + workday + "', '" + early + "','" + absent + "','" + late + "','" + dayType + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        public void updateTimeTables(int Id, string Name, DateTime onDutyTime, decimal workday, int early, int absent, int late, string dayType)
        {
            Sqlconn.Open();
            string sql = "update TimeTables set Name='" + Name + "', onDutyTime='" + onDutyTime + "', workday='" + workday + "', early='" + early + "', absent='" + absent + "', late='" + late + "', dayType='" + dayType + "' where Id='" + Id + "'";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void deleteTimeTables(int Id)
        {

            string sql = "delete from TimeTables where Id=" + Id + "";

            Sqlconn.Close();
            Sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }


        public int selectMaxId()
        {
            Sqlconn.Close();
            Sqlconn.Open();
            string sqlcomm = "SELECT max(Id) FROM TimeTables";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            int count = (int)cmd.ExecuteScalar();
            Sqlconn.Close();
            return count;

        }
        public void InsertTimeTablesWeekDAys(int timeTableID, int weekDaysID)
        {

            Sqlconn.Open();
            string sql = "insert into timeWeekDays ( timeTableID, weekDaysID)" +
                    " values('" + timeTableID + "','" + weekDaysID + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void InsertTimeTablesHoliday(int TimeTableID, int holidayID)
        {
            Sqlconn.Open(); 
            string sql = "insert into timeTableHoliday ( TimeTableID, holidayID)" +
                    " values('" + TimeTableID + "','" + holidayID + "')";
            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

        public DataSet selectTimeTable(int ID)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT * FROM  TimeTables where Id='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectTimeTableWeek(int ID)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT weekDaysID FROM  timeWeekDays where timeTableID='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
        public DataSet selectTimeTableHoliday(int ID)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT holidayID FROM     timeTableHoliday where TimeTableID='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

        public DataSet selectweekDays()
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Id,Name FROM  weekDays  ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }

        public void  deleteTimeTableWeek(int ID)
        {

            Sqlconn.Open();
          
            String sqlcomm = "delete timeWeekDays where timeTableID='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
        public void deleteTimeTableHoliday(int ID)
        {

            Sqlconn.Open();
         
            String sqlcomm = "delete timeTableHoliday where TimeTableID='" + ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }

         public DataSet selectTimeTableEmployee(string empID)
        {

            Sqlconn.Open();
            DataSet ds = new DataSet();
            String sqlcomm = "SELECT Id, timeTableID, empID, startDate, endDate,type FROM employeeTimeTablee where empID='" + empID + "' ";
            SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Sqlconn.Close();
            return ds;
        }
         public void updateTimeTablesEmp(int Id,DateTime startDate,string endDAte,string type,string FP)
         {
             Sqlconn.Open();
             string sql = "update employeeTimeTable set startDate='" + startDate + "', endDate='" + endDAte + "', type='" + type + "',FP='"+FP+"' where Id='" + Id + "'";
             SqlCommand cmd = new SqlCommand(sql, Sqlconn);
             cmd.ExecuteNonQuery();
             Sqlconn.Close();
         }
         public void deleteTimeTablesEmp(int Id)
         {
             Sqlconn.Open();
             string sql = "delete employeeTimeTable where Id='" + Id + "'";
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
