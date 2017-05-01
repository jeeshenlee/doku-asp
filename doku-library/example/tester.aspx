<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tester.aspx.cs" Inherits="doku_library.example.tester" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Doku Tester Page</title>
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script type="text/javascript">
        $(function () {
            var urlHost = window.location.host;
            $("#form_type").change(function () {
                $("#payment_channel").change();
            });
            $("#payment_channel").change(function () {
                if (this.value == "15" || this.value == "04") {
                    if ($("#form_type").val() == "full") {
                        if (this.value == "15") {
                            $("#frmTester").attr("action", "merchant-example.aspx");
                            $("#server_url").val("http://" + urlHost + "/example-payment/merchant-example.aspx");
                        }
                        else if (this.value == "04") {
                            $("#frmTester").attr("action", "merchant-dokuwallet-example.aspx");
                            $("#server_url").val("http://" + urlHost + "/example-payment/merchant-dokuwallet-example.aspx");
                        }
                    }
                    else {
                        if (this.value == "15") {
                            $("#frmTester").attr("action", "merchant-inline-example.aspx");
                            $("#server_url").val("http://" + urlHost + "/example-payment/merchant-inline-example.aspx");
                        }
                        else if (this.value == "04") {
                            $("#frmTester").attr("action", "merchant-inline-dokuwallet-example.aspx");
                            $("#server_url").val("http://" + urlHost + "/example-payment/merchant-inline-dokuwallet-example.aspx");
                        }
                    }
                }
                else if (this.value == "02") {
                    $("#frmTester").attr("action", "merchant-mandiri-example.aspx");
                    $("#server_url").val("http://" + urlHost + "/example-payment/merchant-mandiri-example.aspx");
                }
                else {
                    $("#frmTester").attr("action", "/example-payment/merchant-va-example.aspx");
                    $("#server_url").val("http://" + urlHost + "/example-payment/merchant-va-example.aspx");
                }
            });
        });
    </script>
</head>
<body>
<center>

    <form action="" method="post" name="frmTester" runat="server" ID="frmTester">
        <table align="center">
            <tr align="left">
                <td width="50%">Form Type</td>
                <td width="50%">
                    <asp:DropDownList ID="form_type" name="form_type" runat="server">
                        <asp:ListItem Selected="True" Value="full">Full</asp:ListItem>
                        <asp:ListItem Value="inline">Inline</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="left">
                <td>Mall ID</td>
                <td><input type="text" id="mall_id" name="mall_id" runat="server" value="2074"/></td>
            </tr>
            <tr align="left">
                <td>Chain Merchant</td>
                <td><input type="text" runat="server" id="chain_merchant" name="chain_merchant" value="NA"/></td>
            </tr>
            <tr align="left">
                <td width="50%">Payment Channel</td>
                <td width="50%">
                    <asp:DropDownList ID="payment_channel" name="payment_channel" runat="server">
                        <asp:ListItem Selected="True" Value="15">Credit Card</asp:ListItem>
                        <asp:ListItem Value="04">Doku Wallet</asp:ListItem>
                        <asp:ListItem Value="02">Mandiri Clickpay</asp:ListItem>
                        <asp:ListItem Value="08">Mandiri SOA Lite</asp:ListItem>
                        <asp:ListItem Value="09">Mandiri SOA Full</asp:ListItem>
                        <asp:ListItem Value="21">Sinarmas VA Full</asp:ListItem>
                        <asp:ListItem Value="22">Sinarmas VA Lite</asp:ListItem>
                        <asp:ListItem Value="07">Permata VA Full</asp:ListItem>
                        <asp:ListItem Value="05">Permata VA Lite</asp:ListItem>
                        <asp:ListItem Value="14">ALFA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="left">
                <td>Server Url</td>
                <td><input type="text" id="server_url" name="server_url" runat="server"/></td>
            </tr>
            <tr align="left">
                <td>Transaction ID</td>
                <td><input type="text" id="trans_id" name="trans_id" runat="server"/></td>
            </tr>
            <tr align="left">
                <td>Amount</td>
                <td><input type="text" id="amount" name="amount" runat="server" value="10000.00"/></td>
            </tr>
            <tr align="left">
                <td>Currency</td>
                <td><input type="text" id="currency" name="currency" runat="server" value="360"/></td>
            </tr>
            <tr align="left">
                <td>Customer ID</td>
                <td><input type="text" id="cust_id" name="cust_id" runat="server"/></td>
            </tr>
            <tr align="left">
                <td>Payment Token</td>
                <td><input type="text" id="payment_token" name="payment_token" runat="server"/></td>
            </tr>
            <tr align="left">
                <td colspan="2" align="center">
                    <asp:Button ID="btn_submit" runat="server" Text="submit" />
                </td>
            </tr>
        </table>
    </form>
</center>
</body>
</html>
