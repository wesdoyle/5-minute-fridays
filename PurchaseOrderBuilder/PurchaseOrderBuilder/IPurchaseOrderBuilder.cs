using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrderBuilder
{
    public interface IPurchaseOrderBuilder
    {
        FluentPOBuilder WithType(string type);
        FluentPOBuilder ForCompany(string companyName);
        FluentPOBuilder AtAddress(string address);
        FluentPOBuilder RequestedBy(DateTime date);
        FluentPOBuilder FromVendor(Vendor vendor);
        FluentPOBuilder ForItems(List<LineItem> items);

        PurchaseOrder BuildPurchaseOrder();
    }
}
