<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchant-inline-dokuwallet-example.aspx.cs" Inherits="doku_library.example.merchant_inline_dokuwallet_example" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Com.Doku" %>

<html lang="en">
<head runat="server">
    <title>DOKU Payment Page</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
    <meta name="apple-mobile-web-app-capable" content="yes"/>
    <meta name="apple-mobile-web-app-status-bar-style" content="black"/>
    <!--[if lt IE 9]>
    <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script language="javascript" type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.pack.js"></script>
    <script language="javascript" type="text/javascript" src="http://staging.doku.com/doku-js/assets/js/doku.js?version=<%= Helper.getTime() %>"></script>

    <link href="http://staging.doku.com/doku-js/assets/css/doku.css" rel="stylesheet"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/2.1.5/jquery.fancybox.min.css" rel="stylesheet"/>
    <script type="text/javascript">
        $(function () {
            var data = new Object();
            data.req_merchant_code = '<%= Request.Form["mall_id"] %>';
            data.req_chain_merchant = '<%= Request.Form["chain_merchant"] %>';
            data.req_payment_channel = '<%= Request.Form["payment_channel"] %>';
            data.req_server_url = '<%= Request.Form["server_url"] %>';
            data.req_transaction_id = '<%= Request.Form["trans_id"] %>';
            data.req_amount = '<%= Request.Form["amount"] %>';
            data.req_currency = '<%= Request.Form["currency"] %>';
            data.req_words = '<%= words %>';
            data.req_session_id = <%= Helper.getTime() %>;
            data.req_form_type = '<%= Request.Form["form_type"] %>';
            data.req_custom_form = ['username-field', 'password-field'];

		    var dataForm = getForm(data);
        });
    </script>
</head>
<body>
<section class="default-width">
    <div class="head padd-default">
        <div class="left-head fleft">
            <img src="http://staging.doku.com/doku-js/assets/images/logo-merchant1.png" alt="">
        </div>
        <div class="right-head fright">
            <div class="text-totalpay color-two">Total Payment ( IDR )</div>
            <div class="amount color-one">100000.00</div>
        </div>
        <div class="clear"></div>
    </div>

    <div class="select-payment-channel color-border padd-default">
        Doku Wallet
    </div>

    <div class="content-payment-channel padd-default">
        <div id="creditcard" class="channel">
            <div class="logo-payment-channel right-paychan cc"></div>
            <form novalidate="" autocomplete="on" method="POST" id="cc-valideform" action="../example-payment/merchant-inline-dokuwallet-example.aspx">
                <ul>
                    <div doku-div='form-payment'>
                        <li>
                            <div class="styled-input fleft width50" id="username-field">
                                <label>Username</label>
                            </div>
                            <div class="styled-input fright width50" id="password-field">
                                <label>Password</label>
                            </div>
                            <div class="clear"></div>
                        </li>
                    </div>
                    <li>
                        <div class="styled-input fleft width50">
                            <input type="text" name="email_cc" id="email_cc" required />
                            <label>Email</label>
                        </div>
                        <div class="styled-input fright width50">
                            <input type="text" name="phone_cc" id="phone_cc" required />
                            <label>Phone</label>
                        </div>
                        <div class="clear"></div>
                    </li>
                    <li>
                        <div class="styled-input fleft width50">
                            <input type="text" name="address" id="address" required />
                            <label>Billing Address</label>
                        </div>
                        <div class="styled-input fright width50">
                            <input type="text" name="id_number" id="id_number" required />
                            <label>ID Number</label>
                        </div>
                        <div class="clear"></div>
                    </li>
                </ul>
                <input type="hidden" id="doku-token" name="doku-token">
                <input type="hidden" id="doku-pairing-code"  name="doku-pairing-code">
                <input type="hidden" id="doku-invoice-no"  name="doku-invoice-no">
                <input type="hidden" id="doku-amount"  name="doku-amount">
                <input type="hidden" id="doku-chain-merchant"  name="doku-chain-merchant">
                <input type="hidden" id="doku-currency"  name="doku-currency">
                <input type="hidden" id="doku-mall-id"  name="doku-mall-id">
                <input class="default-btn font-reg" value="Process Payment" id="submitcc" type="button">
            </form>
        </div>
    </div>
</section>
<div class="footer">
    <img src="http://staging.doku.com/doku-js/assets/images/secure.png" alt="">
    <div class="">Copyright DOKU 2016</div>
</div>
</body>
</html>
<script type="application/javascript">
    $("#submitcc").click(function () {
        DokuToken(getToken);
        return false;
    })

    function getToken(response) {
        if (response.res_response_code == '0000') {
            $("#doku-token").val(response.res_token_id);
            $("#doku-pairing-code").val(response.res_pairing_code);
            $("#doku-invoice-no").val(response.res_invoice_no);
            $("#doku-amount").val(response.res_amount);
            $("#doku-chain-merchant").val(response.res_chain_merchant);
            $("#doku-currency").val(response.res_currency);
            $("#doku-mall-id").val(response.res_mall_id);

            $("#cc-valideform").submit();
        } else {
            console.log(response);
        }
    }
</script>