<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="Machine.aspx.cs" Inherits="Machine" %>

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
              <span class="auto-style3">Manage Machine Form</span>
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
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style23">&nbsp;</td>
                              <td class="auto-style16">
                                  <asp:Label ID="Label8" runat="server" Text="Machine No:"></asp:Label>
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
                                  <asp:TextBox ID="txtMachineNO" runat="server" Height="25px" Width="201px"></asp:TextBox>
                              </td>
                              <td class="auto-style36">
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMachineNO" Display="None" ErrorMessage="Machine No is Integer" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                              </td>
                              <td class="auto-style11">
                                  <asp:TextBox ID="txtDesc" runat="server" Height="25px" Width="201px"></asp:TextBox>
                              </td>
                              <td class="auto-style41">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesc" Display="None" ErrorMessage="Description Required"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style27">
                                  <asp:Label ID="lblId" runat="server" Text="Label" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style27">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style25">
                                  &nbsp;</td>
                              <td class="auto-style20">
                                  <asp:Label ID="Label7" runat="server" Text="IP:"></asp:Label>
                              </td>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style21">
                                  <asp:Label ID="Label6" runat="server" Text="Port:"></asp:Label>
                              </td>
                              <td class="auto-style42">
                                  &nbsp;</td>
                              <td class="auto-style28">
                                  &nbsp;</td>
                              <td class="auto-style28">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22">
                                  &nbsp;</td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtIP" runat="server" Height="25px" Width="200px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIP" Display="None" ErrorMessage="IP Required"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style38">
                                  &nbsp;</td>
                              <td class="auto-style30">
                                  <asp:TextBox ID="txtPort" runat="server" Height="25px" Width="200px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPort" Display="None" ErrorMessage="Port Required"></asp:RequiredFieldValidator>
                                </td>
                              <td class="auto-style43">
                                  &nbsp;</td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                              <td class="auto-style29">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style31"></td>
                              <td class="auto-style32">
                                  <asp:Button  class = "btn btn-primary" ID="butSave" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                            
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="False">
                                      <table class="auto-style45">
                                          <tr>
                                              <td class="auto-style46">
                                                  <asp:Button ID="butUpdate" runat="server" class="btn btn-success" ForeColor="White" Height="31px" Text="Update" Width="74px" OnClick="butUpdate_Click" />
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
                                  &nbsp;</td>
                              <td class="auto-style44">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
                              <td class="auto-style34">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style22" colspan="8">
                            
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [tblMachine] ORDER BY [id] DESC"></asp:SqlDataSource>
                                  <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="250px">
                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="machNo,Ip,port"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped"  Width="1014px" PageSize="5" DataSourceID="SqlDataSource1" CssClass="table-striped">
               <Columns>
                                          <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                           <asp:BoundField DataField="machNo" HeaderText="Machine_No" SortExpression="machNo" ReadOnly="True" />
                                          <asp:BoundField DataField="Ip" HeaderText="Ip" SortExpression="Ip" ReadOnly="True"  />
                                          <asp:BoundField DataField="port" HeaderText="Port" SortExpression="port" ReadOnly="True" />
                                          <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
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


