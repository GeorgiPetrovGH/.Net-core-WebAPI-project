using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Websites.Api.Models;
using Websites.Api.Tools;
using Websites.Common;
using Websites.Data;

namespace Websites.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebsiteController : ControllerBase
    {
        private readonly WebsiteRepository websiteRepository;

        public WebsiteController(WebsiteRepository websiteRepository)
        {
            this.websiteRepository = websiteRepository;
        }

        [HttpGet]
        public IEnumerable<WebsiteModel> List(int skip = 0, int take = 20)
        {
            var websites = this.websiteRepository.GetAll(skip, take);            

            return websites;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromForm]WebsiteViewModel input)
        {
            var model = new WebsiteModel()
            {
                Name = input.Name,
                Url = input.Url,
                Category = input.Category,
                Login = new LoginModel()
                {
                    Email = input.Login.Email,
                    Password = HashPassword.GetHashedPassword(input.Login.Password),
                },                
                IsDeleted = false,
                HomepageSnapshot = ImageToByteArray(input.Image)
            };

            var record = await this.websiteRepository.CreateOrUpdate(model);

            return Ok(record);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]int websiteId)
        {
            var record = await this.websiteRepository.SoftDelete(websiteId);
            if (record != null)
            {
                return Ok(record);
            }

            return BadRequest("Not valid entity");
        }

        private byte[] ImageToByteArray(IFormFile image)
        {            
            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                var fileBytes = ms.ToArray();

                return fileBytes;
            }
        }

    }
}
