<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="TakeActionExpLeave.aspx.cs" Inherits="TakeActionExpLeave" %>

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
     <asp:ScriptManager ID="ScriptManager2" runat="server">
         <Services>
        <asp:ServiceReference Path="AutoComplete.asmx" />
        </Services>
        </asp:ScriptManager>
    
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    
    
    <section class="content-header">
         <h1>
              Take Action<span class="auto-style3"> Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                    
                      <table class="style17">
                          <tr>
                              <td class="style18" rowspan="8">
                                  <asp:Panel ID="root" runat="server" Height="100%" Width="168px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                      </asp:TreeView>
                                  </asp:Panel>
                              </td>
                              <td class="style33">
                                  </td>
                              <td colspan="5" class="style35">
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                  <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                        Height="26px" DisplayMode="SingleParagraph" />
                                  </td>
                          </tr>
                          <tr>
                              <td class="style31">
                                  </td>
                              <td class="style31">
                                  <asp:Label ID="Label9" runat="server" Text="Date:"></asp:Label>
                                  </td>
                              <td class="style32">
                                  </td>
                              <td class="style31">
                                
                                  &nbsp;</td>
                              <td class="style31">
                                  </td>
                              <td class="style31">
                                
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style30">
                                  </td>
                              <td class="style31">
                                  <asp:TextBox ID="txtHiredDate" runat="server" Height="25px" Width="147px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="16px" CausesValidation="False" Height="16px"  />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtHiredDate" Display="None" 
                                      ErrorMessage="* Start Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                  </td>
                              <td class="style32">
                                  </td>
                              <td class="style31">
                                
                                  &nbsp;</td>
                              <td class="style31">
                                  </td>
                              <td class="style31">
                                
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style36">
                                  </td>
                              <td class="style36">
                                  <asp:Label ID="Label10" runat="server" Text="Department:"></asp:Label>
                                  </td>
                              <td class="style37">
                                  </td>
                              <td class="style36">
                                
                                    &nbsp;</td>
                              <td class="style36">
                                  </td>
                              <td class="style36">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style20">
                                  </td>
                              <td>
                                  <asp:TextBox ID="txtDep" runat="server" Height="25px" Width="147px" Enabled="False"></asp:TextBox>
                                    
                                  </td>
                              <td class="style19">
                                  </td>
                              <td>                                
                                    &nbsp;</td>
                              <td>
                                  </td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style20">
                                  </td>
                              <td>
                                  <asp:UpdateProgress id="updateProgress" runat="server">
  <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
                                  <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" 
                                      Text="Take Action" Height="32px" />
                                  </td>
                              <td class="style19">
                                  </td>
                              <td>
                                  </td>
                              <td>
                                  </td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="style20">
                                  &nbsp;</td>
                              <td colspan="5">
                                   <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="AttAllTableAdapters."></asp:ObjectDataSource>
                                 
                                  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                                      Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
                                      Height="226px" Visible="False" Width="100%">
                                      <LocalReport ReportEmbeddedResource="AttendanceAndLeaveManagementSystem.ReportP.rdlc" ReportPath="ReportP.rdlc">
                                          <DataSources>
                                              <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="tblATTALL" />
                                          </DataSources>
                                      </LocalReport>
                                  </rsweb:ReportViewer>
                                   </td>
                          </tr>
                          <tr>
                              <td class="style20" colspan="6">
                                  &nbsp;</td>
                          </tr>
                      </table>
             
                       <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtHiredDate" PopupButtonID="ImageButton2"/>
                             
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

