using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? PlanFinishingDate { get; set; }

        public DateTime? FactFinishingDate { get; set; }

        public string AuthorId { get; set; }

        public string AssigneeId { get; set; }
    }
}
