using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces;

public class AdminRepositoryServices : RepositoryServices<Admin, AdminVm>, IAdminRepositoryServices
{
    public AdminRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {
    }
}
