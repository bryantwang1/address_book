namespace AddressBook.Objects
{
  public class Address
  {
    private string _streetAddress;
    private string _city;
    private string _state;
    private int _zip;

    public Address(string contactStreet, string contactCity, string contactState, int contactZip)
    {
      _streetAddress = contactStreet;
      _city = contactCity;
      _state = contactState;
      _zip = contactZip;
    }

    public void SetStreet(string contactStreet)
    {
      _streetAddress = contactStreet;
    }

    public void AddStreet(string contactApt)
    {
      _streetAddress = _streetAddress + ", Apt. " + contactApt;
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

    public void SetZip(int contactZip)
    {
      _zip = contactZip;
    }

    public int GetZip()
    {
      return _zip;
    }
  }
}
