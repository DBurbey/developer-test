using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class ViewingRequest
    {
        [Key]
        public int Id { get; set; }

        public Property Property { get; set; }

        public string UserId { get; set; }

        public DateTime ViewRequestDateTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ViewingRequestStatus Status { get; set; }
    }
}