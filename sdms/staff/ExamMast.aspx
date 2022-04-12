<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ExamMast.aspx.vb" Inherits="staff_ExamMast" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table style="width:100%">
        <tr>
            <td>Exam :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtExamNameSearch" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
            </td>
            <td>
                <asp:Button ID="btnAddExam" runat="server" Text="Add New" />
                <cc1:ModalPopupExtender ID="btnAddExam_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseAdd" PopupControlID="pnlAdd" TargetControlID="btnAddExam">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlGridView" runat="server">
                    <asp:GridView ID="gvExamMast" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ExamMastId">
                        <Columns>
                            <asp:BoundField DataField="ExamName" HeaderText="Exam Name" />
                            <asp:BoundField DataField="ExamTypeName" HeaderText="Exam Type" />
                            <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                            <asp:BoundField DataField="PassingMarks" HeaderText="Passing Marks" />
                            <asp:CheckBoxField DataField="ConsiderForFinal" Text="Considered For Final" />
                            <asp:BoundField DataField="Weightage" HeaderText="Weightage (in %)" />
                            <asp:ButtonField CommandName="Edit1" Text="Edit" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlAdd" runat="server" CssClass="modalPopup">
                <table style="width:98%;" class="tablecss">
                    
                    <tr>
                        <td colspan="2">
                            <div style="float:right">
                                <asp:ImageButton ID="imgCloseAdd" runat="server" ImageUrl="~/images/close1.jpg" />
                            </div>
                            <asp:Label ID="lblHeader" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Exam Name</td>
                        <td>
                            <asp:TextBox ID="txtExamNameAdd" runat="server"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ExamType</td>
                        <td>
                            <asp:DropDownList ID="ddExamTypeAdd" runat="server" Width="163px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total Marks</td>
                        <td>
                            <asp:TextBox ID="txtTotalMarksAdd" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Passing Marks</td>
                        <td>
                            <asp:TextBox ID="txtPassingMarksAdd" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>Consider for Final Result</td>
                        <td>
                            <asp:CheckBox ID="chbConsiderForFinal" runat="server" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblWeightage" runat="server" Text="Weightage" Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWeightage" runat="server" Visible="False"></asp:TextBox>
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
            <td colspan="3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:HiddenField ID="hdnExamMastId" runat="server" />
                <br />
                <asp:HiddenField ID="hdnEdit" runat="server" />
                <cc1:ModalPopupExtender ID="hdnEdit_ModalPopupExtender" runat="server"  Enabled="True" OkControlID="imgCloseAdd" PopupControlID="pnlAdd" TargetControlID="hdnEdit">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
</asp:Content>

