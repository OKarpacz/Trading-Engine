namespace OrdersCS;

public interface IOrderCore
{
    public long OrderId { get; }
    public int SecurityId { get; }
    public string Username { get; }
}