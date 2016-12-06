using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ComboBoxBugDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<string> Foods { get; set; } = new ObservableCollection<string>() { "Pizza", "Ice Cream", "Soup" };

        private string _favoriteFood;
        public string FavoriteFood
        {
            get { return _favoriteFood; }
            set
            {
                _favoriteFood = value;
                switch (_favoriteFood)
                {
                    case "Pizza":
                        _flavours = new ObservableCollection<string>(PizzaToppings);
                        break;
                    case "Ice Cream":
                        _flavours = new ObservableCollection<string>(IceCreamFlavours);
                        break;
                    case "Soup":
                        _flavours = new ObservableCollection<string>(SoupFlavours);
                        break;
                    default:
                        _flavours = new ObservableCollection<string>();
                        break;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FavoriteFood"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flavours"));
            }
        }

        public List<string> PizzaToppings { get; set; } = new List<string>() { "Margarita", "Pepperoni", "Meat Feast" };
        public List<string> IceCreamFlavours { get; set; } = new List<string>() { "Vanilla", "Strawberry", "Chocolate" };
        public List<string> SoupFlavours { get; set; } = new List<string>() { "Tomato", "Leek and Potato", "Chicken" };

        private ObservableCollection<string> _flavours = null;
        public ObservableCollection<string> Flavours
        {
            get
            {
                return _flavours;
            }
            set
            {
                _flavours = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Flavours"));
            }
        }
        public string FavoriteFlavour { get; set; }

    }
}
