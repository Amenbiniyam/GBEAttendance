using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default3 : System.Web.UI.Page
{
    MainDAL da = new MainDAL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet Ds = da.selectSalAll();
        for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
        {
            string empId = Ds.Tables[0].Rows[i][0].ToString();
            string sal = Ds.Tables[0].Rows[i][1].ToString();
            da.updateSal(sal, empId);
        
        
        }
    }
}