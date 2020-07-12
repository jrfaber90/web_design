<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeLog.aspx.cs" Inherits="hw03_FaberJames.TimeLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Default.aspx">Default</a><br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td>Date</td>
                    <td>Time</td>
                    <td>Hours</td>
                </tr>
                <tr>
                    <td>3/7/19</td>
                    <td>1015 - 1415</td>
                    <td>4</td>
                </tr>
                <tr>
                    <td>3/10/19</td>
                    <td>2030 - 2330</td>
                    <td>3</td>
                </tr>
                <tr>
                    <td>3/11/19</td>
                    <td>1430 - 2030</td>
                    <td>6</td>
                </tr>
                <tr>
                    <td>3/12/19</td>
                    <td>1300 - 1345 , 1530 - 1900</td>
                    <td>6.75</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
