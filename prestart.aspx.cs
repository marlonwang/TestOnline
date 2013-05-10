using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public partial class prestart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Button1.Attributes.Add("onclick", "this.form.target='_self'");
        // form1.Target = "_self";
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
                int x = Convert.ToInt32(TextBox1.Text.Trim());//是否数字
                //不是数字则以下 不执行
                System.Web.HttpCookie cookie1 = new HttpCookie("num");
                cookie1.Value = TextBox1.Text;
                Response.AppendCookie(cookie1);
                Response.Write(cookie1.Value);//测试题目数量cookies

               // if(Session["TiType"].ToString()!=null && x>=0)
                 //  Response.Redirect("tstart.aspx");

                if (RadioButtonList1.SelectedIndex == 0 && x >= 0)
                {
                    Response.Redirect("single.aspx");
                }
                else if (RadioButtonList1.SelectedIndex == 1 && x >= 0)
                {
                    Response.Redirect("mulity.aspx");
                }
                else if (RadioButtonList1.SelectedIndex == 2 && x >= 0)
                {
                    Response.Redirect("correct.aspx");
                }
                else if (RadioButtonList1.SelectedIndex == 3 && x >= 0)
                {
                    Response.Redirect("filling.aspx");
                }
                else if (RadioButtonList1.SelectedIndex == 4 && x >= 0)
                {
                    Response.Redirect("compute.aspx");
                }
                else if (RadioButtonList1.SelectedIndex == 5 && x >= 0)
                {
                    Response.Redirect("mixing.aspx");
                }
              
        }
        catch (System.Exception ex)
        {
            TextBox1.Text = "";
            Label1.Text = "请确定 已经选择 题型 及 题目量 再提交！";
           // Response.Write("<script language=javascript > alert('输入不为整数！')</script>");
        }      
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        
    }

    public void NumChecked()//暂时不用该函数
    {
        TextBox1.Text = "";
        bool flag = Regex.IsMatch(this.TextBox1.Text.Trim(), @"^\d+$");
        //如果匹配成功，Regex.IsMatch()将返回true,反之返回false
        if (flag)
        {
            Response.Write("<script>alert('验证成功！')</script>");
        }
        else
        {
            Response.Write("<script>alert('请输入数字！')</script>");
        }
        
    }
    //protected void TextBox1_TextChanged(object sender, EventArgs e)
    //{
    //   // NumChecked();
    //}

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string TimuType = RadioButtonList1.SelectedItem.Text;
        Session["TiType"] = TimuType;
        //Response.Write(Session["TiType"].ToString());//获取题目类型
    }
}
