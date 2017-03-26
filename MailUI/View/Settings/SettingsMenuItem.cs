using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MailUI.Model.Commands;
using MailUI.Model.MainMenu;
using MailUI.Utils.Languages;
using MailUI.ViewModel;
using Localization = MailUI.Utils.Languages.Localization;

namespace MailUI.View.Settings
{
    [Export(typeof(IMenuItem))]
    public class SettingsMenuItem : IMenuItem
    {
        private MainWindowViewModel _viewModel;
        private MainWindow _view;
        private BaseMetroDialog _settingsView;

        public void AttachMenu(MainWindowViewModel viewModel, MainWindow view)
        {
            _viewModel = viewModel;
            _view = view;
            var groupSettings = new MenuItemModel(
                header: "Base_Settings",
                icon: null,
                visible: true,
                toolTip: "Base_Settings",
                command: new CommandModel(VisibleSettings)
                );
            viewModel.MenuItems.Add(groupSettings);
        }

        private void VisibleSettings(object obj)
        {
            _settingsView = new MainWindowUserControls.Settings();
            MetroDialogSettings metroSettings = new MetroDialogSettings
            {
                AnimateShow = true,
                AnimateHide = true
            };
            _settingsView.Title = Localization.Get("Base_Settings").ToUpper();
            _view.ShowMetroDialogAsync(_settingsView, metroSettings);
        }
    }
}
