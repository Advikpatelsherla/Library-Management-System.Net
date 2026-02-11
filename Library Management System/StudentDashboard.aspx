<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="StudentDashboard.aspx.cs"
    Inherits="Library_Management_System.StudentDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Student Dashboard</h2>

            <!-- SEARCH SECTION -->
            <div class="search-section">

                <asp:TextBox ID="txtSearch" runat="server"
                    CssClass="form-input"
                    placeholder="Search by Book Name or Author"></asp:TextBox>

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="primary-btn"
                    OnClick="btnSearch_Click" />

                <asp:Button ID="btnAll" runat="server"
                    Text="View All"
                    CssClass="secondary-btn"
                    OnClick="btnAll_Click" />

            </div>

            <h3>📚 Available Books</h3>

            <div class="grid-scroll">
                <asp:GridView ID="gvBooks" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="False">

                    <Columns>
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="Publication" HeaderText="Publication" />
                        <asp:BoundField DataField="AvailableCopies" HeaderText="Available Copies" />
                    </Columns>
                </asp:GridView>
            </div>

            <br />

            <h3>📖 My Issued Books</h3>

            <div class="grid-scroll">
                <asp:GridView ID="gvMyBooks" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="False"
                    OnRowDataBound="gvMyBooks_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>

                </asp:GridView>

            </div>

        </div>
    </div>

</asp:Content>

