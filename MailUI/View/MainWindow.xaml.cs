using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using MahApps.Metro.Controls.Dialogs;
using MailUI.Context;
using MailUI.Model;

namespace MailUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new UserContext();

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

                var loginData = await this.ShowLoginAsync("Авторизация", "", dialog);
                if (loginData == null)
                {
                    Environment.Exit(0);
                }
                var user = dbContext.Users.FirstOrDefault(item =>
                  string.Equals(item.UserName.ToLower(), loginData.Username.ToLower())
                    && string.Equals(item.Password, loginData.Password));
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

        private async void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            //var login = new AuthorizationControl();
            //login.Visibility = Visibility.Visible;

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Autorization();
        }
    }
}
