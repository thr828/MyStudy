using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStudy
{
    public class Person: IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            //throw new NotImplementedException();
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            int result = this.LastName.CompareTo(other.LastName);
            if (result == 0)
            {
                result = this.FirstName.CompareTo(other.FirstName);
            }
            return result;
        }

        public override string ToString()
        {
            return this.FirstName + "" + this.LastName;
        }

    }
}
