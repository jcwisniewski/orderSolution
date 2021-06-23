using System;
using OrderSolution.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace OrderSolution.Entities
{
     class Order
    {
        public DateTime Moment { get; set; }
        public  OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Item { get; set; } = new List<OrderItem>();

        public Order()
        {
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem (OrderItem item)
        {
            Item.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Item)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Order Moment: " + Moment);
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Client :" + Client.Name + "(" + Client.BirthDate.ToString("dd/mm/yyyy")+ ") - "+ Client.Email);
            sb.AppendLine("Order items:");
                foreach(OrderItem item in Item)
            {
                sb.AppendLine(item.Product.Name+", Price: $ "+item.Product.Price+", Quantity: "+item.Quantity +","+"Subtotal: "+item.SubTotal());
            }
            sb.AppendLine("Total Price: $" + Total());
            

            return sb.ToString();
        }
    }
}
