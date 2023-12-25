<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="PositionEdit.aspx.cs" Inherits="PositionEdit" %>

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
    .auto-style5 {
        width: 339px;
        height: 61px;
    }
    .auto-style6 {
        width: 90px;
        height: 61px;
    }
    .auto-style7 {
        height: 61px;
    }
    .auto-style9 {
        width: 90px;
        height: 27px;
    }
    .auto-style10 {
        height: 27px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
         <h1>
            <span class="auto-style3">Edit Position Form</span>
           </h1>
     
        
        </section>
    <section class="content">
                       <!-- general form elements -->
              <div class="box box-primary" style="height:372px">
               
              
                  <div class="box-body">
                  
                      <table class="datepicker-inline">
                          <tr>
                              <td class="auto-style4" colspan="3">
                                  <asp:Label ID="lblMSG" runat="server"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style10"><asp:Label ID="Label2" runat="server" Text="Position Name:"></asp:Label>
                              </td>
                              <td class="auto-style9"></td>
                              <td class="auto-style10">
                                  <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style5">
                                  <asp:TextBox ID="txtPositionName" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                              <td class="auto-style6">
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPositionName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                              </td>
                              <td class="auto-style7">
                                  <asp:TextBox ID="txtDescription" runat="server" Height="25px" Width="350px"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td class="auto-style1">
                                  &nbsp;</td>
                              <td class="auto-style2">&nbsp;</td>
                              <td>
                                  <asp:Label ID="lblID" runat="server" ForeColor="Red" Visible="False"></asp:Label>
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
</asp:Content>


