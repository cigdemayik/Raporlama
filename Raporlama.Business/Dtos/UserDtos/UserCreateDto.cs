using Raporlama.Business.Dtos.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raporlama.Business.Dtos.UserDtos
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
    }
}
