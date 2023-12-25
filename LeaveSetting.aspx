<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="LeaveSetting.aspx.cs" Inherits="LeaveSetting" %>


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
            width: 249px;
        }
        .auto-style38 {
            width: 249px;
            height: 35px;
        }
        .auto-style39 {
            height: 35px;
        }
        .auto-style40 {
            height: 3px;
            width: 6px;
        }
        .auto-style41 {
            height: 35px;
            width: 6px;
        }
        .auto-style42 {
            width: 6px;
        }
        .auto-style43 {
            width: 249px;
            height: 24px;
        }
        .auto-style44 {
            height: 24px;
            width: 6px;
        }
        .auto-style45 {
            height: 24px;
        }
        .table-striped {}
        .style1
        {
            width: 249px;
            height: 27px;
        }
        .style2
        {
            height: 27px;
            width: 6px;
        }
        .style3
        {
            height: 27px;
        }
    </style>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>   
    <section class="content-header">
         <h1>
              <span class="auto-style3">Employee Leave Setting Form</span>
           </h1>       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style13" rowspan="13">
                                  <asp:Panel ID="root" runat="server" Height="100%" Width="168px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                                  </asp:Panel>
                              </td>
                              <td class="auto-style22" colspan="3">
                                
                                 <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                    <br />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:Label ID="Label9" runat="server" Text="Employee Name:"></asp:Label>
                                  </td>
                              <td class="auto-style40">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:Label ID="lblEndDAte" runat="server" Text="Leave Type:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style38">
                                  <asp:DropDownList ID="ddlEmp" runat="server" Height="30px" Width="160px" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged" AutoPostBack="True">
                                      <asp:ListItem>--Select Department--</asp:ListItem>
                                  </asp:DropDownList>
                                  </td>
                              <td class="auto-style41">
                                
                                    </td>
                              <td class="auto-style39">
                                
                                  <asp:DropDownList ID="ddlLeave" runat="server" Height="29px" Width="138px" 
                                      onselectedindexchanged="ddlLeave_SelectedIndexChanged">
                                  </asp:DropDownList>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style43">
                                  <asp:Label ID="Label12" runat="server" Text="Balance:"></asp:Label>
                                  </td>
                              <td class="auto-style44">
                                
                                    </td>
                              <td class="auto-style45">
                                
                                  <asp:Label ID="Label13" runat="server" Text="Date:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:TextBox ID="txtBalce" runat="server" Height="25px" Width="147px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBalce" Display="None" ErrorMessage="Balance Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                  </td>
                              <td class="auto-style40">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:TextBox ID="txtEndDate" runat="server" Height="25px" Width="177px"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEndDate" Display="None" ErrorMessage="Date Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                          </tr>
                          <tr>
                              <td class="style1">
                                  <asp:Label ID="Label14" runat="server" Text="Leave Entitlement:"></asp:Label>
                              </td>
                              <td class="style2">
                                
                                    </td>
                              <td class="style3">
                                
                                    </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:TextBox ID="txtLeaveEntai" runat="server" Height="25px" Width="147px"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                      Display="None" ErrorMessage="Leave Entitlemen Required" ForeColor="Red" 
                                      ControlToValidate="txtLeaveEntai"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style40">
                                  &nbsp;</td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style40">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
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
                              <td class="auto-style40">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style40">
                                
                                    &nbsp;</td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style35" colspan="3">
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="250px">
                                          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped"  Width="838px" PageSize="5"  CssClass="table-striped" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
               <Columns>
                                           <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True"  />
                                           <asp:BoundField DataField="EmpId" HeaderText="EmpId"  />
                                          <asp:BoundField DataField="Full_Name" HeaderText="Full_Name"  />
                                          <asp:BoundField DataField="Leave_Name" HeaderText="Leave_Name"  />
                                          <asp:BoundField DataField="LeaveBalance" HeaderText="LeaveBalance"  />
                                          
                     <asp:BoundField DataField="Date" HeaderText="Date"  />
                      <asp:BoundField DataField="LeaveEntitlement" HeaderText="LeaveEntitlement"  />
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
                          <tr>
                              <td class="auto-style37">
                                  &nbsp;</td>
                              <td class="auto-style42">
                                           &nbsp;</td>
                              <td class="auto-style7">
                                           &nbsp;</td>
                          </tr>
                      
                   
                             
                                  <cc1:CalendarExtender ID="CalendarExtender4" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtEndDate" PopupButtonID="ImageButton3"/>
                  
                                    </table>
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


