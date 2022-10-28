using System;

namespace PeopleList
{
    public class Nadeko
    {

        public string[] lcr;
        public string responses;

        public Nadeko(params string[] lcr)
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
