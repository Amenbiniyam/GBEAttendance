<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="Holiday.aspx.cs" Inherits="Holiday" %>

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
        .auto-style11 {
            width: 279px;
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
        .auto-style20 {
            width: 248px;
            height: 23px;
        }
        .auto-style21 {
            width: 279px;
            height: 23px;
        }
        .auto-style22 {
    }
        .auto-style23 {
            width: 100px;
            height: 21px;
        }
        .auto-style24 {
            width: 100px;
            height: 5px;
        }
        .auto-style25 {
            width: 100px;
            height: 23px;
        }
        .auto-style26 {
            width: 553px;
            height: 21px;
        }
        .auto-style27 {
            width: 553px;
            height: 5px;
        }
        .auto-style28 {
            width: 553px;
            height: 23px;
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
        .auto-style36 {
            width: 143px;
            height: 5px;
        }
        .auto-style37 {
            width: 143px;
            height: 23px;
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
        .auto-style41 {
            width: 106px;
            height: 5px;
        }
        .auto-style42 {
            width: 106px;
            height: 23px;
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
    </style>
  
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
              <span class="auto-style3">Manage Holiday Form</span>
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
                                
                                  <asp:Label ID="lblMSG" runat="server"></asp:Label>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNAme" ErrorMessage="Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style16"><asp:Label ID="Label2" runat="server" Text="Holiday Name:"></asp:Label>
                              </td>
                              <td class="auto-style35">&nbsp;</td>
                              <td class="auto-style17">
                                  <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                              </td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style26">
                                  &nbsp;</td>
                              <td class="auto-style6" rowspan="6">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style24">&nbsp;</td>
                              <td class="auto-style10">
                                  <asp:TextBox ID="txtNAme" runat="server" Height="25px" Width="200px"></asp:TextBox>
                              </td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style11">
                                  <asp:TextBox ID="txtDesc" runat="server" Height="25px" Width="201px"></asp:TextBox>
                              </td>
                              <td class="auto-style41">
                                  &nbsp;</td>
                              <td class="auto-style27">
                                  &nbsp;</td>
                              <td class="auto-style27">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style25">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  <asp:Label ID="Label7" runat="server" Text="Date:"></asp:Label>
                              </td>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  <asp:Label ID="Label6" runat="server" Text="Cycle per Year:"></asp:Label>
                              </td>
                              <td class="auto-style42">
                                  &nbsp;</td>
                              <td class="auto-style28">
                                  <asp:Label ID="Label8" runat="server" Text="Work Day:"></asp:Label>
                              </td>
                              <td class="auto-style28">
                                  <asp:Label ID="lblDayType" runat="server" Text="Day Type:" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtDAte" runat="server" Height="25px" Width="177px"></asp:TextBox>
                                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                              </td>
                              <td class="auto-style38">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:RadioButtonList ID="radCycle" runat="server" RepeatDirection="Horizontal" 
                                      Width="152px" onselectedindexchanged="radCycle_SelectedIndexChanged">
                                      <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                      <asp:ListItem Value="No">No</asp:ListItem>
                                  </asp:RadioButtonList>
                              </td>
                              <td class="auto-style43">
                                  &nbsp;</td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlWorkDAy" runat="server" Height="30px" Width="91px" 
                                      onselectedindexchanged="ddlWorkDAy_SelectedIndexChanged" 
                                      AutoPostBack="True">
                                      <asp:ListItem>1.0</asp:ListItem>
                                      <asp:ListItem>0.5</asp:ListItem>
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style29">
                                  <asp:DropDownList ID="ddlDayType" runat="server" Height="31px" Visible="False">
                                      <asp:ListItem>Morning</asp:ListItem>
                                      <asp:ListItem>Afternoon</asp:ListItem>
                                  </asp:DropDownList></td>
                          </tr>
                          <tr>
                              <td class="auto-style31"></td>
                              <td class="auto-style32">
                                  <asp:Button  class = "btn btn-primary" ID="butSave" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                            
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="False">
                                      <table class="auto-style45">
                                          <tr>
                                              <td class="auto-style46">
                                                  <asp:Button ID="butUpdate" runat="server" class="btn btn-success" ForeColor="White" Height="31px" OnClick="butDelete_Click" Text="Update" Width="74px" />
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
                              </td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
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
                                  <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtDAte" PopupButtonID="ImageButton1"/>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [Holidays] ORDER BY [Id] DESC"></asp:SqlDataSource>
                                  <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="250px">
                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped"  Width="1014px" PageSize="5" DataSourceID="SqlDataSource1" CssClass="table-striped">
               <Columns>
                                          <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                           <asp:BoundField DataField="HolidayName" HeaderText="HolidayName" SortExpression="HolidayName" />
                                          <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date"   DataFormatString="{0:dd-MMM-yyyy}"  />
                                          <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                          <asp:BoundField DataField="CyclePerYear" HeaderText="CyclePerYear" SortExpression="CyclePerYear" />
                                          <asp:BoundField DataField="WorkDay" HeaderText="WorkDay" SortExpression="WorkDay" />
                                          <asp:BoundField DataField="DayType" HeaderText="DayType" SortExpression="DayType" />
                                          <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton  CausesValidation="false" ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
     
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

