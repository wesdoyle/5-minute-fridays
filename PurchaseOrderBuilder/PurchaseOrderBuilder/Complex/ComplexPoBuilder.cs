using System;
using System.Collections.Generic;

namespace PurchaseOrderBuilder.Complex
{
    // The "Director" class
    public class PurchaseOrderShop
    {
        public void Construct(PurchaseOrderBuilder builder)
        {
            builder.AddLineItems();
            builder.AddRequestedBy();
            builder.AddVendor();
        }
    }

    // The "Builder" Abstract Class
    public abstract class PurchaseOrderBuilder {
        public string PoNumber;
        public List<LineItem> LineItems;
        public Vendor Vendor;
        public DateTime DateOrdered;
        public DateTime RequestedBy;

        public abstract void AddLineItems();
        public abstract void AddVendor();
        public abstract void AddRequestedBy();

        protected PurchaseOrder po;
        public PurchaseOrder PurchaseOrder => po;
    }
}
