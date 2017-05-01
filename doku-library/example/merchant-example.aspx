<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchant-example.aspx.cs" Inherits="doku_library.example.merchant_example" %>
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

		    data.req_customer_id = <% if (Request.Form["cust_id"] != null) { %> '<%= Request.Form["cust_id"] %>'; <% } else { %> 'undefined'; <% } %>
		    data.req_token_payment = <% if (Request.Form["payment_token"] != null) { %> '<%= Request.Form["payment_token"] %>'; <% } else { %> 'undefined'; <% } %>

		    getForm(data);
        });
    </script>
</head>
<body>
    <div doku-div="form-payment">Replace This</div>
</body>
</html>
