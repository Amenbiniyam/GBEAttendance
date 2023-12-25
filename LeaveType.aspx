<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="LeaveType.aspx.cs" Inherits="AttendanceAndLeaveManagementSystem.LeaveType" %>

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
    </style>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
              <span class="auto-style3">Manage Leave Type Form</span>
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
                              <td class="auto-style4" colspan="7">
                                
                                      <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtNAme" ErrorMessage="* Name Required" ForeColor="Red" 
                                      Display="None"></asp:RequiredFieldValidator>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                      DisplayMode="SingleParagraph" ForeColor="Red" />
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style16"><asp:Label ID="Label2" runat="server" Text="Leave Name:"></asp:Label>
                              </td>
                              <td class="auto-style35">&nbsp;</td>
                              <td class="auto-style17">
                                  <asp:Label ID="Label4" runat="server" Text="Max Amount:"></asp:Label>
                              </td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="auto-style26">
                                  <asp:Label ID="Label9" runat="server" Text="Incremental Value:"></asp:Label>
                              </td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style6" rowspan="6">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style54"></td>
                              <td class="auto-style55">
                                  <asp:TextBox ID="txtNAme" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style56">
                                  </td>
                              <td class="auto-style57">
                                  <asp:TextBox ID="txtMaxAmount" runat="server" Height="25px" Width="100px"></asp:TextBox>
                              </td>
                              <td class="auto-style58">
                                  </td>
                              <td class="auto-style59">
                                  <asp:TextBox ID="txtIncValue" runat="server" Height="25px" Width="100px"></asp:TextBox>
                              </td>
                              <td class="auto-style59">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style48">
                                  </td>
                              <td class="auto-style49">
                                  <asp:Label ID="Label6" runat="server" Text="Gender:"></asp:Label>
                              </td>
                              <td class="auto-style50">
                                  </td>
                              <td class="auto-style51">
                                  <asp:Label ID="Label8" runat="server" Text="Consecutive:"></asp:Label>
                              </td>
                              <td class="auto-style52">
                                  </td>
                              <td class="auto-style53">
                                  <asp:Label ID="Label10" runat="server" Text="Annual leave Accrue:"></asp:Label>
                              </td>
                              <td class="auto-style53">
                                  <asp:Label ID="Label11" runat="server" Text="Sick Leave:"></asp:Label>
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:RadioButtonList ID="radCycle" runat="server" RepeatDirection="Horizontal" Width="230px">
                                      <asp:ListItem Value="Male">Male</asp:ListItem>
                                      <asp:ListItem Value="Female">Female</asp:ListItem>
                                      <asp:ListItem Selected="True">Both</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td class="auto-style38">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:DropDownList ID="ddlCons" runat="server" Height="30px" OnSelectedIndexChanged="ddlCons_SelectedIndexChanged" Width="91px">
                                      <asp:ListItem>No</asp:ListItem>
                                      <asp:ListItem>Yes</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style43">
                                  &nbsp;</td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlALAcc" runat="server" Height="30px" Width="91px">
                                      <asp:ListItem>Yes</asp:ListItem>
                                      <asp:ListItem>No</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlSickLeave" runat="server" Height="30px" OnSelectedIndexChanged="ddlCons_SelectedIndexChanged" Width="91px">
                                      <asp:ListItem>No</asp:ListItem>
                                      <asp:ListItem>Yes</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style31"></td>
                              <td class="auto-style32">
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
                              <td class="auto-style33">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                      ControlToValidate="txtMaxAmount" Display="None" 
                                      ErrorMessage="* Max Amount must be &gt;0" 
                                      ValidationExpression="^[1-9]([0-9]*,?)*$" ForeColor="Red"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                      ControlToValidate="txtIncValue" Display="None" 
                                      ErrorMessage="* Incremental Value must be &gt;0" 
                                      ValidationExpression="^[1-9]([0-9]*,?)*$" ForeColor="Red"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style34">
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style31">&nbsp;</td>
                              <td class="auto-style32">
                                  &nbsp;</td>
                              <td class="auto-style39">
                                  &nbsp;</td>
                              <td class="auto-style33">
                                  <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22" colspan="8">
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [LeaveTypes] ORDER BY [Id] DESC"></asp:SqlDataSource>
                                  <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="250px">
                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped"  Width="1014px" PageSize="5" DataSourceID="SqlDataSource1" CssClass="table-striped">
               <Columns>
                                          <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                           <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                          <asp:BoundField DataField="MaximumAmount" HeaderText="MaximumAmount" SortExpression="MaximumAmount"  />
                                          <asp:BoundField DataField="GenderType" HeaderText="GenderType" SortExpression="GenderType" />
                                          <asp:BoundField DataField="IncreamentalValue" HeaderText="IncreamentalValue" SortExpression="IncreamentalValue" />
                                          <asp:BoundField DataField="Consecutive" HeaderText="Consecutive" SortExpression="Consecutive" />
                               
            

                                          <asp:BoundField DataField="ALAccrue" HeaderText="ALAccrue" SortExpression="ALAccrue" />
                     <asp:BoundField DataField="SickLeave" HeaderText="SickLeave" SortExpression="SickLeave" />
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
        <Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>


    </ContentTemplate>
</asp:UpdatePanel>          
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
</asp:Content>


