<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnBook.aspx.cs" Inherits="Library_Management_System.ReturnBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Return Book</h2>

<asp:GridView ID="gvIssuedBooks" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="IssueId"
    OnRowCommand="gvIssuedBooks_RowCommand">

    <Columns>
        <asp:BoundField DataField="IssueId" HeaderText="Issue ID" />
        <asp:BoundField DataField="StudentName" HeaderText="Student" />
        <asp:BoundField DataField="BookName" HeaderText="Book" />
        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />

        <asp:ButtonField Text="Return"
                         CommandName="ReturnBook"
                         ButtonType="Button" />
    </Columns>
</asp:GridView>

<br />
<asp:Label ID="lblMsg" runat="server"></asp:Label>
<br /><br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
