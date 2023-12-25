using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.SqlClient;

using System.Web.Configuration;
/// <summary>
/// Summary description for DAL
/// </summary>
public class MainDAL
{
    public MainDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static String connStrSql = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    public SqlConnection Sqlconn = new SqlConnection(connStrSql);

    public static String connStrSql1 = WebConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
    public SqlConnection Sqlconn1 = new SqlConnection(connStrSql1);

    public DataSet selectSalAll()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "SELECT  empId,salary FROM tblSal order by empId ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;
    }
    public void updateSal(string salary, string EmpId)
    {
        Sqlconn1.Close();
        Sqlconn1.Open();
        // string passwordEnc = EnryptString(password);
        String sqlcomm = "update Employees set salary='" + salary + "' where EmpId='" + EmpId + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn1);
        cmd.ExecuteNonQuery();
        Sqlconn1.Close();

    }
    public void updateWL(double salary, string EmpId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        // string passwordEnc = EnryptString(password);
        String sqlcomm = "update    WaitingDataLists set DivId='" + salary + "' where TypeId =" + EmpId + "";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        cmd.ExecuteNonQuery();
        Sqlconn.Close();

    }

    public DataSet selectDepAut()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "SELECT EmpID,AutID FROM tblDepAut order by AutID ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;
    }

    public void deleteDepAut()
    {

        string sql = "delete from tblDepAut";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();
        Sqlconn.Close();
    }
    public void saveDepAut(DataSet ds)
    {

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            Sqlconn.Close();
            Sqlconn.Open();

            string sql = "insert into tblDepAut  (EmpID, AutID) values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "')";

            SqlCommand cmd = new SqlCommand(sql, Sqlconn);
            cmd.ExecuteNonQuery();
            Sqlconn.Close();
        }
    }
    public DataSet selectMachineAll()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select  id as ID, machNo as Machine_No, Ip as IP, port as Port,Description  from tblMachine order by id";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectMachinebyID(int Id)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select  id as ID, machNo as Machine_No, Ip as IP, port as Port,Description  from tblMachine where id='" + Id + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectUserAll()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select id As ID,userId as User_Id,role as Role from tblUser order by id";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectDataAll()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select * from tblData WHERE   (CONVERT(datetime, date) > '13-sep-2016')";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataTable saveData(DataTable dt)
    {
        DataTable dsA = selectDataAll().Tables[0];
        DataTable dtA = this.compareDataTables(dt, dsA);

        Sqlconn.Close();
        Sqlconn.Open();
        SqlBulkCopy sbc = new SqlBulkCopy(Sqlconn);
        sbc.DestinationTableName = "tblData";
        sbc.WriteToServer(dtA);
        sbc.Close();
        Sqlconn.Close();
        return dtA;

    }

    public DataTable compareDataTables(DataTable First, DataTable Second)
    {
        First.TableName = "FirstTable";
        Second.TableName = "SecondTable";


        DataTable table = new DataTable("Difference");
        DataTable table1 = new DataTable();

        //Must use a Dataset to make use of a DataRelation object
        using (DataSet ds4 = new DataSet())
        {
            //Add tables
            ds4.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
            // ds4.Tables1.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
            //Get Columns for DataRelation
            DataColumn[] firstcolumns = new DataColumn[ds4.Tables[0].Columns.Count];

            for (int i = 0; i < firstcolumns.Length; i++)
            {
                firstcolumns[i] = ds4.Tables[0].Columns[i];

            }

            DataColumn[] secondcolumns = new DataColumn[ds4.Tables[1].Columns.Count];

            for (int i = 0; i < secondcolumns.Length; i++)
            {
                secondcolumns[i] = ds4.Tables[1].Columns[i];
            }



            //Create DataRelation
            DataRelation r = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);

            ds4.Relations.Add(r);

            //Create columns for return table
            for (int i = 0; i < First.Columns.Count; i++)
            {
                table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                table1.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
            }

            //If First Row not in Second, Add to return table.
            table.BeginLoadData();

            foreach (DataRow parentrow in ds4.Tables[0].Rows)
            {
                DataRow[] childrows = parentrow.GetChildRows(r);
                //foreach (DataColumn parentCol in ds4.Tables[0].Columns)
                //{

                if (childrows == null || childrows.Length == 0)
                {
                    table.LoadDataRow(parentrow.ItemArray, true);
                    //table.LoadDataRow(parentrow.ItemArray, true);
                    //table.Rows.Add(parentrow[parentCol].ToString());

                }
                // table.LoadDataRow(childrows, false);
                // table1.Rows.Add(parentrow[parentCol].ToString());
                //}

            }

            table.EndLoadData();

        }

        return table;
    }


    public DataSet selectDataAll(DateTime from, DateTime to)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select    empId,CONVERT(VARCHAR(11), date, 106) AS date , time FROM  tblData where date  between '" + from + "' and '" + to + "' and time<'10:00:00'  order by date,empId";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public void saveMachine(int machNo, string Ip, string port, string Description)
    {

        //string passwordEnc = EnryptString(password);
        string sql = "insert into tblMachine( machNo, Ip, port,Description ) values ('" + machNo + "','" + Ip + "','" + port + "','" + Description + "')";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();
        Sqlconn.Close();


    }
    public void updateMachine(int machNo, string Ip, string port, int id, string Description)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        // string passwordEnc = EnryptString(password);
        String sqlcomm = "update tblMachine set machNo='" + machNo + "',Ip='" + Ip + "',port='" + port + "',Description='" + Description + "'  where id=" + id + "";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        cmd.ExecuteNonQuery();
        Sqlconn.Close();

    }
    public void deleteMachine(int id)
    {

        string sql = "delete from tblMachine where Id=" + id + "";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();

    }

    public void saveExpLeave(int empId)
    {

        //string passwordEnc = EnryptString(password);
        string sql = "insert into tblExLeave( EmpID ) values ('" + empId + "')";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();
        Sqlconn.Close();


    }
    public void deleteExpLeave(int empId)
    {

        string sql = "delete from tblExLeave where EmpID=" + empId + "";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();

    }


    public void saveUser(string userName, string password, int role, int empId, string Email)
    {

        string passwordEnc = EnryptString(password);
        string sql = "insert into tblUser(userId, password, role, empId,Email) values ('" + userName + "','" + passwordEnc + "','" + role + "','" + empId + "','" + Email + "')";
        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();


    }
    public void updateUser(string userName, string password, int role, int empId, int id, string Email)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        string passwordEnc = EnryptString(password);
        String sqlcomm = "update tblUser set userId='" + userName + "',password='" + passwordEnc + "',role='" + role + "',empId='" + empId + "',Email='" + Email + "' where id=" + id + "";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        cmd.ExecuteNonQuery();

    }
    public void deleteUser(int id)
    {

        string sql = "delete from tblUser where id=" + id + "";

        Sqlconn.Close();
        Sqlconn.Open();
        SqlCommand cmd = new SqlCommand(sql, Sqlconn);
        cmd.ExecuteNonQuery();

    }
    public void saveUserInfo(String username, String password)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        string ecPassword = EnryptString(password);
        String sqlcomm = "INSERT INTO tblUser(UserName,Password)values('" + username.ToLower() + "','" + ecPassword + "')";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        cmd.ExecuteNonQuery();

    }
    //EnryptString
    private string EnryptString(string strEncrypted)
    {
        byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
        string encryptedConnectionString = Convert.ToBase64String(b);
        return encryptedConnectionString;
    }
    //DecryptString
    private string DecryptString(string encrString)
    {
        byte[] b = Convert.FromBase64String(encrString);
        string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b);
        return decryptedConnectionString;

    }
    public string selectUser(string userName)
    {
        // DataSet ds = new DataSet();
        string userN = null;
        Sqlconn.Close();
        Sqlconn.Open();
        String sqlComm = "select userId from tblUser where userId='" + userName + "'";
        SqlCommand cmd = new SqlCommand(sqlComm, Sqlconn);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
            userN = reader[0].ToString();
        Sqlconn.Close();
        return userN;


    }
    public String selectUserInformation(String userName)
    {
        DataSet ds = new DataSet();
        Sqlconn.Close();
        Sqlconn.Open();
        String sqlComm = "select Password from tblUser where userId='" + userName.ToLower() + "' ";
        SqlCommand cmd = new SqlCommand(sqlComm, Sqlconn);
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        string password = null;
        if (reader.Read())
            password = reader[0].ToString();
        password = DecryptString(password);
        return password;


    }
    public String selectPassword(String userName)
    {

        Sqlconn.Close();
        Sqlconn.Open();
        String sqlComm = "select Password from tblUser where UserId='" + userName + "'";
        SqlCommand cmd = new SqlCommand(sqlComm, Sqlconn);
        string password = DecryptString(cmd.ExecuteScalar().ToString());
        return password;

    }
    public void changePassword(String password, String userName)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        string enPassword = EnryptString(password);
        String sqlComm = "UPDATE tblUser set Password='" + enPassword + "' where UserId='" + userName.ToLower() + "'";
        SqlCommand cmd = new SqlCommand(sqlComm, Sqlconn);
        cmd.ExecuteNonQuery();

    }
    public String selectUserRole(String userName)
    {

        Sqlconn.Close();
        Sqlconn.Open();
        String sqlComm = "select Role from tblUser where UserId='" + userName + "' ";
        SqlCommand cmd = new SqlCommand(sqlComm, Sqlconn);
        string role = cmd.ExecuteScalar().ToString();
        Sqlconn.Close();
        return role;


    }
    public DataSet selectMenuChild(string Role, string parent)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = " select * from viewMenuRole where RoleID='" + Role + "' and parnt='" + parent + "' order by Ord";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet UserData(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = " select * from viewUserRole where empId='" + empId + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet FP(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = " select FP from Employees where empId='" + empId + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet UserMail(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = " select Email from tblUser where empId='" + empId + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectMenu(string Role)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select DISTINCT parnt from viewMenuRole where RoleID='" + Role + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectMenuRole(string Role, string URL)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select DISTINCT parnt from viewMenuRole where RoleID='" + Role + "' and URL='" + URL + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectUnMail()
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = " select Email from tblUser  where Email !='' and Email not like '&%' and  empId in (select DISTINCT CurrentApprover from LeaveRequests where ProgressStatus in ('Reversal Unauthorized','Unauthorized')) ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }

    public DataSet selectEmpIDUser(string userID)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select  empId FROM   tblUser where userID='" + userID + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectExpLeave(int EmpId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "SELECT EmpID FROM  tblExLeave where EmpID='" + EmpId + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectEmpAut(int depId, string role)
    {
        Sqlconn.Close();
        Sqlconn.Open();

        string depIds = depId.ToString();
        string DePS = "'" + depIds + "'";
        //"'3','4'"

        //if ( depId>=20)
        //{
        //    if (depId <= 31)
        //    {
        //        DePS = DePS + "," + "'15'";
        //    }

        //}
        DataSet ds = new DataSet();
        String sqlcomm = "select  empId,FullNAme FROM   viewEmpROle where Id in (" + DePS + ") and role in (" + role + ") order by role";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectDepAut(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select  AutId FROM   tblDepAut where empId='" + empId + "' ";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectEmpAutRole(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select role FROM   viewEmpROle where empId='" + empId + "'";
        SqlCommand cmd = new SqlCommand(sqlcomm, Sqlconn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        Sqlconn.Close();
        return ds;

    }
    public DataSet selectFullNAme(int empId)
    {
        Sqlconn.Close();
        Sqlconn.Open();
        DataSet ds = new DataSet();
        String sqlcomm = "select FullNAme,empId FROM   viewEmp where empId='" + empId + "'";
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
