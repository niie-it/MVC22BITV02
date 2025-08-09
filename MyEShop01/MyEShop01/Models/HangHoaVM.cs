namespace MyEShop01.Models
{
	public class HangHoaVM
	{
		public int Id { get; set; }
		public string TenHH { get; set; }
		public string Hinh { get; set; }
		public double DonGia { get; set; }
	}

	public class CartItem : HangHoaVM
	{
		public int SoLuong { get; set; }
		public double ThanhTien => DonGia * SoLuong;
	}
}
