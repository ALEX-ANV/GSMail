using System.Collections.Generic;
using System.Linq;

namespace MailUI.Utils
{
    public class StringList<T> : List<T>
    {
        public override string ToString()
        {
            return this.Aggregate("", (current, items) => current + $"{items}\n");
        }
    }
}
