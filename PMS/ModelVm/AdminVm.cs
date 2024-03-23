using AutoMapper;
using PMS.Models;

namespace PMS.ModelVm;

[AutoMap(typeof(Admin),ReverseMap = true)]
public class AdminVm
{
    
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
