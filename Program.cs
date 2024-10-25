// See https://aka.ms/new-console-template for more information
using System.Dynamic;

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




string userChoice = null;
while (userChoice != "z")
{

    if (userChoice != "a") {
        returnToMenu();
    }
    userChoice = Console.ReadLine().Trim().ToLower();
    if (userChoice != "a" && userChoice != "b" && userChoice != "c" && userChoice != "d" && userChoice != "e" && userChoice != "m" && userChoice != "z")
    {
        Console.WriteLine(@"
PLEASE ENTER A VALID OPTION!");
    }
    switch(userChoice)
    {
        case "a":
        productList();
        break;
        case "b":
        addProduct();
        break;
        case "c":
        deleteProduct();
        break;
        case "d":
        updateProductDetails();
        break;
        case "e":
        viewProductDetails();
        break;
        case "m":
        returnToMenu();
        break;
        case "z":
        return;
    }
}

void productList()
{
        Console.WriteLine(@"
List of products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine("m. Refresh menu options");
}


void addProduct()
{
    userChoice = null;
    while (userChoice == null || userChoice == "y" || userChoice == "yes")
    {
    Console.WriteLine(@"Add a product to the list by providing the information below:
    ");
    Console.WriteLine("Enter the name");
    string itemName = Console.ReadLine();

    Console.WriteLine("Enter the price");
    double itemPrice = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the category");
    string itemCategory = Console.ReadLine();

    Product newItem = new Product()
    {
        Name = itemName,
        Price = itemPrice,
        IsAvailable = true,
        Category = itemCategory,
        DateStocked = DateTime.Now,
    };
    products.Add(newItem);
    Console.WriteLine("Do you wish to add another product? (y/n)");
    userChoice = Console.ReadLine();
    }    
}

void deleteProduct()
{
    Console.WriteLine(@"Choose a product to delete:
    ");

    int userIntChoice = 0;
    while (userIntChoice == 0) 
    {
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name}");
        }
        Console.WriteLine($"{products.Count + 1}. Back to main menu");
        userIntChoice = int.Parse(Console.ReadLine());

        if (userIntChoice > 0 && userIntChoice < products.Count + 1)
        {
            Console.WriteLine($"You have removed {products[userIntChoice - 1].Name}");
            products.RemoveAt(userIntChoice - 1);
            userIntChoice = 0;
        }
        else if (userIntChoice == products.Count + 1)
        {
            return;
        }
    }
}

void updateProductDetails()
{
    Console.WriteLine(@"Select a product that you wish to update from the list below:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine($"{products.Count + 1}. Main menu");
    int userIntChoice = int.Parse(Console.ReadLine());
    if (userIntChoice > 0 && userIntChoice < products.Count + 1)
    {
        Console.WriteLine($"You have selected to edit {products[userIntChoice - 1].Name}");
        Console.WriteLine("Enter the new name for the item");
        products[userIntChoice - 1].Name = Console.ReadLine();

        Console.WriteLine("Enter the new price for the item");
        products[userIntChoice - 1].Price = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the new category for the item (must be apparel, potion, enchanted object, or wand)");
        products[userIntChoice - 1].Category = Console.ReadLine();

        Console.WriteLine($"You have sucessfully edited {products[userIntChoice - 1].Name}");
    }
}


void returnToMenu()
{
    Console.WriteLine("Enter a lettered option from the Main Menu:");
    Console.WriteLine(@"
a. View all products
b. Add a product
c. Delete a product
d. Update a product's details
e. View product details
m. Main Menu
z. Exit");
}

void viewProductDetails()
{
    Console.WriteLine(@"
Product Inventory:
");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine($"{products.Count + 1}. Main menu");
    Console.WriteLine(@"
Select a product number to view its details.");

    int userChoice = int.Parse(Console.ReadLine());
    while (userChoice > 0 && userChoice < products.Count + 1)
    {
        Console.WriteLine($"Name: {products[userChoice - 1].Name}");
        Console.WriteLine($"Price: {products[userChoice - 1].Price}");
        Console.WriteLine($"Available for purchase?: {(products[userChoice - 1].IsAvailable ? "Yes" : "No")}");
        Console.WriteLine($"Stock date: {products[userChoice - 1].DateStocked}");
        Console.WriteLine($"Days on shelf: {products[userChoice - 1].DaysOnShelf}");
        Console.WriteLine(@"
Select another product number to view its details.
");
        userChoice = int.Parse(Console.ReadLine());
    }
}

void listProducts()
{
        for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine($"{products.Count + 1}. Main menu");
}