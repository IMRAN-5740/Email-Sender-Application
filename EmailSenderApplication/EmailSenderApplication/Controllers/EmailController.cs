using EmailSenderApplication.Models;
using Microsoft.AspNetCore.Mvc;
using QuickMailer;
using System.Net.Mail;

namespace EmailSenderApplication.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(EmalModel anEmail)
        {
            try
            {
                string message = "Email Send Failed";
                string msg = "";
                List<string> toMails = new List<string>();
                List<string> ccMails = new List<string>();
                List<string> bCcMails = new List<string>();
                List<Attachment> attachments = new List<Attachment>();
                Email email = new Email();
                toMails = GetValidMails(anEmail.To);
                ccMails = GetValidMails(anEmail.Cc);
                bCcMails = GetValidMails(anEmail.BCc);

              
                if (anEmail.To == null && anEmail.Cc == null && anEmail.BCc == null)
                {
                    msg = "Please Select at least one recipient";
                }
                else
                {

                    
                    if (anEmail.Files != null)
                    {
                        var size = anEmail.Files;
                        foreach (var file in anEmail.Files)
                        {
                            Attachment attachment = new Attachment(file.OpenReadStream(), file.FileName);
                            attachments.Add(attachment);

                        }

                    }
                    bool isSend = email.SendEmail(toMails, Credential.Email, Credential.Password, anEmail.Subject, anEmail.Body, ccMails, bCcMails, attachments);

                    if (isSend)
                    {
                        message = "Email has been Send Successfully";
                        ModelState.Clear();
                    }
                }
                
                
                ViewBag.Message = message;
                ViewBag.Msg = msg;
                    return View();
                
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
        
          
        }

        private  List<string> GetValidMails(List<string> mails)
        {
            List<string> validMails = new List<string>();
            Email email = new Email();
            if(mails == null)
            {
                return validMails;
            }
            if (mails.Any())
            {
                foreach (var item in mails)
                {
                    bool isValid = email.IsValidEmail(item);
                    if (isValid)
                    {
                        validMails.Add(item);
                    }
                }
            }
            return validMails;
        }


    }
}
