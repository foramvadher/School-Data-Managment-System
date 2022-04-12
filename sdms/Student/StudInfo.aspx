<%@ Page Title="" Language="VB" MasterPageFile="~/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudInfo.aspx.vb" Inherits="Student_StudInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tablecss">
        <tr>
            <td colspan="2" style="text-align: center; font-weight: 700">Logged in as :
                <asp:Label ID="lblStudDispName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>First Name :</td>
            <td>
                <asp:Label ID="lblStudFirstName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Middle Name :</td>
            <td>
                <asp:Label ID="lblStudMidName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Last Name :</td>
            <td>
                <asp:Label ID="lblStudLastName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Admission No. :</td>
            <td>
                <asp:Label ID="lblAdmnNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Admission Date :</td>
            <td>
                <asp:Label ID="lblAdmnDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Date of Birth :</td>
            <td>
                <asp:Label ID="lblDOB" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Father&#39;s Name :</td>
            <td>
                <asp:Label ID="lblFatherName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Mother&#39;s Name : </td>
            <td>
                <asp:Label ID="lblMotherName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Aadhar No. :</td>
            <td>
                <asp:Label ID="lblAadharNo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Blood Group :</td>
            <td>
                <asp:Label ID="lblBG" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Phone No. (LL) :</td>
            <td>
                <asp:Label ID="lblPhoneNoLL" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Phone No.(Mob) :</td>
            <td>
                <asp:Label ID="lblPhoneNoMob" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Mail Id :</td>
            <td>
                <asp:Label ID="lblMailId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address : </td>
            <td>
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Category :</td>
            <td>
                <asp:Label ID="lblCategoryId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Identification Mark :</td>
            <td>
                <asp:Label ID="lblIdentificationMark" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdnStudMastId" runat="server" />

</asp:Content>

