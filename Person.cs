using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingFile
{
    public class Person
    {

        public Person() { }
        public Person(string firstName, string lastName, string address, string telephone)
        {
            _firstName = firstName;
            _lastName = lastName;
            _address = address;
            _telephoneNumber = telephone;
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _telephoneNumber;

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; }
        }

     

    }
}
