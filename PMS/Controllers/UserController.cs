using Microsoft.AspNetCore.Mvc;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class UserController : Controller
{
    private readonly IUserRepositoryServices _services;

    public UserController(IUserRepositoryServices services)
    {
        _services = services;
    }


    public async Task<ActionResult<UserVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<UserVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new UserVm());
        }
        else
        {
            var entiiys = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<UserVm>> CreateOrEdit(int id, CancellationToken cancellationToken, UserVm userVm)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                var entiys = await _services.InsertAsync(id, userVm, cancellationToken);
                return Json(new { success = true, message = $"{userVm.UserName}'s Data added Successfuly" });

            }
        }
        else
        {
            await _services.UpdatedAsync(id, userVm, cancellationToken);
            return Json(new { success = true, message = $"{userVm.UserName}'s Data Updated Successfuly" });
        }
        return Json(new { success = false, message = $"{userVm.UserName}'s Data Updated Successfuly" });
    }

    public async Task<ActionResult<UserVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.GetByDeltedAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<UserVm>> Detials(int id, CancellationToken cancellationToken)
    {
        var enitys = await _services.GetByIdAsync(id, cancellationToken);
        return View(enitys);
    }
}
