<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="IssueBook.aspx.cs"
    Inherits="Library_Management_System.IssueBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card">

            <h2 class="form-title">Issue Book</h2>

            <div class="form-group">
                <label>Select Student</label>
                <asp:DropDownList ID="ddlStudent" runat="server"
                    CssClass="form-input">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Select Book</label>
                <asp:DropDownList ID="ddlBook" runat="server"
                    CssClass="form-input">
                </asp:DropDownList>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnIssue" runat="server"
                    Text="Issue Book"
                    CssClass="primary-btn"
                    OnClick="btnIssue_Click" />

                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

            <asp:Label ID="lblMsg" runat="server"
                CssClass="success-msg"></asp:Label>

        </div>
    </div>

</asp:Content>
