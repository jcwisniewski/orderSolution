using System;
namespace OrderSolution.Entities.Enums
{
     enum OrderStatus : int
    {
       PendingPayment,
       Processed,
       Shipped,
       Delivered
    }
}
