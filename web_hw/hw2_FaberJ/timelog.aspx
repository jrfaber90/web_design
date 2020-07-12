<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timelog.aspx.cs" Inherits="hw2_FaberJ.timelog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/default.aspx">HW2</asp:HyperLink>
        </div>
    </form>
    <table class="auto-style1">
        <tr>
            <td>Date</td>
            <td>Time</td>
            <td>Hours</td>
        </tr>
        <tr>
            <td>2-16-19</td>
            <td>1634-2000</td>
            <td>3.5</td>
        </tr>
        <tr>
            <td>2-17-19</td>
            <td>1700-2000</td>
            <td>3</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</body>
</html>
