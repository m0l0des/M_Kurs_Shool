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
        
        // ссылка на картинку
        // по ТЗ, если картинка не найдена, то должна выводиться картинка по-умолчанию
        // в XAML-е можно это сделать средствами разметки, но там есть условие что вместо ссылки на картинку получен NULL
        // у нас же возможна ситуация, когда в базе есть путь к картинке, но самой картинки в каталоге нет
        // поэтому я сделал проверку наличия файла картинки и возвращаю картинку по-умолчанию, если нужной нет 
        public Uri ImagePre
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Img ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/img/picture.png");
            }
        }
    }
}
namespace M_Kurs_Shool.window
{

    /// <summary>
    /// Логика взаимодействия для order.xaml
    /// </summary>
    public partial class Change : Window, INotifyPropertyChanged
    {
        private List<Contract> _ChangeList;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Contract> ChangeList
        {
            get
            {
                return _ChangeList;
            }
            set
            {
                _ChangeList = value;
                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs("ChangeList"));
                }
            }
        }


        public Change()
        {
            InitializeComponent();
            this.DataContext = this;
            ChangeList = Core.DB.Contract.ToList();
        }
        private void DelOrd_Click(object sender, RoutedEventArgs e)
        {
            var item = ProductListView.SelectedItem as Contract;
            Core.DB.Contract.Remove(item);
            Core.DB.SaveChanges();
            ChangeList = Core.DB.Contract.ToList();
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            var SelectedService = ProductListView.SelectedItem as Contract;
            var EditServiceWindow = new window.Add (SelectedService);
            if ((bool)EditServiceWindow.ShowDialog())
            {
                // при успешном завершении не забываем перерисовать список услуг
                PropertyChanged(this, new PropertyChangedEventArgs("ChangeList"));
                // и еще счетчики - их добавьте сами
            }
        }
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            //  создаем новую услугу
            var NewService = new Contract();

            var NewServiceWindow = new Add (NewService);
            if ((bool)NewServiceWindow.ShowDialog())
            {
                //список услуг нужно перечитать с сервера
                ChangeList = Core.DB.Contract.ToList();

                PropertyChanged(this, new PropertyChangedEventArgs("ChangeList"));
            }
        }
    }
}

