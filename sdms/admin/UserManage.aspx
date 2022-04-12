<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserManage.aspx.vb" Inherits="admin_UserManage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
        <table style="width:100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlSearch" runat="server">
                    <table >
                        <tr>
                            <td >
                                Name</td>
                            <td >
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td >UserID</td>
                            <td >
                                <asp:TextBox ID="txtUID" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;" colspan="4">
                                <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center;">
                                <asp:Button ID="btnSearch" runat="server" style="text-align: center" Text="SEARCH" Width="112px" />
                                <asp:Button ID="btnNew" runat="server" style="text-align: center" Text="New Record" Width="112px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <asp:HiddenField ID="hdnStudMastID" runat="server" Value="0" />
    <cc1:ModalPopupExtender ID="hdnStudMastID_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseEdit" PopupControlID="pnlEdit" TargetControlID="hdnStudMastID" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnView" runat="server" />
    <asp:HiddenField ID="hdnNew" runat="server" />
    <cc1:ModalPopupExtender ID="hdnNew_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseEdit" PopupControlID="pnlEdit" TargetControlID="hdnNew" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="hdnView_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="btnOK" PopupControlID="pnlView" TargetControlID="hdnView" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
</asp:Content>

