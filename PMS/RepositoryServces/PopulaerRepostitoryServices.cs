using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces
{
    public class PopulaerRepostitoryServices : RepositoryServices<Popular, PopularVm>,IPopulerRepositoryServices
    {
        public PopulaerRepostitoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
