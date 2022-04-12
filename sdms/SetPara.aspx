<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SetPara.aspx.vb" Inherits="SetPara" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .newStyle1 {
            font-size: larger;
        }
        .newStyle2 {
            font-size: xx-large;
        }
        .auto-style4 {
            width: 10%;
        }
        .auto-style5 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
        <table class="auto-style1">
            <tr>
                <td style="text-align: center; font-weight: 700; width:20%">
    
                    <asp:Image ID="Image1" runat="server" Height="103px" ImageUrl="~/images/SchoolLogo.png" />
                    <br />
                    School Logo</td>
                <td colspan="2" style="font-weight: 700; text-align: center;">
    
                    <span class="newStyle2">
    
                    Welcome To SDMS....</span></td>
                <td style="text-align: center; font-weight: 700; width:20% ">
    
                    <asp:Image ID="Image2" runat="server" Height="124px" ImageUrl="~/images/SDMSlogo.PNG" Width="137px" style="text-align: center" />
                    <br />
&nbsp;SDMS Logo</td>
            </tr>
            <tr>
                <td colspan="2">Current Year :</td>
                <td colspan="2">
                    <asp:TextBox ID="txtCurrYear" runat="server" Visible="False"></asp:TextBox>
                    <asp:DropDownList ID="ddCurrYear" runat="server" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">School Name :</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSchoolName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">School Address :</td>
                <td colspan="2">
                    <asp:TextBox ID="txtSchoolAddr" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">School Logo :</td>
                <td colspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">Contact No. :</td>
                <td colspan="2">1.<asp:TextBox ID="txtContactNo1" runat="server"></asp:TextBox>
                    <br />
                    2.<asp:TextBox ID="txtContactNo2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div style="float:right">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <asp:HiddenField ID="hdnFirstEntry" runat="server" />
                </td>
            </tr>
        </table>
       
    </div>
    </form>
</body>
</html>
