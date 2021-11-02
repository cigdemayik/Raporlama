using Raporlama.Entities.Abstracts.Interfaces;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Entities.Concrete
{
    public class ReportType: BaseEntity,ITable
    {
        public ICollection<Report> Reports { get; set; }
    }
}
