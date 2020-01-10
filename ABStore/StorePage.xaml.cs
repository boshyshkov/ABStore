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
    /// Interaction logic for StorePage.xaml
    /// </summary>
    public partial class StorePage : Window
    {

        IGameRepo _gameRepo;
        IUserRepo _userRepo;
        IBuyService _buyService;
        IPriceCalculationStrategy _calcStrat;
        LibraryPage libp;
        ObservableCollection<Game> storeList;
        User storeUser;
        Game selectedGame = new Game();
        bool isOne=false;
        public StorePage(IGameRepo gameRepo, IUserRepo userRepo, IBuyService buyService, IPriceCalculationStrategy calcStrat,LibraryPage lp,User usr)
        {
            libp = lp;
            this._gameRepo = gameRepo;
            this._userRepo = userRepo;
            this._buyService = buyService;
            this._calcStrat = calcStrat;
            storeUser = usr;

            InitializeComponent();
            if (storeList == null)
            {
                storeList = new ObservableCollection<Game>();
            }
            //storeList = new ObservableCollection<Game> {
            //    new Game{Name=" "}
            //};


            List<string> names = new List<string>();
            storeList.Clear();
            foreach (var game in _gameRepo.getAllGames())
            {
                if (!names.Contains(game.Name))
                {
                    names.Add(game.Name);

                    storeList.Add(game);
                }
            }

            StoreLIst.Items.Clear();
            StoreLIst.ItemsSource = storeList;
        }

        private void Library_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
            libp.Show();
            libp.showLib();
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                foreach (var itm in _userRepo.getUsrDetails(1).UserLibrary)
                {
                   StoreLIst.Items.Add(itm);
                }
            }
        }

        private void GamePlayButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            _buyService.BuyGame(_gameRepo.FindByFullName(selectedGame.Name),storeUser);
        }

        private void StoreOneTap(object sender, EventArgs e)
        {
            if (isOne == false)
            {
                isOne = true;
                selectedGame = StoreLIst.CurrentCell.Item as Game;
                string Name = selectedGame.Name;
                GameLabel.Text = Name;
                //DescriptionLabel.Content = Name + " Description";
                string PublisherName = _gameRepo.FindByFullName(Name).PublisherName;
                PublisherLabel.Text = PublisherName;
            }
        }

       
    }
}
