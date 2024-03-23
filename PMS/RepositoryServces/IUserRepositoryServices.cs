using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces
{
    public interface IUserRepositoryServices:IRepositoryServices<User,UserVm>
    {
    }
}
