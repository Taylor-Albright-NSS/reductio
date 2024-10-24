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
            if (Category == "apparel")
            {
                return 1;
            }
            else {
                return 0;
            }
        }
    }


}

