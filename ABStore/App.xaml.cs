using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ABStore.Domain.DefaultImplementations;
using ABStore.Domain.Interfaces;
using ABStore.EF.Repositories;
using Agregate.Enteties;
using Agregate.Repos;
using Ninject;

namespace ABStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;
        

        protected override void OnStartup(StartupEventArgs e)
        {
            

            
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<IUserRepo>().To<UserRepository>();
            container.Bind<IGameRepo>().To<GameRepository>();
            container.Bind<IBuyService>().To<BuyService>();
            container.Bind<IPriceCalculationStrategy>().To<DefaultCalculationStrategy>();
        }
        
        private void ComposeObjects()
        {

            Current.MainWindow = this.container.Get<MainWindow>();

            
            Current.MainWindow.Title = "ABStore";
         
        }
        
    }

    
}
