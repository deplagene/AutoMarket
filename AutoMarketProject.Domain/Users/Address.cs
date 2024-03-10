namespace AutoMarketProject.Domain.Users;

public record Address
{
    protected Address(string country, string city, string street)
    {
        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country can't be empty",
                nameof(country));
        
        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("city can't be empty",
                nameof(city));
        
        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Street can't be empty",
                nameof(street));
        
        Country = country;
        City = city;
        Street = street;
    }
    
    /// <summary>
    /// Страна
    /// </summary>
    public string Country { get; private set; }

    
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }

    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    
    
    /// <summary>
    /// Установить страну
    /// </summary>
    /// <param name="country"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetCountry(string country)
    {
        if (string.IsNullOrEmpty(country))
            throw new ArgumentException("Country can't be empty"
                , nameof(country));
        if (Country != country)
            Country = country;
    }
    
    
    /// <summary>
    /// Установить город
    /// </summary>
    /// <param name="city"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetCity(string city)
    {
        if (string.IsNullOrEmpty(city))
            throw new ArgumentException("City can't be empty"
                , nameof(city));
        if (City != city)
            City = city;
    }
    
    /// <summary>
    /// Установить улицу
    /// </summary>
    /// <param name="street"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetStreet(string street)
    {
        if (string.IsNullOrEmpty(street))
            throw new ArgumentException("Country can't be empty"
                , nameof(street));
        if (Street != street)
            Street = street;
    }
}