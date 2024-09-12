using ConsoleApp1.Context;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Functions;

public class Function
{
    public void GetAllProduct(ProductDbContext dbContext)
    {
        var products = from Product in dbContext.Products select Product;
        foreach (var product in products)
            Console.WriteLine("Id:" + product.Id + " Ad:" + product.Name + " Qiymet:" + product.Price + " CategoryId:" + product.CategoryId);
    }

    public void GetProductId(ProductDbContext dbContext, int Id)
    {
        var products = from Product in dbContext.Products where Product.Id == Id select Product;
        foreach(var product in products)
        {
            Console.WriteLine("Id:" + product.Id + " Ad:" + product.Name + " Qiymet:" + product.Price + " CategoryId:" + product.CategoryId);
        }
    }

    public async Task AddProduct(ProductDbContext dbContext, Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(ProductDbContext dbContext, int Id)
    {
        // Ürünü veritabanında bul
        var product = await dbContext.Products.FindAsync(Id);

        if (product != null)
        {
            dbContext.Products.Remove(product);

            await dbContext.SaveChangesAsync();
            Console.WriteLine("Silindi...");
        }
        else
        {
            Console.WriteLine("Ürün bulunamadı.");
        }
    }

    public async Task UpdateProduct(ProductDbContext dbContext, int Id, string Name)
    {
        var product = await dbContext.Products.FindAsync(Id);

        if (product != null)
        {
            product.Name = Name;
            await dbContext.SaveChangesAsync();
            Console.WriteLine("Degisiklik Yapildi.");
        }
        else
        {
            Console.WriteLine("Urun Bulunamadi.");
        }
    }
}
