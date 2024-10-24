public class Product 
{
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }
    public string Category { get; set; }
    public DateTime DateStocked { get; set; }

    public int DaysOnShelf
    {
        get
        {
            TimeSpan timeOnShelf = DateTime.Now - DateStocked;
            return timeOnShelf.Days;
        }
    }
    public int ProductTypeId
    {
        get
        {
            switch(Category)
            {
                case "apparel":
                return 1;
                case "potion":
                return 2;
                case "enchanted object":
                return 3;
                case "wand":
                return 4;
                default:
                return 0;
            }
        }
    }


}

