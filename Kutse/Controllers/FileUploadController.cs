using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutse.Controllers
{
    public class FileUploadController : Controller
    {
        //GET: FileUpload
        public ActionResult FileUpload()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase FileName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (FileName != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(FileName.FileName));
                        FileName.SaveAs(path);
                       
                        ViewBag.FileStatus = "Fail oli salvestatud: "+ path;
                        //ViewBag.Imagename = String.Format("{0}", path.Replace('+', '_'));
                        ViewBag.ImageUrl = "Images/"+Path.GetFileName(FileName.FileName);
                        
                    }
                    else
                    {
                        ViewBag.FileStatus = "Fail on edukalt allalaaditud!";
                    }

                    
                }
                   
                catch (Exception)
                {

                    ViewBag.FileStatus="Viga! Faili allalaadimisega!";
                }

            }
            return View();
        }
    }
}