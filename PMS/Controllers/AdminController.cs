using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using PMS.Models;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class AdminController : Controller
{
    private readonly IAdminRepositoryServices _services;

    public AdminController(IAdminRepositoryServices services)
    {
        _services = services;
    }

    public async Task<ActionResult<AdminVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }
    [HttpGet]
    public async Task<ActionResult<AdminVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new AdminVm());
        }
        else
        {
            var entiys= await _services.GetByIdAsync(id,cancellationToken);
            return View(entiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<AdminVm>> CreateOrEdit(int id, CancellationToken cancellationToken,AdminVm adminVm)
    {
        if(id == 0)
        {
            if (ModelState.IsValid)
            {
                var entiys=await _services.InsertAsync(id,adminVm, cancellationToken);
                return Json(new { success = true, message = $"{adminVm.UserName}'s Data added Successfuly" });

            }
        }
        else
        {
            await _services.UpdatedAsync(id,adminVm, cancellationToken);
            return Json(new { success = true, message = $"{adminVm.UserName}'s Data Updated Successfuly" });
        }
        return Json(new { success = true, message = $"{adminVm.UserName}'s Data Not Added Successfuly" });
    }

    public async Task<ActionResult<AdminVm>>Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.GetByDeltedAsync(id,cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<AdminVm>> Details(int id,CancellationToken cancellationToken)
    {
        var enitys= await _services.GetByIdAsync(id, cancellationToken);
        return View(enitys);
    }
}
