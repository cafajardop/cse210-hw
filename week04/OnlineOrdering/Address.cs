public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        string normalized = _country.Trim().ToUpper();
        return normalized == "USA" || normalized == "UNITED STATES" || normalized == "UNITED STATES OF AMERICA";
    }

    public string GetFullAddress()
    {
        return $"{_street}{_city}, {_stateOrProvince}{_country}";
    }
}
