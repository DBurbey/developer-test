using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;
using System.Globalization;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class RequestViewCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RequestViewCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RequestViewCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var viewingRequest = new ViewingRequest 
            {                
                Status = ViewingRequestStatus.Pending,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ViewRequestDateTime = DateTime.ParseExact(command.RequestViewDateTime ,"d.M.yyyy HH:mm", CultureInfo.InvariantCulture),
                UserId = command.UserId 
            };

            if (property.ViewingRequests  == null)
            {
                property.ViewingRequests = new List<ViewingRequest>();
            }
                
            property.ViewingRequests.Add(viewingRequest);
            
            _context.SaveChanges();
        }
    }
}