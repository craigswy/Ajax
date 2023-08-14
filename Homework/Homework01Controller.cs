using Microsoft.AspNetCore.Mvc;

namespace MSIT150Site.Homework
{
    public class Homework01Controller : Controller
    {
        public IActionResult Index()
        {
            // 作業一
            return View();
        }

        public IActionResult Travel() 
        {
            // 作業二
            return View();
                    
        }

        public IActionResult Check() 
        {
            // 作業三
            return View();
        
        }

        public IActionResult Cities() 
        {
            // 作業四
            return View();
        
        }

        public IActionResult PicturePreview() 
        {
            // 作業五
            return View();
        
        }

    }
}
