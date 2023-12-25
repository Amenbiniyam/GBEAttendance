<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="AttendanceAndLeaveManagementSystem.NewUser2" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
        .auto-style4 {
        }
        .auto-style6 {
            width: 297px;
        }
        .auto-style7 {
            width: 248px;
        }
        .auto-style10 {
            width: 248px;
            height: 5px;
        }
        .auto-style16 {
            width: 248px;
            height: 21px;
        }
        .auto-style17 {
            width: 279px;
            height: 21px;
        }
        .auto-style22 {
    }
        .auto-style23 {
            width: 100px;
            height: 21px;
        }
        .auto-style26 {
            width: 553px;
            height: 21px;
        }
        .auto-style29 {
            width: 553px;
        }
        .auto-style30 {
            width: 279px;
        }
    .auto-style31 {
        width: 100px;
        height: 25px;
    }
    .auto-style32 {
        width: 248px;
        height: 25px;
    }
    .auto-style33 {
            width: 279px;
            height: 25px;
        }
    .auto-style34 {
        width: 553px;
        height: 25px;
    }
        .auto-style35 {
            width: 143px;
            height: 21px;
        }
        .auto-style38 {
            width: 143px;
        }
        .auto-style39 {
            width: 143px;
            height: 25px;
        }
        .auto-style40 {
            width: 106px;
            height: 21px;
        }
        .auto-style43 {
            width: 106px;
        }
        .auto-style44 {
            width: 106px;
            height: 25px;
        }
        .auto-style45 {
            width: 100%;
        }
        .auto-style46 {
            width: 83px;
        }
        .auto-style47 {
            width: 14px;
        }
        .auto-style48 {
            width: 100px;
            height: 31px;
        }
        .auto-style49 {
            width: 248px;
            height: 31px;
        }
        .auto-style50 {
            width: 143px;
            height: 31px;
        }
        .auto-style51 {
            width: 279px;
            height: 31px;
        }
        .auto-style52 {
            width: 106px;
            height: 31px;
        }
        .auto-style53 {
            width: 553px;
            height: 31px;
        }
        .auto-style54 {
            width: 100px;
            height: 34px;
        }
        .auto-style55 {
            width: 248px;
            height: 34px;
        }
        .auto-style56 {
            width: 143px;
            height: 34px;
        }
        .auto-style57 {
            width: 279px;
            height: 34px;
        }
        .auto-style58 {
            width: 106px;
            height: 34px;
        }
        .auto-style59 {
            width: 553px;
            height: 34px;
        }
        .style1
        {
            width: 522px;
            height: 21px;
        }
        .style2
        {
            width: 522px;
            height: 34px;
        }
        .style3
        {
            width: 522px;
            height: 25px;
        }
        .style4
        {
            width: 513px;
            height: 21px;
        }
        .style5
        {
            width: 513px;
            height: 34px;
        }
        .style6
        {
            width: 513px;
            height: 25px;
        }
        .style7
        {
            width: 536px;
            height: 21px;
        }
        .style8
        {
            width: 536px;
            height: 34px;
        }
        .style9
        {
            width: 536px;
            height: 25px;
        }
        .style10
        {
            height: 21px;
        }
        .style11
        {
            width: 214px;
            height: 34px;
        }
        .style12
        {
            height: 25px;
        }
    </style>  <style type="text/css">
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
        .auto-style7 {
        }
        .auto-style13 {
            width: 187px;
        }
        .auto-style22 {            height: 34px;
        }
        .auto-style35 {
    }
    .auto-style36 {
        height: 3px;
    }
        .auto-style37 {
            width: 311px;
        }
        .style17
        {
            width: 100%;
        }
        .style18
        {
            width: 172px;
        }
        .style19
        {
            width: 22px;
        }
        .style20
        {
        }
        .style30
        {
            width: 14px;
            height: 9px;
        }
        .style31
        {
            height: 9px;
        }
        .style32
        {
            width: 22px;
            height: 9px;
        }
        .style33
        {
            width: 14px;
            height: 33px;
        }
        .style35
        {
            height: 33px;
        }
        .style36
        {
            height: 7px;
        }
        .style37
        {
            width: 22px;
            height: 7px;
        }
    </style>
  
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
              <span class="auto-style3">Manage User Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>             
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="10">
                                
                                      <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                      <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                          DisplayMode="SingleParagraph" ForeColor="Red" />
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="style10">
                                  <asp:Label ID="Label11" runat="server" Text="Employee Name:"></asp:Label>
                              </td>
                              <td class="auto-style35">&nbsp;</td>
                              <td class="auto-style35">
                                  &nbsp;</td>
                              <td class="auto-style35">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="style1">
                                  &nbsp;</td>
                              <td class="style4">
                                  &nbsp;</td>
                              <td class="style7">
                                  &nbsp;</td>
                              <td class="auto-style6" rowspan="9">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style23">
                                  &nbsp;</td>
                              <td class="style10" colspan="5">
                                   <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" 
            ontextchanged="txtName_TextChanged" TabIndex="1"  Width="250px" Height="25px"  ></asp:TextBox>
            <ajaxToolkit:CollapsiblePanelExtender  CollapsedImage="AttReport.aspx"  />
                  <ajaxToolkit:AutoCompleteExtender
                                 runat="server" 
                                 ID="AutoCompleteExtender1" 
                                 TargetControlID="txtName"
                                 ServicePath="AutoComplete.asmx" 
                                 ServiceMethod="GetCompletionList"
                                 MinimumPrefixLength="1" 
                                 CompletionInterval="10"
                                 EnableCaching="true"
                                 CompletionSetCount="12" /></td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="style1">
                                  &nbsp;</td>
                              <td class="style4">
                                  &nbsp;</td>
                              <td class="style7">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style23">
                                  &nbsp;</td>
                              <td class="style10">
                                  <asp:Label ID="Label2" runat="server" Text="User Id:"></asp:Label>
                              </td>
                              <td class="auto-style35">
                                  &nbsp;</td>
                              <td class="auto-style35">
                                  <asp:Label ID="Label8" runat="server" Text="Role:"></asp:Label>
                              </td>
                              <td class="auto-style35">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
                              </td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="style1">
                                  <asp:Label ID="Label9" runat="server" Text="Confirm Password:"></asp:Label>
                              </td>
                              <td class="style4">
                                  &nbsp;</td>
                              <td class="style7">
                                  <asp:Label ID="Label10" runat="server" Text="EmpID:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style54"></td>
                              <td class="style11">
                                  <asp:TextBox ID="txtUserId" runat="server" Height="25px" Width="163px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtUserId" Display="None" ErrorMessage="* User ID Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style56">
                                  &nbsp;</td>
                              <td class="auto-style56">
                                  <asp:DropDownList ID="ddlRole" runat="server" Height="30px" 
                                      OnSelectedIndexChanged="ddlCons_SelectedIndexChanged" Width="102px" 
                                      DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                                      <asp:ListItem>No</asp:ListItem>
                                      <asp:ListItem>Yes</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" 
                                      SelectCommand="SELECT [Id], [Name] FROM [tblRole]"></asp:SqlDataSource>
                              </td>
                              <td class="auto-style56">
                                  &nbsp;</td>
                              <td class="auto-style57">
                                  <asp:TextBox ID="txtPassword" runat="server" Height="25px" Width="200px" 
                                      TextMode="Password"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                      ControlToValidate="txtPassword" Display="None" 
                                      ErrorMessage="* Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style58">
                                  </td>
                              <td class="style2">
                                  <asp:TextBox ID="txtConPassword" runat="server" Height="25px" Width="200px" 
                                      TextMode="Password"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                      ControlToValidate="txtConPassword" Display="None" 
                                      ErrorMessage="* confirm Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="style5">
                                  </td>
                              <td class="style8">
                                  <asp:TextBox ID="txtEmpId" runat="server" Height="27px" Width="98px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                      ControlToValidate="txtEmpId" Display="None" ErrorMessage="*EMP ID Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style54">
                                  &nbsp;</td>
                              <td class="style11">
                                  <asp:Label ID="Label12" runat="server" Text="Email:"></asp:Label>
                                  <asp:TextBox ID="txtEmail" runat="server" Height="31px" Width="202px"></asp:TextBox>
                              </td>
                              <td class="auto-style56">
                                  &nbsp;</td>
                              <td class="auto-style56">
                                  &nbsp;</td>
                              <td class="auto-style56">
                                  &nbsp;</td>
                              <td class="auto-style57">
                                  &nbsp;</td>
                              <td class="auto-style58">
                                  &nbsp;</td>
                              <td class="style2">
                                  &nbsp;</td>
                              <td class="style5">
                                  &nbsp;</td>
                              <td class="style8">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style31"></td>
                              <td class="style12">
                                  <asp:Button  class = "btn btn-primary" ID="butSave" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                            
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="False">
                                      <table class="auto-style45">
                                          <tr>
                                              <td class="auto-style46">
                                                  <asp:Button ID="butUpdate" runat="server" class="btn btn-success" ForeColor="White" Height="31px"  Text="Update" Width="74px" OnClick="butUpdate_Click" />
                                              </td>
                                              <td class="auto-style47">
                                                  <asp:Button ID="Button4" runat="server" class="btn btn-default" Height="31px" OnClick="Button4_Click" OnClientClick="return Hidepopup()" style="text-align: center" Text="NO" Width="58px" />
                                              </td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                      </table>
                                  </asp:Panel>
                                                   
                                  
                                  
                                    </td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style33">
                                  <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                      ControlToCompare="txtPassword" ControlToValidate="txtConPassword" 
                                      ErrorMessage="* Passwords do not match" Display="None" ForeColor="Red"></asp:CompareValidator>
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="style3">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                      ControlToValidate="txtEmpId" Display="None" ErrorMessage="* EMP-ID Integer " 
                                      ForeColor="Red" ValidationExpression="^[1-9]([0-9]*,?)*$"></asp:RegularExpressionValidator>
                              </td>
                              <td class="style6">
                                  </td>
                              <td class="style9">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style31">
                                  &nbsp;</td>
                              <td class="style12">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style33">
                                  &nbsp;</td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="style6">
                                  &nbsp;</td>
                              <td class="style9">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style31">&nbsp;</td>
                              <td class="style12">
                                  
                                  <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" 
                                      SelectCommand="SELECT * FROM [viewUserRole]"></asp:SqlDataSource>
                                         <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" 
            ontextchanged="TextBox1_TextChanged" TabIndex="1"  Width="250px" Height="25px"  ></asp:TextBox>
            <ajaxToolkit:CollapsiblePanelExtender  CollapsedImage="AttReport.aspx"  />
                  <ajaxToolkit:AutoCompleteExtender
                                 runat="server" 
                                 ID="AutoCompleteExtender2" 
                                 TargetControlID="TextBox1"
                                 ServicePath="AutoComplete.asmx" 
                                 ServiceMethod="GetCompletionList"
                                 MinimumPrefixLength="1" 
                                 CompletionInterval="10"
                                 EnableCaching="true"
                                 CompletionSetCount="12" />
                              </td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  <asp:Button ID="Button1" runat="server" CausesValidation="False" 
                                      class="btn btn-primary" ForeColor="White" Height="29px" 
                                      onclick="Button1_Click1" Text="All User" Width="72px" />
                                </td>
                              <td class="auto-style39">
                              
                                  &nbsp;</td>
                              <td class="auto-style33">
                              
                                  <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                                 
                            
                                  
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="style6">
                                  &nbsp;</td>
                              <td class="style9">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style31">
                                  &nbsp;</td>
                              <td class="style12">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style33">
                                  &nbsp;</td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="style6">
                                  &nbsp;</td>
                              <td class="style9">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22" colspan="11">
                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="250px">
                                        
                           

                           <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  
                                           AllowPaging="True" AllowSorting="True"  
                                           class="table table-bordered table-striped"  Width="1014px" PageSize="5"  
                                           CssClass="table-striped"  DataSourceID="SqlDataSource2" 
                                           onselectedindexchanged="GridView2_SelectedIndexChanged">
                                      <Columns>
                                          <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                          <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" 
                                              SortExpression="userId" />
                                        
                                          <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                                              SortExpression="Name" />
                                               <asp:BoundField DataField="empId" HeaderText="empId" ReadOnly="True" 
                                              SortExpression="empId" />
                                               <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                                              SortExpression="Email" />
                                              <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton  CausesValidation="false" ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?');" />
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
     </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>   
                                      </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                  </asp:GridView>
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  
                                           AllowPaging="True" AllowSorting="True"  
                                           class="table table-bordered table-striped"  Width="1014px" PageSize="5"  
                                           CssClass="table-striped" Visible="False"  >
                                      <Columns>
                                          <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                          <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" 
                                              SortExpression="userId" />
                                        
                                          <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                                              SortExpression="Name" />
                                               <asp:BoundField DataField="empId" HeaderText="empId" ReadOnly="True" 
                                              SortExpression="empId" />
                                                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" 
                                              SortExpression="Email" />
                                              <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton  CausesValidation="false" ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?');" />
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
     </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>   
                                      </Columns>
                                        <PagerStyle CssClass="pagination-ys" />
                                  </asp:GridView>
                                  </asp:Panel>
                              </td>
                          </tr>
                          </table>
   


    </ContentTemplate>
</asp:UpdatePanel>          
                
        
        </section>
    </div>
    </div>
</asp:Content>


