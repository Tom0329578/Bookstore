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
    }
}
