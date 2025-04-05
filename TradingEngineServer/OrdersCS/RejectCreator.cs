namespace OrdersCS;

public sealed class RejectCreator
{
    public static Rejects GenerateOrderCoreRejection(IOrderCore rejectedOrder, RejectionReason rejectionReason)
    {
        return new Rejects(rejectedOrder, rejectionReason);
    }
}