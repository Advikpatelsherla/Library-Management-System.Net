<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="Library_Management_System.AddBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Add Book</h2>

<table>
    <tr>
        <td>Book Name:</td>
        <td><asp:TextBox ID="txtBookName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Author:</td>
        <td><asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Publication:</td>
        <td><asp:TextBox ID="txtPublication" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Total Copies:</td>
        <td><asp:TextBox ID="txtTotal" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Save Book" OnClick="btnSave_Click" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
        </td>
    </tr>
</table>

<br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
