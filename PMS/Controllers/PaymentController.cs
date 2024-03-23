using Microsoft.AspNetCore.Mvc;
using PMS.Models;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class PaymentController : Controller
{
    private readonly IPaymentRepositryServices _paymentRepositryServices;

    public PaymentController(IPaymentRepositryServices paymentRepositryServices)
    {
        _paymentRepositryServices = paymentRepositryServices;
    }


    public async Task<ActionResult<PaymentVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _paymentRepositryServices.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<PaymentVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new PaymentVm());
        }
        else
        {
            var entiiys = await _paymentRepositryServices.GetByIdAsync(id, cancellationToken);
            return View (entiiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<PaymentVm>> CreateOrEdit(int id, CancellationToken cancellationToken, PaymentVm paymentVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var entiys = await _paymentRepositryServices.InsertAsync(id, paymentVm, cancellationToken);
                return Json(new { success = true, message = $"{paymentVm.Email}'s Data added Successfuly" });

            }
        }
        else
        {
            await _paymentRepositryServices.UpdatedAsync(id, paymentVm, cancellationToken);
            return Json(new { success = true, message = $"{paymentVm.Email}'s Data Update Successfuly" });
        }
        return Json(new { success = true, message = $"{paymentVm.Email}'s Data Not Added Successfuly" });
    }

    public async Task<ActionResult<PaymentVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _paymentRepositryServices.GetByDeltedAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<PaymentVm>> Detials(int id, CancellationToken cancellationToken)
    {
        var enitys = await _paymentRepositryServices.GetByIdAsync(id, cancellationToken);
        return View (enitys);
    }
}
