using System;
using System.Net;
using System.Net.Mail;

public class SentMail : Register
{
    public static void MailSent(int otp, string keyValue, string mail)
    {
        String otPin = otp.ToString();
        string senderEmail = "gopilingam2025@gmail.com";
        string senderPassword = "whuutbhxgcizevrz";
        string receiverEmail = mail;
        string subject = "OTP Verification";
        string message = $"The One Time Password is \"{otPin}\" for Your {keyValue} Product Purchase..";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true,
        };

        MailMessage mailMessage = new MailMessage(senderEmail, receiverEmail, subject, message);

        try
        {
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public static void MailSentSummary(string keyValue, String name, string mail)
    {
        string senderEmail = "gopilingam2025@gmail.com";
        string senderPassword = "whuutbhxgcizevrz";
        string receiverEmail = mail;
        string subject = "Order Summary";
        string message = "<html><body>" +
                $"<h2>Dear {name}, Thank you For Purchasing a {keyValue} Product</h2>" +
                "<h3>ORDER SUMMARY<br></h3>" +
                "<p>--------------------------------------<br>" +
                "|    Price Bill (*includes GST)       |<br>" +
                "--------------------------------------<br>" +
                $"    Product Name :   <b>{keyValue}</b><br>" +
                $"Price&nbsp;&nbsp;&nbsp;&nbsp;:<b>Rs.{GstBill.pprice}</b><br>" +
                $"      CGST(9%)   :       <b>Rs.{GstBill.cgst}</b><br>" +
                $"      SGST(9%)   :       <b>Rs.{GstBill.sgst}</b><br>" +
                "--------------------------------------<br>" +
                $"   Total Price   :      <b>Rs.{GstBill.roundPrice}</b><br>" +
                "--------------------------------------<br>" +
                "Your Payment Is Successful..<br></p>" +
                "<p>Regards,<br><b>MI Store</b></p>" +
                "</body></html>";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true,
        };

        MailMessage mailMessage = new MailMessage(senderEmail, receiverEmail, subject, message);
        mailMessage.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
