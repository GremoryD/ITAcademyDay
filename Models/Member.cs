using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademyDay.Models
{
    public class Member : IHighlighted, INotifyPropertyChanged
    {
        private int _workload;
        private bool _isHighligted = false;

        public string Name { set; get; }
        public string Rank { set; get; }
        public int Workload { get => _workload; set { if (value >= 0 && value <= 10) _workload = value; } }
        public int CountTask { set; get; } 

        private bool _isInnerChange = false;
        public bool IsHighligted
        {
            get => _isHighligted;
            set
            {
                _isHighligted = value;

                _isHighligted = value;
                if (!_isInnerChange)
                {
                    foreach (var pair in DataITAD.Instance.MenagmentCollection.Where(p => p.Key == this))
                        pair.Value.InnerSelection(value);
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

        public override string ToString()
        {
            return $"{Name} :{Rank}[{Workload}] ";
        }
    }
}
