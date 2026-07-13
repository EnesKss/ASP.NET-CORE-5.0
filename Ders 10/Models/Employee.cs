namespace App.Models
{
    // ==========================================
    // MODEL KATMANI (Veri Yapısı ve İş Mantığı)
    // ==========================================
    // Bu katman sadece uygulamanın verilerini (ve bazen iş kurallarını) temsil eder.
    // Ekranda (HTML'de) bu verinin nasıl görüneceğini bilmez.
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
