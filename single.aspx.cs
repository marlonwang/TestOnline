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

public partial class single : System.Web.UI.Page
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
        string sqlstr = "SELECT top " + Tinum + " * FROM singlechoice order by rnd(-1 * id + time())";
        OleDbDataAdapter MyAdapter = new OleDbDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        MyAdapter.Fill(ds);

        this.DataList1.DataSource = ds;
        this.DataList1.DataBind();//problem solved

        //this.GridView1.DataSource = ds;
        //this.GridView1.DataBind();
       

        sqlcon.Close();

    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        RadioButton r = (RadioButton)e.Item.FindControl("RadioButton1");
        r.Attributes.Add("onclick", "resetname('" + r.ClientID + "')");
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       //Datalist
        foreach (DataListItem dr in DataList1.Items)
        {
        string str = "";
        if (((RadioButton)dr.FindControl("RadioButton1")).Checked)
        {
            str = "A";

        }
        else if (((RadioButton)dr.FindControl("RadioButton2")).Checked)
        {
            str = "B";
        }
        else if (((RadioButton)dr.FindControl("RadioButton3")).Checked)
        {
            str = "C";
        }
        else if (((RadioButton)dr.FindControl("RadioButton4")).Checked)
        {
            str = "D";
        }
        if (((Label)dr.FindControl("answerLabel")).Text.Trim() == str)//将用户选择结果和答案进行比较
        {
           
            ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image2")).ImageUrl = ("image/right.jpg");
            ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image2")).Visible = true;

        }
        else if (((Label)dr.FindControl("answerLabel")).Text.Trim() != str)
        { 
            ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image2")).ImageUrl = ("image/wrong.jpg");
            ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image2")).Visible = true;
        }
        

       // Response.Write(((Label)dr.FindControl("answerLabel")).Text.Trim());

        //显示答案Label
        ((Label)DataList1.Items[dr.ItemIndex].FindControl("AnsLabel")).Visible = true;
        ((Label)DataList1.Items[dr.ItemIndex].FindControl("answerLabel")).Visible = true;
       }
    
      ////////////////////////
      //GridView
      ////////////////////////
        //Hashtable htsing = new Hashtable();
        //foreach (GridViewRow dr in GridView1.Rows)//对单选题每题进行判断用户选择答案
        //{

        //    string str = "";
        //    if (((RadioButton)dr.FindControl("RadioButton1")).Checked)
        //    {
        //        str = "A";

        //    }
        //    else if (((RadioButton)dr.FindControl("RadioButton2")).Checked)
        //    {
        //        str = "B";
        //    }
        //    else if (((RadioButton)dr.FindControl("RadioButton3")).Checked)
        //    {
        //        str = "C";
        //    }
        //    else if (((RadioButton)dr.FindControl("RadioButton4")).Checked)
        //    {
        //        str = "D";
        //    }
        //    if (((Label)dr.FindControl("answerLabel")).Text.Trim() == str)//将用户选择结果和答案进行比较
        //    {
               
        //        ((Image)GridView1.Rows[dr.RowIndex].FindControl("Image1")).ImageUrl = ("image/right.jpg");
        //        ((Image)GridView1.Rows[dr.RowIndex].FindControl("Image1")).Visible = true;

        //    }
        //    else if (((Label)dr.FindControl("answerLabel")).Text.Trim() != str)
        //    {     
        //        ((Image)GridView1.Rows[dr.RowIndex].FindControl("Image1")).ImageUrl = ("image/wrong.jpg");
        //        ((Image)GridView1.Rows[dr.RowIndex].FindControl("Image1")).Visible = true;
        //    }
        //    htsing.Add(dr.RowIndex, str);
        //    //显示答案Label
        //    ((Label)GridView1.Rows[dr.RowIndex].FindControl("AnsLabel")).Visible = true;
        //    ((Label)GridView1.Rows[dr.RowIndex].FindControl("answerLabel")).Visible = true;
        //}

        ///////////////////////////////////////////
        //Session["htsing"] = htsing;//保存单选题答案
        ///////////////////////////////////////////
        
          
        
    }
          
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("single.aspx");
    }
}
