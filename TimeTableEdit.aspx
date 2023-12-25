<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="TimeTableEdit.aspx.cs" Inherits="TimeTableEdit" %>

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
            width: 37px;
        }
        .style2
        {
            width: 79px;
        }
        .style3
        {
            width: 183px;
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
                              </td>
                          </tr>
                          <tr>
                              <td class="style3"><asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>
                              </td>
                              <td class="auto-style21">&nbsp;</td>
                              <td class="auto-style13">
                                  <asp:Label ID="Label3" runat="server" Text="On Duty Time:"></asp:Label>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  <asp:Label ID="Label4" runat="server" Text="Early:"></asp:Label>
                              </td>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style20">
                                  <asp:Label ID="Label5" runat="server" Text="Absent:"></asp:Label>
                              </td>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style19">
                                  <asp:Label ID="Label6" runat="server" Text="Late:"></asp:Label>
                              </td>
                              <td class="auto-style17">&nbsp;</td>
                              <td class="style2">
                                  <asp:Label ID="Label7" runat="server" Text="Work day:"></asp:Label>
                              </td>
                              <td class="auto-style17">&nbsp;</td>
                              <td>
                                  <asp:Label ID="lblDayType" runat="server" Text="Day Type:" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="style3">
                                  <asp:TextBox ID="txtName" runat="server" Height="25px" Width="159px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  <asp:TextBox ID="txtonDutyTime" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  	
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  <asp:TextBox ID="txtEarly" runat="server" Height="25px" Width="100px"></asp:TextBox>
                                  	
                              </td>
                              <td class="auto-style23">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  <asp:TextBox ID="txtAbsent" runat="server" Height="25px" Width="100px"></asp:TextBox>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  <asp:TextBox ID="txtLAte" runat="server" Height="25px" Width="100px"></asp:TextBox>
                              </td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style2">
                                  <asp:DropDownList ID="ddlWorkday" runat="server" Height="31px" 
                                      AutoPostBack="True" onselectedindexchanged="ddlWorkday_SelectedIndexChanged">
                                      <asp:ListItem>1</asp:ListItem>
                                      <asp:ListItem>0.5</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style1">
                                  <asp:DropDownList ID="ddlDayType" runat="server" Height="31px" Visible="False">
                                      <asp:ListItem>Morning</asp:ListItem>
                                      <asp:ListItem>Afternoon</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style23">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style2">
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

                                          <asp:CheckBoxList ID="chkWeekDAys" runat="server"  Height="20px" RepeatColumns="7" RepeatDirection="Horizontal" Width="100%">
                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                </asp:CheckBoxList>

                                      </fieldset>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style7" colspan="13">
                                  
                                       <fieldset style="height: 90px">
                                          <legend>Holiday</legend>
                                           <asp:Panel ID="Panel1" runat="server" Height="75px" ScrollBars="Horizontal">
                                       <asp:CheckBoxList ID="chkHoliday" runat="server"   RepeatColumns="10" RepeatDirection="Horizontal" Width="100%">
                                      </asp:CheckBoxList>
                                     </asp:Panel>
                                                 </fieldset>
                                 
                              </td>
                          </tr>
                          <tr>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style23">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style19">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td class="style2">
                                  &nbsp;</td>
                              <td class="auto-style17">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style1" colspan="13">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style3">
                      <asp:Button  class = "btn btn-success" ID="Button3" runat="server" Height="29px" Text="Update" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                  &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Back to List</asp:LinkButton>
                              </td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style20">&nbsp;</td>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style19">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td class="style2">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style3">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style20">&nbsp;</td>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style19">&nbsp;</td>
                              <td class="auto-style17">&nbsp;</td>
                              <td class="style2">&nbsp;</td>
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


