<%@ Page Title="" Language="VB" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudMarksRpt.aspx.vb" Inherits="Student_StudMarksRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        Class :
        <asp:DropDownList ID="ddClass" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </div>
    <br />
    <div></div>
    <div>
        <asp:GridView ID="gvStudMarks" runat="server">
        </asp:GridView>
    </div>
</asp:Content>

