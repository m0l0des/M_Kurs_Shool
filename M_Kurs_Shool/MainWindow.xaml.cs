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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M_Kurs_Shool
{
    public partial class Contract
    {
        // ссылка на картинку
        // по ТЗ, если картинка не найдена, то должна выводиться картинка по-умолчанию
        // в XAML-е можно это сделать средствами разметки, но там есть условие что вместо ссылки на картинку получен NULL
        // у нас же возможна ситуация, когда в базе есть путь к картинке, но самой картинки в каталоге нет
        // поэтому я сделал проверку наличия файла картинки и возвращаю картинку по-умолчанию, если нужной нет 
        public Uri ImagePreview
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Avatat ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/img/picture.png");
            }
        }
        public float DiscountFloat
        {
            get
            {
                return Convert.ToSingle(Summa ?? 0);
            }
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private List<Contract> _ContractList;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Contract> ContractList
        {
            get
            {
                var FilteredServiceList = _ContractList.FindAll(item =>
                item.DiscountFloat >= CurrentDiscountFilter.Item1 &&
              item.DiscountFloat < CurrentDiscountFilter.Item2);


                if (SortPriceAscending)
                    return FilteredServiceList.OrderBy(item => (item.Summa)).ToList();
                else
                    return FilteredServiceList.OrderByDescending(item => (item.Summa)).ToList();
            }
            set
            {
                _ContractList = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ContractList = Core.DB.Contract.ToList();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void OrdProvidClick(object sender, RoutedEventArgs e)
        {
            var ord = new window.Change();
            ord.ShowDialog();
        }

        private void SearchFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private Boolean _SortPriceAscending = true;
        public Boolean SortPriceAscending
        {
            get { return _SortPriceAscending; }
            set
            {
                _SortPriceAscending = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractList"));
                }

            }

        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortPriceAscending = (sender as RadioButton).Tag.ToString() == "1";
        }
        private string _SearchFilter = "";
        public string SearchFilter
        {
            get { return _SearchFilter; }
            set
            {
                _SearchFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractList"));

                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
        }
        private Tuple<float, float> _CurrentDiscountFilter = Tuple.Create(float.MinValue, float.MaxValue);

        public Tuple<float, float> CurrentDiscountFilter
        {
            get
            {
                return _CurrentDiscountFilter;
            }
            set
            {
                _CurrentDiscountFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("ContractList"));
                }
            }
        }

        public List<string> FilterByDiscountNamesList
        {
            get
            {
                return FilterByDiscountValuesList
                    .Select(item => item.Item1)
                    .ToList();
            }
        }

        private List<Tuple<string, float, float>> FilterByDiscountValuesList =
          new List<Tuple<string, float, float>>() {
        Tuple.Create("Все записи", 0f, 30000f),
        Tuple.Create("от 10000 до 12000", 10000f, 12000f),
        Tuple.Create("от 13000 до 15000", 13000f, 15000f),
        Tuple.Create("от 16000 до 17000", 16000f, 17000f),
        Tuple.Create("от 18000 до 20000", 18000f, 20000f)
    }; private void DiscountFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentDiscountFilter = Tuple.Create(
                FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item2,
                FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item3
            );
        }


    }

}