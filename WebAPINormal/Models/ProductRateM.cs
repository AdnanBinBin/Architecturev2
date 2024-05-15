namespace PrintWebApp.Models
{
    public class ProductRateM
    {
        public int IdProduct { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; } // Changement de "Active" à "IsActive"

    }
}
