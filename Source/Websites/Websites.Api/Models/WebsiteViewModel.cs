using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Websites.Common;

namespace Websites.Api.Models
{
    public class WebsiteViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        public LoginViewModel Login { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
