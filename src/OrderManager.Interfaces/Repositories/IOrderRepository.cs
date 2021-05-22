namespace OrderManager.Interface.Repositories
{
    public interface IOrderRepository
    {
        decimal TicketMaximum();
        dynamic OrderClients();
    }
}
