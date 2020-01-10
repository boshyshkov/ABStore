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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        
        IGameRepo _gameRepo;
        IUserRepo _userRepo;
        IBuyService _buyService;
        IPriceCalculationStrategy _calcStrat;
       
        public SignUpWindow(IGameRepo gameRepo, IUserRepo userRepo, IBuyService buyService, IPriceCalculationStrategy calcStrat)
        {
            //foreach (var usr in _userRepo.getAllUsers())
            //{
            //    Console.WriteLine(usr.Id.ToString());

            //}
            this._gameRepo = gameRepo;
            this._userRepo = userRepo;
            this._buyService = buyService;
            this._calcStrat = calcStrat;
            InitializeComponent();
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User usr = new User();
            bool isUsed = false;
            List<User> allUsers = _userRepo.getAllUsers();
            usr.Login = LoginBox.Text;
            usr.Password = _PasswordBox.Password;
            foreach(var usrs in allUsers)
            {
                if(usr.Login == usrs.Login)
                {
                    
                    LoginBox.Clear();
                    _PasswordBox.Clear();
                    isUsed = true;
                }
            }
            if (isUsed)
            {
                MessageBox.Show("This login is already used");
            }
            else
            {
                _userRepo.RegisterUser(usr);
                _buyService.BuyGame(_gameRepo.FindByFullName("CSGO"), usr);
                new LibraryPage(_gameRepo, _userRepo, _buyService, _calcStrat,null,usr).Show();
                this.Hide();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}
