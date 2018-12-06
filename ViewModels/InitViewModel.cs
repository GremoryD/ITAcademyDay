using ITAcademyDay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ITAcademyDay.ViewModels
{
    public class InitViewModel
    {

        public String imageBinding { set; get; }
        public ICommand NextWindowCommand { get; set; }

        public InitViewModel()
        {
            imageBinding = "/ITAcademyDay;component/Img/1.png";
            NextWindowCommand = new SimpleCommand(NextWindow);
        }

        private void NextWindow()
        {
            imageBinding = "/ITAcademyDay;component/Img/2.png";
        }
    }
}
