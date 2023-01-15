using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Timers;

namespace Nuvei
{
    public class PersonComparer : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            return x.Id - y.Id;
        }
    }

    public interface IPerson
    {
        int Id { get; }
        // String FirstName { get; }
        // String LastName { get; }
        // Date DateOfBirth { get; }
        // int Height { get; }
        // etc… there may be more, such as get property methods
        //You cannot rely on the properties in this interface, they can be changed and removed.
    }

    public class Person : IPerson
    {
        public int Id { get; set; }
    }
}