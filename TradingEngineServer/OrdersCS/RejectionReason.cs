namespace OrdersCS;

public enum RejectionReason
{
    Unknown,
    OrderNotFound,
    InstrumentNotFound,
    AttemptingToModifyWrongSide
}