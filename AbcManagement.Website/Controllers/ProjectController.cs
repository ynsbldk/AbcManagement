using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AbcManagement.Business.Service;
using AbcManagement.Entities.Entities;
using AbcManagement.Entities.IService;
using AbcManagement.Website.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace AbcManagement.Website.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public ProjectController(IProjectService projectService, ICategoryService categoryService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._mapper = mapper;
            this._projectService = projectService;
            this._userManager = userManager;
            this._categoryService = categoryService;
        }

        // GET: ProjectController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("getallproject")]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAllProject()
        {
            var projects = await _projectService.GetAllWithProject();

            var projectResources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectModel>>(projects);

            UserProject model = new UserProject
            {
                myProject = projectResources,
                myUser = await _projectService.GetProjectUser()
            };

            return View(model);
        }

        [HttpGet("createproject")]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost("createproject")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProject(ProjectModel projectModel)
        {
            var projectToCreate = _mapper.Map<ProjectModel, Project>(projectModel);
            projectToCreate.AppUser = await GetCurrentUserAsync();
            await _projectService.CreateProject(projectToCreate);

            return View();
        }

        [HttpGet("createcategory")]
        public ActionResult CreateCategory()
        {
            var list = _projectService.GetProjectList();
            ViewBag.project = list.Result.ToList().Select(x => x);
            return View();
        }

        [HttpPost("createcategory")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory(CategoryModel categoryModel)
        {
            var list = _projectService.GetProjectList();

            ViewBag.project = list.Result.ToList().Select(x => x);

            var categoryToCreate = _mapper.Map<CategoryModel, Category>(categoryModel);

            categoryToCreate.AppUser = await GetCurrentUserAsync();

            var project = await _projectService.GetProjectById(categoryModel.ProjectId);
            await _projectService.UpdateProject(project, categoryModel.Project);

            await _categoryService.CreateCategory(categoryToCreate);

            return View();

        }

    }
}
