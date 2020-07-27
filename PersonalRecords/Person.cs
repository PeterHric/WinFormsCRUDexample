using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalRecords
{

    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Age { get; set; }

        public override string ToString()
        {
            return String.Format("First Name: {0} , Last Name: {1} , Age: {2}",FirstName,LastName,Age);
        }
    }
}
