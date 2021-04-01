using System;
using System.Collections.Generic;
using System.Text;

namespace Order
{
    public class Client
    {
        public string ClientID { get; set; }
        public Client() { }
        public Client(string id)
        {
            ClientID = id;
        }

        public override string ToString()
        {
            return ClientID;
        }
    }
}
