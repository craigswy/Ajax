using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MSIT150Site.Models;

namespace MSIT150Site.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000); //睡5秒鐘，再往下執行
            return Content("Hello Ajax!!");
        }

        public IActionResult GetDemo(UserViewModel user)  //public IActionResult GetDemo(string name, int age = 30)
        {
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest"; 
            }
            return Content($"Hello {user.name}, You are {user.age} years old.");
        }

        public IActionResult Register(Members member, IFormFile file)
        {
            
            //return Content($"{_host.ContentRootPath}");  //C:\shared\Ajax\MSIT150Site\
            //   return Content($"{_host.WebRootPath}");  //C:\shared\Ajax\MSIT150Site\wwwroot
            string filePath = Path.Combine(_host.WebRootPath, "uploads", file.FileName); //C:\shared\Ajax\MSIT150Site\wwwroot\uploads\walk.gif

            //上傳檔案到uploads資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            //將圖轉成二進位
            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }

            //    return Content($"上傳檔案到 {filePath}");

            //  return Content($"{file.FileName} - {file.Length} - {file.ContentType}");

            member.FileName = file.FileName;
            member.FileData = imgByte;
            _context.Members.Add(member);
            _context.SaveChanges();

            return Content("新增成功!!");
        }
    }
}
