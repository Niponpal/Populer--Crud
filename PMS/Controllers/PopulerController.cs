using Microsoft.AspNetCore.Mvc;
using PMS.ModelVm;
using PMS.RepositoryServces;

namespace PMS.Controllers;

public class PopulerController : Controller
{
    private readonly IPopulerRepositoryServices _services;

    public PopulerController(IPopulerRepositoryServices services)
    {
        _services = services;
    }

    public async Task<ActionResult<PopularVm>> Index(CancellationToken cancellationToken)
    {
        return View(await _services.GetAllAsync(cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult<PopularVm>> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new PopularVm());
        }
        else
        {
            var entiiys = await _services.GetByIdAsync(id, cancellationToken);
            return View(entiiys);
        }
    }
    [HttpPost]
    public async Task<ActionResult<PopularVm>> CreateOrEdit(int id, CancellationToken cancellationToken, PopularVm popularVm, IFormFile photo, IFormFile photo2,IFormFile photo3)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                //Photos code stared
                if (photo != null && photo.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    
                    popularVm.Image1 = $"{photo.FileName}";
                }


                if (photo2 != null && photo2.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo2.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo2.CopyTo(stream);
                    }

                    popularVm.Image2 = $"{photo2.FileName}";
                }

                if (photo3 != null && photo3.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo3.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        photo3.CopyTo(stream);
                    }

                    popularVm.Image3 = $"{photo3.FileName}";
                }


                var entiys = await _services.InsertAsync(id, popularVm, cancellationToken);
                return Json(new { success = true, message = $"{popularVm.Name}'s Data added Successfuly" });

            }
        }
        else
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                popularVm.Image1 = $"{photo.FileName}";
            }

            if (photo2 != null && photo2.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo2.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo2.CopyTo(stream);
                }
                popularVm.Image2 = $"{photo2.FileName}";
            }


            if (photo3 != null && photo3.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", photo3.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    photo3.CopyTo(stream);
                }
                popularVm.Image3 = $"{photo3.FileName}";
            }

            await _services.UpdatedAsync(id, popularVm, cancellationToken);
            return Json(new { success = true, message = $"{popularVm.Name}'s Data added Successfuly" });
        }
        return Json(new { success = true, message = $"{popularVm.Name}'s Data added Successfuly" });
    }

    public async Task<ActionResult<PopularVm>> Delted(int id, CancellationToken cancellationToken)
    {
        if (id != 0)
        {
            await _services.GetByDeltedAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<ActionResult<PopularVm>> Detials(int id, CancellationToken cancellationToken)
    {
        var enitys = await _services.GetByIdAsync(id, cancellationToken);
        return View(enitys);
    }
}
