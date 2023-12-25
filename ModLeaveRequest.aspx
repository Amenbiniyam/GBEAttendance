<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeFile="ModLeaveRequest.aspx.cs" Inherits="ModLeaveRequest" %>
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
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>   
    <section class="content-header">
         <h1>
              <span class="auto-style3">Employee Leave Issue</span></h1>
         <p class="MsoNormal">
             Request</p>
         <h1>
              <span class="auto-style3">&nbsp;Form</span>
           </h1>
        
        </section>
    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
                  


                      <table class="auto-style70">
                          <tr>
                              <td class="auto-style71" rowspan="8">
                                   <asp:Panel ID="root" runat="server" Height="100%" Width="168px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                              
                                  </asp:Panel></td>
                              <td>
                                
                                    &nbsp;</td>
                              <td colspan="8">
                                
                                   <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                                  </td>
                          </tr>
                          <tr>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36">
                                  <asp:Label ID="Label9" runat="server" Text="Employee Name:"></asp:Label>
                                  </td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                
                                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                              </td>
                              <td class="auto-style36"></td>
                          </tr>
                          <tr>
                              <td class="auto-style72">
                                  &nbsp;</td>
                              <td class="auto-style72">
                                  <asp:DropDownList ID="ddlEmp" runat="server" Height="30px" Width="160px" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged" AutoPostBack="True">
                                      <asp:ListItem>--Select Department--</asp:ListItem>
                                  </asp:DropDownList>
                                  </td>
                              <td class="auto-style72"></td>
                              <td class="auto-style72">
                                
                                  &nbsp;</td>
                              <td class="auto-style72"></td>
                              <td class="auto-style72">
                                
                                  &nbsp;</td>
                              <td class="auto-style72"></td>
                              <td class="auto-style72">
                                
                                    &nbsp;</td>
                              <td class="auto-style72"></td>
                          </tr>
                          <tr>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                          </tr>
                          <tr>
                              <td class="auto-style36">&nbsp;</td>
                              <td class="auto-style36">
                                
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                                  &nbsp;</td>
                              <td class="auto-style36"></td>
                              <td class="auto-style36">
                               <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                  </td>
                              <td class="auto-style36"></td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td colspan="7">
                                
                                  <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                                
                                    
                                
                                    </td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td>&nbsp;</td>
                              <td>
                                  &nbsp;</td>
                              <td>&nbsp;</td>
                              <td>
                                  <asp:Panel ID="Panel3" runat="server" Height="34px" Visible="False" Width="163px">
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
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>&nbsp;</td>
                              <td>
                                  &nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td colspan="9">
                                   <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="220px">
                           <table bgcolor="White">
        
        <tr>
           
            <td>
                &nbsp;</td>
            <td colspan="5">
               
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                        onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                           
                            <asp:TemplateField HeaderText="Edit/Delete" ItemStyle-Width="30px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" runat="server" CausesValidation="false" 
                                        ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit" />
                                    <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" 
                                        OnClick="Delete" 
                                        OnClientClick="return confirm('Are you sure you want to delete this record?');" 
                                        ToolTip="Delete" />
                                    <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%>
                                    <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
                                </ItemTemplate>
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#6698FF" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                      
               
            </td>
           
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            
          <td  colspan="5">
           <asp:GridView ID="grvView" runat="server"   
                                           class="table table-bordered table-striped"  PageSize="5"  
                                           CssClass="table-striped" BackColor="White" BorderColor="#CCCCCC" 
                                           BorderStyle="None" BorderWidth="1px" 
                  CellPadding="3" Width="470px" 
                  onselectedindexchanged="grvView_SelectedIndexChanged"  >
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
                                  </asp:GridView></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
               
               </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
               
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
                                  </asp:Panel>    
                              
                              </td>
                          </tr>
                      </table>
                  


        <Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>


 <%--   </ContentTemplate>
</asp:UpdatePanel>--%>          
                  </div><!-- /.box-body -->
               
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
        </ContentTemplate>
        </asp:UpdatePanel>
        
</asp:Content>


