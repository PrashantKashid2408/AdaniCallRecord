using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AdaniCall.Utility.Common;
using Core.Utility.Common;

namespace Core.Utility.Common
{
    /// <summary>
    /// Author : Kaustubh
    /// Date : 8/16/2016
    /// </summary>
    public class Email
    {


        #region ENUMS

        public enum EmailPriority
        {
            High = System.Net.Mail.MailPriority.High,
            Normal = System.Net.Mail.MailPriority.Normal,
            Low = System.Net.Mail.MailPriority.Low
        }

        #endregion

        #region DECLARTIONS

        //private readonly string _strDefaultFrom;
        private readonly string _module = "CommonLibrary.Utilities.Email";
        private string _strFrom;
        private string _strTo;
        private string _strCC;
        private string _strBCC;
        private string _strReplyTo;

        /// <summary>
        /// Add fileNames to AttachmentList to send along with the email when Send() method is invoked
        /// </summary>
        public List<string> AttachmentList = new List<string>();

        #endregion

        #region PROPERTIES

        private string From
        {
            get
            {
                return this._strFrom;
            }
            set
            {
                this._strFrom = value;
            }
        }

        private string To
        {
            get
            {
                return this._strTo;
            }
            set
            {
                this._strTo = value.Trim().Replace(";", ",").Trim(',');
            }
        }

        /// <summary>
        /// Gets or sets CarbonCopy for Email
        /// Note : You must assign comma(,) or semicolon(;) separated email id(s) to this property
        /// </summary>
        public string CC
        {
            get
            {
                return this._strCC;
            }
            set
            {
                this._strCC = value.Trim().Replace(";", ",").Trim(',');
            }
        }

        /// <summary>
        /// Gets or sets BlindCarbonCopy for Email
        /// Note : You must pass comma(,) or semicolon(;) separated email id(s) to this property
        /// </summary>
        public string BCC
        {
            get
            {
                return this._strBCC;
            }
            set
            {
                this._strBCC = value.Trim().Replace(";", ",").Trim(',');
            }
        }

        /// <summary>
        /// Gets or sets ReplyTo for Email
        /// Note : You must pass comma(,) or semicolon(;) separated email id(s) to this property
        /// </summary>
        public string ReplyTo
        {
            get
            {
                return this._strReplyTo;
            }
            set
            {
                this._strReplyTo = value.Trim().Replace(";", ",").Trim(',');
            }
        }

        /// <summary>
        /// Gets or sets the Subject for Email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the Body for Email
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the IsBodyHTML property for Email [true = HtmlBody, false = Plaintext Body] 
        /// </summary>
        public bool IsBodyHTML { get; set; }

        public EmailPriority MailPriority { get; set; }
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Constructor sets the From and To 
        /// </summary>
        /// <param name="sender">Pass sender email address</param>
        /// <param name="receipients">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        public Email(string sender, string receipients)
        {
            this.From = sender;
            this.To = receipients;
        }

        /// <summary>
        /// Overloaded constructor that sets sender, receipients and cc
        /// </summary>
        /// <param name="sender">Pass sender email address</param>
        /// <param name="receipients">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        /// <param name="cc">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        public Email(string sender, string receipients, string cc)
            : this(sender, receipients)
        {
            this.CC = cc;
        }

        /// <summary>
        /// Overloaded constructor that sets sender, receipients, cc and bcc
        /// </summary>
        /// <param name="sender">Pass sender email address</param>
        /// <param name="receipients">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        /// <param name="cc">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        /// <param name="bcc">Pass comma (,) or semicolon(;) separated receiver email addresses</param>
        public Email(string sender, string receipients, string cc, string bcc)
            : this(sender, receipients, cc)
        {
            this.BCC = bcc;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Call this method to send the email to the receipient
        /// </summary>
        /// <returns></returns>
        public bool Send()
        {
            bool returnValue = false;

            try
            {
                MailMessage mailMessage = new MailMessage();

                if (!string.IsNullOrWhiteSpace(this.From))
                {
                    MailAddress fromAddress = new MailAddress(this.From);
                    mailMessage.From = fromAddress;
                }

                if (!string.IsNullOrWhiteSpace(this.To))
                {
                    string[] arrTo = this.To.Trim().Split(',');

                    foreach (string to in arrTo)
                    {
                        if (!string.IsNullOrWhiteSpace(to))
                            mailMessage.To.Add(to);
                    }
                }

                if (!string.IsNullOrWhiteSpace(this.CC))
                {
                    foreach (string cc in this.CC.Trim().Split(','))
                    {
                        if (!string.IsNullOrWhiteSpace(cc))
                            mailMessage.CC.Add(cc);
                    }
                }

                if (!string.IsNullOrWhiteSpace(this.BCC))
                {
                    foreach (string bcc in this.BCC.Trim().Split(','))
                    {
                        if (!string.IsNullOrWhiteSpace(bcc))
                            mailMessage.Bcc.Add(bcc);
                    }
                }

                if (!string.IsNullOrWhiteSpace(this.ReplyTo))
                {
                    MailAddress replyToAddress = new MailAddress(this.ReplyTo);
                    mailMessage.ReplyToList.Add(replyToAddress);
                }

                if (AttachmentList.Count > 0)
                {
                    foreach (string file in AttachmentList)
                    {
                        if (!string.IsNullOrWhiteSpace(file))
                        {
                            Attachment attachment = new Attachment(file);
                            mailMessage.Attachments.Add(attachment);
                        }
                    }
                }

                mailMessage.Subject = this.Subject;
                mailMessage.Body = this.Body;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = this.IsBodyHTML;
                mailMessage.Priority = (MailPriority)this.MailPriority;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;

                //if (AdaniCallConstants.UseSmtpCredentials.ToLower().Equals("true"))   // if false then use basic credentials 
                //{
                //    smtpClient.Host = SandeshakamConstants.SmtpHost;
                //    smtpClient.Port = Convert.ToInt32(SandeshakamConstants.SmtpPort);
                //    smtpClient.UseDefaultCredentials = SandeshakamConstants.UseDefaultCredentials.ToLower().Equals("false") ? false : true;
                //    smtpClient.Credentials = new NetworkCredential(SandeshakamConstants.SmtpUsername, SandeshakamConstants.SmtpPassword); ;
                //}
               // else
              //  {
                    //smtpClient.Host = SandeshakamConstants.DefaultHost;
              //  }

               // smtpClient.EnableSsl = SandeshakamConstants.EnableSsl.ToLower().Equals("true") ? true : false;

                try
                {

                    //  NOTE : If the mail configuration doesn't work on live then please do following:
                    // 1. Uncomment the below code and run on live (with UseSmtpCredentials = true, UseDefaultCredentials = true, EnableSsl = true in web.config settings)
                    // 2. Comment the below code and run on live again
                    //    #region NOTE : FOR TESTING PURPOSES ONLY 

                    //    ServicePointManager.ServerCertificateValidationCallback =
                    //delegate(object s, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    //  System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    //{ return true; };
                    //    #endregion

                    smtpClient.Send(mailMessage);
                    returnValue = true;
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    for (int i = 0; i < ex.InnerExceptions.Length; i++)
                    {
                        SmtpStatusCode smtpStatusCode = ex.InnerExceptions[i].StatusCode;
                        if (smtpStatusCode == SmtpStatusCode.MailboxBusy || smtpStatusCode == SmtpStatusCode.MailboxUnavailable)
                        {
                            Log.WriteLog(_module, "Delivery failed - retrying in 5 seconds.", ex.Source, ex.Message);
                            System.Threading.Thread.Sleep(5000);
                            smtpClient.Send(mailMessage);
                            returnValue = true;
                            mailMessage.Dispose();
                        }
                        else
                            Log.WriteLog(_module, "Failed to deliver message to " + ex.InnerExceptions[i].FailedRecipient + "", ex.Source, ex.Message);
                    }
                }
                finally
                {
                    mailMessage.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogWithoutMail(_module, "Send()", ex.Source, ex.Message);
            }

            return returnValue;
        }

        /// <summary>
        /// Method extracts the subject from template
        /// Note : The subject inside the template should be enclosed within [[SUBJECT}{SUBJECT]] in the hidden field
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public string GetSubject(string template)
        {
            string result = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(template))
                {
                    int start = template.IndexOf("[[SUBJECT}");
                    int end = template.IndexOf("{SUBJECT]]");

                    if (start > -1 && end > -1)
                    {
                        start = start + 10;
                        end = end - start;
                        result = template.Substring(start, end);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetSubject(template=" + template + ")", ex.Source, ex.Message);
            }

            return result;
        }

        #endregion
    }
}
