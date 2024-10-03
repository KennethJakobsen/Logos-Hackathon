using Menu.Domain;
using Menu.Messages;
using Rebus.Bus;
using Rebus.Handlers;

namespace Menu.Worker.Handlers;

public class CreateMenuItemCommmandHandler(IBus bus) : IHandleMessages<CreateMenuItemCommand>
{
    private readonly IBus _bus = bus;

    public async Task Handle(CreateMenuItemCommand message)
    {
        var mItem = new MenuItem(message.Id, message.Name, message.Price, message.Description);
        
        await _bus.Publish(new MenuItemCreatedEvent(message.Id));
    }
}