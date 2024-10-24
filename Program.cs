// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Product> inventory = new List<Product>()
{
    new Product() 
    {
        Name = "Wizard Robes",
        Price = 150,
        IsAvailable = true,
        Category = "apparel",
        DateStocked = new DateTime(2024, 10, 20),

    }
};

Console.WriteLine($@"Date stocked: {inventory[0].DateStocked}
Time on shelf: {inventory[0].DaysOnShelf}
Product Type Id: {inventory[0].ProductTypeId}");
