using Framework.Img;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace testweb.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            //ViewBag.Image = Img.resizeImageFromFile("E:\\projetvisualstudio\\UnitTest\testweb\\Content\\test1.jpg", 100, 200);
            //WebImage img = new WebImage("~/Content/test1.jpg").Resize(100, 200).Write();

            //img.Save("~/Content/test2.jpg");
            return View();
        }

        //public WebImage Image()
        //{
        //    //ViewBag.Image = Img.resizeImageFromFile("E:\\projetvisualstudio\\UnitTest\testweb\\Content\\test1.jpg", 100, 200);
        //    return Img.resizeImageFromFile("Content/test1.jpg", 400, 200);
        //    //return new WebImage("~/Content/test1.jpg").Resize(600, 800).Write();

        //    //img.Save("~/Content/test2.jpg");
        //}

        //public WebImage Image2()
        //{
        //    //ViewBag.Image = Img.resizeImageFromFile("E:\\projetvisualstudio\\UnitTest\testweb\\Content\\test1.jpg", 100, 200);
        //    return Img.resizeImageFromFile("Content/test1.jpg", 400, 200, true);
        //    //return new WebImage("~/Content/test1.jpg").Resize(600, 800).Write();

        //    //img.Save("~/Content/test2.jpg");
        //}

        //public WebImage Image3()
        //{
        //    //ViewBag.Image = Img.resizeImageFromFile("E:\\projetvisualstudio\\UnitTest\testweb\\Content\\test1.jpg", 100, 200);
        //    return Img.resizeImageFromFile("Content/test1.jpg", 400, 200);
        //    //return new WebImage("~/Content/test1.jpg").Resize(600, 800).Write();

        //    //img.Save("~/Content/test2.jpg");
        //}

        //public virtual ActionResult GetModifiedImage()
        //{
        //    var imagePath = Img.resizeImageFromFile("~/Content/test1.jpg", 500, 800);

        //    return base.File(imagePath, "image/jpg");
        //}

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}