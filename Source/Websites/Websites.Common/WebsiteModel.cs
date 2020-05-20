using System;
using System.Collections.Generic;
using System.Text;

namespace Websites.Common
{
    public class WebsiteModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public LoginModel Login { get; set; }

        public CategoryType Category { get; set; }

        public byte[] HomepageSnapshot { get; set; }

        public bool IsDeleted { get; set; }
    }
}
