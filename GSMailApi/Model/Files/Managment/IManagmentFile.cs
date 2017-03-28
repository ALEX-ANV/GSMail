using System.Collections.Generic;

namespace GSMailApi.Model.Files.Managment
{
    public interface IManagmentFile
    {
        string[] FormatString(string[] pattern, IDictionary<string, object> values, char quotesStart = '{', char quoteEnd = '}');

        string FormatString(string pattern, IDictionary<string, object> values, char quotesStart = '{', char quoteEnd = '}');
    }
}