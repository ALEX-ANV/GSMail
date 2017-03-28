using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GSMailApi.Utils;

namespace GSMailApi.Model
{
    public class BaseModel : NotifyPropertyChanged, IBaseModel
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
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
