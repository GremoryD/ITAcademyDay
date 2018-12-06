using ITAcademyDay.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITAcademyDay.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public object CurrentPanel { get; set; }

        public MembersPanelViewModels MembersPanel { get; set; }
        public TasksPanelViewModels TasksPanel { get; set; }
        public InitViewModel InitPanel { get; set; }
        public ManagementPanelViewModel ManagmentPanel { get; set; }
        public FinishedTaskViewModel finishedTaskView { get; set; }
        public RankingViewModel rankingViewModel { get; set; }

        public MainViewModel()
        {
            SwitchCommand = new SimpleCommand<string>(Switch);
            InitPanel = new InitViewModel(); 
            MembersPanel = new MembersPanelViewModels();
            TasksPanel = new TasksPanelViewModels();
            ManagmentPanel = new ManagementPanelViewModel();
            rankingViewModel = new RankingViewModel();
            finishedTaskView = new FinishedTaskViewModel();

            CurrentPanel = InitPanel;
            Notify("CurrentPanel");
        }

        private void Switch(string obj)
        {
            switch (int.Parse(obj))
            {
                case 0:
                    CurrentPanel = MembersPanel;
                    break;
                case 1:
                    CurrentPanel = TasksPanel;
                    break;
                case 2:
                    CurrentPanel = ManagmentPanel;
                    break;
                case 3:
                    CurrentPanel = finishedTaskView;
                    break;
                case 4:
                    CurrentPanel = rankingViewModel;
                    break;
            }
            Notify("CurrentPanel");
        }

        public ICommand SwitchCommand { get; set; }

        

        public event PropertyChangedEventHandler PropertyChanged;
        private void  Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
