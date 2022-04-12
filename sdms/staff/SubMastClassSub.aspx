<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SubMastClassSub.aspx.vb" Inherits="staff_SubMastClassSub" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 119px;
        }
        .auto-style6 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width:100%">
        <tr>
            <td style="width:50%; vertical-align:top">
                <table>
                    <tr>
                        <td>Class :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddClassNameSearch" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnAddClassSub" runat="server" Text="Add New Subject to Class" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMsgClassSub" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlGridViewClassSub" runat="server">
                                <asp:GridView ID="gvViewClassSub" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" DataKeyNames="ClassSubId">
                                    <Columns>
                                        <asp:BoundField DataField="SubName" HeaderText="Subjects" />
                                        <asp:ButtonField CommandName="Edit1" Text="Edit" />
                                        <asp:ButtonField CommandName="Delete1" Text="Delete" />
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            
                            <asp:Panel ID="pnlAddEditClassSub" runat="server" CssClass="modalPopup">
                                <table class="auto-style1">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblAddEditClassSub" runat="server"></asp:Label>
                                            <div style="float:right">
                                <asp:ImageButton ID="imgCloseAddClassSub" runat="server" ImageUrl="~/images/close1.jpg" />
                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style6">Subject :</td>
                                        <td class="auto-style6">
                                            <asp:TextBox ID="txtAddSub" runat="server"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="txtAddSub_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServicePath="~/webservice.asmx" TargetControlID="txtAddSub" ServiceMethod="SearchSub">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnSubmitClassSub" runat="server" Text="Submit" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlConfirm" runat="server" CssClass="modalPopup">
                                <table class="auto-style1">
                                    <tr>
                                        <td>
                                            Confirmation....</td>
                                    </tr>
                                    <tr>
                                        <td>Are you Sure ?</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="float: right">
                                                <asp:Button ID="btnYes" runat="server" Text="YES" />
                                            </div>
                                            <div style="float: left">
                                                <asp:Button ID="btnNo" runat="server" Text="NO" />
                                            </div>
                                            

                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width:50%; vertical-align:top">
                <table class="auto-style1">
                    <tr>
                        <td>Subject :<asp:TextBox ID="txtSubNameSearch" runat="server"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtSubNameSearch_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServiceMethod="SearchSub" ServicePath="~/webservice.asmx" TargetControlID="txtSubNameSearch">
                            </cc1:AutoCompleteExtender>
                            <asp:Button ID="btnSearchSubMast" runat="server" Text="Search" />
                        </td>
                        <td>
                            <asp:Button ID="btnAddSubMast" runat="server" Text="Add New Subject" />
                            <cc1:ModalPopupExtender ID="btnAddSubMast_ModalPopupExtender" runat="server" Enabled="True" OkControlID="imgCloseEditSub" PopupControlID="pnlAddEditSubMast" TargetControlID="btnAddSubMast" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMsgSubMast" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style5">
                            <asp:GridView ID="gvViewSubMast" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="SubMastId" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="SubName" HeaderText="SubjectName" />
                                    <asp:BoundField DataField="SubDescription" HeaderText="Subject Description" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlAddEditSubMast" runat="server" CssClass="modalPopup">
                                <table class="auto-style1">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblAddEditSubMast" runat="server"></asp:Label>
                                            <div style="float:right">
                                <asp:ImageButton ID="imgCloseEditSub" runat="server" ImageUrl="~/images/close1.jpg" />
                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Subject Name :</td>
                                        <td>
                                            <asp:TextBox ID="txtSubName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Subject Description :</td>
                                        <td>
                                            <asp:TextBox ID="txtSubDescription" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btnSubmitSubMast" runat="server" Text="Submit" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlConfirm0" runat="server" CssClass="modalPopup">
                                <table class="auto-style1">
                                    <tr>
                                        <td>
                                            Confirmation....</td>
                                    </tr>
                                    <tr>
                                        <td>Are you Sure ?</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="float: right">
                                                <asp:Button ID="btnYes0" runat="server" Text="YES" />
                                            </div>
                                            <div style="float: left">
                                                <asp:Button ID="btnNo0" runat="server" Text="NO" />
                                            </div>
                                            

                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnClassSubId" runat="server" />
    <asp:HiddenField ID="hdnSubMastId" runat="server" />
    <asp:HiddenField ID="hdnEditClassSub" runat="server" />
    <cc1:ModalPopupExtender ID="hdnEditClassSub_ModalPopupExtender" runat="server" Enabled="True" OkControlID="imgCloseAddClassSub" PopupControlID="pnlAddEditClassSub" TargetControlID="hdnEditClassSub">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEditSubMast" runat="server" />
    <asp:HiddenField ID="hdnConfirmClassSub" runat="server" />
    <cc1:ModalPopupExtender ID="hdnConfirmClassSub_ModalPopupExtender" runat="server" Enabled="True" OkControlID="btnNo" PopupControlID="pnlConfirm" TargetControlID="hdnConfirmClassSub">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnConfirmSubMast" runat="server" />
    <cc1:ModalPopupExtender ID="hdnConfirmSubMast_ModalPopupExtender" runat="server" Enabled="True" OkControlID="btnNo0" PopupControlID="pnlConfirm0" TargetControlID="hdnConfirmSubMast">
    </cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="hdnEditSubMast_ModalPopupExtender" runat="server" Enabled="True" OkControlID="imgCloseEditSub" PopupControlID="pnlAddEditSubMast" TargetControlID="hdnEditSubMast">
    </cc1:ModalPopupExtender>
</asp:Content>

