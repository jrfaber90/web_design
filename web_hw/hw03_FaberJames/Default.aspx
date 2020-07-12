<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hw03_FaberJames.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW03 - James Faber</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>HW 3 - James Faber</h2>
            <p><a href="TimeLog.aspx">Time Log</a>&nbsp; <a href="ClassDiagram.aspx">Class Diagram</a></p>
            <p>&nbsp;</p>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Create Event">
                <br />
                Event Name:
                <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
                <br />
                <br />
                Available Seat Numbers: First
                <asp:TextBox ID="txtFirstSeat" runat="server" Width="32px"></asp:TextBox>
                &nbsp;Last
                <asp:TextBox ID="txtLastSeat" runat="server" Width="36px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnMakeEvent" runat="server" OnClick="btnMakeEvent_Click" Text="Make Event" />
                &nbsp;
                <asp:Button ID="btnStartOver" runat="server" Text="Start Over" OnClick="btnStartOver_Click" />
                <br />
            </asp:Panel>
            <p>
            </p>
        </div>
        <asp:Panel ID="Panel2" runat="server" GroupingText="Purchase Ticket">
            <br />
            Name
            <asp:TextBox ID="txtPersonName" runat="server"></asp:TextBox>
            &nbsp; Age
            <asp:TextBox ID="txtPersonAge" runat="server" Width="35px"></asp:TextBox>
            <br />
            <br />
            Pick Seat,
            <asp:Label ID="lblAvailSeats" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            &nbsp;available<br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:ListBox ID="lbxAvailSeats" runat="server" Height="292px" Width="81px"></asp:ListBox>
                    </td>
                    <td>
                        <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
                        <br />
                        <asp:Button ID="btnEventSummary" runat="server" Text="Event Summary" OnClick="btnEventSummary_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
