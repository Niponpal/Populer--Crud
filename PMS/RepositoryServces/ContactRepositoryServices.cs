using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces;

public class ContactRepositoryServices : RepositoryServices<Contaact, ContactVm>, IContactRepositoryServices
{
    public ContactRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
    {
    }
}
