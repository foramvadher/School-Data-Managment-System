<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptStaffInfo.aspx.vb" Inherits="Reports_RptStaffInfo" %>

<%@ Register src="ReportHeader.ascx" tagname="ReportHeader" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Panel ID="pnlPrint" runat="server"> 
    <table style="width:100%">
        <tr>
            <td colspan="2"> <uc1:ReportHeader ID="ReportHeader1" runat="server" /></td>
        </tr>
        <tr>
            <td>
                List of Staff</td>
            <td>
                <div style="float: right">
                    <asp:Label ID="lblPrincipal" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvStaffList" runat="server" AutoGenerateColumns="False" CellPadding="5" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="StaffMastId" HeaderText="Staff No.">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StaffDispName" HeaderText="Name">
                        <ItemStyle Width="500px" />
                        </asp:BoundField>
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnExportPDF" runat="server" Text="Save To Pdf" />
            </td>
        </tr>
    </table>
    </asp:Panel>  
</asp:Content>

