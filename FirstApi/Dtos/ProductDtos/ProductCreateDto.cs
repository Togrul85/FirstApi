namespace FirstApi.Dtos.ProductDtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public double SalePrice { get; set; }

        public double CostPrice { get; set; }

        public bool IsActive { get; set; }

    }
}
