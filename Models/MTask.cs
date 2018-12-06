using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademyDay.Models
{
    public enum TaskState { Done,InProcess}
    public class MTask : IHighlighted, INotifyPropertyChanged
    {


        private int _digicult;
        private bool _isHighligted = false;
        public TaskState State { set; get; } = TaskState.InProcess;
        public String Name { set; get; }
        public String finishedTime { set; get; }
        public String Description { set; get; }

        public int Prioriti { get => _digicult; set { if (value > 0) _digicult = value; } }
        public int digicult { get => _digicult; set { if (value > 0) _digicult = value; } }

        private bool _isInnerChange = false;
        public bool IsHighligted
        {
            get => _isHighligted;
            set
            {
                _isHighligted = value;
                if (!_isInnerChange)
                {
                    foreach (var pair in DataITAD.Instance.MenagmentCollection.Where(p => p.Value == this))
                        pair.Key.InnerSelection(value);
                }
                Notify("IsHighligted");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InnerSelection(bool value)
        {
            _isInnerChange = true;
            IsHighligted = value;
            _isInnerChange = false;
        }
    }
}
