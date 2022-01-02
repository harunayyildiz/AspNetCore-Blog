using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog ID";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;// İlk 2 row başlık içeriyor.
                foreach (var item in BlogTitleList())
                {
                    workSheet.Cell(BlogRowCount, 1).Value = item.Id;
                    workSheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> blogModels = new List<BlogModel>();
            using (var c = new Context())
            {
                blogModels = c.Blogs.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    BlogName = x.BlogTitle
                }).ToList();
                return blogModels;
            }

        }

        public IActionResult blogListExcelTrig()
        {
            return View();
        }
    }
}
