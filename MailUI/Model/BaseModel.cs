using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using MailUI.Utils;

namespace MailUI.Model
{
    public class BaseModel : IBaseModel, INotifyPropertyChanged
    {
        public IDictionary<string, object> GetValues<T>() where T : new()
        {
            return GetValues(new T());
        }

        public IDictionary<string, object> GetValues(object value)
        {
            var bindFlags = BindingFlags.Instance | BindingFlags.Static |
                            BindingFlags.Public | BindingFlags.NonPublic |
                            BindingFlags.FlattenHierarchy;            
            var members = value.GetType().GetProperties(bindFlags);

            return members.ToDictionary(member => member.Name.ToLower(), member => member.GetValue(this));
        }

        private string _userName;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
