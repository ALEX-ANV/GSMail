using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using GSMailApi.Model.Files.Managment;
using MailUI.Model;
using MailUI.Model.Commands;
using MailUI.View;
using MailUI.View.ManagmentControls;

namespace MailUI.ViewModel.ManagmentViewModels
{
    [Export(typeof(ITemplateView))]
    public class NippoViewModel : BaseViewModel, ITemplateView
    {
        public TemplateModel Template { get; set; }

        private NippoFile _nippoFileSettings;
        public NippoFile NippoFileSettings
        {
            get { return _nippoFileSettings; }
            set { SetProperty(ref _nippoFileSettings, value); }
        }

        private string[] _content;
        public string[] Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private ICommand _addItem;
        public ICommand AddItem
        {
            get { return _addItem; }
            set { _addItem = value; }
        }

        private ICommand _removeItem;
        public ICommand RemoveItem
        {
            get { return _removeItem; }
            set { _removeItem = value; }
        }

        public NippoViewModel()
        {
            NippoFileSettings = new NippoFile();
            MainWindow.GlobalParameters.PropertyChanged += UpdateGlobalParameters;
            AddItem = new CommandModel(AddItemActivity);
            RemoveItem = new CommandModel(RemoveItemActivity);
        }

        private void UpdateGlobalParameters(object sender, PropertyChangedEventArgs e)
        {
            var value = sender as BaseModel;
            if (value == null)
            {
                return;
            }
            if (e.PropertyName == nameof(NippoFileSettings.UserName) && value.UserName != null)
            {
                NippoFileSettings.UserName = value.UserName;
                NippoFileSettings.NameFile =
                    $"ni{value.Date:yMMdd}.{value.UserName.ToLower()}";
            }
            if (e.PropertyName == nameof(NippoFileSettings.Date))
            {
                NippoFileSettings.Date = value.Date;
            }
            Content = NippoFileSettings.FormatString(Content, NippoFileSettings.GetValues<NippoFile>());
        }

        private void AddItemActivity(object o)
        {
            var act = new Activity();
            act.PropertyChanged += UpdateItem;
            NippoFileSettings.Activities.Add(act);
        }

        private void UpdateItem(object sender, PropertyChangedEventArgs e)
        {
            var val = sender as Activity;
            if (!string.IsNullOrEmpty(val?.TaskName) && !string.IsNullOrEmpty(val.Customer)
              && !string.IsNullOrEmpty(val.Description))
            {
                var list = Content.ToList();
                //foreach (var activity in NippoFileSettings.Activities)
                //{
                    list.Insert(Template.ListPatterns[nameof(NippoFileSettings.Activities).ToLower()].Line, 
                        val.FormatString(Template.ListPatterns[nameof(NippoFileSettings.Activities).ToLower()].Pattern,
                        val.GetValues<Activity>()).TrimEnd());
                Content = list.ToArray();
                //}
            }
        }

        private void RemoveItemActivity(object o)
        {
            if (NippoFileSettings.Activities.Any())
            {
                NippoFileSettings.Activities.Remove(NippoFileSettings.Activities.Last());
            }
        }

        public void Attach(ManagmentViewModel managmentView, TemplateModel contentTemplate)
        {
            Template = contentTemplate;
            Content = contentTemplate.Content.ToArray();
            var it = new Activity();
            it.PropertyChanged += UpdateItem;
            NippoFileSettings.Activities = new ObservableCollection<ManagmentFile> { it };
            var model = new ManagmentFileModel(InstanceType, new NippoControlView(this));
            managmentView.ManagmentFiles.Add(model);
        }

        public string InstanceType { get { return "nippo"; } }
    }
}
