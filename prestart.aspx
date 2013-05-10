<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prestart.aspx.cs" Inherits="prestart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_blank"/>

<title>testing</title>

</head>

<body>
<form id="form1" runat="server">

  <div >

     <div style="width:815px; height:auto; float:left; font-size:14px">
      <dl>
        <dt><b>系统介绍</b></dt>
          <dd>&nbsp;&nbsp;</dd>
          <dd>1、在线测试系统提供了“单项选择、多项选择、填空、改错、计算、综合”六大题型；</dd>
          <dd>2、提交测试结果后，系统将会自动给出正确答案；</dd>
          <dd>3、测试时可以自由选择题目数以及题型。</dd>
      </dl>
      <hr style="color:#CBCBCB; " />
      <dl>
        <dt><b>进入测试</b></dt>
          <dd>&nbsp;&nbsp;</dd>
          <dd>选择测试题型及题目：</dd>
       
          <dd>
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                  onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" Width="176px">
                  <asp:ListItem>单选题 【共 10 题】</asp:ListItem>
                  <asp:ListItem>多选题 【共 05 题】</asp:ListItem>
                  <asp:ListItem>改错题 【共 06 题】</asp:ListItem>
                  <asp:ListItem>填空题 【共 08 题】</asp:ListItem>
                  <asp:ListItem>计算题 【共 07 题】</asp:ListItem>
                  <asp:ListItem>综合题 【共 05 题】</asp:ListItem>
              </asp:RadioButtonList>
          </dd>
          <dd>选择题目量为：<asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="60px" ></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                  ControlToValidate="TextBox1" ErrorMessage="   请输入合适的正整数" 
                  ValidationExpression="^\+?[1-9][0-9]*$"></asp:RegularExpressionValidator>
                    </dd>
          <dd>&nbsp;&nbsp;</dd>
          <dd>
              <asp:Button ID="Button1" runat="server" Text="进入测试" onclick="Button1_Click" />
              <asp:Button ID="Button2" runat="server" Text="重新选择" onclick="Button2_Click" />
              <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
          </dd>
      </dl>     
     </div>
</div>
</form>
</body>
</html>