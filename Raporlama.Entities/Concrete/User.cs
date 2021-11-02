using Raporlama.Entities.Abstracts.Interfaces;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Entities.Concrete
{
    public class User: BaseEntity,ITable
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
