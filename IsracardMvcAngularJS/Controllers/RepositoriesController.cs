using IsracardMvcAngularJS.Core.interfaces;
using IsracardMvcAngularJS.Core.models;
using System.Web.Mvc;

namespace IsracardMvcAngularJS.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoryService _repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Repository()
        {
            return View();
        }

        public ActionResult BookmarkedRepos()
        {
            return View();
        }

        // should be in webapi controllers
        [HttpPost]
        public ActionResult SetBookmarkRepository(Repository repository)
        {
            _repositoryService.BookmarkRepository(repository);

            return Json(new { bookmarkredRepos = _repositoryService.GetBookmarkedRepositories() });
        }

        [HttpPost]
        public ActionResult GetBookmarkedRepositories()
        {
            return Json(new { bookmarkredRepos = _repositoryService.GetBookmarkedRepositories() });
        }
    }
}