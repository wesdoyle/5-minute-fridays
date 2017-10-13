using System;
using System.Collections.Generic;

namespace PurchaseOrderBuilder.Complex.ConcreteBuilders
{
    // A Concrete Builder
    class BreadSuppliesPoBuilder : PurchaseOrderBuilder
    {
        public BreadSuppliesPoBuilder()
        {
            po = new PurchaseOrder("BREAD");
        }

        public override void AddVendor()
        {
            po.Vendor = HelperMethods.GetBakeryVendor();
        }

        public override void AddRequestedBy()
        {
            po.RequestedBy = DateTime.Now + TimeSpan.FromDays(14);
        }

        public override void AddLineItems()
        {
            var lineItems = new List<LineItem>() {
                new LineItem
                {
                    Description = "Salt",
                    Qty = 10,
                    UnitCost = 2.01M,
                    UnitOfMeasure = Units.Kilograms
                },

                new LineItem
                {
                    Description = "Bread Yeast",
                    Qty = 2,
                    UnitCost = 5.17M,
                    UnitOfMeasure = Units.Pounds
                }
            };

            po.Items = lineItems;
        }
    }
}