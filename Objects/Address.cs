namespace AddressBook.Objects
{
    public class Address
    {
        private string _streetAddress;
        private string _city;
        private string _state;
        private string _zip;

        public Address(string contactStreet, string contactCity, string contactState, string contactZip)
        {
            _streetAddress = contactStreet;
            _city = contactCity;
            _state = contactState.ToUpper();
            _zip = contactZip;
        }

        public void SetStreet(string contactStreet)
        {
            _streetAddress = contactStreet;
        }

        public void AddStreet(string contactApt)
        {
            if(contactApt != "")
            {
                _streetAddress = _streetAddress + ", Apt. " + contactApt;
            }
        }

        public string GetStreet()
        {
            return _streetAddress;
        }

        public void SetCity(string contactCity)
        {
            _city = contactCity;
        }

        public string GetCity()
        {
            return _city;
        }

        public void SetState(string contactState)
        {
            _state = contactState;
        }

        public string GetState()
        {
            return _state;
        }

        public void SetZip(string contactZip)
        {
            _zip = contactZip;
        }

        public string GetZip()
        {
            return _zip;
        }
    }
}
