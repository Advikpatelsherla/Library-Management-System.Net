<%@ Page Language="C#"
    AutoEventWireup="true"
    MasterPageFile="~/Site.Master"
    CodeBehind="ViewStudents.aspx.cs"
    Inherits="Library_Management_System.ViewStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-wrapper">
        <div class="form-card wide-card">

            <h2 class="form-title">Students List</h2>

            <!-- SEARCH SECTION -->
            <div class="search-section">

                <asp:TextBox ID="txtSearch" runat="server"
                    CssClass="form-input"
                    placeholder="Search by student name"></asp:TextBox>

                <asp:Button ID="btnSearch" runat="server"
                    Text="Search"
                    CssClass="primary-btn"
                    OnClick="btnSearch_Click" />


            </div>

            <!-- GRID VIEW -->
            <div class="table-wrapper">
    <div class="grid-scroll">

        <asp:GridView ID="gvStudents" runat="server"
            CssClass="styled-grid"
            AutoGenerateColumns="False"
            DataKeyNames="StudentId"
            OnRowEditing="gvStudents_RowEditing"
            OnRowUpdating="gvStudents_RowUpdating"
            OnRowCancelingEdit="gvStudents_RowCancelingEdit"
            OnRowDeleting="gvStudents_RowDeleting">

            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="StudentName" HeaderText="Name" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>

        </asp:GridView>

    </div>
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
