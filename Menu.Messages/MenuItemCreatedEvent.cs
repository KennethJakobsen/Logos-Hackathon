namespace Menu.Messages;

public class MenuItemCreatedEvent(int id)
{
    public int Id { get; set; } = id;
}