using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces
{
    public class SealesOwnersRepositoryServices : RepositoryServices<SealesOwners, SealesOwnersVm>,ISealesOwnerRepositoryServices
    {
        public SealesOwnersRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
