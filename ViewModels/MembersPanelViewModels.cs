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
    public class MembersPanelViewModels
    {
        public ICommand CreateMembersCommand { get; set; }
        public ICommand DeleteMemberCommand { get; set; }

        public MembersPanelViewModels()
        {
            CreateMembersCommand = new SimpleCommand(CreateMember);
            DeleteMemberCommand = new SimpleCommand<Member>(DeleteMember);
        }

        private void DeleteMember(Member obj)
        { 
                DataITAD.Instance.membersCollection.Remove(obj);

                foreach (KeyValuePair<Member, MTask> keyValuePair in DataITAD.Instance.MenagmentCollection)
                {
                    if (keyValuePair.Key.Equals(obj))
                    {
                        DataITAD.Instance.MenagmentCollection.Remove(keyValuePair);
                    }
                } 
        }

        private void CreateMember()
        {
            Window childWindow = new Window()
            {
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };
            childWindow.Content = new AddMemberViewModel();
            childWindow.ShowDialog();
        }
    }
}
