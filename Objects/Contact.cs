using System.Collections.Generic;

namespace AddressBook.Objects
{
    public class Contact
    {
        private string _name;
        private string _phone;
        private Address _address;
        private int _id;
        private static List<Contact> _contacts = new List<Contact> {};

        public Contact(string contactName, string contactPhone)
        {
            _name = contactName;
            _phone = contactPhone;
            Add();
            SetId();
        }

        public void SetName(string contactName)
        {
            _name = contactName;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetPhone(string contactPhone)
        {
            _phone = contactPhone;
        }

        public string GetPhone()
        {
            return _phone;
        }

        public void SetAddress(Address contactAddress)
        {
            _address = contactAddress;
        }

        public Address GetAddress()
        {
            return _address;
        }

        public void SetId()
        {
            _id = _contacts.Count;
        }

        public int GetId()
        {
            return _id;
        }

        public void Add()
        {
            _contacts.Add(this);
        }

        public static List<Contact> GetAll()
        {
            return _contacts;
        }

        public static Contact Find(int searchId)
        {
            return _contacts[searchId-1];
        }

        public static void ClearAll()
        {
            _contacts = new List<Contact> {};
        }
    }
}
