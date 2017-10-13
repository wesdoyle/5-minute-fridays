using PurchaseOrderBuilder.Complex;
using PurchaseOrderBuilder.Complex.ConcreteBuilders;
using System;

namespace PurchaseOrderBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Method 1: "Manual Object construction"
            var vendor = HelperMethods.GetDryGoodsVendor();
            var lineItems = HelperMethods.ReceiveOrderFromSystem();
            var type = "BREAD";

            var po = new PurchaseOrder(type)
            {
                CompanyAddress = "7 Oceanview Rd",
                CreatedOn = DateTime.Now,
                Vendor = vendor,
                Items = lineItems,
                RequestedBy = DateTime.Now.AddDays(7),
                CompanyName = "Productive Dev Bakery"
            };

            PrintPurchaseOrder(po);

            // Method 2: "Fluent PO Builder"
            var poBuilder = new FluentPOBuilder();

            PurchaseOrder po2 = poBuilder
                .WithType("BREAD")
                .ForCompany("Productive Dev Bakery")
                .AtAddress("1234 Market Sq")
                .RequestedBy(DateTime.Now.AddDays(7))
                .FromVendor(vendor)
                .ForItems(lineItems);

            PrintPurchaseOrder(po2);

            // Method 3: "Classic Builder Pattern"
            Complex.PurchaseOrderBuilder builder;
            var shop = new PurchaseOrderShop();
            builder = new CleaningSuppliesPoBuilder();
            shop.Construct(builder);
            PrintPurchaseOrder(builder.PurchaseOrder);
        }

        private static void PrintPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine("Hit any key to print purchase order.");
            Console.ReadLine();

            Console.WriteLine("PURCHASE ORDER\n**************\n");
            Console.WriteLine("\tPO#: {0}", po.PoNumber);
            Console.WriteLine("\tDate: {0}", po.CreatedOn);
            Console.WriteLine("\tCompany: {0}", po.CompanyName);
            Console.WriteLine("\tAddress: {0}", po.CompanyAddress);
            Console.WriteLine("\tRequested By: {0}", po.RequestedBy.ToString("d"));
            Console.WriteLine(
                "\nVendor Info:\n************\n" +
                $"\t{po.Vendor.CompanyName}\n" +
                $"\t{po.Vendor.Address}\n" +
                $"\t{po.Vendor.Website}\n");
            Console.WriteLine("Itemized Order\n**************\n");
            Console.WriteLine("\tQty \tDescription \tUnitCost \tTotalCost");

            foreach(var item in po.Items)
            {
                Console.WriteLine(
                    $"\t{item.Qty} {item.UnitOfMeasure}" +
                    $"\t{item.Description}" +
                    $"\t@ ${item.UnitCost}" +
                    $"\t ${item.UnitCost * item.Qty}");
            }

            Console.WriteLine($"\nTotal Cost: {po.TotalOrderCost}");
            Console.ReadLine();
        }
    }
}
