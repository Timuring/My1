using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_POSUDA.Classes;
using WPF_POSUDA.Models;

namespace WPF_POSUDA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User20is11Context context { get; } = new User20is11Context();
    }
}
