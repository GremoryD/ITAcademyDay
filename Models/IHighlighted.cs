using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAcademyDay.Models
{
    public interface IHighlighted
    {
        bool IsHighligted { get; set; }
        void InnerSelection(bool value);
    }
}
