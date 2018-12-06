using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademyDay.Models
{
    public class DataITAD
    { 
        public DataITAD()
        {
            membersCollection.Add(new Member()
            {
                Name = "Dima",
                Rank = "Test",
                CountTask = 0
            }); 
            membersCollection.Add(new Member()
            {
                Name = "Anna",
                Rank = "Test",
                CountTask = 0
            }); 
            membersCollection.Add(new Member()
            {
                Name = "Ivan",
                Rank = "Test",
                CountTask = 0
            });

            doneTasksCollection.Add(new MTask()
            {
                Name="Task1",
                Description="Test",
                digicult=4,
                finishedTime= "MMddHHmm"
            });

        }

        private static DataITAD s_instance; 
        public static DataITAD Instance {
            get{
                if (s_instance == null) { s_instance = new DataITAD(); }
                return s_instance;
            }
        }

        public ObservableCollection<Member> raportsCollection { set; get; } = new ObservableCollection<Member>();

        public ObservableCollection<Member> membersCollection { set; get; } = new ObservableCollection<Member>();
        public ObservableCollection<MTask> tasksCollection { set; get; } = new ObservableCollection<MTask>();

        public ObservableCollection<MTask> doneTasksCollection { set; get; } = new ObservableCollection<MTask>();

        public ObservableCollection<KeyValuePair<Member, MTask>> MenagmentCollection { set; get; } = new ObservableCollection<KeyValuePair< Member, MTask>>();




    }
}
