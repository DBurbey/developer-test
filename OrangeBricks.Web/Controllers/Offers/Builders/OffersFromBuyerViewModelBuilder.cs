using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersFromBuyerViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersFromBuyerViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersFromBuyerViewModel Build(string UserId)
        {
            var offers = _context.Offers
                .Where(p => p.UserId == UserId)
                .Include(x => x.Property).ToList();

            return new OffersFromBuyerViewModel()
            {
                Offers = offers.Select(x => new OfferFromBuyerViewModel()
                {
                     PropertyId = x.Property.Id, 
                     Amount = x.Amount,
                     Status = x.Status.ToString(),
                     CreatedAt  = x.CreatedAt,
                     StreetName = x.Property.StreetName,
                     PropertyType = x.Property.PropertyType,
                     NumberOfBedrooms = x.Property.NumberOfBedrooms
                }).ToList()
            };
        }
    }
}