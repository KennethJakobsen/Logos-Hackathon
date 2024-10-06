using Menu.Domain;
using Menu.Infrastructure.Database.Repositories;
using Menu.Messages;
using Rebus.Bus;
using Rebus.Handlers;

namespace Menu.Worker.Handlers;

public class CreateMenuItemCommmandHandler(IBus bus, MenuItemRepository repo) : IHandleMessages<CreateMenuItemCommand>
{
    private readonly IBus _bus = bus;
    private readonly MenuItemRepository _repo = repo;

    public async Task Handle(CreateMenuItemCommand message)
    {
        var mItem = new MenuItem(message.Id, message.Name, message.Price, message.Description);
        await _repo.SaveAsync(mItem);
        await _bus.Publish(new MenuItemCreatedEvent(message.Id));
    }
}