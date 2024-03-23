using AutoMapper;
using PMS.Models;

namespace PMS.ModelVm
{
    [AutoMap(typeof(Contaact),ReverseMap = true)]
    public class ContactVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TextArea { get; set; }
    }
}
