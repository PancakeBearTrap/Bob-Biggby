using System;

namespace PeopleList
{
    public class AlphaBob
    {

        public string[] lcr;
        public string responses;

        public AlphaBob(params string[] lcr)
        {
            this.lcr = lcr;
        }

        public bool HasName(string answer)
        {
            foreach (var n in lcr)
            {
                if (string.Equals(n, answer, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
