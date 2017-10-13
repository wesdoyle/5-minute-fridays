using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderBuilder.Complex.ConcreteBuilders
{
    // A Concrete implementation of the Builder
    public class CleaningSuppliesPoBuilder : PurchaseOrderBuilder
    {
        public CleaningSuppliesPoBuilder()
        {
            po = new PurchaseOrder("CLEAN");
        }

        public override void AddVendor()
        {
            po.Vendor = HelperMethods.GetCleaningVendor();
        }

        public override void AddRequestedBy()
        {
            po.RequestedBy = DateTime.Now + TimeSpan.FromDays(7);
        }

        public override void AddLineItems()
        {
            var lineItems = new List<LineItem>() {
                new LineItem
                {
                    Description = "Detergent",
                    Qty = 3,
                    UnitCost = 2.41M,
                    UnitOfMeasure = Units.Gallons
                },

                new LineItem
                {
                    Description = "Towels",
                    Qty = 100,
                    UnitCost = 0.05M,
                    UnitOfMeasure = Units.Each
                }
            };

            po.Items = lineItems;
        }
    }
}
