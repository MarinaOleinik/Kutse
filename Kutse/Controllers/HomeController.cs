using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Kutse.Models;

namespace Kutse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule!!!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust!" : "Tere päevast!";
            return View();
        }
        [HttpGet]
        public ViewResult Form()
        {
            return View();
        }
        

        //FileStream file = new FileStream("sendi.jpg",FileMode.Open);
        [HttpPost]
        
        public ViewResult Form(Guests guests)
        {
            

            if (ModelState.IsValid)
            {
                
                return View("Thanks", guests);
            }
            else
            {
                return View();
            }
        }



























        [HttpGet]
        public ActionResult Pilt()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Pilt(string ToEmailId, string Subject, string Message, HttpPostedFileBase file)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmailId);
                mail.From = new MailAddress("dotnetpools@gmail.com");
                mail.Subject = Subject;
                string Body = Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Send Attahment

                System.Net.Mail.Attachment attachment;
                string filename = System.IO.Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Path.Combine(Server.MapPath("~/Images/" + filename), Path.GetFileName(file.FileName)));
                string filepathtoattach = "Images/" + filename;
                attachment = new System.Net.Mail.Attachment(Server.MapPath(filepathtoattach));
                mail.Attachments.Add(attachment);

                SmtpClient smtp = new SmtpClient();
                //SMTP Server Address of gmail
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("kfcapptest@gmail.com", "vytasapptest");
                // Smtp Email ID and Password For authentication
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Message snd successfully";
            }
            catch
            {
                ViewBag.Message = "Error............";
            }
            return View();
        }


    }
}