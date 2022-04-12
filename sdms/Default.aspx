<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/encrypt.js"></script>
    <script type="text/javascript">
        function encryptpass()
        {
            var pass = document.getElementById('txtPass');
            pass.value = MD5(pass.value);
        }


    </script>
    <title>LoginPage</title>
    <style>
        #container {
            width: 300px; /*can be in percentage also.*/
            height: 200px;
            margin: 100px auto auto auto;
            padding: 10px;
            position: relative;
            background-color: white;
            box-shadow: 10px 10px 20px #050505;
        }

        #main_content {
            top: 200px;
            left: 0px;
            width: 100%;
            height: 500px;
            /*background-color: whitesmoke;*/
        }


        body {
            background: url('images/schoolPhoto.jpg') no-repeat;
            background-size: 100%;
        }
            body:before {
                content: "";
                display: block;
                position: fixed;
                width: 100%;
                height: 100%;
                left: 0;
                top: 0;
                z-index: -1;
                background-color: rgba(255, 255, 255, 0.6);
            }
        .auto-style2 {
            width: 598px;
            height: 78px;
        }
        input[type="submit"] {
            border-style: none;
        border-color: inherit;
        border-width: medium;
        background-color: #008dde !important;
        border-radius: 3px;
        -moz-border-radius: 3px;
        -webkit-border-radius: 3px;
        color: white !important;
        cursor: pointer;
        font-family: 'Open Sans', Arial, Helvetica, sans-serif;
        text-transform: uppercase;
        -webkit-appearance:none;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div id="main_content">
            <div style="width:100%;text-align:center;margin-top:30px;"><img alt="" class="auto-style2" src="images/sdms.gif" /></div>
            <div id="container">

                <table cellpadding="4" cellspacing="0" style="width: 100%; height: 100%;">
                    <tr>
                        <td colspan="2" style="text-align: center; font-weight: 700; background-color: #79D5B7;color:#FD5200;" >Login As...</td>
                    </tr>
                    <tr>
                        <td>User name</td>
                        <td>
                            <asp:TextBox ID="txtUser" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>User Type</td>
                        <td>

                            <asp:DropDownList ID="ddUserType" runat="server" Width="150px">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td >
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="encryptpass()" Width="150px" />
                        </td>
                    </tr>

                </table>

            </div>
        </div>

    </form>
</body>
</html>
