using ABStore.Domain.Interfaces;
using Agregate.Enteties;
using Agregate.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ABStore
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Window
    {
        Game selectedGame = new Game();
        User LibraryUser;
        IGameRepo _gameRepo;
        IUserRepo _userRepo;
        IBuyService _buyService;
        IPriceCalculationStrategy _calcStrat;
        StorePage stp;
        ObservableCollection<Game> userLib;
        
        public LibraryPage(IGameRepo gameRepo, IUserRepo userRepo, IBuyService buyService, IPriceCalculationStrategy calcStrat,StorePage sp, User ActiveUser)
        {
           
            this._gameRepo = gameRepo;
            this._userRepo = userRepo;
            this._buyService = buyService;
            this._calcStrat = calcStrat;
            this.LibraryUser = ActiveUser;
            if (sp == null)
            {
                stp = new StorePage(_gameRepo, _userRepo, _buyService, _calcStrat, this,this.LibraryUser);
            }
            else
            {
                stp = sp;
            }

            InitializeComponent();
            if (userLib == null)
            {
                userLib = new ObservableCollection<Game>();
            }
            //this.LibraryUser.UserLibrary.Clear();
            //_userRepo.UpdateUser(this.LibraryUser);
            //foreach(var libItm in _userRepo.getUserByLogin(this.LibraryUser.Login).UserLibrary)
            //{
            //    if (_gameRepo.FindById(libItm.GameId) == _gameRepo.FindByFullName("CSGO"))
            //    {

            //    }
            //    else
            //    {
            //         _buyService.BuyGame(_gameRepo.FindByFullName("CSGO"), this.LibraryUser);
            //    }
            //}


            userLib.Clear();
            foreach(var libItm in userRepo.getUsrDetails(LibraryUser.Id).UserLibrary)
            {
                userLib.Add(_gameRepo.FindById(libItm.GameId));
            }

            LibraryLIst.Items.Clear();
            LibraryLIst.ItemsSource = userLib;
            
            //foreach (var itm in _userRepo.getUsrDetails(LibraryUser.Id).UserLibrary)
            //{
            //    int i = 0;

               
            //    LibraryLIst.Resources.Add(i, _gameRepo.FindById(itm.GameId).Name);
            //    i++;

            //}
            
        
           
           
        }
        public void showLib()
        {
            if (userLib == null)
            {
                userLib = new ObservableCollection<Game>();
            }
            //this.LibraryUser.UserLibrary.Clear();
            //_userRepo.UpdateUser(this.LibraryUser);
            //foreach(var libItm in _userRepo.getUserByLogin(this.LibraryUser.Login).UserLibrary)
            //{
            //    if (_gameRepo.FindById(libItm.GameId) == _gameRepo.FindByFullName("CSGO"))
            //    {

            //    }
            //    else
            //    {
            //         _buyService.BuyGame(_gameRepo.FindByFullName("CSGO"), this.LibraryUser);
            //    }
            //}


            userLib.Clear();
            foreach (var libItm in _userRepo.getUsrDetails(LibraryUser.Id).UserLibrary)
            {
                userLib.Add(_gameRepo.FindById(libItm.GameId));
            }

            //LibraryLIst.Items.Clear();
            LibraryLIst.ItemsSource = userLib;
        }
        private void Library_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            stp.Show();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                
            }
        }

        private void LibraryLIst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LibraryOneTap(object sender, EventArgs e)
        {
            //ImageSource src = new ImageSource()
            
            int selected_index = LibraryLIst.SelectedIndex + 1;
            selectedGame = LibraryLIst.CurrentCell.Item as Game;
            string Name = selectedGame.Name;
            NameLabel.Content = Name;
            DescriptionLabel.Content = Name + " Description";
            string PublisherName = _gameRepo.FindByFullName(Name).PublisherName;
            PublisherLabel.Content = PublisherName;
            //GameImage.Source = "D:\\2 курс\\Proga ABStore\\" + Name + "_Image.jpg";
           // GameImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/ABStore;component/"+ Name + "_image.jpg"));
        }
    }
}
