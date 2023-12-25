<%@ Page Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="LeaveReversal.aspx.cs" Inherits="LeaveReversal" Title="LeaveReversal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <table bgcolor="White">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                  <asp:Panel ID="mesgPN" runat="server" Height="26px" Width="804px">
                                      &nbsp;&nbsp;
                                      <asp:Label ID="lblMSG" runat="server" Font-Bold="True" Font-Size="13pt" 
                                          ForeColor="#339966" Height="20px" style="text-align: center"></asp:Label>
                                  </asp:Panel></td>
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
                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
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
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" Height="189px" ScrollBars="Both" 
                    Width="1072px">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
    ForeColor="#333333" onselectedindexchanged="GridView1_SelectedIndexChanged">
                        <RowStyle BackColor="#EFF3FB" />
                        <Columns>
                            
                             <asp:TemplateField   ItemStyle-Width = "30px" HeaderText = "Reversal" >
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
       
     
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button  class = "btn btn-success" ID="butUpdate" runat="server" 
                    Height="29px" Text="Update" Width="72px" ForeColor="White" 
                    OnClick="Button3_Click" Visible="False" />&nbsp;<asp:Button ID="butCAl" 
                    runat="server" Height="29px" onclick="Button3_Click1" Text="Cancel" 
                    Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                                  <asp:Label ID="lblSum" runat="server" Text="Submit To:"></asp:Label>
                                  <asp:DropDownList ID="ddlSubmitTo" runat="server" Height="29px">
                                  </asp:DropDownList>
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
            <td colspan="5">
               
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="200px">
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
                </asp:Panel>
            </td>
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
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


