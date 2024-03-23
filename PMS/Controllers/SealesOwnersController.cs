using Microsoft.AspNetCore.Mvc;
using PMS.Models;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class SealesOwnersController : Controller
{
    private readonly ISealesOwnerRepositoryServices _services;

    public SealesOwnersController(ISealesOwnerRepositoryServices services)
    {
        _services = services;
    }


    public async Task<ActionResult<SealesOwnersVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<SealesOwnersVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new SealesOwnersVm());
        }
        else
        {
            var entiiys = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<SealesOwnersVm>> CreateOrEdit(int id, CancellationToken cancellationToken, SealesOwnersVm sealesOwnersVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var entiys = await _services.InsertAsync(id, sealesOwnersVm, cancellationToken);
                return Json(new { success = true, message = $"{sealesOwnersVm.Name}'s Data added Successfuly" });

            }
        }
        else
        {
            await _services.UpdatedAsync(id, sealesOwnersVm, cancellationToken);
            return Json(new { success = true, message = $"{sealesOwnersVm.Name}'s Data added Successfuly" });
        }
        return Json(new { success = true, message = $"{sealesOwnersVm.Name}'s Data added Successfuly" });
    }

    public async Task<ActionResult<SealesOwnersVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.GetByDeltedAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    public async Task<ActionResult<PaymentVm>> Detials(int id, CancellationToken cancellationToken)
    {
        var enitys = await _services.GetByIdAsync(id, cancellationToken);
        return View(enitys);
    }

}
