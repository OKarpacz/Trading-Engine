using System.Windows.Input;

namespace OrdersCS;

public class CancelOrder : IOrderCore
{
    public CancelOrder(IOrderCore orderCore)
    {
        
        _orderCore = orderCore;
    }

    public long OrderId => _orderCore.OrderId;
    public string Username => _orderCore.Username;
    public int SecurityId => _orderCore.SecurityId;
    
    
    private readonly IOrderCore _orderCore;
}