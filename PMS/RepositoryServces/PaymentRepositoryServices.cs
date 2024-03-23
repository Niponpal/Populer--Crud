using AutoMapper;
using PMS.DataBase;
using PMS.Models;
using PMS.ModelVm;
using PMS.Services;

namespace PMS.RepositoryServces
{
    public class PaymentRepositoryServices : RepositoryServices<Payment, PaymentVm>,IPaymentRepositryServices
    {
        public PaymentRepositoryServices(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
    }
}
