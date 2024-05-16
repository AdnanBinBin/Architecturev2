namespace WebAPINormal.DTO
{
    public class ProductRateDTO
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    
        public ProductRateDTO(string code, string name, decimal price, bool active)
        {
            ProductCode = code;
            ProductName = name;
            Price = price;
            IsActive = active;
        }


    }
}
