<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="AddStudent.aspx.cs"
    Inherits="Library_Management_System.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card">

            <h2 class="form-title">Manage Student</h2>

            <div class="form-group">
                <label>Student Name</label>
                <asp:TextBox ID="txtStudentName" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Department</label>
                <asp:TextBox ID="txtDepartment" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Mobile</label>
                <asp:TextBox ID="txtMobile" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnSave" runat="server"
                    Text="Save Student"
                    CssClass="primary-btn"
                    OnClick="btnSave_Click" />

                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

            <asp:Label ID="lblMsg" runat="server"
                CssClass="success-msg"></asp:Label>

        </div>
    </div>

</asp:Content>
