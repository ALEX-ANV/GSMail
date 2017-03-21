using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using MahApps.Metro.Controls.Dialogs;
using MailUI.Context;
using MailUI.Model;
using MailUI.Model.TabControlModels;
using MailUI.ViewModel;

namespace MailUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        //public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            dbContext = new UserContext();
            DataContext = new MainWindowViewModel();
        }

        private UserContext dbContext;

       

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
                var user = dbContext.Users.FirstOrDefault(item =>
                  string.Equals(item.UserName.ToLower(), /*loginData.Username*/"anv".ToLower())
                    && string.Equals(item.Password, /*loginData.Password*/"313"));
                if (user == null)
                {
                    await this.ShowMessageAsync("Ошибка", "Неправильный логин или пароль");
                    continue;
                }
                GlobalParameters.Date = DateTime.Now;
                GlobalParameters.UserName = user.UserName;
                break;
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            //var login = new AuthorizationControl();
            //login.Visibility = Visibility.Visible;

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
