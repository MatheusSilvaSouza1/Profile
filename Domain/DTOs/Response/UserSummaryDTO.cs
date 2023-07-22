using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class UserSummaryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string MotherName { get; set; }
        public LoginSummaryDTO Login { get; set; }
        public IReadOnlyCollection<AddressSummaryDTO> Addresses { get; set; }
    }
}