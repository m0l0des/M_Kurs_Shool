using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M_Kurs_Shool
{
    public partial class Client
    {

        public string FullName
        {
            get
            {
                return FirstName + LastName + Patronymic;
            }
        }
    }
}
namespace M_Kurs_Shool.window
{

    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window, INotifyPropertyChanged
    {

        public List<Client> ClientList { get; set; }

        public Add(Contract contract)
        {
            InitializeComponent();
            this.DataContext = this;
            CurrentAdd = contract;
            ClientList = Core.DB.Client.ToList();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Contract CurrentAdd { get; set; }
        public string WindowName
        {
            get
            {
                return CurrentAdd.id == 0 ? "Новая услуга" : "Редоктирование улсгуи";
            }
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {



            {
                if (CurrentAdd.id == 0)
                    Core.DB.Contract.Add(CurrentAdd);


                try
                {
                    Core.DB.SaveChanges();
                }
                catch
                {
                }
                DialogResult = true;
            }



        }

        public string NewProduct
        {
            get
            {
                if (CurrentAdd.id == 0) return "collapsed";
                return "visible";



            }
        }
    }
}
