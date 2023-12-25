<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="EmployeeTimetableCreate.aspx.cs" Inherits="EmployeeTimetableCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        }
        .auto-style13 {
            width: 187px;
        }
        .auto-style22 {
            width: 100px;
        }
        .auto-style29 {
            width: 553px;
        }
        .auto-style30 {
            width: 380px;
        }
        .auto-style31 {
            width: 100%;
        }
        .auto-style33 {
        width: 40px;
    }
        .auto-style34 {
            width: 250px;
        }
        .style1
        {
            width: 397px;
        }
        .style2
        {
            width: 450px;
        }
    </style>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <span class="auto-style3">Create Employee/Schedule Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style13" rowspan="6">
                                  <asp:Panel ID="root" runat="server" Height="311px" Width="168px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                                  </asp:Panel>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                                
                                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                               <fieldset>
                                   <legend>Schedule</legend>

                                   <table class="auto-style31">
                                       <tr>
                                           <td>
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                           </td>
                                           <td class="auto-style33">
                                            
                                               <asp:Label ID="Label12" runat="server">Type</asp:Label>
                                            
                                           </td>
                                           <td>
                                               <asp:DropDownList ID="ddlType" runat="server">
                                                   <asp:ListItem>And</asp:ListItem>
                                                   <asp:ListItem>Or</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                           <td>
                                               <asp:Label ID="Label15" runat="server" Text="Finger Print Required:"></asp:Label>
                                               <asp:DropDownList ID="ddlFP" runat="server" Height="25px">
                                                   <asp:ListItem>Yes</asp:ListItem>
                                                   <asp:ListItem>No</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                       </tr>
                                   </table>
                                      <asp:Panel ID="Panel1" runat="server" Height="60px" ScrollBars="Vertical">
                                                   <asp:CheckBoxList ID="chkTimeTable" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="0" Width="100%">
                                                   </asp:CheckBoxList>
                                               </asp:Panel>
                                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT [Id], [Name] FROM [TimeTables] ORDER BY [Name]"></asp:SqlDataSource>

                               </fieldset> 
                               </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">&nbsp;</td>
                              <td class="auto-style7" colspan="5" rowspan="4">
                                           <fieldset>
                                   <legend>Employee</legend>

                                      <asp:Panel ID="Panel2" runat="server" Height="60px" ScrollBars="Vertical">
                                                   <asp:CheckBoxList ID="chkEmployee" runat="server"  RepeatColumns="4" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="0" Width="100%">
                                                   </asp:CheckBoxList>
                                               </asp:Panel>

                               </fieldset> </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22">&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style13">
                                  &nbsp;</td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="style1">
                                  <asp:Label ID="Label9" runat="server" Text="Start Date:"></asp:Label>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="style2">
                                  <asp:Label ID="lblEndDAte" runat="server" Text="End Date:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                              <td class="auto-style6">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style13">
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                              </td>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="style1">
                                  <asp:TextBox ID="txtHiredDate" runat="server" Height="25px" Width="127px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtHiredDate" PopupButtonID="ImageButton2"/>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtHiredDate" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style30">
                                  &nbsp;</td>
                              <td class="style2">
                                  <asp:TextBox ID="txtEndDate" runat="server" Height="25px" Width="125px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <cc1:CalendarExtender ID="CalendarExtender3" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtEndDate" PopupButtonID="ImageButton3"/>
                              </td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                              <td class="auto-style6">
                                  &nbsp;</td>
                          </tr>
                          </table>
                  
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                  &nbsp;<asp:Button  class = "btn btn-primary" ID="Button3" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                       &nbsp;<asp:Button  class = "btn btn-primary" ID="butClear" runat="server" 
                          Height="29px" Text="Clear" Width="72px" ForeColor="White" onclick="butClear_Click" CausesValidation="False" 
                         />
                      &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                          OnClick="LinkButton1_Click" CausesValidation="False">Back to List</asp:LinkButton>
                              </div>
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>


