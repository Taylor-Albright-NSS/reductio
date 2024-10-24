// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Product> products = new List<Product>()
{
    new Product() 
    {
        Name = "Wizard Robes",
        Price = 150,
        IsAvailable = true,
        Category = "apparel",
        DateStocked = new DateTime(2024, 10, 12),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Unusually Large Hat",
        Price = 75,
        IsAvailable = true,
        Category = "apparel",
        DateStocked = new DateTime(1297, 3, 12),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Potion Of Healing",
        Price = 200,
        IsAvailable = true,
        Category = "potions",
        DateStocked = new DateTime(2024, 10, 18),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Potion Of Mana",
        Price = 200,
        IsAvailable = true,
        Category = "potions",
        DateStocked = new DateTime(2024, 10, 18),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Wildly Flaming Longbow",
        Price = 2250,
        IsAvailable = true,
        Category = "enchanted object",
        DateStocked = new DateTime(2020, 10, 20),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Dragon Bone Wand",
        Price = 3100,
        IsAvailable = true,
        Category = "wand",
        DateStocked = new DateTime(2024, 10, 20),
        //DaysOnShelf
        //ProductTypeId
    },
};

Console.WriteLine(@"Welcome to the Reductio & Absurdum Magic Shop!
Below is a list of options for you to browse our menu!");

    Console.WriteLine("Please enter a lettered option from the list below:");
    Console.WriteLine(@"
a. View all products
b. Add a product
c. Delete a product
d. Update a product's details
m. Refresh menu
z. Exit");


string userChoice = null;
while (userChoice != "z")
{


    userChoice = Console.ReadLine().Trim().ToLower();
    if (userChoice != "a" && userChoice != "b" && userChoice != "c" && userChoice != "d")
    {
        Console.WriteLine("Please enter a valid lettered option from the list.");
    }
    switch(userChoice)
    {
        case "a":
        productList();
        break;
        case "b":
        Console.Write("No option yet");
        break;
        case "c":
        Console.Write("No option yet");
        break;
        case "d":
        Console.Write("No option yet");
        break;
        case "m":
        returnToMenu();
        break;
    }
}

void productList()
{
    Console.WriteLine("List of products:");
    
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine($"m. Return to menu");
}

void returnToMenu()
{
    Console.WriteLine("Please enter a lettered option from the list below:");
    Console.WriteLine(@"
a. View all products
b. Add a product
c. Delete a product
d. Update a product's details
m. Refresh menu
z. Exit");
}

