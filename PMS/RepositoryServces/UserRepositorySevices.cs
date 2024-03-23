using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces
{
    public class UserRepositorySevices : RepositoryServices<User, UserVm>,IUserRepositoryServices
    {
        public UserRepositorySevices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
