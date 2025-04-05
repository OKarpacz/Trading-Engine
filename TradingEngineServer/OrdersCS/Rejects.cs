namespace OrdersCS;

public class Rejects : IOrderCore
{
    public Reject(IOrderCore rejectedOrder, RejectionReason rejectionReason)
    {
        RejectionReason = rejectionReason;
        _orderCore = rejectedOrder;
        
        return "TO BE CONTINUED"
    }

    
    public RejectionReason RejectionReason {get; private set;}
    public long OrderId => _orderCore.OrderId;
    public string Username => _orderCore.Username;
    public int SecurityId => _orderCore.SecurityId;
    
    private readonly IOrderCore _orderCore;
    
}