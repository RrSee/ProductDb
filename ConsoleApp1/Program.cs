using ConsoleApp1.Context;
using ConsoleApp1.Entities;
using ConsoleApp1.Functions;

class Program
{
    static async Task Main(string[] args)
    {
        ProductDbContext dbContext = new ProductDbContext();

        Function func = new Function();
        func.GetAllProduct(dbContext);
        //func.GetProductId(dbContext, 2);
        //Product product1 = new Product()
        //{
        //    Name = "Yuxa",
        //    Price = 3,
        //    CategoryId = 2
        //};
        //func.AddProduct(dbContext, product1);
        //func.DeleteProduct(dbContext, 9);
        //func.UpdateProduct(dbContext, 2, "Mirinda");
    }
}