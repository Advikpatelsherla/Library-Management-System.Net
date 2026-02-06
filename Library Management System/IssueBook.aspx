<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueBook.aspx.cs" Inherits="Library_Management_System.IssueBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Issue Book</h2>

<table>
    <tr>
        <td>Select Student:</td>
        <td>
            <asp:DropDownList ID="ddlStudent" runat="server"></asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td>Select Book:</td>
        <td>
            <asp:DropDownList ID="ddlBook" runat="server"></asp:DropDownList>
        </td>
    </tr>

    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnIssue" runat="server"
                        Text="Issue Book"
                        OnClick="btnIssue_Click" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </td>
    </tr>
</table>

<br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
