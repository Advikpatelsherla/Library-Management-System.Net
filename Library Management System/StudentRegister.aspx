<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="StudentRegister.aspx.cs"
    Inherits="Library_Management_System.StudentRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card">

            <h2 class="form-title">Student Registration</h2>

            <div class="form-group">
                <label>Student Name</label>
                <asp:TextBox ID="txtName" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Department</label>
                <asp:TextBox ID="txtDept" runat="server"
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

            <div class="form-group">
                <label>Password</label>
                <asp:TextBox ID="txtPassword" runat="server"
                    TextMode="Password"
                    CssClass="form-input"></asp:TextBox>
            </div>


            <div class="form-actions">
                <asp:Button ID="btnRegister" runat="server"
                    Text="Register"
                    CssClass="primary-btn"
                    OnClick="btnRegister_Click" />

                <a href="Login.aspx" class="secondary-btn">
                    Back to Login
                </a>
            </div>

            <asp:Label ID="lblMsg" runat="server"
                CssClass="success-msg"></asp:Label>

        </div>
    </div>

</asp:Content>
