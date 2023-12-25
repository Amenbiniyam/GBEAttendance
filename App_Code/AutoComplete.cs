using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;

/// <summary>
[WebService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public  string[] GetCompletionList(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }
        DataTable dt = GetRecords(prefixText.ToUpper());
        List<string> items = new List<string>(count);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strName = dt.Rows[i][0].ToString();
            items.Add(strName);
        }
        return items.ToArray();
    }
    [WebMethod]
    public string[] GetCompletionListReport(string prefixText, int count)
    {
        if (count == 0)
        {
            count = 10;
        }
        DataTable dt = GetRecordsReport(prefixText.ToUpper());
        List<string> items = new List<string>(count);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string strName = dt.Rows[i][0].ToString();
            items.Add(strName);
        }
        return items.ToArray();
    }

    public DataTable GetRecords(string strName)
    {
        DataSet objDs = new DataSet();
        try
        {
            string strConn = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@Name", strName);
            cmd.CommandText = "Select (FullNAme+'='+cast (EmpId as varchar)) as FullName from viewEmp where FullNAme like @Name+'%'";
           
           // (fullName+'='+cast (shId as varchar))
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
           
        }
        catch (Exception ex)
        { 

        }
        return objDs.Tables[0];

        //SELECT branch_code,cust_ac_no,ac_desc FROM fcDebub Global v11.STTM_CUST_ACCOUNT WHERE ac_desc like 'SAMUEL KUMA JOTE'


    }
    public DataTable GetRecordsReport(string strName)
    {
        string strConn = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection con = new SqlConnection(strConn);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Parameters.AddWithValue("@Name", strName);
        cmd.CommandText = "SELECT DISTINCT FullName from tblApplicant where FullName like @Name+'%'";
        DataSet objDs = new DataSet();
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        dAdapter.SelectCommand = cmd;
        con.Open();
        dAdapter.Fill(objDs);
        con.Close();
        return objDs.Tables[0];


        //SELECT branch_code,cust_ac_no,ac_desc FROM fcDebub Global v11.STTM_CUST_ACCOUNT WHERE ac_desc like 'SAMUEL KUMA JOTE'


    }
    public DataTable GetRecords1(string strName)
    {
        string strConn = ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;
        OracleConnection con = new OracleConnection(strConn);
        con.Open();
        //OracleCommand cmd = new OracleCommand();
        //cmd.Connection = con;
        //cmd.CommandType = System.Data.CommandType.Text;
        //cmd.Parameters.AddWithValue("@Name", strName);
        string sqlcomm = " SELECT ac_desc FROM fcDebub Global v11.STTM_CUST_ACCOUNT WHERE upper(ac_desc) like'" + strName + "%'";
        DataSet objDs = new DataSet();
        //OracleDataAdapter dAdapter = new OracleDataAdapter();
        //dAdapter.SelectCommand = cmd;

        //dAdapter.Fill(objDs);
        //con.Close();
        //return objDs.Tables[0];

        OracleCommand cmd = new OracleCommand(sqlcomm, con);
        OracleDataAdapter da = new OracleDataAdapter(cmd);
        da.Fill(objDs);
        con.Close();
        return objDs.Tables[0];






    }

}


