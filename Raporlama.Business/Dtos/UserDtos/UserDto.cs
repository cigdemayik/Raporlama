using Raporlama.Business.Dtos.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Business.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
