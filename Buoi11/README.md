# Buổi 11 (19/07/2025) - LAB 7

## Thực hiện CRUD trên Product (mục 4.x)

### Tái sử dụng method upload file đã khai báo ở mục 3.x, trong đó hình sản phẩm sẽ lưu ở ```wwwroot\Images\Products```
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

## 1. Action ```Index()``` hiển thị danh sách sản phẩm
- Không hiện cột ```description``` do nhiều dữ liệu
- Cần hiển thị tên loại, tên nhà cung cấp ra ==> ở câu query thêm lệnh ```.Include(p => p.Category)``` và ```.Include(p => p.Supplier)```

## 2. Action ```Create()``` thêm mới sản phẩm
- Cần đổ dữ liệu cho DropDown List chọn loại/nhà cung cấp
	- Ở Action: ```ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");```
 	- Ở View, thêm/hiệu chỉnh thuộc tính ```asp-items="ViewBag.Suppliers"``` cho thẻ ```<select>```
- Chỉnh sửa cột ```Description``` thành dạng multiple line ==> sử dụng thẻ ```<textarea>```
- Chỉnh sửa cho phép upload hình:
	- Thêm thuộc tính ```enctype="multipart/form-data"``` cho form
 	- Chỉnh thuộc tính ```Image``` thành ```type="file"```
- Action POST vẫn truyền ```ViewBag.Suppliers```,... qua View cho trường hợp nhập sai
