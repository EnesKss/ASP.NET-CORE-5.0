namespace App.Models
{
    // ==========================================
    // MODEL KATMANI
    // ==========================================
    // Veritabanı tablosunun veya işlenecek verinin C# nesnesi (Object) olarak karşılığıdır.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
