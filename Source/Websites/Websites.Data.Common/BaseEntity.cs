using System;
using System.Collections.Generic;
using System.Text;

namespace Websites.Data.Common
{
    public interface BaseEntity
    {
        int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
