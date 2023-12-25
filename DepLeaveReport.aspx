<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="DepLeaveReport.aspx.cs" Inherits="DepLeaveReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
    </style>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <span class="auto-style3">Leave Report Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style22" colspan="5">
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                  <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:Label ID="Label9" runat="server" Text="Start Date:"></asp:Label>
                                  </td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:Label ID="lblEndDAte" runat="server" Text="End Date:"></asp:Label>
                              </td>
                              <td class="auto-style36">
                                
                                  &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:Label ID="Label10" runat="server" Text="Employee Name:"></asp:Label>
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:TextBox ID="txtHiredDate" runat="server" Height="25px" Width="147px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="16px" CausesValidation="False"  />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHiredDate" Display="None" ErrorMessage="Start Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                  </td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:TextBox ID="txtEndDate" runat="server" Height="25px" Width="177px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate" Display="None" ErrorMessage="End Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style36">
                                
                                  &nbsp;</td>
                              <td class="auto-style36">
                                
                                    <asp:DropDownList ID="ddlEmployee" runat="server" Height="33px" 
                                      onselectedindexchanged="ddlEmployee_SelectedIndexChanged" Width="233px">
                                  </asp:DropDownList>
                                    
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generate Report" Height="32px" />
                                  </td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                      TypeName="AttendanceAndLeaveManagementSystem.AttAllTableAdapters.">
                                  </asp:ObjectDataSource>
                              </td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style35" colspan="5">
                                  <asp:GridView ID="GridView1" runat="server" Visible="False">
                                  </asp:GridView>
                                   <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="AttAllTableAdapters."></asp:ObjectDataSource>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                                      Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
                                      Height="329px" Visible="False" Width="100%" 
                                      InteractiveDeviceInfos="(Collection)">
                                      <LocalReport ReportEmbeddedResource="LeaveReport.rdlc" ReportPath="LeaveReport.rdlc">
                                          <DataSources>
                                              <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet1" />
                                          </DataSources>
                                      </LocalReport>
                                  </rsweb:ReportViewer>
                                   <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                      TypeName="leaveRTableAdapters."></asp:ObjectDataSource>
                                   </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                           &nbsp;</td>
                              <td class="auto-style7">
                                           &nbsp;</td>
                              <td class="auto-style7">
                                           &nbsp;</td>
                              <td class="auto-style7">
                                           &nbsp;</td>
                          </tr>
                          </table>
                       <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtHiredDate" PopupButtonID="ImageButton2"/>
                             
                                  <cc1:CalendarExtender ID="CalendarExtender4" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtEndDate" PopupButtonID="ImageButton3"/>
                  
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                  &nbsp;</div>
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

