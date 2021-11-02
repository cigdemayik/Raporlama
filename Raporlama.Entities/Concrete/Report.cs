using Raporlama.Entities.Abstracts.Interfaces;
using Raporlama.Entities.Concrete.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Entities.Concrete
{
    public class Report:BaseEntity ,ITable
    {
        public int ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
