<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssuedBooks.aspx.cs" Inherits="Library_Management_System.IssuedBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Issued Books (Not Returned)</h2>

<asp:GridView ID="gvIssued" runat="server"
    AutoGenerateColumns="False"
    BorderWidth="1"
    CellPadding="5">

    <Columns>
        <asp:BoundField DataField="StudentName" HeaderText="Student" />
        <asp:BoundField DataField="BookName" HeaderText="Book" />
        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>
</asp:GridView>

<br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
