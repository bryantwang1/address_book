using System;
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

        public void UpdateId(int updatedId)
        {
            _id = updatedId;
        }

        public int GetId()
        {
            return _id;
        }

        public void Add()
        {
            _contacts.Add(this);
        }

        public static void Delete(int searchId)
        {
            _contacts.RemoveAt(searchId-1);

            int counter = 1;
            foreach(Contact contact in _contacts)
            {
                contact.UpdateId(counter);
                counter++;
            }
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

        public static List<Contact> Search(string userQuery)
        {
            string userQueryLower = userQuery.ToLower();
            List<Contact> searchResults = new List<Contact> {};
            foreach(Contact contact in _contacts)
            {
                List<string> allProperties = new List<string> {};
                allProperties.Add(contact.GetName().ToLower());
                allProperties.Add(contact.GetPhone().ToLower());
                allProperties.Add(contact.GetAddress().GetStreet().ToLower());
                allProperties.Add(contact.GetAddress().GetCity().ToLower());
                allProperties.Add(contact.GetAddress().GetState().ToLower());
                allProperties.Add(contact.GetAddress().GetZip().ToLower());

                foreach(string property in allProperties)
                {
                    if(property.Contains(userQueryLower))
                    {
                        searchResults.Add(contact);
                        break;
                    }
                }
            }
            return searchResults;
        }

        public static List<string> SuggestSearch(string userQuery)
        {
            string userQueryLower = userQuery.ToLower();
            List<string> searchSuggestions = new List<string> {};
            char[] splitQueryChar = userQueryLower.ToCharArray();
            List<string> splitQueryString = new List<string> {};

            foreach(char charLetter in splitQueryChar)
            {
                splitQueryString.Add(charLetter.ToString());
            }

            foreach(Contact contact in _contacts)
            {
                List<string> allProperties = new List<string> {};
                allProperties.Add(contact.GetName().ToLower());
                allProperties.Add(contact.GetPhone().ToLower());
                allProperties.Add(contact.GetAddress().GetStreet().ToLower());
                allProperties.Add(contact.GetAddress().GetCity().ToLower());
                allProperties.Add(contact.GetAddress().GetState().ToLower());
                allProperties.Add(contact.GetAddress().GetZip().ToLower());

                foreach(string property in allProperties)
                {
                    int scoreCounter = 0;
                    foreach(string character in splitQueryString)
                    {
                        if(property.Contains(character))
                        {
                            scoreCounter++;
                        }
                    }
                    if(scoreCounter >= userQuery.Length/2)
                    {
                        searchSuggestions.Add(property);
                    }
                }
            }
            return searchSuggestions;
        }
    }
}
