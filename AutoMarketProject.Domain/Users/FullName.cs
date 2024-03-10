namespace AutoMarketProject.Domain.Users;

public record FullName
{
    private FullName(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("FirstName can't be empty",
                nameof(firstName));

        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("LastName can't be empty",
                nameof(lastName));
            
        FirstName = firstName;
        LastName = lastName;
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; }
    
    
    /// <summary>
    /// Установить имя
    /// </summary>
    /// <param name="firstName"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new ArgumentException("FirstName can't be empty",
                nameof(firstName));
        if (FirstName != firstName)
            FirstName = firstName;
    }
    
    
    /// <summary>
    /// Установить фамилию
    /// </summary>
    /// <param name="lastName"></param>
    /// <exception cref="ArgumentException"></exception>
    public void SetLastName(string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
            throw new ArgumentException("FirstName can't be empty",
                nameof(lastName));
        if (LastName != lastName)
            LastName = lastName;
    }
}