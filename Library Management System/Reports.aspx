<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="Reports.aspx.cs"
    Inherits="Library_Management_System.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Library Reports</h2>

            <!-- REPORT BUTTONS -->
            <div class="form-actions">

                <asp:Button ID="btnBooks" runat="server"
                    Text="Books Report"
                    CssClass="primary-btn"
                    OnClick="btnBooks_Click" />

                <asp:Button ID="btnIssued" runat="server"
                    Text="Issued Books Report"
                    CssClass="secondary-btn"
                    OnClick="btnIssued_Click" />

            </div>

            <!-- REPORT GRID -->
            <div class="table-wrapper">

                <asp:GridView ID="gvReport" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="True">
                </asp:GridView>

            </div>

            <!-- PRINT + BACK -->
            <div class="form-actions">

                <asp:Button ID="btnPrint" runat="server"
                    Text="Print"
                    CssClass="primary-btn"
                    OnClientClick="window.print(); return false;" />

                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>

            </div>

        </div>
    </div>

</asp:Content>
