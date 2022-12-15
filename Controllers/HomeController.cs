using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tz.Models;

namespace tz.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoldersContext context;

        public HomeController(FoldersContext context)
        {
            this.context = context;
        }

        [Route("{*url}")]
        public IActionResult Index(string? url)
        {
            string path;
            Folder parentFolder;
            List<Folder> childFolders;

            if (url == null)
            {
                parentFolder = GetRootFolder();
                path = parentFolder.FolderName;
            }
            else
            {
                parentFolder = GetParentFolder(url);
                path = url;
            }

            childFolders = GetChildFolders(parentFolder);

            ViewBag.Path = path;
            ViewBag.ParentFolder = parentFolder;
            ViewBag.ChildFolders = childFolders;

            return View();
        }

        public IActionResult UploadFolder(string folderName, string path)
        {
            return View();
        }

        private Folder GetRootFolder()
        {
            Folder parentFolder = context.Folders.Find(HierarchyId.Parse("/"));

            return parentFolder;
        }

        private Folder GetParentFolder(string url)
        {
            string lastUrlPart = url.Split('/').Last();
            Folder parentFolder = context.Folders.First(f => f.FolderName == lastUrlPart);

            return parentFolder;
        }

        private List<Folder> GetChildFolders(Folder parentFolder)
        {
            List<Folder> childFolders = context.Folders
                .Where(f => f.FolderLevel.GetAncestor(1) == parentFolder.FolderLevel).ToList();

            return childFolders;
        }
    }
}