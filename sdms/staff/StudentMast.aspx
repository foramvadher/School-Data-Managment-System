<%@ Page Title="Student Master" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="StudentMast.aspx.vb" Inherits="StudentMast" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <script src="~js/encrypt.js"></script>
     <script type="text/javascript">

    </script>
    <style type="text/css">
        .auto-style4 {
        }
        .auto-style5 {
            height: 21px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            height: 29px;
        }
        .viewheader {
            width: 199px;
            font-weight:bold;
        }
        .auto-style9 {
            width: 199px;

        }
        .auto-style10 {
            height: 54px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlSearch" runat="server">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style5">
                                Name</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtStudDispNameSearch" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style5">Address</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtAddrSearch" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                Admission No</td>
                            <td>
                                <asp:TextBox ID="txtAdmnNoSearch" runat="server"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
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
                <asp:Panel ID="pnlGrid" runat="server" Visible="False">
                    <asp:GridView ID="gvStudMast" runat="server" AutoGenerateColumns="False" Width="1004px" AllowPaging="True" DataKeyNames="StudMastId" EmptyDataText="  ">
                        <Columns>
                            <asp:BoundField DataField="AdmnNo" HeaderText="Admission No." ReadOnly="True" />
                            <asp:BoundField DataField="StudDispName" HeaderText="Name" />
                            <asp:BoundField DataField="addr" HeaderText="Address" />
                            <asp:BoundField DataField="PhNoMob" HeaderText="Phone No.(Mob)" />
                            <asp:BoundField DataField="AadharNo" HeaderText="Aadhar No." />
                            <asp:BoundField DataField="dob" DataFormatString="{0:dd/MM/yyyy}" HeaderText="DOB" />
                            <asp:BoundField DataField="TransferDate" HeaderText="Transfer Date" NullDisplayText=" " />
                            <asp:CommandField SelectText="View" ShowSelectButton="True" />
                            <asp:ButtonField CommandName="edit1" Text="Edit" />
                            <asp:ButtonField CommandName="Transfer" Text="Transfer" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEdit" runat="server" CssClass="modalPopup" >
                <table style="width:98%;" class="tblpopup">
                    
                    <tr>
                        <td colspan="2" class="auto-style10">
                            <asp:Label ID="lblHeaderEdit" runat="server" Text="Label"></asp:Label>
                             <div style="float:right">
                                <asp:ImageButton ID="imgCloseEdit" runat="server" ImageUrl="~/images/close1.jpg" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>First Name</td>
                        <td>
                            <asp:TextBox ID="txtStudFirstNameEdit" runat="server"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Middle Name</td>
                        <td>
                            <asp:TextBox ID="txtStudMidNameEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name</td>
                        <td>
                            <asp:TextBox ID="txtStudLastNameEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Father&#39;s Name</td>
                        <td>
                            <asp:TextBox ID="txtFatherNameEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mother&#39;s Name</td>
                        <td>
                            <asp:TextBox ID="txtMotherNameEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            Date Of Admission</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="txtDateOfAdmnEdit" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateOfAdmnEdit_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDateOfAdmnEdit" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Admission No.</td>
                        <td>
                            <asp:TextBox ID="txtAdmnNoEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Aadhar No.</td>
                        <td>
                            <asp:TextBox ID="txtAadharNoEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Date of Birth</td>
                        <td>
                            <asp:TextBox ID="txtDOBEdit" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDOBEdit_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOBEdit" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Blood Group</td>
                        <td>
                            <asp:TextBox ID="txtBGEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone No.(LL)</td>
                        <td>
                            <asp:TextBox ID="txtPhNoLLEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone No.(Mob)</td>
                        <td>
                            <asp:TextBox ID="txtPhNoMobEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mail Id</td>
                        <td>
                            <asp:TextBox ID="txtMailIdEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Adress</td>
                        <td>
                            <asp:TextBox ID="txtAddrEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Category</td>
                        <td>
                            <asp:TextBox ID="txtCategoryIdEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Identification Mark</td>
                        <td>
                            <asp:TextBox ID="txtIdentificationMarkEdit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMsg1" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
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
            <td>
                <asp:Panel ID="pnlView" runat="server" CssClass="modalPopup">
                <table class="tablecss" style="width:98%">
                    <tr>
                        <td class="viewheader">
                            Student ID</td>
                        <td>
                            <asp:Label ID="lblStudMastIdView" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            First Name</td>
                        <td>
                            <asp:Label ID="lblStudFirstNameView" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Middle Name</td>
                        <td>
                            <asp:Label ID="lblStudMidNameView" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Last Name
                        </td>
                        <td>
                            <asp:Label ID="lblStudLastNameView" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Father&#39;s Name</td>
                        <td>
                            <asp:Label ID="lblFatherNameView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Mother&#39;s Name</td>
                        <td>
                            <asp:Label ID="lblMotherNameView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Date Of Admission</td>
                        <td>
                            <asp:Label ID="lblDateOfAdmnView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Admission No.</td>
                        <td>
                            <asp:Label ID="lblAdmnNoView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Aadhar No.</td>
                        <td>
                            <asp:Label ID="lblAadharNoView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">Date of Birth</td>
                        <td>
                            <asp:Label ID="lblDOBView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Blood Group</td>
                        <td>
                            <asp:Label ID="lblBGView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Phone No.(LL)</td>
                        <td>
                            <asp:Label ID="lblPhNoLLView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Phone No.(Mob)</td>
                        <td>
                            <asp:Label ID="lblPhNoMobView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Mail Id</td>
                        <td>
                            <asp:Label ID="lblMailIdView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style9">
                            Adress</td>
                        <td class="auto-style6">
                            <asp:Label ID="lblAddrView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Category</td>
                        <td>
                            <asp:Label ID="lblCategoryIdView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="viewheader">
                            Identification Mark</td>
                        <td>
                            <asp:Label ID="lblIdentificationMarkView" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnOk" runat="server" Text="OK" />
                        </td>
                    </tr>
                </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Panel ID="pnlTransferInfo" runat="server" CssClass="modalPopup">
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblHeaderTransfer" runat="server" Text="Label"></asp:Label>
                                 <div style="float:right">
                                    <asp:ImageButton ID="imgCloseTransfer" runat="server" ImageUrl="~/images/close1.jpg" />
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>Transfer Date :</td>
                            <td>
                                <asp:TextBox ID="txtTransferDate" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtTransferDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtTransferDate">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>Transfer Reason :</td>
                            <td>
                                <asp:TextBox ID="txtTransferReason" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSubmitTransfer" runat="server" Text="Submit" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

             </td>
        </tr>
        </table>
    <asp:HiddenField ID="hdnStudMastID" runat="server" Value="0" />
    <cc1:ModalPopupExtender ID="hdnStudMastID_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseEdit" PopupControlID="pnlEdit" TargetControlID="hdnStudMastID" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hdnView" runat="server" />
    <asp:Panel ID="Panel2" runat="server">
        <asp:HiddenField ID="hdnTransferInfo" runat="server" />
        <cc1:ModalPopupExtender ID="hdnTransferInfo_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseTransfer" PopupControlID="pnlTransferInfo" TargetControlID="hdnTransferInfo" BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
    </asp:Panel>
    <asp:HiddenField ID="hdnNew" runat="server" />
    <cc1:ModalPopupExtender ID="hdnNew_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseEdit" PopupControlID="pnlEdit" TargetControlID="hdnNew" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <cc1:ModalPopupExtender ID="hdnView_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="btnOK" PopupControlID="pnlView" TargetControlID="hdnView" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
</asp:Content>

