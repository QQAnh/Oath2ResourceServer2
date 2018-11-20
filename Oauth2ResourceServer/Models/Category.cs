using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oauth2ResourceServer.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CategoryStatus Status { get; set; }

        public IEnumerable<Song> Songs { get; set; }

        public Category()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = CategoryStatus.Available;
        }
    }

    public enum CategoryStatus
    {
        Available = 1,
        Deleted = 0
    }
}
