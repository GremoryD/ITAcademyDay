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
    class AddTaskViewModel
    {
        public String TaskName { set; get; }
        public String TaskDescription { set; get; }
        public int Dificult
        {
            set;
            get;
        } = 1;
        public Member Executor { set; get; }

        public ICommand AddTaskCommand { get; set; } 

        public AddTaskViewModel()
        {
            AddTaskCommand = new SimpleCommand<Window>(AddTask); 
        }

        private void AddTask(Window obj)
        {
            if(Executor.Workload + Dificult < 10) { 
                MTask mTask = new MTask()
                {
                    Name = TaskName, 
                    Description = TaskDescription,
                    digicult = Dificult
                };
                Executor.Workload += Dificult;
                DataITAD.Instance.tasksCollection.Add(mTask);

                DataITAD.Instance.MenagmentCollection.Add(new KeyValuePair<Member, MTask>(Executor, mTask));
                obj.Close();
            }
            else
            {
                MessageBoxResult errormsg = MessageBox.Show(Executor.Name + " is to workloaded","OK",MessageBoxButton.OK);
            }
        }
    }
}
