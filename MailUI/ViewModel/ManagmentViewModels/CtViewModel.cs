using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GSMailApi.Model.Files.Managment;
using MailUI.Model;
using MailUI.Model.Commands;
using MailUI.View;
using MailUI.View.ManagmentControls;

namespace MailUI.ViewModel.ManagmentViewModels
{
    [Export(typeof(ITemplateView))]
    public class CtViewModel : BaseViewModel, ITemplateView
    {
        public TemplateModel Template { get; set; }

        private LineCtWorkingDay _generateCtWorkingDay;
        public LineCtWorkingDay GenerateCtWorking
        {
            get { return _generateCtWorkingDay; }
            set { SetProperty(ref _generateCtWorkingDay, value);}
        }

        private Visibility _visibilityContent = Visibility.Hidden;
        public Visibility VisibilityContent
        {
            get { return _visibilityContent; }
            set { SetProperty(ref _visibilityContent, value); }
        }

        public CtViewModel(string[] pattern)
        {
           Content = pattern.ToArray();
        }

        public CtViewModel()
        {
            CtFileSettings = new CtFile();
            GenerateCtWorking = new LineCtWorkingDay
            {
                StartTime = "09:00",
                EndTime = "18:00",
                StartDinner = "13:00",
                EndDinner = "14:00"
            };
            CtFileSettings.PropertyChanged += UpdateContent;
            MainWindow.GlobalParameters.PropertyChanged += UpdateGlobalParameters;
            AddItem = new CommandModel(AddItemCtWorkingDay);
            RemoveItem = new CommandModel(RemoveItemCtWorkingDay);
            GenerateCtFile = new CommandModel(GenerateCt);
        }

        private void UpdateWorkingDay(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (CtFileSettings.CtWorking.Any())
            {
                var pattern = Template.ListPatterns[nameof(CtFileSettings.CtWorking).ToLower()];
                var line = pattern.Line;
                var list = CtFileSettings.FormatString(new List<string>(Template.Content).ToArray(), CtFileSettings.GetValues<CtFile>()).ToList();
                foreach (var working in CtFileSettings.CtWorking)
                {
                    var str = "";
                    for (var i = 0; i < pattern.Index; i++)
                    {
                        str += " ";
                    }
                    str += CtFileSettings.FormatString(pattern.Pattern, working.GetValues<LineCtWorkingDay>()).TrimEnd();
                    working.PropertyChanged += (o, args) =>
                    {
                        var val = o as LineCtWorkingDay;
                        if (!string.IsNullOrEmpty(val?.EndTime) && !string.IsNullOrEmpty(val.StartTime))
                        {
                            UpdateWorkingDay(null, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                        }
                    };
                    list.Insert(line, str);
                    Content = list.ToArray();
                    line++;
                }
            }
        }

        private void UpdateContent(object sender, PropertyChangedEventArgs e)
        {
            var value = sender as CtFile;
            if (value == null)
            {
                return;
            }
            if (e.PropertyName == nameof(value.UserName) && !string.IsNullOrEmpty(CtFileSettings.UserName))
            {
                CtFileSettings.NameFile =
                    $"{value.Date.ToString("yMMdd").Substring(1)}ct_.{value.UserName.ToLower()}";

            }
            Content = CtFileSettings.FormatString(Content, CtFileSettings.GetValues<CtFile>());
        }

        private void AddItemCtWorkingDay(object o)
        {
           CtFileSettings.CtWorking.Add(new LineCtWorkingDay()); 
        }

        private void RemoveItemCtWorkingDay(object o)
        {
            if (CtFileSettings.CtWorking.Any())
            {
                CtFileSettings.CtWorking.Remove(CtFileSettings.CtWorking.Last());
            }
        }

        private void GenerateCt(object o)
        {
            VisibilityContent = Visibility.Visible;
            var list = CtFileSettings.FormatString(new List<string>(Template.Content).ToArray(), CtFileSettings.GetValues<CtFile>()).ToList();
            var pat = Template.ListPatterns[nameof(CtFileSettings.CtWorking).ToLower()];
            var pattern = Template.ListPatterns[nameof(CtFileSettings.CtWorking).ToLower()];
            int line = pattern.Line;
            for (var i = 1; i <= DateTime.DaysInMonth(2017, 10); i++)
            {
                var date = new DateTime(2017, 10, i);
                var dic = new Dictionary<string, object> {{nameof(date), date}};
                dic = dic.Concat(GenerateCtWorking.GetValues<LineCtWorkingDay>().Where(k => !
                   string.Equals(k.Key, "date", StringComparison.InvariantCultureIgnoreCase)
                )).ToDictionary(t => t.Key, t => t.Value);
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //dates.Add(date.ToString("dd'.'MM") + " xxx");
                    list.Insert(line, date.ToString("dd'.'MM") + " xxx");
                    CtFileSettings.CtWorking.Add(new LineCtWorkingDay() {StartTime = "xxx", Day = date});
                }
                else
                {
                    //dates.Add(date.DayOfWeek == DayOfWeek.Monday ? "" : 
                    //    CtFileSettings.FormatString(pat.Pattern, dic).TrimEnd());
                    list.Insert(line, date.DayOfWeek == DayOfWeek.Monday ? "" :
                        CtFileSettings.FormatString(pat.Pattern, dic).TrimEnd());
                    CtFileSettings.CtWorking.Add(new LineCtWorkingDay()
                    {
                        Day = date,
                        StartTime = dic[nameof(GenerateCtWorking.StartTime).ToLower()].ToString(),
                        EndTime = dic[nameof(GenerateCtWorking.EndTime).ToLower()].ToString(),
                        StartDinner = dic[nameof(GenerateCtWorking.StartDinner).ToLower()].ToString(),
                        EndDinner = dic[nameof(GenerateCtWorking.EndDinner).ToLower()].ToString()
                    });
                }
                Content = list.ToArray();
                line++;
            }
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
            //Content = CtFileSettings.FormatString(Content, CtFileSettings.GetValues<CtFile>());
        }


        private string[] _content;
        public string[] Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private CtFile _ctFileSettings;
        public CtFile CtFileSettings
        {
            get { return _ctFileSettings; }
            set { SetProperty(ref _ctFileSettings, value); }
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

        private ICommand _generateCtFile;
        public ICommand GenerateCtFile
        {
            get { return _generateCtFile; }
            set { _generateCtFile = value; }
        }

        public void Attach(ManagmentViewModel managmentView, TemplateModel contentTemplate)
        {
            Template = contentTemplate;
            Content = contentTemplate.Content.ToArray();
            CtFileSettings.CtWorking = new ObservableCollection<ManagmentFile>();
            CtFileSettings.CtWorking.CollectionChanged += UpdateWorkingDay;
            var model = new ManagmentFileModel(InstanceType, new CtControlView(this));
            managmentView.ManagmentFiles.Add(model);
        }

        public string InstanceType { get { return "ct"; } }
    }
}
