using ITAcademyDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademyDay.ViewModels
{
    public class ManagementPanelViewModel
    {
        public List<MTask> SelectedTasks { get; set; }
        public List<Member> SelectedMembers { get; set; }
    }
}
