using System;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class OffersFromBuyerViewModel
    {
        public List<OfferFromBuyerViewModel> Offers;
    }
    public class OfferFromBuyerViewModel
    {
        public int PropertyId { get; set;  }
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public bool HasOffers { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
}