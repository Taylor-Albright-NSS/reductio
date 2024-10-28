using System.Dynamic;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
Console.WriteLine("Hello, World!");

List<Product> products = new List<Product>()
{
    new Product() 
    {
        Name = "Wizard Robes",
        Price = 150.99,
        IsAvailable = true,
        Category = "apparel",
        DateStocked = new DateTime(2024, 10, 12),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Unusually Large Hat",
        Price = 75.99,
        IsAvailable = false,
        Category = "apparel",
        DateStocked = new DateTime(1297, 3, 12),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Potion Of Healing",
        Price = 199.99,
        IsAvailable = true,
        Category = "potions",
        DateStocked = new DateTime(2024, 10, 18),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Potion Of Mana",
        Price = 199.98,
        IsAvailable = false,
        Category = "potions",
        DateStocked = new DateTime(2024, 10, 18),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Wildly Flaming Longbow",
        Price = 2250.99,
        IsAvailable = true,
        Category = "enchanted objects",
        DateStocked = new DateTime(2020, 10, 20),
        //DaysOnShelf
        //ProductTypeId
    },
    new Product() 
    {
        Name = "Dragon Bone Wand",
        Price = 3100.50,
        IsAvailable = true,
        Category = "wands",
        DateStocked = new DateTime(2024, 10, 20),
        //DaysOnShelf
        //ProductTypeId
    },
};

Console.WriteLine(@"Welcome to the Reductio & Absurdum Magic Shop!
Below is a list of options for you to browse our menu!");
showMainMenuOptions();

string userChoice = null;
while (userChoice != "z")
{
    userChoice = Console.ReadLine().Trim().ToLower();
    switch(userChoice)
    {
        case "a":
        productList();
        break;
        case "b":
        viewAvailableProducts();
        break;
        case "c":
        addProduct();
        break;
        case "d":
        deleteProduct();
        break;
        case "e":
        updateProductDetails();
        break;
        case "f":
        viewProductDetails();
        break;
        case "g":
        searchForProduct();
        break;
        case "m":
        showMainMenuOptions();
        break;
        case "z":
        return;
        default:
        Console.WriteLine("Please enter a valid menu option.");
        break;
    }
}

void productList()
{
        Console.WriteLine(@"
List of products:");
    int listNumber = 0;
    for (int i = 0; i < products.Count; i++)
    {
        listNumber++;
        Console.WriteLine($"{listNumber}. {products[i].Name}");
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

    Console.WriteLine("Enter the name of the item:");
    string itemName = Console.ReadLine();

    Console.WriteLine("Enter the price:");
    double itemPrice = 0;
    while (itemPrice == 0)
    {
        try 
        {
            itemPrice = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter only numbers for the price.");
            Console.WriteLine("Enter the price again:");
        }
    }
    string itemCategory = null;
    while (itemCategory != "apparel" && itemCategory != "wands" && itemCategory != "enchanted objects" && itemCategory != "potions")
    {
        Console.WriteLine("Select a category for your item: apparel, wands, enchanted objects, potions.");
        itemCategory = Console.ReadLine();
        if (itemCategory != "apparel" && itemCategory != "wands" && itemCategory != "enchanted objects" && itemCategory != "potions")
        {
            Console.WriteLine("Please choose a category from the list provided!");
        }
    }


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
    showMainMenuOptions();  
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

        Console.WriteLine("Enter the new category for the item (must be apparel, potion, enchanted objects, or wands)");
        products[userIntChoice - 1].Category = Console.ReadLine();

        Console.WriteLine($"You have sucessfully edited {products[userIntChoice - 1].Name}");
    }
}


void showMainMenuOptions()
{
    Console.WriteLine("Enter a lettered option from the Main Menu:");
    Console.WriteLine(@"
a. View all products
b. View available products
c. Add a product
d. Delete a product
e. Update a product's details
f. View product details
g. Lookup items by category
m. Main Menu
z. Exit");
}

void viewProductDetails()
{

    Console.WriteLine("Product Inventory:");
    Console.WriteLine("");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    Console.WriteLine($"{products.Count + 1}. Main menu");
    Console.WriteLine("Select a product number to view its details.");
    Console.WriteLine("");
    Product productToTest = null;
    int productIndex = 0;
    while(productToTest == null)
    {
        try
        {
            string userChoice = Console.ReadLine().Trim().ToLower();
            productIndex = int.Parse(userChoice);
            if (productIndex == products.Count + 1)
            {
                showMainMenuOptions();
                return;
            }
            Product productToText = products[int.Parse(userChoice) - 1];
                    
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}. Please choose again.");
        }

        if (productIndex > 0 && productIndex <= products.Count)
        {
            Console.WriteLine($"Name: {products[productIndex - 1].Name}");
            Console.WriteLine($"Price: {products[productIndex - 1].Price.ToString("F2")}");
            Console.WriteLine($"Available for purchase?: {(products[productIndex - 1].IsAvailable ? "Yes" : "No")}");
            Console.WriteLine($"Stock date: {products[productIndex - 1].DateStocked}");
            Console.WriteLine($"Days on shelf: {products[productIndex - 1].DaysOnShelf}");
            Console.WriteLine($"Select another product number to view its details or enter {products.Count + 1} to return to the main menu.");
            Console.WriteLine(" ");
            productToTest = null;
        }
    }


}

void viewAvailableProducts()

{
    List<Product> availableProducts = products.Where(p => p.IsAvailable).ToList();
    for (int i = 0; i < availableProducts.Count; i++) 
    {
        Console.WriteLine($"{i + 1}. {availableProducts[i].Name}");
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

void searchForProduct()
{
    Console.WriteLine(@"Which product type would you like to look up? (apparel, wands, enchanted objects, potions)");
    List<Product> filteredItems = new List<Product>();
    string searchedItem = null;
    // while (searchedItem != "apprel" && searchedItem != "wands" && searchedItem != "enchanted objects" && searchedItem != "potions")
    while (searchedItem == null) 
    {
        searchedItem = Console.ReadLine();
        switch (searchedItem)
        {
            case "apparel":
            filteredItems = products.Where(product => product.Category == "apparel").ToList();
            break;
            case "wands":
            filteredItems = products.Where(product => product.Category == "wands").ToList();
            break;
            case "enchanted objects":
            filteredItems = products.Where(product => product.Category == "enchanted objects").ToList();
            break;
            case "potions":
            filteredItems = products.Where(product => product.Category == "potions").ToList();
            break;
            default:
            searchedItem = null;
            break;
        }
    
        for (int i = 0; i < filteredItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {filteredItems[i].Name}");
        }
        Console.WriteLine("Would you like to look up another category? (y/n)");
        string userResponse = Console.ReadLine();
        if (userResponse == "y" || userResponse == "yes")
        {
        Console.WriteLine(@"Which product type would you like to look up? (apparel, wands, enchanted objects, potions)");
            searchedItem = null;
        }
        else 
        {
            showMainMenuOptions();
        }
    }
}