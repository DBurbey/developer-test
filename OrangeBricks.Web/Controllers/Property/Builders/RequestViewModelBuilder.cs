using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class RequestViewViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public RequestViewViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public RequestViewViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new RequestViewViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName               
            };
        }
    }
}