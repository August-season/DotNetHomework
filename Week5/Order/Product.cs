using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
   public class Product
    {
        public string ProductID { get; set; }

        public string Name { get; }
        public double Price { get; set; }

        public Product()
        {
            //ID = Guid.NewGuid().ToString();
        }
        public Product(string id,string name, double price)
        {
            ProductID = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + '-' + Price + "元";
        }

        public override int GetHashCode()
        {
            int hashCode = 110068;
            hashCode = hashCode * -68 + EqualityComparer<string>.Default.GetHashCode(ProductID);
            hashCode = hashCode * -68 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
