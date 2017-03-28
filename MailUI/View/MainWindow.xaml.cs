using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MailUI.Model;
using MailUI.Model.MainMenu;
using MailUI.ViewModel;
using MySqlCon.Context;

namespace MailUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        [ImportMany(typeof(IMenuItem))]
        private IEnumerable<IMenuItem> MenuItemCollections { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new EmployeeContext();
            DataContext = new MainWindowViewModel();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var menuItem in MenuItemCollections)
            {
                menuItem.AttachMenu(this.DataContext as MainWindowViewModel, this);
            }
        }

        private EmployeeContext _dbContext;

        public static BaseModel GlobalParameters = new BaseModel();

        public async void Autorization()
        {
            while (true)
            {
                var dialog = new LoginDialogSettings
                {
                    AnimateShow = true,
                    AnimateHide = true,
                    ColorScheme = MetroDialogColorScheme.Theme,
                    AffirmativeButtonText = "Войти",
                    NegativeButtonVisibility = Visibility.Visible,
                    NegativeButtonText = "Отмена",
                    UsernameWatermark = "Логин...",
                    PasswordWatermark = "Пароль...",

                };

                //var loginData = await this.ShowLoginAsync("Авторизация", "", dialog);
                //if (loginData == null)
                //{
                //    Environment.Exit(0);
                //}
                var user = _dbContext.Employees.FirstOrDefault(item =>
                  string.Equals(item.CompanyName.ToLower(), /*loginData.Username*/"anv".ToLower())
                    && string.Equals(item.Password, /*loginData.Password*/"313"));
                if (user == null)
                {
                    await this.ShowMessageAsync("Ошибка", "Неправильный логин или пароль");
                    continue;
                }
                GlobalParameters.Date = DateTime.Now;
                GlobalParameters.UserName = user.CompanyName;
                break;
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Autorization();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
