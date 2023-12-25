<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="DepLeaveBalance.aspx.cs" Inherits="DepLeaveBalance" %>
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
                      checked = false;
                      break;
                  }
              }
          }
          headerCheckBox.checked = checked;

      }
</script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
 
    <section class="content-header">
         <h1>
              <span class="auto-style3">Department Employees Leave Balance Form</span></h1>
       
        
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
                                  <asp:Label ID="Label14" runat="server" Text="Date :"></asp:Label>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                
                                    &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
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
                                
                                    &nbsp;</td>
                              <td class="auto-style72">&nbsp;</td>
                              <td class="auto-style72">
                                  &nbsp;</td>
                              <td class="auto-style72">&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  
                                     &nbsp;</td>
                              <td class="auto-style36">
                              
                              </td>
                              <td class="auto-style36">
                              
                               <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td colspan="5">
                              <asp:ImageButton ID="butView" runat="server" 
                                      ImageUrl="Images/view-detail-button.gif" OnClick="butView_Click" 
                                      style="height: 27px" />
                                
                                    
                                
                                    </td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="False" Width="163px">
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
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>
                                  &nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td colspan="8">
                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="220px">
                                          <asp:GridView ID="grvDetail" runat="server" 
                                              class="table table-bordered table-striped" 
                                              DataKeyNames="Id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                                              PageSize="3" Width="981px">
                                            
                                              <PagerStyle CssClass="pagination-ys" />
    </asp:GridView>
                           
                                  </asp:Panel>    
                              
                              </td>
                              <td>
                                   &nbsp;</td>
                          </tr>
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


