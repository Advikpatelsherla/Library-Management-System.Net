<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendReminder.aspx.cs" Inherits="Library_Management_System.SendReminder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h2>Send Email Reminder</h2>

Search Student:
<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
<asp:Button ID="btnSearch" runat="server"
    Text="Search"
    OnClick="btnSearch_Click" />
<asp:Button ID="btnAll" runat="server"
    Text="View All"
    OnClick="btnAll_Click" />

<br /><br />

<asp:GridView ID="gvIssuedAll" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="Email">

    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>Select</HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="StudentName" HeaderText="Student" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="BookName" HeaderText="Book" />
        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" />
        <asp:BoundField DataField="DueDate" HeaderText="Due Date" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>
</asp:GridView>

<br />

<asp:Button ID="btnSend" runat="server"
    Text="Send Reminder to Selected"
    OnClick="btnSend_Click" />

<br /><br />
<asp:Label ID="lblMsg" runat="server"></asp:Label>

<br /><br />
<a href="Dashboard.aspx">Back to Dashboard</a>


    </form>
</body>
</html>
