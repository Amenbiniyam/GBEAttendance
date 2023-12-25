<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="TimeTableCreate.aspx.cs" Inherits="TimeTableCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
    }
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
        .auto-style4 {
        }
        .auto-style7 {
        }
        .auto-style11 {
            width: 173px;
        }
        .auto-style13 {
            width: 117px;
        }
        .auto-style17 {
            width: 35px;
        }
        .auto-style19 {
            width: 124px;
        }
        .auto-style20 {
            width: 45px;
        }
        .auto-style21 {
            width: 61px;
        }
        .auto-style22 {
            width: 54px;
        }
        .auto-style23 {
            width: 49px;
        }
        .style1
        {
            width: 81px;
        }
        .style2
        {
            width: 182px;
            height: 13px;
        }
        .style3
        {
            width: 61px;
            height: 13px;
        }
        .style4
        {
            width: 117px;
            height: 13px;
        }
        .style5
        {
            width: 54px;
            height: 13px;
        }
        .style8
        {
            width: 124px;
            height: 13px;
        }
        .style9
        {
            width: 35px;
            height: 13px;
        }
        .style10
        {
            width: 81px;
            height: 13px;
        }
        .style11
        {
            height: 13px;
        }
        .style12
        {
            width: 182px;
        }
        .style13
        {
            width: 134px;
            height: 13px;
        }
        .style14
        {
            width: 134px;
        }
        .style15
        {
            width: 15px;
            height: 13px;
        }
        .style16
        {
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
              <span class="auto-style3">Create Schedule Form</span>
           </h1>
        
        
        </section>
    <section class="content">
                       <!-- general form elements -->
              <div class="box box-primary" style="height:400px; top: 0px; left: 0px;">
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style4" colspan="13">
                                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                      DisplayMode="SingleParagraph" ForeColor="Red" />
                              </td>
                          </tr>
                          <tr>
                              <td class="style2"><asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
                              </td>
                              <td class="style3"></td>
                              <td class="style4">
                                  <asp:Label ID="Label3" runat="server" Text="On Duty Time:"></asp:Label>
                              </td>
                              <td class="style5">
                                  </td>
                              <td class="style4">
                                  <asp:Label ID="Label4" runat="server" Text="Early(In Minute):"></asp:Label>
                              </td>
                              <td class="style15"></td>
                              <td class="style13">
                                  <asp:Label ID="Label5" runat="server" Text="Absent(In Minute):"></asp:Label>
                              </td>
                              <td class="style5"></td>
                              <td class="style8">
                                  <asp:Label ID="Label6" runat="server" Text="Late(In Minute):"></asp:Label>
                              </td>
                              <td class="style9"></td>
                              <td class="style10">
                                  <asp:Label ID="Label7" runat="server" Text="Work day:"></asp:Label>
                              </td>
                              <td class="style9"></td>
                              <td class="style11">
                                  <asp:Label ID="lblDayType" runat="server" Text="Day Type:" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  <asp:TextBox ID="txtName" runat="server" Height="25px" Width="159px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtName" ErrorMessage="  *Name Required " ForeColor="Red" 
                                      Display="None"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  <asp:TextBox ID="txtonDutyTime" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  	
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                      ControlToValidate="txtonDutyTime" Display="None" 
                                      ErrorMessage="  *On Duty Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                  	
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  <asp:TextBox ID="txtEarly" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  	
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                      ControlToValidate="txtEarly" Display="None" ErrorMessage="  *Early Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                      ControlToValidate="txtEarly" Display="None" 
                                      ErrorMessage="* Early positive Integer " ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                  	
                              </td>
                              <td class="style16">
                                  &nbsp;</td>
                              <td class="style14">
                                  <asp:TextBox ID="txtAbsent" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                      ControlToValidate="txtAbsent" Display="None" ErrorMessage=" * Absent Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                      ControlToValidate="txtAbsent" Display="None" 
                                      ErrorMessage="* Abset positive Integer " ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  <asp:TextBox ID="txtLAte" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                      ControlToValidate="txtLAte" Display="None" ErrorMessage="*Late Required" 
                                      ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                      ControlToValidate="txtLAte" Display="None" 
                                      ErrorMessage="* Late positive Integer" ValidationExpression="^[1-9][0-9]*$"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style1">
                                  <asp:DropDownList ID="ddlWorkday" runat="server" Height="31px" 
                                      AutoPostBack="True" onselectedindexchanged="ddlWorkday_SelectedIndexChanged">
                                      <asp:ListItem>1</asp:ListItem>
                                      <asp:ListItem>0.5</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td>
                                  <asp:DropDownList ID="ddlDayType" runat="server" Height="31px" Visible="False">
                                      <asp:ListItem>Morning</asp:ListItem>
                                      <asp:ListItem>Afternoon</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="style16">
                                  &nbsp;</td>
                              <td class="style14">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style1">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style7" colspan="13">
                                   <fieldset style="height: 51px">
                                          <legend>Week Days</legend>

                                          <asp:CheckBoxList ID="chkWeekDAys" runat="server" DataMember="DefaultView" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" Height="20px" RepeatColumns="7" RepeatDirection="Horizontal" Width="100%">
                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                </asp:CheckBoxList>
                                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [weekDays]"></asp:SqlDataSource>

                                      </fieldset>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style7" colspan="13">
                                  
                                       <fieldset style="height: 90px">
                                          <legend>Holiday</legend>
                                           <asp:Panel ID="Panel1" runat="server" Height="75px" ScrollBars="Horizontal">
                                       <asp:CheckBoxList ID="chkHoliday" runat="server" DataSourceID="SqlDataSource2" DataTextField="HolidayName" DataValueField="Id" RepeatColumns="10" RepeatDirection="Horizontal" Width="100%">
                                      </asp:CheckBoxList>
                                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT [Id], [HolidayName] FROM [Holidays]"></asp:SqlDataSource>
                                     </asp:Panel>
                                                 </fieldset>
                                 
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="style16">
                                  &nbsp;</td>
                              <td class="style14">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style1">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style1" colspan="13">
                      <asp:Button  class = "btn btn-primary" ID="Button3" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                  &nbsp;<asp:Button  class = "btn btn-primary" ID="butClear" runat="server" 
                          Height="29px" Text="Clear" Width="72px" ForeColor="White" onclick="butClear_Click" CausesValidation="False" 
                         />
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Back to List</asp:LinkButton>
                              </td>
                          </tr>
                          <tr>
                              <td class="style12">
                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="style16">&nbsp;</td>
                              <td class="style14">&nbsp;</td>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style19">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td class="style1">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style12">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="style16">&nbsp;</td>
                              <td class="style14">&nbsp;</td>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style19">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td class="style1">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                      </table>
                  
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
</asp:Content>


