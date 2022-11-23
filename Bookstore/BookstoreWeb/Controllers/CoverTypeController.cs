using BookStore.DataAccess;
using BookstoreWeb.Models;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.DataAccess.Repository;
using BookStore.DataAccess.Repository.IRepository;

namespace BookstoreWeb.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoverTypeRepository _coverTypeRepository;

        public CoverTypeController(IUnitOfWork context)
        {
            _unitOfWork = context;
            _coverTypeRepository = _unitOfWork.CoverType;
        }

        public IActionResult Index()
        {
            return View(_coverTypeRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            if (_coverTypeRepository.GetFirstOrDefault(c => c.Name == coverType.Name) != null)
            {
                ModelState.AddModelError("uniquename", "Deze categorienaam bestaal al");
            }

            if (ModelState.IsValid)
            {
                _coverTypeRepository.Add(coverType);
                try
                {
                    _unitOfWork.Save();
                    TempData["result"] = "Categorie succesvol toegevoegd.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Er is een probleem met de database!";
                    return View(coverType);
                }
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CoverType coverType = _coverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        public IActionResult Edit(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                _coverTypeRepository.Update(coverType);
                try
                {
                    _unitOfWork.Save();
                    TempData["result"] = "Categorie succesvol gewijzigd.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Er is een probleem met de database!";
                    return View(coverType);
                }
                return RedirectToAction("Index");
            }
            return View(coverType);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CoverType coverType = _coverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(CoverType coverType)
        {
            _coverTypeRepository.Remove(coverType);
            try
            {
                _unitOfWork.Save();
                TempData["result"] = "Categorie succesvol verwijderd.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Er is een probleem met de database!";
                return View(coverType);
            }
            return RedirectToAction("Index");
        }
    }
}


