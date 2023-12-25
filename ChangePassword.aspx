<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
        }
        .style19
        {
        height: 35px;
        width: 22px;
    }
        .style21
        {
            width: 29px;
            height: 35px;
        }
        </style>  <style type="text/css">
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
            width: 311px;
        }
        .style19
        {
            width: 22px;
        }
        .style43
    {
        width: 29px;
    }
    .style46
    {
        width: 170px;
    }
    .style47
    {
        width: 170px;
        height: 35px;
    }
    .style50
    {
        width: 125px;
    }
    .style51
    {
        width: 125px;
        height: 35px;
    }
    .style54
    {
        width: 394px;
    }
    .style55
    {
        width: 394px;
        height: 35px;
    }
    .style63
    {
        height: 35px;
    }
    .style65
    {
        width: 170px;
        height: 52px;
    }
    .style66
    {
        width: 394px;
        height: 52px;
    }
    .style67
    {
        width: 125px;
        height: 52px;
    }
    .style68
    {
        width: 29px;
        height: 52px;
    }
    .style69
    {
        height: 52px;
    }
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

           
          <section class="content-header">
         <h1>
              <span class="auto-style3">Change Password Form</span>
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
           </h1>       
        
        </section>



    <section class="content">
                       <!-- general form elements -->
                   
              <div class="box box-primary" >
               
              
                  <div class="box-body">
            <table class="style1">
        <tr>
            <td class="style3" colspan="6">
                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel></td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style46">
               
            </td>
            <td class="style54">
               
                &nbsp;</td>
            <td class="style50">
               
                &nbsp;</td>
            <td class="style43">
               
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style19">
                </td>
            <td class="style47">
                <asp:Label ID="Label1" runat="server" Text="Old Password :"></asp:Label>
            </td>
            <td class="style55">
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" 
                    Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txtOldPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </td>
            <td class="style51">
            </td>
            <td class="style21">
                </td>
            <td class="style19">
            </td>
        </tr>
        <tr>
            <td class="style63">
                </td>
            <td class="style47">
                <asp:Label ID="Label2" runat="server" Text="New Password :"></asp:Label>
            </td>
            <td class="style55">
               
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="25px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtConPassword" 
                    ErrorMessage="Passwords do not match." ForeColor="Red"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
               
            </td>
            <td class="style51">
            </td>
            <td class="style21">
                </td>
            <td class="style63">
            </td>
        </tr>
        <tr>
            <td class="style63">
                </td>
            <td class="style47">
                <asp:Label ID="Label3" runat="server" Text="Confirm New Password :"></asp:Label>
            </td>
            <td class="style55">
                <asp:TextBox ID="txtConPassword" runat="server" Height="25px" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtConPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="style51">
            </td>
            <td class="style21">
            </td>
            <td class="style63">
                </td>
        </tr>
        <tr>
            <td class="style69">
                </td>
            <td class="style65">
                &nbsp;</td>
            <td class="style66">
                <asp:Button  class = "btn btn-primary" ID="butSave" runat="server" Height="29px" Text="Save" Width="72px" ForeColor="White" OnClick="Button3_Click" />
            </td>
            <td class="style67">
                </td>
            <td class="style68">
                </td>
            <td class="style69">
                </td>
        </tr>
    </table>


                
        
        </section>
    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

