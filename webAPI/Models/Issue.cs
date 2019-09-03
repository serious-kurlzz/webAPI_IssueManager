using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public enum Status : byte
    {
        Open = 1,
        Developing = 2,
        Testing = 3,
        Closed = 4
    }

    public class Issue
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? PlanFinishingDate { get; set; }

        public DateTime? FactFinishingDate { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public string AssigneeId { get; set; }
    }
}
