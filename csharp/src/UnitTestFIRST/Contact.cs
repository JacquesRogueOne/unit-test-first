using System;

namespace UnitTestFIRST
{
    public class Contact
    {
        private readonly string name;
        private readonly string phoneNumber;

        public Contact(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.name == ((Contact)obj).name && this.phoneNumber == ((Contact)obj).phoneNumber;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Tuple.Create(this.name, this.phoneNumber).GetHashCode();
        }

        public override string ToString()
        {
            return "PhoneBook{"+"name='"+name+'\''+", phoneNumber='"+phoneNumber+'\''+'}'; 
        }
    }
}
