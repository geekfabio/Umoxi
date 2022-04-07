using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umoxi
{
    class HtmlBody
    {
        public static string UserName;
        public static string userFullName;
        public static string CodeConfirm;

        public static string Body(string MessageHtml)
        {
            switch (MessageHtml)
            {
                case "ForgotPassword":
                    #region MessageBody
                    MessageHtml = @"<!doctype html>
                        <html>
                            <head>
                                <meta charset='utf-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1'>
                                <title>Redefinição de senha</title>
                                <link href='https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css' rel='stylesheet'>
                                <link href='' rel='stylesheet'>
                                <style></style>
                                <script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>
                                <script type='text/javascript' src='https://stackpath.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.bundle.min.js'></script>
                                <script type='text/javascript'></script>
                            </head>
                            <body oncontextmenu='return false' class='snippet-body'>
                            <!DOCTYPE html>
<html>

<head>
    <title></title>
    <meta http-equiv=""Content - Type"" content=""text / html; charset = utf - 8""/>
            <meta name=""viewport"" content= ""width=device-width, initial-scale=1"" >


               <meta http-equiv =""X-UA-Compatible"" content= ""IE=edge""/>


                    <style type = ""text/css"">
                         @media screen {
                        @font - face {
                            font - family: 'Lato';
                            font - style: normal;
                            font - weight: 400;
                        src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }

                        @font - face {
                            font - family: 'Lato';
                            font - style: normal;
                            font - weight: 700;
                        src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }

                        @font - face {
                            font - family: 'Lato';
                            font - style: italic;
                            font - weight: 400;
                        src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }

                        @font - face {
                            font - family: 'Lato';
                            font - style: italic;
                            font - weight: 700;
                        src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
                    }
                    body,
                    table,
                    td,
                    a {
                        -webkit - text - size - adjust: 100 %;
                        -ms - text - size - adjust: 100 %;
                    }

                    table,
                    td {
                        mso - table - lspace: 0pt;
                        mso - table - rspace: 0pt;
                    }

                    img {
                        -ms - interpolation - mode: bicubic;
                    }

                    img {
                    border: 0;
                    height: auto;
                        line - height: 100 %;
                    outline: none;
                        text - decoration: none;
                    }

                    table {
                        border - collapse: collapse!important;
                    }

                    body {
                    height: 100 % !important;
                    margin: 0!important;
                    padding: 0!important;
                    width: 100 % !important;
                    }

                    a[x - apple - data - detectors] {
                    color: inherit!important;
                        text - decoration: none!important;
                        font - size: inherit!important;
                        font - family: inherit!important;
                        font - weight: inherit!important;
                        line - height: inherit!important;
                    }

                    @media screen and(max - width:600px) {
                        h1 {
                            font - size: 32px!important;
                            line - height: 32px!important;
                        }
                    }

                    div[style *= ""margin: 16px 0;""] {
                    margin: 0!important;
                    }
    </style>
</head>

<body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
     
         <table border=""0"" cellpadding =""0"" cellspacing =""0"" width =""100%"">

                    <tr>


                        <td bgcolor=""#0052CC"" align =""center"">


                               <table border=""0"" cellpadding=""0"" cellspacing =""0"" width =""100%"" style =""max-width: 600px;"">


                                            <tr>


                                                <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;""> </td>


                                                 </tr>


                                             </table>


                                         </td>


                                     </tr>


                                     <tr>


                                         <td bgcolor=""#0052CC"" align=""center"" style=""padding: 0px 10px 0px 10px;"">


                                                  <table border=""0"" cellpadding =""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">


                                                               <tr>


                                                                   <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">


                                                                              <h1 style =""font-size: 48px; font-weight: 400; margin: 2;""> Redefinir senha! </h1> <img src=""https://lh3.googleusercontent.com/SMSi6cy2fpmCrmlHPQVqTveYlIUgANWScmnG7XPa9dLzk_SlFBJ5V9x6e06lzwgtCaLBCWB1UXlyEDRfwaJFSNlYnG9a2qbAkXvw6FsrQF1dmAwSEmIxJkiWxhY8XqBeCefeERWMeCg8e-xSAoswvWK2Rq0Muqd6y8ve5xb3qEpHJ1eDW7cw7i22E8IcCRYlSVT8BNfPzNUEaJALMRLVr8z5rE6fCWdvGzL4G8XEqt_wswR7XuDs78Qdsa5-erLryyPKWSqTk_2sbN5AE3TNaNRllTcBs-zIpIngc3hkp61dOhfJuu1_VCt7eVN_h515FfifLgO0wGRIEOWivoZaNhzqpueTLAT0ar9RPOITzzfbCWFGPk86FW6pcTl_ipVPCS6qX23NPDqStTcKgqJBhhNnN0UEpjxKjL1ePM-KOwYuySygDQU1npqK3kqPSpibdu-o_GjbRWx3oSNQaNsJToJIOQUdbPzxosEvzFXoqQmQ4vH29dBa15JorOyAbVzsv8_SBEZM52PczlmZQJlbVnxbuELl4BVLSZkuBVIegenN57C1M3T3i-uzFJlvzIYyCrqJERrgJ-dca6-Dy0eT9K7XOZfVaN3IEDzPUipqlJTYuxo0ukT41Sb3S9L7XtWyS7IFxJ9ZxsSCTfS5UeKZpDfe2ueHkz7eT8hFF_mHos4bn6zWs-FO0cTLpNjsUYFoNnZWg1ZW8vLqmAAiaDAsXKQ=w670-h667-no?authuser=0"" alt=""logo"" width=""120px"">




                                                                                                                                  </td>


                                                                                     </tr>


                                                                                 </table>


                                                                             </td>


                                                                         </tr>


                                                                         <tr>


                                                                             <td bgcolor =""#f4f4f4"" align =""center"" style=""padding: 0px 10px 0px 10px;"">


                                                                                      <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">


                                                                                                   <tr>


                                                                                                       <td bgcolor =""#ffffff"" align= ""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">


                                                                                                                <p style=""margin: 0;""> Caro " +userFullName+@", <br>
                                                                                                                         Aqui está o código de verificação que você precisa para fazer a redefiniçao da senha para acessar sua conta: "+UserName+@" 
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"">


                               <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">


                                          <tr>


                                              <td bgcolor = ""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">


                                                       <table border=""0"" cellspacing=""0"" cellpadding = ""0"">


                                                                <tr>


                                                                    <td align=""center"" style=""border-radius: 3px;"" bgcolor=""#0052CC""><a style=""font-size: 30px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #0052CC; display: inline-block;""> "+CodeConfirm+ @" </a></td>


                                                                         </tr>


                                                                     </table>


                                                                 </td>


                                                             </tr>


                                                         </table>


                                                     </td>


                                                 </tr> 


                                                 <tr>


                                                     <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 0px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">


                                                              <p style=""margin: 0;""> Nota: <br> Por favor, não responda a este e-mail. Ele foi enviado de um endereço somente de notificação que
                                                                          não aceita mensagens recebidas. Se você não quiz redefinir sua senha no Umoja School, alguém tentou redefinir
                                                                         sua senha.</p>


                                                                 </td>


                                                             </tr> 


                                                                  <tr>


                                                                      <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">


                                                                               <p style=""margin: 0;""><a style=""color: #0052CC;""> Veje o seu historico de activades no aplicativo para saber mais!</a></p>


                                                                                    </td>


                                                                                </tr>


                                                                                <tr>


                                                                                    <td bgcolor = ""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">


                                                                                             <p style=""margin: 0;""> Saudações <br> A Equipe T-Project </p>


                                                                                                  </td>


                                                                                              </tr>


                                                                                          </table>


                                                                                      </td>


                                                                                  </tr>


                                                                                  <tr>


                                                                                      <td bgcolor = ""#f4f4f4"" align=""center"" style=""padding: 30px 10px 0px 10px;"">


                                                                                               <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">


                                                                                                            <tr>


                                                                                                                <td bgcolor=""#99B9EB"" align =""center"" style=""padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">


                                                                                                                         <h2 style=""font-size: 20px; font-weight: 400; color: #111111; margin: 0;""> Necessidade de ajuda?</h2>


                                                                                                                              <p style=""margin:0;""><a href=""#"" target=""_blank"" style=""color: #0052CC;""> Estamos aqui para ajudá-lo.</a></p>


                                                                                                                                       </td>


                                                                                                                                   </tr>


                                                                                                                               </table>


                                                                                                                           </td>


                                                                                                                       </tr>


                                                                                                                       <tr>


                                                                                                                           <td bgcolor =""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">


                                                                                                                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">


                                                                                                                                                 <tr>


                                                                                                                                                     <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;""> <br>
                            <i style =""margin: 0;""> Siga a T-Project :<a href =""#"" target =""_blank"" style=""color: #ffffff; font-weight: 700;""> <img src=""https://img.icons8.com/color/2x/facebook-new.png"" alt=""Facebook icon"" width=""20px""> </a>


                                                       </i>
                           
                                                         <i style = ""margin: 10;""><a href = ""#"" target =""_blank"" style =""color: #ffffff; font-weight: 700;""> <img src=""https://img.icons8.com/color/2x/instagram-new--v1.png"" alt=""Instagram icon"" width=""20px""> </a>


                                                                               </i>
                                                   
                                                                               </i>
                                                   
                                                                               <i style = ""margin: 0;""><a href = ""#"" target =""_blank"" style =""color: #ffffff; font-weight: 700;""> <img src=""https://img.icons8.com/color/2x/twitter--v1.png"" alt=""Twitter icon"" width=""20px""> </a>


                                                                                                       </p>
                                                                           
                                                                                                   </td>
                                                                           


                                                                                                                                                                                                                                           </tr>


                                                                                                                                                            </table>


                                                                                                                                                        </td>


                                                                                                                                                    </tr>


                                                                                                                                                </table>
                                                                                                                                            </body>



                                                                                                                                            </html>


                                                                                                                                                                        </body>


                                                                                                                                                                    </html>
                                                                                                                                                                 ";
                    #endregion
                    break;

                case "ToastNotificationLogin":
                    #region MessageBody
                    MessageHtml = @" <toast>
            <visual>
            <binding template=""ToastGeneric"">
              <text> My School </text>
   
                 <text> Nova sessão iniciado no sistema com o utilizador " + ConnectionNode.userName + @"</text>
      
                    <text placement=""attribution""> Sessão </text>
       
                     <image src=""C:\Users\Lakra\Documents\Umoxi\300ppi\icon.png"" placement=""appLogoOverride"" alt =""Logo""/>
            
                        </binding>
            
                      </visual>
            
                </toast>";
                    #endregion
                    break;

                default:
                    break;

            }

            return MessageHtml;
        }
    }
}
