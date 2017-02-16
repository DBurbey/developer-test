namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class RequestViewCommand
    {
        public int PropertyId { get; set; }

        public string RequestViewDateTime { get; set; }

        public string UserId { get; set; }
    }
}