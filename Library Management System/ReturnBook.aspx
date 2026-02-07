<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="ReturnBook.aspx.cs"
    Inherits="Library_Management_System.ReturnBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Return Book</h2>

            <!-- GRID VIEW -->
            <div class="table-wrapper">

                <asp:GridView ID="gvIssuedBooks" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="False"
                    DataKeyNames="IssueId"
                    OnRowCommand="gvIssuedBooks_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="IssueId" HeaderText="Issue ID" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student" />
                        <asp:BoundField DataField="BookName" HeaderText="Book" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />

                        <asp:ButtonField
                            Text="Return"
                            CommandName="ReturnBook"
                            ButtonType="Button" />
                    </Columns>

                </asp:GridView>

            </div>

            <asp:Label ID="lblMsg" runat="server"
                CssClass="success-msg"></asp:Label>

            <div class="form-actions">
                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

        </div>
    </div>

</asp:Content>
