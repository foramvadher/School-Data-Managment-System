<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StudCurrInfo.aspx.vb" Inherits="staff_StudCurrInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td style="width:50%">Class/Section :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddClassSection" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <div style="float:left">
                </div>
                <div style="float: right">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" />
                    <cc1:ModalPopupExtender ID="btnAdd_ModalPopupExtender" runat="server" Enabled="True" OkControlID="imgCloseAdd" PopupControlID="pnlAdd" TargetControlID="btnAdd">
                    </cc1:ModalPopupExtender>
                </div>

            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                    <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float:left">
                    <asp:Label ID="lblHeaderClassSection" runat="server"></asp:Label>
                </div>
                <br />
                <asp:GridView ID="gvStudClassMap" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="StudCurrInfoId">
                    <Columns>
                        <asp:BoundField DataField="StudDispName" HeaderText="Name" />
                        <asp:BoundField DataField="RollNo" HeaderText="Roll No." />
                        <asp:ButtonField CommandName="Edit1" Text="Edit" />
                    </Columns>
                </asp:GridView>
                <br />
                <div style="float:left">
                    &nbsp;<asp:Button ID="btnOrganize" runat="server" Text="Organize Roll No." OnClientClick="return confirm('Are your sure ?');" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlAdd" runat="server">
                    <table class="modalPopup">
                        <tr>
                            <td>Student :</td>
                            <td>
                                <div style="float:right">
                                    <asp:ImageButton ID="imgCloseAdd" runat="server" ImageUrl="~/images/close1.jpg" />
                                 </div>
                                <asp:TextBox ID="txtStudent" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="txtStudent_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="~/webservice.asmx" TargetControlID="txtStudent" ServiceMethod="SearchStud">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Roll No.:</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txtRollNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:HiddenField ID="hdnStudCurrInfoId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnClassCurrInfoId" runat="server" Value="0" />
            </td>
        </tr>
    </table>
</asp:Content>

