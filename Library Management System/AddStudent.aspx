<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Library_Management_System.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Add Student</h2>

<table>
    <tr>
        <td>Student Name:</td>
        <td><asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Department:</td>
        <td><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Mobile:</td>
        <td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnSave" runat="server"
                        Text="Save Student"
                        OnClick="btnSave_Click" />
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
