<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="Library_Management_System.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

       <h1 class="dashboard-heading">
            Library Management System
        </h1>
        <hr />
<div class="dashboard-grid">

    <div class="dashboard-card">
        <a href="AddBook.aspx">
            <i class="fa-solid fa-book"></i>
            <h3>Add Book</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="ViewBooks.aspx">
            <i class="fa-solid fa-book-open"></i>
            <h3>View Books</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="AddStudent.aspx">
            <i class="fa-solid fa-user-plus"></i>
            <h3>Add Student</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="ViewStudents.aspx">
            <i class="fa-solid fa-users"></i>
            <h3>View Students</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="IssueBook.aspx">
            <i class="fa-solid fa-arrow-up-right-from-square"></i>
            <h3>Issue Book</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="ReturnBook.aspx">
            <i class="fa-solid fa-arrow-rotate-left"></i>
            <h3>Return Book</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="IssuedBooks.aspx">
            <i class="fa-solid fa-clipboard-list"></i>
            <h3>Issued Books</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="SendReminder.aspx">
            <i class="fa-solid fa-envelope"></i>
            <h3>Send Reminder</h3>
        </a>
    </div>

    <div class="dashboard-card">
        <a href="Reports.aspx">
            <i class="fa-solid fa-chart-column"></i>
            <h3>Reports</h3>
        </a>
    </div>

</div>


</asp:Content>

