using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ApiPaykapTransaction.Models
{
    public static class SendEmail
    {
        public static string PopulateBodyGenericNotification(string bodyTxt, string bodyTxt1, string bodyTxt2, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/generic-notification-FRA.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{bodyTxt}", bodyTxt);
            body = body.Replace("{bodyTxt1}", bodyTxt1);
            body = body.Replace("{bodyTxt2}", bodyTxt2);
            return body;
        }

        public static string PopulateBodyConfirmationMail(string name, string code, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/ConfirmationMail-FRA.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{name}", name);
            body = body.Replace("{code}", code);
            return body;
        }

        public static string PopulateBodyLastConnection(string name, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/ClientAccountLastConnection-FRA.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{name}", name);
            return body;
        }

        public static string PopulateBodyResetPassword(string name, string bodyTxt, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/ResetPassword-FRA.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{name}", name);
            body = body.Replace("{bodyTxt}", bodyTxt);
            return body;
        }

        public static string PopulateBodyInvitePerson(string name, string senderName, string link, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/SendInvitation-FRA.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{name}", name);
            body = body.Replace("{senderName}", senderName);
            body = body.Replace("{link}", link);
            return body;
        }

        public static string PopulateBodyTransactionTranscript(string TRANS_DESC, string TRANS_AMT, 
                                                    string TRANS_DATE, string TRANS_NBR, string lang)
        {
            string body = string.Empty;
            if (lang == "FRA")
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/TransactionTranscript.html")))
                {
                    body = reader.ReadToEnd();
                }
            }

            body = body.Replace("{TRANS_DESC}", TRANS_DESC);
            body = body.Replace("{TRANS_AMT}", TRANS_AMT);
            body = body.Replace("{TRANS_DATE}", TRANS_DATE);
            body = body.Replace("{TRANS_NBR}", TRANS_NBR);
            return body;
        }
    }
}