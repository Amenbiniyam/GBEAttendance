<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="Director.aspx.cs" Inherits="Director" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel>
<asp:Button  class="btn btn-success" ID="Button3" runat="server" Height="29px" Text="Update" Width="72px" ForeColor="White" OnClick="Button3_Click" />

                                  

    <asp:Panel ID="Panel1" runat="server" Height="437px" ScrollBars="Vertical">
    <asp:GridView ID="GridView1" CssClass="Grid" HeaderStyle-CssClass="header" runat="server"
        AutoGenerateColumns="false" Width="426px" Height="52px" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" 
            HorizontalAlign="Center">
        <Columns>        
             
                  
                <asp:TemplateField HeaderText="EmpID" >
                    <ItemTemplate>
                     
                       
                         <asp:TextBox ID="txtEmpId" runat="server" Text='<%# Bind("EmpID")%>' ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                 ControlToValidate="txtEmpId" ErrorMessage="*"></asp:RequiredFieldValidator>
                   </ItemTemplate>
                    
                    <HeaderStyle ></HeaderStyle>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="AutID" >
                    <ItemTemplate>
                     
                          <asp:TextBox ID="txtAud" runat="server" Text='<%# Bind("AutID")%>' ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                 ControlToValidate="txtAud" ErrorMessage="*"></asp:RequiredFieldValidator>
                   </ItemTemplate>
                    
                    <HeaderStyle ></HeaderStyle>
                </asp:TemplateField>
                
                </Columns>

<HeaderStyle CssClass="header" BackColor="#E8E8E8"></HeaderStyle>
    </asp:GridView>
    </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

