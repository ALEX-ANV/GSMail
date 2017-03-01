using System.Collections.Generic;

namespace MailUI.Model
{
    public interface IBaseModel
    {
        IDictionary<string, object> GetValues<T>() where T : new();

        IDictionary<string, object> GetValues(object value);
    }
}