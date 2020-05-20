using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Websites.Common;
using Websites.Data.Common;

namespace Websites.Data.Models
{
    public class Website : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(128)]
        public string LoginEmail { get; set; }

        [Required]
        public string LoginPassword { get; set; }

        [NotMapped]
        public CategoryType Category
        {
            get
            {
                return (CategoryType)CategoryId;
            }
            set
            {
                CategoryId = (int)value;
            }
        }

        [Required]
        public byte[] HomepageSnapshot { get; set; }

        public bool IsDeleted { get; set; }
    }
}
