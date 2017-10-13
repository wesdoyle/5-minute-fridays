using System;
using System.Collections.Generic;

namespace PurchaseOrderBuilder
{
    public class FluentPOBuilder : IPurchaseOrderBuilder
    {
        private string _type;
        private DateTime _createdOn = DateTime.Now;
        private string _companyName;
        private string _address;
        private DateTime _requestedBy;
        private Vendor _vendor;
        private List<LineItem> _items;

        public FluentPOBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public FluentPOBuilder AtAddress(string address)
        {
            _address = address;
            return this;
        }

        public FluentPOBuilder ForCompany(string companyName)
        {
            _companyName = companyName;
            return this;
        }

        public FluentPOBuilder ForItems(List<LineItem> items)
        {
            _items = items;
            return this;
        }

        public FluentPOBuilder FromVendor(Vendor vendor)
        {
            _vendor = vendor;
            return this;
        }

        public FluentPOBuilder RequestedBy(DateTime date)
        {
            _requestedBy = date;
            return this;
        }

        public PurchaseOrder BuildPurchaseOrder()
        {
            return new PurchaseOrder(_type)
            {
                CompanyName = _companyName,
                CompanyAddress = _address,
                CreatedOn = _createdOn,
                RequestedBy = _requestedBy,
                Vendor = _vendor,
                Items = _items
            };
        }

        public static implicit operator PurchaseOrder(FluentPOBuilder pob)
        {
            return pob.BuildPurchaseOrder();
        }
    }
}
