<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Library_Management_System.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h2>Library Management System</h2>
<hr />

<ul>
    <li><a href="AddBook.aspx">Manage Books</a></li>
    <li><a href="ViewBooks.aspx">View Books</a></li>
    <li><a href="AddStudent.aspx">Manage Students</a></li>
    <li><a href="ViewStudents.aspx">View Students</a></li>
    <li><a href="IssueBook.aspx">Issue Book</a></li>
    <li><a href="ReturnBook.aspx">Return Book</a></li>
    <li><a href="IssuedBooks.aspx">Issued Books</a></li>
    <li><a href="SendReminder.aspx">Send Email Reminder</a></li>
    <li><a href="Reports.aspx">Reports</a></li>


</ul>

    </form>
</body>
</html>
