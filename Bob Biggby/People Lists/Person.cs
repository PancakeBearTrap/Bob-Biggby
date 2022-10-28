using System;

namespace PeopleList
{
    class Person
    {
        public string[] names;

        public int blameCount;
        public int joePoints;
        public int tally;

        public int shamePoints;

        public ulong id;

        public ulong[] userRoles;


        public Person(params string[] names)
        {
            this.names = names;
        }

        public bool HasName(string name)
        {
            foreach (var n in names)
            {
                if (string.Equals(n, name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
