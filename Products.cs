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
                case "potions":
                return 2;
                case "enchanted objects":
                return 3;
                case "wands":
                return 4;
                default:
                return 0;
            }
        }
    }

}

