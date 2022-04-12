<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MarksMast.aspx.vb" Inherits="MarksMast" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>
                
                <asp:Panel ID="Panel1" runat="server">
                    <table class="auto-style1">
                        <tr>
                            <td>Class :</td>
                            <td>
                                <asp:DropDownList ID="ddClass" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>Exam :</td>
                            <td>
                                <asp:DropDownList ID="ddExam" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>Sub :</td>
                            <td>
                                <asp:DropDownList ID="ddSub" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align:center">
                                <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGridView" runat="server">
                    <asp:GridView ID="gvMarks" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="StudCurrInfoID,StudMarksId">
                        <Columns>
                            <asp:BoundField HeaderText="Roll No." DataField="RollNo" />
                            <asp:BoundField HeaderText="Name" DataField="StudDispName" />
                            <asp:TemplateField HeaderText="Marks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMarks" runat="server" text ='<%# Bind("marks") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
         <tr>
            <td>
                
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                
                <asp:HiddenField ID="hdnClass" runat="server" />
                <asp:HiddenField ID="hdnExam" runat="server" />
                <asp:HiddenField ID="hdnSub" runat="server" />
                
            </td>
        </tr>
    </table>
</asp:Content>

