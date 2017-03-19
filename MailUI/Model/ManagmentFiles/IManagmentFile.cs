using System.Collections.Generic;

namespace MailUI.Model.ManagmentFiles
{
    public interface IManagmentFile
    {
        string[] FormatString(string[] pattern, IDictionary<string, object> values, char quotesStart = '{', char quoteEnd = '}');

        string FormatString(string pattern, IDictionary<string, object> values, char quotesStart = '{', char quoteEnd = '}');
    }
}