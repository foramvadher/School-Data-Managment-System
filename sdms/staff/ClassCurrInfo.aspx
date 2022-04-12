<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ClassCurrInfo.aspx.vb" Inherits="ClassCurrInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <table class="auto-style1">
        <tr>
            <td style="margin-left: 600px">Class :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddClass" runat="server">
                </asp:DropDownList>
            </td>
            <td>Section :
                <asp:TextBox ID="txtSection" runat="server" Width="40px"></asp:TextBox>
            </td>
            <td>Class Teacher :
                <asp:TextBox ID="txtClassTeacher" runat="server" Width="250px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtClassTeacher_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServiceMethod="searchstaff" ServicePath="~/webservice.asmx" TargetControlID="txtClassTeacher" MinimumPrefixLength="2">
                </cc1:AutoCompleteExtender>
            </td>
            <td>
                <asp:Button ID="btnAddClassInfo" runat="server" Text="Add" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgClass" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="pnlGridViewClass" runat="server">
                    <asp:GridView ID="gvClassCurrInfo" runat="server" AutoGenerateColumns="False" DataKeyNames="ClassCurrInfoId" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ClassName" HeaderText="Class" ReadOnly="True" />
                            <asp:BoundField DataField="Section" HeaderText="Section" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Class Teacher">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtClassTeacherID" runat="server" Text='<%# Bind("StaffDispName") %>'></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="txtClassTeacherID_AutoCompleteExtender" runat="server" DelimiterCharacters="" Enabled="True" ServiceMethod="searchstaff" ServicePath="~/webservice.asmx" TargetControlID="txtClassTeacherID">
                                    </cc1:AutoCompleteExtender>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("StaffDispName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:HiddenField ID="hdnClassCurrInfoId" runat="server" />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
    </table>

</asp:Content>

