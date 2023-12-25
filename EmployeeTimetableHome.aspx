<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="EmployeeTimetableHome.aspx.cs" Inherits="EmployeeTimetableHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
  
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .modal-body {
            height: 266px;
        }
        .auto-style10 {
            width: 199px;
        }
        .auto-style11 {
            width: 155px;
        }
        .table-striped {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <asp:Button class = "btn btn-primary" ID="Button1" runat="server" Text="[+] Create New" ForeColor="White" Height="31px" OnClick="Button1_Click1" CausesValidation="False" />
          
                    <asp:Label ID="lblParID" runat="server" Visible="False"></asp:Label>
          
        </section>

        <!-- Main content -->
         <!-- Main content -->
        <section class="content">
        
        <div class="box box-primary" style="height:500px">
                <div class="box-header">
                    <h3 class="box-title">Employee/Schedule Information </h3>
                    <p class="box-title">&nbsp;</p>
                    <p class="box-title">
                        <asp:Label ID="lblMSG" runat="server"></asp:Label>
                    </p>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div><!-- /.box-header -->
                <div class="box-body">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <table style="width:100%" >

        <tr>
            <td class="auto-style11">
                     <asp:Panel ID="root" runat="server" Height="440px" Width="148px" ScrollBars="Both">
                                      <asp:TreeView ID="treeDepa" runat="server" Height="313px" Width="169px" OnSelectedNodeChanged="treeDepa_SelectedNodeChanged">
                                          <SelectedNodeStyle ForeColor="Red" />
                                      </asp:TreeView>
                                  </asp:Panel>
            </td>
            <td>
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Width="100%" Height="440px">&nbsp;
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  PageSize="6" DataSourceID="SqlDataSource1" CssClass="table-striped" Width="100%">
        <Columns>
            <asp:BoundField DataField="empID" HeaderText="empID" SortExpression="empID" />
            <asp:BoundField DataField="Full_Name" HeaderText="Full_Name" SortExpression="Full_Name" ReadOnly="True" />
            <asp:BoundField DataField="Schedule_Name" HeaderText="Schedule_Name" SortExpression="Schedule_Name" />
            <asp:BoundField DataField="Start_Date" HeaderText="Start_Date" SortExpression="Start_Date" ReadOnly="True" />
            <asp:BoundField DataField="End_Date" HeaderText="End_Date" SortExpression="End_Date" ReadOnly="True" />
            <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"   />
            

              <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "Edit/Delete">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?');" />
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
   </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>
            

        </Columns>
       <PagerStyle CssClass="pagination-ys" />
    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [viewTimeEmployee] WHERE ([Department_Id] = @Department_Id)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblParID" Name="Department_Id" PropertyName="Text" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
  



                </asp:Panel>
            </td>
          
        </tr>

    </table>



<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>


    </ContentTemplate>
</asp:UpdatePanel>
                    </div>
         </div>
        </section><!-- /.content -->
</asp:Content>


