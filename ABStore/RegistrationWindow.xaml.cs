using ABStore.Domain.Interfaces;
using Agregate.Enteties;
using Agregate.Repos;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    
    public partial class RegistrationWindow : Window
    {
        User ActiveUser;
        Window nextWindow;
        IGameRepo _gameRepo;
        IUserRepo _userRepo;
        IBuyService _buyService;
        IPriceCalculationStrategy _calcStrat;
        public RegistrationWindow(IGameRepo gameRepo, IUserRepo userRepo, IBuyService buyService, IPriceCalculationStrategy calcStrat)
        {
            this._gameRepo = gameRepo;
            this._userRepo = userRepo;
            this._buyService = buyService;
            this._calcStrat = calcStrat;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool TrueType = false;
           foreach(var usr in _userRepo.getAllUsers())
            {
                if (LoginBox.Text == usr.Login && PasswordBox.Password == usr.Password)
                {
                    ActiveUser = _userRepo.getUserByLogin(LoginBox.Text);
                    new LibraryPage(_gameRepo, _userRepo, _buyService, _calcStrat, null, ActiveUser).Show();
                    //nextWindow.Show();
                    TrueType = true;
                }
                
            }
            if (!TrueType)
            {
                MessageBox.Show("Invalid login or password");
                LoginBox.Clear();
                PasswordBox.Clear();
            }
           
                this.Hide();
        }
    }
}
