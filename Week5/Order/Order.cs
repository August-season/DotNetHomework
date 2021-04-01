using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
   public class Order : IComparable
    {

        public string OrderId { get; set; }

        public Client Client { get; set; }
        public string ClientID { get; set; }

        public string Address { get; set; }

        public List<OrderDetails> Items { set; get; }
        public double TotalPrice { get; }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderDetails>();
            Client = new Client("c01");
        }
        public Order(string id, Client c, string addr, List<OrderDetails> items)
        {
            OrderId = id;
            Client = c;
            Address = addr;
            Items = items;
            TotalPrice = 0;
            foreach (OrderDetails item in Items)
            {
                TotalPrice += item.ItemPrice;
            }
        }

        public void AddItem(OrderDetails OrderDetails)
        {
            if (Items.Contains(OrderDetails))
                throw new ApplicationException($"添加错误：订单项已经存在!");
            Items.Add(OrderDetails);
        }

        public void RemoveItem(OrderDetails OrderDetails)
        {
            Items.Remove(OrderDetails);
        }

        public override bool Equals(object obj)
        {
            Order od = obj as Order;
            return od != null && OrderId == od.OrderId;
        }

        public override string ToString()
        {
            string s = "订单ID:" + OrderId + '\t' + "Client:" + Client + '\t' + "OrderPrice:" + TotalPrice + "\t\n";
            foreach (OrderDetails item in Items) s += item + "\t\n";
            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Order od = obj as Order;
            if (od != null)
            {
                int id1 = Convert.ToInt32(this.OrderId.Remove(0, 1));
                int id2 = Convert.ToInt32(od.OrderId.Remove(0, 1));
                return id1 - id2;
            }
            throw new NotImplementedException();
        }
    }
}
