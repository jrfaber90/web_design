<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hw04_Faber.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajax via jQuery</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#btnCalculate').click(function () {
                var input = $('#txbEquation').val();
                $.ajax({
                    type: 'GET',
                    url: 'Calculate.aspx/DoMath',
                    data: { equation: input },
                    success: function (response) {
                        console.log(response);
                        $("txaAnswer").val(response);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>HW 4 - James Faber, <a href="Time%20Log.aspx">Time Log</a></h2>
        </div>
        <p>
            <input id="txbEquation"  type="text" />&nbsp;
            <input id="btnCalculate" type="button" value="Calculate" />
        </p>
        <p>
            <textarea id="txaAnswer">

            </textarea>
        </p>
    </form>
</body>
</html>
