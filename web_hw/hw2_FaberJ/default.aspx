<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="hw2_FaberJ._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 158px;
        }
        .auto-style3 {
            width: 149px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/timelog.aspx">Time Log</asp:HyperLink>
       <h3>Course Registration System</h3>
            <p>
                <asp:CheckBoxList ID="ckbExtras" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1000">Dorm</asp:ListItem>
                    <asp:ListItem Value="500">Meal Plan</asp:ListItem>
                    <asp:ListItem Value="50">Football Tixs</asp:ListItem>
                </asp:CheckBoxList>
            </p>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Available Classes</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>Registered Classes</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:ListBox ID="lbxAvailableClasses" runat="server" Height="316px" SelectionMode="Multiple" Width="155px"></asp:ListBox>
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                        <br />
                        <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove" />
                        <br />
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
                        <br />
                        Total Hours: <asp:Label ID="lblHours" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        <br />
                        Total Cost:
                        <asp:Label ID="lblCost" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox ID="lbxRegisteredClasses" runat="server" Height="302px" SelectionMode="Multiple" Width="155px"></asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblTooMany" runat="server" ForeColor="Red" Text="You cannot register for more than 19 hours" Visible="False"></asp:Label>
        <p>
            Class Number:
            <asp:TextBox ID="txtClassNum" runat="server"></asp:TextBox>
&nbsp; Credits:
            <asp:TextBox ID="txtCredits" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btnMakeAvailable" runat="server" OnClick="btnMakeAvailable_Click" Text="Make Available" />
&nbsp;<asp:Button ID="btnRemoveFromAvail" runat="server" OnClick="btnRemoveFromAvail_Click" Text="Remove From Available" />
&nbsp;<p>
            <asp:Label ID="lblSame" runat="server" ForeColor="Red" Text="Not added. Course already exists" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCredits" ErrorMessage="RangeValidator" ForeColor="Red" MaximumValue="10" MinimumValue="1" Type="Integer">Credit Hours must be between 1 and 10.</asp:RangeValidator>
        </p>
        <p>
            <asp:Label ID="lblNotRemRegFor" runat="server" ForeColor="Red" Text="Not Removed. Course is registered for." Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblNotFound" runat="server" ForeColor="Red" Text="Course not found." Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
