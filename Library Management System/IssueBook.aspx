<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="IssueBook.aspx.cs"
    Inherits="Library_Management_System.IssueBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card">

            <h2 class="form-title">Issue Book</h2>

            <!-- STUDENT SEARCHABLE DROPDOWN -->
            <div class="form-group">
                <label>Select Student</label>

                <ajaxToolkit:ComboBox
                    ID="cmbStudent"
                    runat="server"
                    CssClass="form-input"
                    AutoCompleteMode="SuggestAppend"
                    DropDownStyle="DropDown"
                    CaseSensitive="false">
                </ajaxToolkit:ComboBox>
            </div>

            <!-- BOOK SEARCHABLE DROPDOWN -->
            <div class="form-group">
                <label>Select Book</label>

                <ajaxToolkit:ComboBox
                    ID="cmbBook"
                    runat="server"
                    CssClass="form-input"
                    AutoCompleteMode="SuggestAppend"
                    DropDownStyle="DropDown"
                    CaseSensitive="false">
                </ajaxToolkit:ComboBox>
            </div>

            <!-- ACTION BUTTONS -->
            <div class="form-actions">
                <asp:Button ID="btnIssue" runat="server"
                    Text="Issue Book"
                    CssClass="primary-btn"
                    OnClick="btnIssue_Click" />

                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

            <!-- MESSAGE -->
            <asp:Label ID="lblMsg" runat="server"
                CssClass="success-msg">
            </asp:Label>

        </div>
    </div>

</asp:Content>
