using Raporlama.Business.Dtos.CompanyDtos;
using Raporlama.Business.Dtos.ReportTypeDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Business.Dtos.ReportDtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReportTypeId { get; set; }
        public ReportTypeDto ReportType { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
