using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
   public class OrderDetails
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public Product Prodc { get; set; }
        //public string ProductID { get; set; }
        public int Num { get; set; }
        public double ItemPrice { get; set; }



        public OrderDetails(string id, Product p, int num)
        {
            Id = id;
            Prodc = p;
            Num = num;
            ItemPrice = Num * Prodc.Price;
        }

        public override bool Equals(object obj)
        {
            var odi = obj as OrderDetails;
            return odi != null && Prodc.ProductID == odi.Prodc.ProductID;
        }

        public override string ToString()
        {

            return "[Item]" + Id + '\t' + Prodc + '\t' + Num + '\t' + ItemPrice + '\t';
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
