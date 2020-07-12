<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeLog.aspx.cs" Inherits="hw05.TimeLog" %>

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
    <table class="auto-style1">
        <tr>
            <td>Date</td>
            <td>Time</td>
            <td>Hours</td>
        </tr>
        <tr>
            <td>4/6/19</td>
            <td>1400-2000</td>
            <td>6</td>
        </tr>
        <tr>
            <td>4/7/19</td>
            <td>1800-2200</td>
            <td>4</td>
        </tr>
        <tr>
            <td>4/10/19</td>
            <td>1700-2000</td>
            <td>3</td>
        </tr>
        <tr>
            <td>4/14/19</td>
            <td>1600-2100</td>
            <td>5</td>
        </tr>
        <tr>
            <td>4/18/19</td>
            <td>1800-2000</td>
            <td>2</td>
        </tr>
        <tr>
            <td>4/20/19</td>
            <td>1530-1700</td>
            <td>1.5</td>
        </tr>
    </table>
    <form id="form1" runat="server">
        <div>
            Total hours: 21.5</div>
    </form>
</body>
</html>
