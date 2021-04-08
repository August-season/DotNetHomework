using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Order
{
    public class OrderService
    {
        public List<Order> orders { get; set; }

        public OrderService() {
           
        }

        public OrderService(List<Order> ods)
        {
            orders = ods;
        }



        public void AddOrder(Order od)
        {
            try
            {
                orders.Add(od);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("添加订单失败");
                Console.WriteLine(e.Message);
            }

        }
        public  void DeleteOrder(string id)
        {
            try
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].OrderId == id)
                    {
                        orders.Remove(orders[i]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("删除订单失败");
            }
        }


        public void ChangeOrder(Order od, Client client)
        {
            int index = orders.IndexOf(od);
            od.Client = client;
            orders[index].Client = client;
        }
        public  void ChangeOrder(Order od, string addr)
        {
            int index = orders.IndexOf(od);
            od.Address = addr;
            orders[index].Address = addr;
        }
        public void ChangeOrder(Order od, List<OrderDetails> li)
        {
            int index = orders.IndexOf(od);
            od.Items = li;
            orders[index].Items = li;
        }

        public IEnumerable<Order> SearchOrder(int opt, string info)
        {
            switch (opt)
            {
                case 1: //订单号查询
                    var query1 = from od1 in orders
                                 where od1.OrderId == info
                                 orderby od1.TotalPrice
                                 select od1;
                    return query1;
                case 2: //商品名称查询
                    var query2 = from od2 in orders
                                 from items in od2.Items
                                 where items.Prodc.Name == info
                                 select od2;
                    return query2;
                case 3: //客户查询
                    var query3 = from od3 in orders
                                 where od3.Client.ToString() == info
                                 orderby od3.TotalPrice
                                 select od3;
                    return query3;
                default:
                    return null;
            }
        }


        public void SortOrder()
        {
            orders.Sort();
        }

        public void SortOrder(Comparison<Order> comp)
        {
            orders.Sort(comp);
        }
  
    }
}
