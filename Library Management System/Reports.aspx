<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Library_Management_System.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Library Reports</h2>

<asp:Button ID="btnBooks" runat="server"
    Text="Books Report"
    OnClick="btnBooks_Click" />

<asp:Button ID="btnIssued" runat="server"
    Text="Issued Books Report"
    OnClick="btnIssued_Click" />

<br /><br />

<asp:GridView ID="gvReport" runat="server"
    AutoGenerateColumns="True"
    BorderWidth="1"
    CellPadding="5">
</asp:GridView>

<br />

<asp:Button ID="btnPrint" runat="server"
    Text="Print"
    OnClientClick="window.print(); return false;" />

<br /><br />
<a href="Dashboard.aspx">Back to Dashboard</a>

    </form>
</body>
</html>
