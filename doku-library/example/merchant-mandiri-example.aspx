<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="merchant-mandiri-example.aspx.cs" Inherits="doku_library.example.merchant_mandiri_example" %>
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
    <script type="text/javascript" src='http://staging.doku.com/doku-js/assets/js/doku.js'></script>
    <link href="http://staging.doku.com/doku-js/assets/css/doku.css" rel="stylesheet"/>
    
    <script type="text/javascript">
        $(function () {
            /* hide show payment channel */
            $('#select-paymentchannel').change(function () {
                $('.channel').hide();
                $('#' + $(this).val()).show();
            });

            var data = new Object();

            data.req_cc_field = 'cc_number';
            data.req_challenge_field = 'CHALLENGE_CODE_1';

            dokuMandiriInitiate(data);

        });
    </script>

    <script type="text/javascript">
        jQuery(function ($) {
            $('.cc-number').payment('formatCardNumber');

            $.fn.toggleInputError = function (erred) {
                this.parent('.form-group').toggleClass('has-error', erred);
                return this;
            };

            $('form').submit(function (e) {
                e.preventDefault();

                var cardType = $.payment.cardType($('.cc-number').val());
                $('.cc-number').toggleInputError(!$.payment.validateCardNumber($('.cc-number').val()));
            });

            var challenge3 = Math.floor(Math.random() * 999999999);
            $("#challenge_div_3").text(challenge3);
            $("#CHALLENGE_CODE_3").val(challenge3);


        });

    </script>
</head>
<body>
<section class="default-width"><!-- start content -->

    <div class="head padd-default"><!-- start head -->
        <div class="left-head fleft">
            <img src="http://staging.doku.com/doku-js/assets/images/logo-merchant.png" alt="" />
        </div>
        <div class="right-head fright">
            <div class="text-totalpay color-two">Total Payment ( IDR )</div>
            <div class="amount color-one">214.300.000,00</div>
        </div>
        <div class="clear"></div>
    </div><!-- end head -->

    <div class="select-payment-channel color-border padd-default"><!-- start select payment channel -->
        Mandiri Clickpay
    </div><!-- end select payment channel -->

    <div class="content-payment-channel padd-default"><!-- start content payment channel -->
        <form method="post" action="../example-payment/merchant-mandiri-example.aspx">
        <div id="mandiriclickpay" class="channel"> <!-- mandiri clickpay -->
            <div class="logo-payment-channel right-paychan mandiriclickpay"></div>

            <div class="styled-input">
                <input type="text" id="cc_number" name="cc_number" class="cc-number" required />
                <label>mandiri debit card number</label>
            </div>
            <div class="desc">
                Pastikan bahwa kartu Anda telah diaktivasi melalui layanan mandiri Internet Banking Bank Mandiri pada menu Authorized Payment agar dapat melakukan transaksi Internet Payment.
            </div>
            <div class="line"></div>
            <div class="token">
                <img src="http://luna2.nsiapay.com/doku-js/assets/images/token.png" alt="" class="fleft" />
                <div class="text-token desc fright">
                    Gunakan token pin mandiri untuk bertransaksi. Nilai yang dimasukkan pada token Anda (Metode APPLI 3)
                </div>
                <div class="clear"></div>
            </div>
            <div class="list-chacode">
                <ul>
                    <li>
                        <div class="text-chacode">Challenge Code 1</div>
                        <input type="text" id="CHALLENGE_CODE_1" name="CHALLENGE_CODE_1" readonly="true" required/>
                        <div class="clear"></div>
                    </li>
                    <li>
                        <div class="text-chacode">Challenge Code 2</div>
                        <div class="num-chacode">0000100000</div>
                        <input type="hidden" name="CHALLENGE_CODE_2" value="0000100000"/>
                        <div class="clear"></div>
                    </li>
                    <li>
                        <div class="text-chacode">Challenge Code 3</div>
                        <div class="num-chacode" id="challenge_div_3"></div>
                        <input type="hidden" name="CHALLENGE_CODE_3" id="CHALLENGE_CODE_3" value=""/>
                        <div class="clear"></div>
                    </li>
                    <div class="clear"></div>
                </ul>
            </div>
            <div class="validasi">
                <div class="styled-input fleft width50">
                    <input type="text" required="" name="response_token">
                    <label>Token Response</label>
                </div>
                <div class="clear"></div>
					<span title="Explenation Text" class="tooltip tolltips-wallet">
						   <span title="More"><img src="http://luna2.nsiapay.com/doku-js/assets/images/icon-help.png" alt="" style="margin: 0 0 0 10px;" /></span>
					</span>
            </div>
            <input type="hidden" name="invoice_no" value="<%= Request.Form["trans_id"] %>"/>
            <input type="button" value="Process Payment" class="default-btn" onclick="this.form.submit();">
        </div><!-- mandiri clickpay -->
        </form>
    </div><!-- end content payment channel -->

</section><!-- end content -->

<div class="footer">
    <img src="http://staging.doku.com/doku-js/assets/images/secure.png" alt="" />
    <br /><br />
    <div class="">Copyright DOKU 2016</div>
</div>
</body>
</html>
