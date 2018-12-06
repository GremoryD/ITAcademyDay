using ITAcademyDay.Model;
using ITAcademyDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ITAcademyDay.ViewModels
{
    class AddMemberViewModel
    {
        public String MemberName { set; get; }
        public String MemberRank { set; get; }


        public ICommand AddMemberCommand { get; set; }

        public AddMemberViewModel()
        {
            AddMemberCommand = new SimpleCommand<Window>(AddMembeer);
        }

        private void AddMembeer(Window obj)
        {
            DataITAD.Instance.membersCollection.Add(new Member() { Name = MemberName, Rank = MemberRank, Workload = 0 });
            obj.Close();
        }
    }
}
