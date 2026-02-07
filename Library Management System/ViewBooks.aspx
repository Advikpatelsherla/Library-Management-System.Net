<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="ViewBooks.aspx.cs"
    Inherits="Library_Management_System.ViewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Books List</h2>

            <!-- SEARCH SECTION -->
            <div class="search-section">

                <asp:DropDownList ID="ddlSearchType" runat="server" CssClass="form-input">
                    <asp:ListItem Text="Book Name" Value="BookName"></asp:ListItem>
                    <asp:ListItem Text="Author" Value="Author"></asp:ListItem>
                    <asp:ListItem Text="Publication" Value="Publication"></asp:ListItem>
                </asp:DropDownList>

                <asp:TextBox ID="txtSearch" runat="server"
                    CssClass="form-input"
                    placeholder="Search..."></asp:TextBox>

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="primary-btn"
                    OnClick="btnSearch_Click" />

                <asp:Button ID="btnAll" runat="server"
                    Text="View All"
                    CssClass="secondary-btn"
                    OnClick="btnAll_Click" />

            </div>

            <!-- GRID VIEW -->
            <div class="table-wrapper">

                <asp:GridView ID="gvBooks" runat="server"
                    CssClass="styled-grid"
                    AutoGenerateColumns="False"
                    DataKeyNames="BookId"
                    OnRowEditing="gvBooks_RowEditing"
                    OnRowUpdating="gvBooks_RowUpdating"
                    OnRowCancelingEdit="gvBooks_RowCancelingEdit"
                    OnRowDeleting="gvBooks_RowDeleting">

                    <Columns>
                        <asp:BoundField DataField="BookId" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="BookName" HeaderText="Book Name" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="Publication" HeaderText="Publication" />
                        <asp:BoundField DataField="TotalCopies" HeaderText="Total Copies" />
                        <asp:BoundField DataField="AvailableCopies" HeaderText="Available Copies" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>

                </asp:GridView>

            </div>

            <!-- ACTIONS -->
            <div class="form-actions">
                <a href="Dashboard.aspx" class="secondary-btn">
                    Go Back
                </a>
            </div>

        </div>
    </div>

</asp:Content>
