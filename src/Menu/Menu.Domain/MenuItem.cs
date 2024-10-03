namespace Menu.Domain;

public class MenuItem(int id, string name, decimal price, string description)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public string Description { get; set; } = description;
}