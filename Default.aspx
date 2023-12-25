<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="ApprovalSetting_Id" HeaderText="ApprovalSetting_Id" 
                SortExpression="ApprovalSetting_Id" />
            <asp:BoundField DataField="EmployeePositions_Id" 
                HeaderText="EmployeePositions_Id" SortExpression="EmployeePositions_Id" />
            <asp:BoundField DataField="WillStatus" HeaderText="WillStatus" 
                SortExpression="WillStatus" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AttendanceManagmentConnectionString2 %>" 
        SelectCommand="SELECT * FROM [ApprovalLevels]"></asp:SqlDataSource>
</asp:Content>

