<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="EmployeeTimetableEdit.aspx.cs" Inherits="EmployeeTimetableEdit" %>

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
        .auto-style22 {
            width: 100px;
        }
        .auto-style29 {
            width: 553px;
        }
        .auto-style30 {
            width: 380px;
        }
        .auto-style34 {
        }
        .auto-style35 {
        }
        .auto-style37 {
            width: 264px;
        }
    </style>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <span class="auto-style3">Edit Employee/Schedule Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                                
                                   <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>


                                      <asp:ScriptManager ID="ScriptManager1" runat="server">
                                      </asp:ScriptManager>


                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                                
                                    <asp:Label ID="Label13" runat="server" Text="Full Name:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style4" colspan="5">
                                
                                    <asp:TextBox ID="txtFullName" runat="server" Height="25px" Width="200px" Enabled="False"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style37">
                                  <asp:Label ID="Label9" runat="server" Text="Start Date:"></asp:Label>
                              </td>
                              <td>
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:Label ID="lblEndDAte" runat="server" Text="End Date:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  <asp:Label ID="Label14" runat="server" Text="Type:"></asp:Label>
                              </td>
                              <td class="auto-style29">
                                  <asp:Label ID="Label15" runat="server" Text="Finger Print Required:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style37">
                                  <asp:TextBox ID="txtHiredDate" runat="server" Height="24px" Width="176px"></asp:TextBox>
                                   <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtHiredDate" PopupButtonID="ImageButton2"/>
                              </td>
                              <td>
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:TextBox ID="txtEndDate" runat="server" Height="25px" Width="177px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <cc1:CalendarExtender ID="CalendarExtender3" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtEndDate" PopupButtonID="ImageButton3"/>
                              </td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlType" runat="server" Height="33px" Width="82px">
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlFP" runat="server" Height="25px">
                                      <asp:ListItem>Yes</asp:ListItem>
                                      <asp:ListItem>No</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style35" colspan="5">
                                  <asp:Button ID="butUpdate" runat="server" class="btn btn-success" 
                                      ForeColor="White" Height="31px"  Text="Update" Width="74px" 
                                      OnClick="butUpdate_Click" Enabled="False" />
                      &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Back to List</asp:LinkButton>
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style35" colspan="5">
                                  <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style34" colspan="5">
                                           <asp:Panel ID="Panel2" runat="server">
                                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped"  Width="1014px" PageSize="5" DataSourceID="SqlDataSource1" CssClass="table-striped">
               <Columns>
                                          <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                           <asp:BoundField DataField="Schedule_Name" HeaderText="Schedule_Name" SortExpression="Schedule_Name" />
                                          <asp:BoundField DataField="Start_Date" HeaderText="Start_Date" SortExpression="Start_Date" ReadOnly="True"  />
                                          <asp:BoundField DataField="End_Date" HeaderText="End_Date" SortExpression="End_Date" ReadOnly="True" />
                                       
 
            

                                          <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                           <asp:BoundField DataField="FP" HeaderText="FP" SortExpression="FP" />
                             <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton  CausesValidation="false" ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');"  />
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
     </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>              

        </Columns>
       <PagerStyle CssClass="pagination-ys" />
    </asp:GridView>
                                               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT [Id], [Schedule_Name], [Start_Date], [End_Date], [Type],[FP] FROM [viewEmpTimeEdit] WHERE ([empID] = @empID) ORDER BY [Id] DESC">
                                                   <SelectParameters>
                                                       <asp:ControlParameter ControlID="lblParID" Name="empID" PropertyName="Text" Type="String" />
                                                   </SelectParameters>
                                               </asp:SqlDataSource>
 

                                  </asp:Panel>
                       </td>
                          </tr>
                          </table>
                  
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                  &nbsp;</div>
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
         <Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>


        
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
           </ContentTemplate>
</asp:UpdatePanel>  
</asp:Content>


