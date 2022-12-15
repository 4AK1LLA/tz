using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace tz.Models
{
    public class Folder
    {
        [Key]
        public HierarchyId FolderLevel { get; set; }
        public string FolderName { get; set; }
    }
}
