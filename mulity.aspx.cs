﻿using System;
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

public partial class mulity : System.Web.UI.Page
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
      
        //RandNum();

    }
    protected void Banding()
    {
        //string str = Request.Cookies["num"].ToString();
       // int TiNum = int.Parse(str);
        
        int Tinum =int.Parse(Request.Cookies["num"].Value);
        OleDbConnection sqlcon;
        string strCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|ItemPool.mdb";

        sqlcon = new OleDbConnection(strCon);
        sqlcon.Open();
        string sqlstr = "SELECT top " + Tinum + " * FROM mulitychoice order by rnd(-1 * id + time())";
        OleDbDataAdapter MyAdapter = new OleDbDataAdapter(sqlstr, sqlcon);
        DataSet ds = new DataSet();
        MyAdapter.Fill(ds);
        this.DataList1.DataSource = ds;
        this.DataList1.DataBind();//problem solved
        sqlcon.Close();

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hashtable htMulit = new Hashtable();
        foreach (DataListItem dr in DataList1.Items)
        {
            string str = "";
            if (((CheckBox)dr.FindControl("CheckBox1")).Checked)
            {
                str += "A";
            }
            if (((CheckBox)dr.FindControl("CheckBox2")).Checked)
            {
                str += "B";
            }
            if (((CheckBox)dr.FindControl("CheckBox3")).Checked)
            {
                str += "C";
            }
            if (((CheckBox)dr.FindControl("CheckBox4")).Checked)
            {
                str += "D";
            }
            if (((Label)dr.FindControl("answerLabel")).Text.Trim() == str)//将用户选择结果和答案进行比较
            {
                
                ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image1")).ImageUrl = ("image/right.jpg");
                ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image1")).Visible = true;

            }
            else if (((Label)dr.FindControl("answerLabel")).Text.Trim() != str)
            {
                ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image1")).ImageUrl = ("image/wrong.jpg");
                ((Image)DataList1.Items[dr.ItemIndex].FindControl("Image1")).Visible = true;
            }

             //Response.Write(((Label)dr.FindControl("answerLabel")).Text.Trim());//显示成功

            //显示答案
            ((Label)DataList1.Items[dr.ItemIndex].FindControl("AnsLabel")).Visible = true;
            ((Label)DataList1.Items[dr.ItemIndex].FindControl("answerLabel")).Visible = true;

            htMulit.Add(dr.ItemIndex, str);

        }
       
        
    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("mulity.aspx");
    }
}
