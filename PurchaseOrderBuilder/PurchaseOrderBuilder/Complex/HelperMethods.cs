using System;
using System.Collections.Generic;

namespace PurchaseOrderBuilder.Complex
{
    public class HelperMethods
    {
        public static Vendor GetCleaningVendor()
        {
            return new Vendor
            {
                Id = 32,
                CompanyName = "Productive Cleaners",
                Address = "1234 Main St.",
                Phone = "5553332",
                Website = "example.com",
                CreatedOn = DateTime.Parse("10/15/2017")
            };
        }

        public static Vendor GetBakeryVendor()
        {
            return new Vendor
            {
                Id = 21,
                CompanyName = "Productive Dry Goods",
                Address = "302 East Ave.",
                Phone = "5551337",
                Website = "productivedev.com",
                CreatedOn = DateTime.Parse("10/01/2015")
            };
        }

        public static DateTime GetLeadTime(Vendor vendor)
        {
            return DateTime.Now + TimeSpan.FromDays(3);
        }

        // These Methods are outside of our builder pattern - our client
        // application sends us a vendor and list of line items for the order.
        public static Vendor GetDryGoodsVendor()
        {
            return new Vendor
            {
                Id = 22,
                Address = "123 Main St.",
                CompanyName = "Wholesale Dry Goods",
                CreatedOn = DateTime.Parse("1/30/1992"),
                Phone = "555-1234",
                Website = "www.productivedev.com"
            };
        }

        public static List<LineItem> ReceiveOrderFromSystem()
        {
            var lineItems = new List<LineItem>();

            var flourLineItem = new LineItem
            {
                Qty = 50,
                Description = "Pastry Flour",
                UnitOfMeasure = Units.Pounds,
                UnitCost = .18M
            };

            var saltLineItem = new LineItem
            {
                Qty = 10,
                Description = "Sea Salt",
                UnitOfMeasure = Units.Kilograms,
                UnitCost = 2.5M
            };

            var milkLineItem = new LineItem
            {
                Qty = 25,
                Description = "Whole Milk",
                UnitOfMeasure = Units.Gallons,
                UnitCost = 3.50M
            };

            lineItems.AddRange(new List<LineItem>{
                flourLineItem, saltLineItem, milkLineItem
            });

            return lineItems;
        }
    }
}
