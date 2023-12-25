﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="CompanyHome.aspx.cs" Inherits="CompanyHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
  
    <style type="text/css">
        .auto-style1 {
        }
        .auto-style2 {
            width: 15px;
        }
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            width: 330px;
        }
        .auto-style7 {
            width: 1241px;
        }
        .auto-style9 {
        width: 37px;
    }
        .modal-body {
            height: 266px;
        }
        .auto-style10 {
            width: 199px;
        }
        .auto-style11 {
            width: 1115px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <asp:Button class = "btn btn-primary" ID="Button1" runat="server" Text="[+] Create New" ForeColor="White" Height="31px" OnClick="Button1_Click1" CausesValidation="False" />
          
        </section>

        <!-- Main content -->
         <!-- Main content -->
        <section class="content">
        
        <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title">Company Information </h3>
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

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"  AllowPaging="True" AllowSorting="True"  class="table table-bordered table-striped" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1014px" PageSize="8" DataSourceID="SqlDataSource1" CssClass="table-striped">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
            <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />
                            <asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
            <asp:ImageButton CausesValidation="false" ID="lnkEdit" runat="server" ImageUrl="~/Images/Edit.png" OnClick="Edit" ToolTip="Edit"  />
             <asp:ImageButton ID="LinkButton1" runat="server" ImageUrl="~/Images/Delete.png" ToolTip="Delete" OnClick = "Delete"  OnClientClick="return confirm('Are you sure you want to delete this record?');"  /> 
    
     
       <%--<asp:LinkButton class="glyphicon glyphicon-pencil" ID="lnkEdit" runat="server" Text="Edit"  data-title="Edit" OnClick = "Edit"></asp:LinkButton>--%> 
        <%--<asp:LinkButton class="glyphicon glyphicon-trash" BackColor="Red" ID="LinkButton1" Text="Delete"  runat="server"  data-title="Edit" OnClick = "Delete"></asp:LinkButton>--%>
   </ItemTemplate>
                <ItemStyle Width="80px" />
</asp:TemplateField>
            

        </Columns>
       <PagerStyle CssClass="pagination-ys" />
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString %>" SelectCommand="SELECT * FROM [Companies] ORDER BY [Id] DESC"></asp:SqlDataSource>



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


