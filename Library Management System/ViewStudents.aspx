<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="Library_Management_System.ViewStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Students List</h2>

Search by Name:
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server"
            Text="Search"
            OnClick="btnSearch_Click" />
<asp:Button ID="btnAll" runat="server"
            Text="View All"
            OnClick="btnAll_Click" />

<br /><br />

<asp:GridView ID="gvStudents" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="StudentId"
    OnRowEditing="gvStudents_RowEditing"
    OnRowUpdating="gvStudents_RowUpdating"
    OnRowCancelingEdit="gvStudents_RowCancelingEdit"
    OnRowDeleting="gvStudents_RowDeleting">

    <Columns>
        <asp:BoundField DataField="StudentId" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="StudentName" HeaderText="Name" />
        <asp:BoundField DataField="Department" HeaderText="Department" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

<br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
