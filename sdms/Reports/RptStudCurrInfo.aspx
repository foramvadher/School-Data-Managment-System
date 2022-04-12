<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RptStudCurrInfo.aspx.vb" Inherits="Reports_RptStudCurrInfo" EnableEventValidation="false" %>

<%@ Register src="ReportHeader.ascx" tagname="ReportHeader" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
                    Class/Section :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddClassSection" runat="server" AutoPostBack="True">
                </asp:DropDownList>

    <asp:Panel ID="pnlPrint" runat="server"> 
    <table style="width:100%">
        <tr>
            <td colspan="2"> <uc1:ReportHeader ID="ReportHeader1" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Class/Section :
                <asp:Label ID="lblClass" runat="server"></asp:Label>
            </td>
            <td>
                <div style="float:right">
                     Class Teacher&nbsp; :&nbsp;
                     <asp:Label ID="lblClassTeacher" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvStudClassMap" runat="server" AutoGenerateColumns="False" CellPadding="5" Width="100%" DataKeyNames="ClassName,Section,StaffDispName">
                    <Columns>
                        <asp:BoundField DataField="RollNo" HeaderText="Roll No.">
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudDispName" HeaderText="Name">
                        <ItemStyle Width="500px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Remarks" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnExportPDF" runat="server" Text="Export to PDF" />
            </td>
        </tr>
    </table>
    </asp:Panel>  
</asp:Content>

