using Assignment2.Models;
using Assignment2.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            // bulk email tester
            //String toEmail = "shua0098@student.monash.edu";
            //String subject = "backup email";
            //String contents = "backup email";
            //HttpPostedFileBase attachment = null;

            //EmailSender es = new EmailSender();
            //es.Send(toEmail, subject, contents, attachment);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Here is the navigation provided for you.";

            return View();
        }

        public ActionResult Send_Email()
        {
            SendEmailViewModel sendEmailViewModel = new SendEmailViewModel();
            sendEmailViewModel.ToEmail = User.Identity.GetUserName();
            //sendEmailViewModel.Subject = "Your appointment";
            //sendEmailViewModel.Contents = "Please write the appointment  details";
            //sendEmailViewModel.Attachment = { System.Web.HttpPostedFileWrapper};
            return View(sendEmailViewModel);
            //return View(new SendEmailViewModel());
        }

     

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    HttpPostedFileBase attachment = model.Attachment;


                    var mail = new MailMessage();
                    mail.To.Add(toEmail);
                    mail.From = new MailAddress("LeileiHan1119@outlook.com");
                    mail.Subject = "Appointment Conformation";
                    mail.Body =
                        "You have successfully made an appointment!"+"\n" + "The subject is" +subject + ".\n"+"The contents is"+contents+".";
                    mail.IsBodyHtml = false;
                    if (attachment != null && attachment.ContentLength > 0)
                    {
                        Attachment mailAttachment = new Attachment(attachment.InputStream, attachment.FileName);
                        mail.Attachments.Add(mailAttachment);
                    }
                    var smtp = new SmtpClient();
                    smtp.Host = "smtp.office365.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential
                        ("LeileiHan1119@outlook.com", "1998H1119ll");
                    smtp.Send(mail);




                    ViewBag.Result = "The email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}