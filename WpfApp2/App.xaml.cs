using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp2.Models;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<users> usersList = DbService.GetAllUsers();
        public static List<goods> goodList = DbService.GetAllGoods();
    }

}
