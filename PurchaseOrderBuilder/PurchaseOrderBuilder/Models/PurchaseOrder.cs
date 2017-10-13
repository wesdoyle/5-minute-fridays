using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseOrderBuilder
{
    // Product
    public class PurchaseOrder
    {
        private string _type;

        public PurchaseOrder(string type)
        {
            _type = type;
        }

        public string PoNumber => _type + $"_{DateTime.Now.ToString("yyMMdd-HHmm")}";
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RequestedBy { get; set; }
        public Vendor Vendor { get; set; }
        public List<LineItem> Items { get; set; }

        public decimal TotalOrderCost
            => Items.Select(i => (i.UnitCost * i.Qty)).Sum();
    }

}
