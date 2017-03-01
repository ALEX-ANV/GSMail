using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using MailUI.Model;
using MailUI.Model.ManagmentFiles;
using MailUI.View;

namespace MailUI.ViewModel.ManagmentViewModels
{
    public class CtViewModel : BaseViewModel
    {
        //BaseModel GlobalParameters { get; set; }

        public CtViewModel(string[] pattern)
        {
            MainWindow.GlobalParameters.PropertyChanged += UpdateGlobalParameters;
            CtFileSettings = new CtFile();
            Content = pattern.Aggregate("", (current, item) => $"{current}\n{item}");
        }

        private void UpdateGlobalParameters(object sender, PropertyChangedEventArgs e)
        {
            var value = sender as BaseModel;
            if (value == null)
            {
                return;
            }
            if (e.PropertyName == nameof(CtFileSettings.UserName) && value.UserName != null)
            {
                CtFileSettings.UserName = value.UserName;
            }
            if (e.PropertyName == nameof(CtFileSettings.Date))
            {
                CtFileSettings.Date = value.Date;
            }
            Content = CtFileSettings.FormatString(Content, CtFileSettings.GetValues<CtFile>());
        }


        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private CtFile _ctFileSettings;

        public CtFile CtFileSettings
        {
            get { return _ctFileSettings; }
            set
            {
                _ctFileSettings = value;
                OnPropertyChanged();
            }
        }
    }
}
