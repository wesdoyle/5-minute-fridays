using System;

namespace PurchaseOrderBuilder
{
    public class Vendor
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class LineItem
    {
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal UnitCost { get; set; }
        public string UnitOfMeasure { get; set; }
    }

    public class Units 
    {
        private Units(string value) { Value = value; }
        public string Value { get; set; }

        public static string Each => new Units("Ea").Value;
        public static string Pounds => new Units("Lb").Value;
        public static string Kilograms => new Units("Kg").Value;
        public static string Gallons => new Units("Gal").Value;
    }
}
