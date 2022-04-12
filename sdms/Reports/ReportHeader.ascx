<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReportHeader.ascx.vb" Inherits="Reports_ReportHeader" %>
<table cellpadding="5" cellspacing="0" style="width:100%;border-collapse:collapse;border:solid thin black; font-family:Calibri">
    <tr>
        <td rowspan="2" style="width:10%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/reportLogo.PNG" />
        </td>
        <td style="text-align:center">
        <h2>
            <asp:Label ID="lblSchoolName" runat="server" Font-Bold="False"></asp:Label>
        </h2>
        </td>
        <td rowspan="2" style="width:10%; text-align:right">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/SDMSlogo.PNG" Height="150px" />
        </td>
    </tr>
    <tr>
        <td style="text-align:center">
            <asp:Label ID="lblSchoolAddr" runat="server" Font-Bold="False"></asp:Label>
        </td>
    </tr>
</table>

