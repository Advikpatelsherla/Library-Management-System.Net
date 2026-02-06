<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="Library_Management_System.ViewBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Books List</h2>
        <h3>Search Books</h3>

Search by:
<asp:DropDownList ID="ddlSearchType" runat="server">
    <asp:ListItem Text="Book Name" Value="BookName"></asp:ListItem>
    <asp:ListItem Text="Author" Value="Author"></asp:ListItem>
    <asp:ListItem Text="Publication" Value="Publication"></asp:ListItem>
</asp:DropDownList>

<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>

<asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
<asp:Button ID="btnAll" runat="server" Text="View All" OnClick="btnAll_Click" />

<br /><br />


<asp:GridView ID="gvBooks" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="BookId"
    OnRowEditing="gvBooks_RowEditing"
    OnRowUpdating="gvBooks_RowUpdating"
    OnRowCancelingEdit="gvBooks_RowCancelingEdit"
    OnRowDeleting="gvBooks_RowDeleting">

    <Columns>
        <asp:BoundField DataField="BookId" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
        <asp:BoundField DataField="Author" HeaderText="Author" />
        <asp:BoundField DataField="Publication" HeaderText="Publication" />
        <asp:BoundField DataField="TotalCopies" HeaderText="Total Copies" />
        <asp:BoundField DataField="AvailableCopies" HeaderText="Available Copies" />

        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>


<br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
