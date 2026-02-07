<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="AddBook.aspx.cs"
    Inherits="Library_Management_System.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card">

            <h2 class="form-title">Add Book</h2>

            <div class="form-group">
                <label>Book Name</label>
                <asp:TextBox ID="txtBookName" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Author</label>
                <asp:TextBox ID="txtAuthor" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Publication</label>
                <asp:TextBox ID="txtPublication" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Total Copies</label>
                <asp:TextBox ID="txtTotal" runat="server"
                    CssClass="form-input"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnSave" runat="server"
                    Text="Save Book"
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
