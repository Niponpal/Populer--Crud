using Microsoft.AspNetCore.Mvc;
using PMS.Models;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepositoryServices _contactRepositoryServices;

    public ContactController(IContactRepositoryServices contactRepositoryServices)
    {
        _contactRepositoryServices = contactRepositoryServices;
    }

    public async Task<ActionResult<ContactVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _contactRepositoryServices.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<ContactVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new ContactVm());
        }
        else
        {
            var entiiys= await _contactRepositoryServices.GetByIdAsync(id, cancellationToken);
            return View (entiiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<ContactVm>> CreateOrEdit(int id, CancellationToken cancellationToken, ContactVm contactVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var entiys = await _contactRepositoryServices.InsertAsync(id, contactVm, cancellationToken);
                return Json(new { success = true, message = $"{contactVm.Name}'s Data added Successfuly" });

            }
        }
        else
        {
            await _contactRepositoryServices.UpdatedAsync(id, contactVm, cancellationToken);
            return Json(new { success = true, message = $"{contactVm.Name}'s Data added Successfuly" });
        }
        return Json(new { success = true, message = $"{contactVm.Name}'s Data added Successfuly" });
    }

    public async Task<ActionResult<ContactVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _contactRepositoryServices.GetByDeltedAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<ContactVm>> Detials(int id, CancellationToken cancellationToken)
    {
        var enitys = await _contactRepositoryServices.GetByIdAsync(id, cancellationToken);
        return View (enitys);
    }
}
