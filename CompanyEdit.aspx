﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="CompanyEdit.aspx.cs" Inherits="CompanyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 339px;
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
            height: 23px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
         <h1>
              Edit<span class="auto-style3"> Company Form</span>
           </h1>
        
        
        </section>
    <section class="content">
                       <!-- general form elements -->
              <div class="box box-primary" style="height:443px">
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style4" colspan="3">
                                  <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                                  
&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                              
                            </td>
                          </tr>
                          <tr>
                              <td><asp:Label ID="Label2" runat="server" Text="Company Name:"></asp:Label>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>
                                  <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txtCompanyName" runat="server" Height="25px" Width="350px"    ></asp:TextBox>
                              </td>
                              <td class="auto-style2">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompanyName" ErrorMessage="Company Name Required" ForeColor="Red" Height="20px" Display="None"></asp:RequiredFieldValidator>
                              </td>
                              <td>
                                  <asp:TextBox ID="txtDescription" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1"><asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td><asp:Label ID="Label5" runat="server" Text="Telephone:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txtAddress" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>
                                  <asp:TextBox ID="txtTele" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1"><asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td><asp:Label ID="Label6" runat="server" Text="Fax:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txtEmail" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                              <td class="auto-style2">
                                  
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Format is wrong" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="None"></asp:RegularExpressionValidator>
                              </td>
                              <td>
                                  <asp:TextBox ID="txtFAx" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1"><asp:Label ID="Label8" runat="server" Text="Website:"></asp:Label>
                              </td>
                              <td class="auto-style2"><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Website Format is wrong" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" Display="None"></asp:RegularExpressionValidator>
                                  </td>
                              <td>
                                  <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txtWebsite" runat="server" Height="25px" Width="350px"></asp:TextBox>
             
                              </td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                              </td>
                          </tr>
                      </table>
                  
                  </div><!-- /.box-body -->
                  <div class="box-footer">
                      <asp:Button  class = "btn btn-success" ID="Button3" runat="server" Height="29px" Text="Update" Width="72px" ForeColor="White" OnClick="Button3_Click" />
                  &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="False">Back to List</asp:LinkButton>
                  </div>
             
              </div><!-- /.box -->

              <!-- Form Element sizes -->
             <!--/.col (right) -->
        
        </section>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>


