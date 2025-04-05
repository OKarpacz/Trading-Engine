namespace OrdersCS;

public class Order : IOrderCore
{
 public Order(IOrderCore orderCore, bool isBuySide, long price, uint quantity)
 {
  //Propperties
   Price = price;
   IsBuySide = isBuySide;
   InitialQuantity = quantity;
   CurrentQuantity = quantity;
   
   
   //Fields
   _orderCore = orderCore;
 }

 public Order(ModifyOrder modifyOrder) :
  this(modifyOrder, modifyOrder.IsBuySide, modifyOrder.Price, modifyOrder.Quantity)
 {
  
 }
 
 public long Price{ get; private set; }
 public uint InitialQuantity{ get; private set; }
 public uint CurrentQuantity { get; private set; }
 public bool IsBuySide{ get; private set; } 
 public long OrderId => _orderCore.OrderId;
 public string Username => _orderCore.Username;
 public int SecurityId => _orderCore.SecurityId;
 
 
 //Methods 
 public void IncreaseQuantity(uint quantityDelta)
 {
  CurrentQuantity += quantityDelta;
 }

 public void DecreaseQuantity(uint quantityDelta)
 {
  if(quantityDelta > CurrentQuantity)
    throw new InvalidCastException($"Quantity delta {quantityDelta} is greater than current quantity {CurrentQuantity} for OrderId {_orderCore.OrderId}");
  CurrentQuantity -= quantityDelta;
 }
 
 //FIELDS
 private readonly IOrderCore _orderCore;
 
}