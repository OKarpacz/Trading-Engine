﻿namespace OrdersCS;

public class OrderCore : IOrderCore
{
    public OrderCore(long orderId, int securityId, string username)
    {
        OrderId = orderId;
        SecurityId = securityId;
        Username = username;
    }
    
    public long OrderId { get; private set; }
    public int SecurityId { get; private set; }
    public string Username { get; private set; }
    
}