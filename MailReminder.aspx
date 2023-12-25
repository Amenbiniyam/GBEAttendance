<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="MailReminder.aspx.cs" Inherits="MailReminder" %>

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
              <span class="auto-style3"> Mail Reminder Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                    
                      <table class="style17">
                          <tr>
                              <td class="style33">
                                  </td>
                              <td class="style35" colspan="5">
                                  <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                  <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                                  </td>
                          </tr>
                          <tr>
                              <td class="style31">
                                  </td>
                              <td class="style31">
                                  &nbsp;</td>
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
                                   <asp:UpdateProgress id="updateProgress" runat="server">
  <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
                                  <asp:Button ID="Button4" runat="server" Height="32px" OnClick="Button4_Click" 
                                      Text="Send Mail" />
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
                                  &nbsp;</td>
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
                                  &nbsp;</td>
                              <td colspan="5">
                                   <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Vertical" 
                                       Width="996px">
                                       <asp:GridView ID="grvData" runat="server" CellPadding="4" ForeColor="#333333">
                                           <AlternatingRowStyle BackColor="White" />
                                           <EditRowStyle BackColor="#2461BF" />
                                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                           <RowStyle BackColor="#EFF3FB" />
                                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                           <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                           <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                       </asp:GridView>
                                   </asp:Panel>
                              </td>
                          </tr>
                          <tr>
                              <td class="style20" colspan="6">
                                  &nbsp;</td>
                          </tr>
                      </table>
             
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

