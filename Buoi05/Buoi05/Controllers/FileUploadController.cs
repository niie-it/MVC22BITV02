using Microsoft.AspNetCore.Mvc;

namespace Buoi05.Controllers
{
	public class FileUploadController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult UploadFile(IFormFile MyFile)
		{
			if (MyFile == null)
			{
				TempData["Message"] = "Chưa có file upload";
			}
			else
			{
				var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles", MyFile.FileName);
				using (var file = new FileStream(fullPath, FileMode.Create))
				{
					MyFile.CopyTo(file);
				}
				TempData["Message"] = "Upload thành công";
			}
			return RedirectToAction("Index");
		}
		
		public IActionResult UploadFiles(List<IFormFile> MyFiles)
		{
			if (MyFiles == null || MyFiles.Count == 0)
			{
				TempData["Message"] = "Chưa chọn file upload";
			}
			else
			{
				foreach(var MyFile in  MyFiles)
				{
					var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadFiles", MyFile.FileName);
					using (var file = new FileStream(fullPath, FileMode.Create))
					{
						MyFile.CopyTo(file);
					}
				}				
				TempData["Message"] = $"Upload {MyFiles.Count} file thành công";
			}
			return RedirectToAction("Index");
		}

	}
}
