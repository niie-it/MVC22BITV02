# Buổi 11 (19/07/2025) - LAB 7

## Thực hiện CRUD trên Product (mục 4.x)

### Tái sử dụng method upload file đã khai báo ở mục 3.x
```cs
	public class MyTool
	{
		public static string UploadImageToFolder(IFormFile myfile, string folder)
		{
			try
			{
				var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", folder, myfile.FileName);
				using (var newFile = new FileStream(filePath, FileMode.Create))
				{
					myfile.CopyTo(newFile);
				}
				return myfile.FileName;
			}
			catch (Exception ex)
			{
				return string.Empty;
			}
		}
	}
```