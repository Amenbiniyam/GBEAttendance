<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="DepartmentPositionCreate.aspx.cs" Inherits="DepartmentPositionCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
    }
        .auto-style2 {
            width: 90px;
        }
        .newStyle1 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style3 {
            font-family: Arial, Helvetica, sans-serif;
            font-weight: normal;
        }
        .auto-style4 {
        }
        .auto-style5 {
            width: 217px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
              <span class="auto-style3">Create Department/Position Form</span>
           </h1>
        
        
        </section>
    <section class="content">
                       <!-- general form elements -->
              <div class="box box-primary" style="height:400px">
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style5" rowspan="6">
                                  <asp:Panel ID="root" runat="server" Height="337px" Width="200px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="184px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                                  </asp:Panel>
                              </td>
                              <td class="auto-style4" colspan="3">
                                    <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
                              </td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label2" runat="server" Text="Department Name:"></asp:Label>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txtDepartmentName" runat="server" Height="25px" Width="350px" Enabled="False"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepartmentName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style2">
                                  <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
                              </td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style1" colspan="3">
                                  <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="251px">
                                  <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataMember="DefaultView" 
                                          DataSourceID="SqlDataSource1" DataTextField="PositionName" DataValueField="Id" 
                                          Height="178px" RepeatColumns="4" RepeatDirection="Horizontal" Width="100%">
                                  </asp:CheckBoxList>
                                  </asp:Panel>
                                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [Positions] ORDER BY [PositionName]"></asp:SqlDataSource>
                                  
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                      <asp:Button  class = "btn btn-primary" ID="Button3" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                  &nbsp;<asp:Button  class = "btn btn-primary" ID="butClear" runat="server" 
                          Height="29px" Text="Clear" Width="72px" ForeColor="White" onclick="butClear_Click" CausesValidation="False" 
                         />
                  &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Back to List</asp:LinkButton>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                  &nbsp;</td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>&nbsp;</td>
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


