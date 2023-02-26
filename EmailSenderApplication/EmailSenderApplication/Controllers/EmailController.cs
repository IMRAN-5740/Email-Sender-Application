using EmailSenderApplication.Models;
using Microsoft.AspNetCore.Mvc;
using QuickMailer;

namespace EmailSenderApplication.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(EmailViewModel anEmail)
        {
            try
            {
                List<string> toMails = new List<string>();
                List<string> ccMails = new List<string>();
                List<string> bCcMails = new List<string>();
                string message = "Email Send Failed";
                Email email = new Email();
                toMails = GetValidMails(anEmail.To);
                ccMails = GetValidMails(anEmail.Cc);
                bCcMails = GetValidMails(anEmail.BCc);
                bool isSend=email.SendEmail(toMails, Credential.Email, Credential.Password,anEmail.Subject, anEmail.Body,ccMails,bCcMails);
                
                if(isSend)
                {
                    message = "Email has been Send Successfully";
                }
                ViewBag.Message = message;  
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;

            }
          
        }

        public List<string> GetValidMails(List<string> mails)
        {
            List<string> validMails = new List<string>();
            Email email = new Email();
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
