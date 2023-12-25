using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
   
   // public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
  public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    public int GetAllUserInfo(int a, int b)
    {
        return a + b;
    }
    [WebMethod]
    public DataTable getData(int iMachineNumber, string Ip, string Port)
    {
        //int idwErrorCode = 0;
        string sdwEnrollNumber = "";
        int idwVerifyMode = 0;
        int idwInOutMode = 0;
        int idwYear = 0;
        int idwMonth = 0;
        int idwDay = 0;
        int idwHour = 0;
        int idwMinute = 0;
        int idwSecond = 0;
        int idwWorkcode = 0;
        int iGLCount = 0;
        int iIndex = 0;
        DataTable DT = new DataTable("Table1");
       // DT.Columns.Add("Count");
        DT.Columns.Add("empId");
        DT.Columns.Add("date");
        DT.Columns.Add("time");
        //DT.Columns.Add("idwYear");
        //DT.Columns.Add("idwWorkcode");
        //DT.Columns.Add("idwWorkcode1");
        // axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
       // bool bIsConnected = axCZKEM1.Connect_Net(Ip, Convert.ToInt32(Port));
     //   if (bIsConnected == true)
      //  {
       //     axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
           


         ////   if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
         //   {
         //       while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
         //                  out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
         //       {
         //           iGLCount++;
         //           DataRow row = DT.NewRow();
         //           // row[0] = iGLCount.ToString();
         //           row[0] = sdwEnrollNumber;//modify by Darcy on Nov.26 2009
         //           // row[0] = idwWorkcode;
         //           row[1] = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString();
         //           row[2] = idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
         //           //row[5] = idwWorkcode.ToString();
         //           DT.Rows.Add(row);
         //           iIndex++;
         //       }
         //   }

       // }
       // axCZKEM1.Disconnect();
        return DT;
        //bindingSource = new BindingSource();

        //bindingSource.DataSource = DT;



        //dataGridView1.DataSource = bindingSource;
    }
    //public DataTable  getData(int iMachineNumber,string Ip,string Port)
    //    {
    //        //int idwErrorCode = 0;
    //        string sdwEnrollNumber = "";
    //        int idwVerifyMode = 0;
    //        int idwInOutMode = 0;
    //        int idwYear = 0;
    //        int idwMonth = 0;
    //        int idwDay = 0;
    //        int idwHour = 0;
    //        int idwMinute = 0;
    //        int idwSecond = 0;
    //        int idwWorkcode = 0;
    //        int iGLCount = 0;
    //        int iIndex = 0;
    //        DataTable DT = new DataTable("Table1");
    //        DT.Columns.Add("Count");
    //        DT.Columns.Add("sdwEnrollNumber");
    //        DT.Columns.Add("idwVerifyMode");
    //        DT.Columns.Add("idwInOutMode");
    //        DT.Columns.Add("idwYear");
    //        DT.Columns.Add("idwWorkcode");
    //        DT.Columns.Add("idwWorkcode1");
    //        // axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
    //        bool bIsConnected = axCZKEM1.Connect_Net(Ip, Convert.ToInt32(Port));
    //        if (bIsConnected == true)
    //        {
    //            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
    //            if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
    //            {
    //                while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
    //                           out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
    //                {
    //                    iGLCount++;
    //                    DataRow row = DT.NewRow();
    //                    row[0] = iGLCount.ToString();
    //                    row[1] = sdwEnrollNumber;//modify by Darcy on Nov.26 2009
    //                    row[2] = idwVerifyMode.ToString();
    //                    row[3] = idwInOutMode.ToString();
    //                    row[4] = idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString();
    //                    row[5] = idwWorkcode.ToString();
    //                    DT.Rows.Add(row);
    //                    iIndex++;
    //                }
    //            }
    //        }
    //        return DT;
    //        //bindingSource = new BindingSource();

    //        //bindingSource.DataSource = DT;



    //        //dataGridView1.DataSource = bindingSource;
    //    }

    //}
    
}

