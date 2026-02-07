<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="IssuedBooks.aspx.cs"
    Inherits="Library_Management_System.IssuedBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Issued Books (Not Returned)</h2>

            <!-- GRID VIEW -->
            <div class="table-wrapper">

                <asp:GridView ID="gvIssued" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="False">

                    <Columns>
                        <asp:BoundField DataField="StudentName" HeaderText="Student" />
                        <asp:BoundField DataField="BookName" HeaderText="Book" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>

                </asp:GridView>

            </div>

            <div class="form-actions">
                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

        </div>
    </div>

</asp:Content>
