<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ClassYearMast.aspx.vb" Inherits="ClassYearMast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>Class :</td>
            <td>
                <asp:TextBox ID="txtAddClass" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAddClass" runat="server" Text="Add" />
            </td>
            <td>Year :</td>
            <td>
                <asp:TextBox ID="txtAddYear" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnAddYear" runat="server" Text="Add" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lblMsgClass" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lblMsgYear" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlGridViewClass" runat="server">
                    <asp:GridView ID="gvClassMast" runat="server" AutoGenerateColumns="False" DataKeyNames="ClassMastId" Width="90%">
                        <Columns>
                            <asp:BoundField DataField="ClassName" HeaderText="Classes" />
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td colspan="3">
                <asp:GridView ID="gvYearMast" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="YearName" HeaderText="Years" />
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:HiddenField ID="hdnClassMastId" runat="server" />
            </td>
            <td colspan="3">
                <asp:HiddenField ID="hdnYearMastId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

