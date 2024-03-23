using AutoMapper;
using PMS.Models;

namespace PMS.ModelVm
{
    [AutoMap(typeof(User),ReverseMap = true)]
    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
