<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="hw03_FaberJames.Summary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HW03 - Summary</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 245px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ticket Holders for
                <asp:Label ID="lblEventName" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </h2>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnPurchaseMore" runat="server" OnClick="btnPurchaseMore_Click" Text="Purchase More Tickets" />
                </td>
                <td>&nbsp;Sort:<asp:RadioButtonList ID="radOrder" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radOrder_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Order Purchased</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Seat</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td>Remove Ticket Holder <asp:DropDownList ID="ddlRemove" runat="server">
                        <asp:ListItem>Choose Person to Remove</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
                </td>
            </tr>
        </table>
        <br />
        <asp:TextBox ID="txtMessage" runat="server" Height="251px" TextMode="MultiLine" Width="541px"></asp:TextBox>
    </form>
</body>
</html>
