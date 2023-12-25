<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="DepartmentPositionHome.aspx.cs" Inherits="DepartmentPositionHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .modal-body {
            height: 266px;
        }
        .auto-style6 {
            width: 208px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager2" runat="server">
              </asp:ScriptManager>
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <section class="content-header">
        <asp:Button class = "btn btn-primary" ID="Button1" runat="server" Text="[+] Create New" ForeColor="White" Height="31px" OnClick="Button1_Click1" />
         
        </section>

        <!-- Main content -->
        <section class="content">
        
        <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Job Position to Department Information </h3>
                    <p class="box-title">&nbsp;</p>
                    <p class="box-title">
                        <asp:Label ID="lblMSG" runat="server"></asp:Label>
                    </p>
                    <asp:Label ID="Label1" runat="server" Text="Department Name:"></asp:Label>
                    <asp:Label ID="lblDepID" runat="server"></asp:Label>
                    <table class="auto-style5">
                        <tr>
                            <td>
                                
                                  <asp:Panel ID="root" runat="server" Height="440px" Width="200px" 
                                      ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="184px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                                  </asp:Panel>
                                
                                </td>
                            <td>
                     <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" 
                    Height="440px">       
                                
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  
        AllowPaging="True" AllowSorting="True"  
        class="table table-bordered table-striped" 
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="648px" 
        PageSize="8" DataSourceID="SqlDataSource1" CssClass="table-striped">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="PositionName" HeaderText="PositionName" 
                SortExpression="PositionName" />
      <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "Delete">
   <ItemTemplate>
          
             <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?');"/>

     
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
                        </table>
                </div><!-- /.box-header -->
                <div class="box-body">


  


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" 
        SelectCommand="SELECT [Id], [PositionName] FROM [depPosition] WHERE ([DepartmentName] = @DepartmentName)">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblDepID" Name="DepartmentName" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>


 <%--   </ContentTemplate>
</asp:UpdatePanel>--%>
                    </div>
         </div>
        </section><!-- /.content -->
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

