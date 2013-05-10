<%@ Page Language="C#" AutoEventWireup="true" CodeFile="single.aspx.cs" Inherits="single" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>在线测试</title>
    
    <style type="text/css">
      #list1{ width:35px;}
      #list2{ width:30px;}
      #list4{ text-align:right; width:375px;}
      #list3{ text-align:left; width:375px;} 
    </style>
    
</head>



<body>
    <form id="form1" runat="server">
    
  <div  >
   
     <div style="width:810px; height:auto; float:left; font-size:14px">
      <div style="height:3px; width:815px"></div>
      <div style="width:815px; height:25px; line-height:25px; text-align:center; float:left; font-size:18px">
          <b>正在测试---<asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>选<asp:Label
              ID="Label3" runat="server" Text="" ForeColor="Red"></asp:Label>题</b>
          <hr style="color:#CBCBCB; " /> 
      </div>
      <div>
         <%-- <asp:GridView ID="GridView1" AutoGenerateColumns="False"  runat="server" 
              BorderStyle="None" GridLines="None">
              <RowStyle BorderStyle="None" />
              <EmptyDataRowStyle BorderStyle="None" />
           <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                  <table style="margin-top:20px;">
                       <tr><td  id="list1"></td><td  id="list2"><%# Container.DataItemIndex+1%>&nbsp;<img src="image/ask.jpg" alt="???" />&nbsp;&nbsp;</td>
                           <td colspan='2'><asp:Label ID="itemwtLabel" runat="server" Text='<%# Eval("itemwt") %>' /> ( ) 
                             <asp:Image ID="Image1" runat="server" Visible="False" /></td></tr>
                       <tr><td  id="list1"></td><td id="list2"></td><td colspan='2'>
                           
                           <asp:Label ID="AnsLabel" runat="server" Text="答案： " Visible="False" ForeColor="#3333CC"></asp:Label>
                             <asp:Label ID="answerLabel" runat="server" Text='<%# Eval("answer") %>' Visible="False" ForeColor="Red" /></td></tr>
                             
                       <tr><td  id="list1"></td><td id="list2"></td><td id="list3">A.
                           <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="single" /> 
                             <asp:Label ID="itemda1Label" runat="server" Text='<%# Eval("itemda1") %>' /></td>
                           
                           <td id="list3">B.<asp:RadioButton ID="RadioButton2" runat="server"  GroupName="single" /> 
                             <asp:Label ID="itemda2Label" runat="server" Text='<%# Eval("itemda2") %>' /></td></tr>
                       <tr><td id="list1"></td><td id="list2"></td><td id="list3">C.
                           <asp:RadioButton ID="RadioButton3" runat="server" GroupName="single" />
                             <asp:Label ID="itemda3Label" runat="server" Text='<%# Eval("itemda3") %>' /></td>
                           
                           <td id="list3">D.<asp:RadioButton ID="RadioButton4"  runat="server" GroupName="single" />
                             <asp:Label ID="itemda4Label" runat="server" Text='<%# Eval("itemda4") %>' /></td></tr>
                     </table>
               </ItemTemplate>
             </asp:TemplateField>
              
           </Columns>
              <FooterStyle BorderStyle="None" />
              <PagerStyle BorderStyle="None" />
              <SelectedRowStyle BorderStyle="None" />
              <HeaderStyle BorderStyle="None" />
              <EditRowStyle BorderStyle="None" />
              <AlternatingRowStyle BorderStyle="None" />
          </asp:GridView>--%>
          
          
          
             <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataKeyField="ID" 
                ForeColor="#333333" Width="815px">
                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                 <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                 <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <ItemTemplate>
                    <table style="margin-top:20px;">
                       <tr><td  id="list1"></td><td  id="list2"><%# Container.ItemIndex+1%>&nbsp;<img src="image/ask.jpg" alt="???" />&nbsp;&nbsp;</td>
                           <td colspan='2'><asp:Label ID="itemwtLabel" runat="server" Text='<%# Eval("itemwt") %>' /> ( )
                               <asp:Image ID="Image2" runat="server" Visible="False" /></td></tr>
                       <tr><td  id="list1"></td><td id="list2"></td><td colspan='2'>
                           
                           <asp:Label ID="AnsLabel" runat="server" Text="答案： " Visible="False" ForeColor="#3333CC"></asp:Label><asp:Label ID="answerLabel" runat="server" Text='<%# Eval("answer") %>' Visible="False" ForeColor="Red" /></td></tr>
                       <tr><td  id="list1"></td><td id="list2"></td><td id="list3">A.
                           <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="single" />  <asp:Label ID="itemda1Label" runat="server" Text='<%# Eval("itemda1") %>' /></td>
                           
                           <td id="list3">B.<asp:RadioButton ID="RadioButton2" runat="server"  GroupName="single" /> <asp:Label ID="itemda2Label" runat="server" Text='<%# Eval("itemda2") %>' /></td></tr>
                       <tr><td id="list1"></td><td id="list2"></td><td id="list3">C.
                           <asp:RadioButton ID="RadioButton3" runat="server" GroupName="single" /> <asp:Label ID="itemda3Label" runat="server" Text='<%# Eval("itemda3") %>' /></td>
                           
                           <td id="list3">D.<asp:RadioButton ID="RadioButton4"  runat="server" GroupName="single" /><asp:Label ID="itemda4Label" runat="server" Text='<%# Eval("itemda4") %>' /></td></tr>
                     </table>
                 </ItemTemplate>
             </asp:DataList>
             
             <table><tr><td id="list1"></td><td id="list2"></td>
                        <td id="list4"><asp:Button ID="Button1" runat="server" Text="提交" 
                                onclick="Button1_Click" />&nbsp;&nbsp;</td>
                        <td id="list3"><asp:Button ID="Button2" runat="server" Text="重置" 
                                onclick="Button2_Click" />
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
             </table>
             
     </div>
  </div>
  
</div>
    </form>
</body>
</html>
