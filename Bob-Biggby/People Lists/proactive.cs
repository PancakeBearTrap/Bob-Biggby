using System;

namespace PeopleList
{
    class Proactive
    {
        public string[] maiar;
        public long proactivePoints;
        public ulong id;

        public Proactive(params string[] maiar)
        {
            this.maiar = maiar;
        }

        public bool HasName(string maia)
        {
            foreach (var n in maiar)
            {
                if (string.Equals(n, maia, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}