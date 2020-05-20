using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Websites.Common;
using Websites.Data.Common;
using Websites.Data.Models;

namespace Websites.Data
{
    public class WebsiteRepository : DbRepository<Website, WebsitesDbContext>
    {
        public WebsiteRepository(WebsitesDbContext context) : base(context)
        {
        }

        public List<WebsiteModel> GetAll(int skip = 0, int take = 20, string name = "")
        {
            return this.All().Where(x => x.IsDeleted == false && x.Name.Contains(name))
                .Skip(skip)
                .Take(take)
                .OrderBy(x => x.Name)
                .Select(x => new WebsiteModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Url = x.Url,
                    Category = x.Category,
                    Login = new LoginModel
                    {
                        Email = x.LoginEmail,
                        Password = x.LoginPassword
                    }
                })
                .ToList();
        }

        public async Task<WebsiteModel> CreateOrUpdate(WebsiteModel model)
        {
            var websiteEntity = this.All().FirstOrDefault(w => w.Name == model.Name);
            if (websiteEntity != null)
            {
                websiteEntity.Url = model.Url;
                websiteEntity.Category = model.Category;
                websiteEntity.HomepageSnapshot = model.HomepageSnapshot;
                websiteEntity.LoginEmail = model.Login.Email;
                websiteEntity.LoginPassword = model.Login.Password;

                websiteEntity =  await this.Update(websiteEntity);
            } 
            else
            {
                var entity = new Website()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Category = model.Category,
                    LoginEmail = model.Login.Email,
                    LoginPassword = model.Login.Password,
                    HomepageSnapshot = model.HomepageSnapshot,
                    IsDeleted = false
                };

                websiteEntity = await this.Add(entity);
            }

            model.Id = websiteEntity.Id;

            return model;
        }

        public async Task<WebsiteModel> SoftDelete(int websiteId)
        {
            var websiteEntity = this.All().FirstOrDefault(w => w.Id == websiteId);
            if (websiteEntity != null)
            {
                websiteEntity.IsDeleted = true;

                websiteEntity = await this.Update(websiteEntity);

                return new WebsiteModel()
                {
                    Id = websiteEntity.Id,
                    Category = websiteEntity.Category,
                    Url = websiteEntity.Url,
                    Login = new LoginModel()
                    {
                        Email = websiteEntity.LoginEmail
                    },
                    IsDeleted = websiteEntity.IsDeleted
                };
            }

            return null;
        }
    }
}
