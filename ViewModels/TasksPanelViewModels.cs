using ITAcademyDay.Model;
using ITAcademyDay.Models;
using ITAcademyDay.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ITAcademyDay.ViewModels
{
    public class TasksPanelViewModels
    {

        public ICommand CreateTaskCommand {get; set; }
        public ICommand DoneTasskCommand { get; set; }
        public ICommand RemoveTaskCommand { get; set; }

        public TasksPanelViewModels()
        {
            CreateTaskCommand = new SimpleCommand(CreateTask);
            DoneTasskCommand = new SimpleCommand<MTask>(DoneTassk);
            RemoveTaskCommand = new SimpleCommand<MTask>(RemoveTask);
        }

        private void DoneTassk(MTask obj)
        {
            obj.State = TaskState.Done;
            obj.finishedTime = DateTime.Now.ToString("dd/MM HH:mm");
            DataITAD.Instance.doneTasksCollection.Add(obj);
            DataITAD.Instance.tasksCollection.Remove(obj);

            DataITAD.Instance.tasksCollection.Remove(obj);

            foreach (KeyValuePair<Member, MTask> keyValuePair in DataITAD.Instance.MenagmentCollection)
            {
                if (keyValuePair.Value.Equals(obj))
                {
                    keyValuePair.Key.CountTask++;
                }
            }

        }


        private void RemoveTask(MTask obj)
        {
            DataITAD.Instance.tasksCollection.Remove(obj);

            foreach (KeyValuePair<Member, MTask> keyValuePair in DataITAD.Instance.MenagmentCollection)
            {
                if (keyValuePair.Value.Equals(obj)){
                    DataITAD.Instance.MenagmentCollection.Remove(keyValuePair);
                }
            }
        }


        private void CreateTask()
        {
            Window childWindow = new Window()
            {
                SizeToContent = SizeToContent.WidthAndHeight,
            };
            childWindow.Content = new AddTaskViewModel();
            childWindow.Show();
        }
    }
}
