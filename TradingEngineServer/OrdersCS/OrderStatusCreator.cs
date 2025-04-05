namespace OrdersCS;

public sealed class OrderStatusCreator
{
    public static CancelOrderStatus CreateCancelOrderStatus(CancelOrder cancelOrder)
    {
        return new CancelOrderStatus();
    }

    public static NewOrderStatus GenerateNewOrderStatus(Order order)
    {
        return new NewOrderStatus();
    }

    public static ModifyOrderStatus GenerateModifyOrderStatus(ModifyOrder modifyOrder)
    {
        return new ModifyOrderStatus();
    }
}