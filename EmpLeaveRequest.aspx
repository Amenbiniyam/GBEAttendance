<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="EmpLeaveRequest.aspx.cs" Inherits="EmpLeaveRequest" %>
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
        .auto-style36 {
        height: 3px;
    }
        .auto-style45 {
            height: 24px;
        }
        .table-striped {}
        .auto-style46 {
            height: 3px;
            width: 2px;
        }
        .auto-style47 {
            height: 35px;
            width: 2px;
        }
        .auto-style70 {
            width: 100%;
        }
        .auto-style71 {
            width: 168px;
        }
        .auto-style72 {
            height: 43px;
        }
        .auto-style73 {
            height: 38px;
        }
        </style>
<script type = "text/javascript">
      
      function Check_Click(objRef) {
          //Get the Row based on checkbox
          var row = objRef.parentNode.parentNode;
          if (objRef.checked) {
              //If checked change color to Aqua
              row.style.backgroundColor = "aqua";
          }
          else {
              //If not checked change back to original color
              if (row.rowIndex % 2 == 0) {
                  //Alternating Row Color
                  row.style.backgroundColor = "#C2D69B";
              }
              else {
                  row.style.backgroundColor = "white";
              }
          }

          //Get the reference of GridView
          var GridView = row.parentNode;

          //Get all input elements in Gridview
          var inputList = GridView.getElementsByTagName("input");

          for (var i = 0; i < inputList.length; i++) {
              //The First element is the Header Checkbox
              var headerCheckBox = inputList[0];

              //Based on all or none checkboxes
              //are checked check/uncheck Header Checkbox
              var checked = true;
              if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                  if (!inputList[i].checked) {
                      checked = true;
                      break;
                  }
              }
          }
          headerCheckBox.checked = checked;

      }
</script>--%>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <span class="auto-style3">Employee Leave Request Form</span></h1>
       
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
  

                      <table class="auto-style70">
                          <tr>
                              <td>
                                
                                    &nbsp;</td>
                              <td colspan="6">
                                
                                   <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtStartDate" Display="None" ErrorMessage="* Date Required" 
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                        DisplayMode="SingleParagraph" />
                                  </td>
                              <td>
                                
                                   &nbsp;</td>
                              <td>
                                
                                   &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36">
                                
                                  <asp:Label ID="lblEndDAte" runat="server" Text="Leave Type:"></asp:Label>
                                  </td>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                  <asp:Label ID="Label14" runat="server" Text="Date From:"></asp:Label>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                
                                    <asp:Label ID="Label15" runat="server" Text="No Days:"></asp:Label>
                                
                              </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  <asp:Label ID="lblSum" runat="server" Text="Submit To:"></asp:Label>
                              </td>
                              <td class="auto-style36">&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style72">
                                  &nbsp;</td>
                              <td class="auto-style72">
                                
                                  <asp:DropDownList ID="ddlLeave" runat="server" Height="29px" Width="138px" AutoPostBack="True" OnSelectedIndexChanged="ddlLeave_SelectedIndexChanged">
                                      <asp:ListItem>-Select Leave Type-</asp:ListItem>
                                  </asp:DropDownList>
                                  </td>
                              <td class="auto-style72"></td>
                              <td class="auto-style72">
                                
                                  <asp:TextBox ID="txtStartDate" runat="server" Height="25px" Width="110px" 
                                      ></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Cala.jpeg" 
                    Width="18px" CausesValidation="False"  />
                                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server"  Format="dd-MMM-yyyy" 
        TargetControlID="txtStartDate" PopupButtonID="ImageButton3"/>
                                  </td>
                              <td class="auto-style72"></td>
                              <td class="auto-style72">
                                
                                    <asp:TextBox ID="txtNoDays" runat="server" Height="25px" Width="110px"></asp:TextBox>
                                
                                    </td>
                              <td class="auto-style72">&nbsp;</td>
                              <td class="auto-style72">
                                  <asp:DropDownList ID="ddlSubmitTo" runat="server" Height="29px">
                                  </asp:DropDownList>
                              </td>
                              <td class="auto-style72">&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                  <asp:Label ID="Label17" runat="server" Text="Days:"></asp:Label>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  <asp:Label ID="Label18" runat="server" Text="Jump:"></asp:Label>
                              </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                      ControlToValidate="txtNoDays" Display="None" 
                                      ErrorMessage="* No of Days Required" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  <asp:Label ID="Label20" runat="server" Text="Reason:"></asp:Label>
                              </td>
                              <td class="auto-style36">&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                  <asp:DropDownList ID="ddlDays" runat="server" Height="30px" AutoPostBack="True" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                                      <asp:ListItem>0.5</asp:ListItem>
                                      <asp:ListItem>1</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:DropDownList ID="ddlDateType" runat="server" Height="30px" Visible="True">
                                      <asp:ListItem>Morning</asp:ListItem>
                                      <asp:ListItem>Afternoon</asp:ListItem>
                                  </asp:DropDownList>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  
                                     <asp:TextBox ID="txtJump" runat="server" Height="25px" Width="110px">0</asp:TextBox>
                                  
                                  </td>
                              <td class="auto-style36">
                              
                              </td>
                              <td class="auto-style36">
                              <asp:ImageButton ID="butView" runat="server" 
                                      ImageUrl="Images/view-detail-button.gif" OnClick="butView_Click" 
                                      style="height: 27px" />
                               <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine"></asp:TextBox>
                              </td>
                              <td class="auto-style36">&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td colspan="5">
                                <asp:UpdateProgress id="updateProgress" runat="server">
  <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/Images/loader.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
                                <asp:Button  class = "btn btn-primary" ID="butSave" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" Visible="True" />
                                  <asp:Label ID="lblID" runat="server" Visible="true"></asp:Label>
                             
                                   
                                
                                    </td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="True" Width="163px">
                                      <table class="auto-style45">
                                          <tr>
                                              <td class="auto-style46">
                                                  &nbsp;</td>
                                              <td class="auto-style47">
                                                  &nbsp;</td>
                                              <td>
                                                  &nbsp;</td>
                                          </tr>
                                      </table>
                                  </asp:Panel>
                              </td>
                              <td>&nbsp;</td>
                              <td>
                                  <asp:Label ID="Label19" runat="server" Text="Today Balance:"></asp:Label>
                                  <asp:Label ID="lblBal" runat="server" ForeColor="Blue"></asp:Label>
                              </td>
                              <td>&nbsp;</td>
                              <td>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                      ControlToValidate="txtNoDays" Display="None" 
                                      ErrorMessage="* No of Days Decimal" ForeColor="Red" 
                                      ValidationExpression="^(\d{1,3})(.\d{1})?$"></asp:RegularExpressionValidator>
                              </td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td colspan="8">
                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="270px">
                                       <asp:GridView ID="grveDeatial" runat="server" CellPadding="4" 
                                           ForeColor="#333333" Height="77px" Width="271px">
                                           <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                           <EditRowStyle BackColor="#999999" />
                                           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                           <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                           <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                           <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                           <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                           <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                           <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                           <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                           <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                       </asp:GridView>
                                       <br />
                                       <br />
                                       <br />
                                       <asp:GridView ID="grvView" runat="server"   
                                           class="table table-bordered table-striped"  PageSize="5"  
                                           CssClass="table-striped" BackColor="White" BorderColor="#CCCCCC" 
                                           BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="470px"  >
                                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" onclick = "Check_Click(this)"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                                             <FooterStyle BackColor="White" ForeColor="#000066" />
                                           <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                             <PagerStyle CssClass="pagination-ys" BackColor="White" ForeColor="#000066" 
                                               HorizontalAlign="Left" />
                                           <RowStyle ForeColor="#000066" />
                                           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                           <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                           <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                           <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                           <SortedDescendingHeaderStyle BackColor="#00547E" />
                                  </asp:GridView>
                                          
                           
                                       <asp:GridView ID="GridView1" runat="server">
                                       </asp:GridView>
                           
                                       <asp:GridView ID="grvDetail1" runat="server" AllowPaging="True" 
                                           AllowSorting="True" AutoGenerateColumns="True" 
                                           class="table table-bordered table-striped" CssClass="table-striped" 
                                           DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                                           PageSize="3" Width="838px">
                                           <Columns>
                                               <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="True" 
                                                   ReadOnly="True" />
                                               <asp:BoundField DataField="EmpId" HeaderText="EmpId" />
                                               <asp:BoundField DataField="Full_Name" HeaderText="Full_Name" />
                                               <asp:BoundField DataField="Leave_Name" HeaderText="Leave_Name" />
                                               <asp:BoundField DataField="LeaveBalance" HeaderText="LeaveBalance" />
                                               <asp:BoundField DataField="LeaveTaken" HeaderText="LeaveTaken" />
                                               <asp:BoundField DataField="Date" HeaderText="Date" />
                                               <asp:TemplateField HeaderText="" ItemStyle-Width="30px">
                                                   <ItemTemplate>
                                                       <%-- <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/view-detail-button.gif" OnClick="Edit" ToolTip="Edit"  />
           --%><%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%>
                                                       <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
                                                   </ItemTemplate>
                                                   <ItemStyle Width="80px" />
                                               </asp:TemplateField>
                                           </Columns>
                                           <PagerStyle CssClass="pagination-ys" />
                                       </asp:GridView>
                              <asp:GridView ID="grvDetail" runat="server" CellPadding="4" 
                                           ForeColor="#333333" onselectedindexchanged="grvDetail_SelectedIndexChanged1" >
                                             <Columns>
                              <asp:TemplateField   ItemStyle-Width = "30px" HeaderText = "Edit/Delete" >
   <ItemTemplate>
            <asp:ImageButton CausesValidation="true" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="EditDE" ToolTip="Edit"  />
             <asp:ImageButton CausesValidation="true" ID="lnkDelete" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "DeleteDE"  OnClientClick="return confirm('Are you sure you want to delete this record?');"  /> 
    
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
   </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>
                        

                        </Columns>
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
                              <td>
                                   &nbsp;</td>
                          </tr>
                      </table>
                  


    

         
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
          </ContentTemplate>
</asp:UpdatePanel>   
        
</asp:Content>


