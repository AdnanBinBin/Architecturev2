namespace WebAPINormal.DTO
{
    public class ProductRateDTO
    {


        public int IdProduct { get; set; }
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

        public ProductRateDTO(int idProduct, string code, string name, decimal price, bool active)
        {
            IdProduct = idProduct;
            ProductCode = code;
            ProductName = name;
            Price = price;
            IsActive = active;
        }


    }
}
