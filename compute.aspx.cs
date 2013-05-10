using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class compute : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Attributes.Add("onclick", "this.form.target='_self'");

        if (Session["TiType"] == null)
        {
            Response.Redirect("prestart.aspx");
        }
        else

            Label1.Text = Session["TiType"].ToString();
            Label3.Text = Request.Cookies["num"].Value.ToString();

        if (!IsPostBack)
         {
            Banding();
         }

        // 数据库中无 目的 的 自动添加目的
        foreach (DataListItem dr in DataList1.Items)
        {
            //可实现
            if (((Label)dr.FindControl("itemwtLabel")).Text.Trim() == "")
                ((Label)DataList1.Items[dr.ItemIndex].FindControl("Label4")).Visible = true;
        }
    }
    protected void Banding()
    {
        //string str = Request.Cookies["num"].ToString();
        // int TiNum = int.Parse(str);

        int Tinum = int.Parse(Request.Cookies["num"].Value);
        OleDbConnection sqlcon;
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|ItemPool.mdb";

        sqlcon = new OleDbConnection(strCon);
        sqlcon.Open();
        string sqlstr = "SELECT top " + Tinum + " * FROM counting order by rnd(-1 * id + time())";
        OleDbDataAdapter MyAdapter = new OleDbDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        MyAdapter.Fill(ds);
        this.DataList1.DataSource = ds;
        this.DataList1.DataBind();//problem solved
        sqlcon.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (DataListItem dr in DataList1.Items)
        {
            //暂时不可实现
            if (((Label)dr.FindControl("itemwtLabel")).Text.Trim() == "")
                ((Label)DataList1.Items[dr.ItemIndex].FindControl("Label4")).Visible = true;

            ((Label)DataList1.Items[dr.ItemIndex].FindControl("AnsLabel")).Visible = true;
            ((Label)DataList1.Items[dr.ItemIndex].FindControl("answerLabel")).Visible = true;

        }    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("compute.aspx");
    }
}
