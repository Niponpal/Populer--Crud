using AutoMapper;
using PMS.Models;

namespace PMS.ModelVm
{
    [AutoMap(typeof(SealesOwners), ReverseMap = true)]
    public class SealesOwnersVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
