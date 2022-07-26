using CustomExceptions;
namespace Models;

public class Profile
{
    public Profile()
    {
        ProfileID = 0;
        UserID = 0;
        _firstName = "";
        _lastName = "";
        _displayName = "";
        _profilePic = "";
    }
    public int ProfileID {get; set;}
    public int UserID {get; set;}
    
    private string? _firstName;
    public string? FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }   
            else if (value.Length == 0 || value.Length > 50)
            {
                throw new InvalidInputException("Not within length 1 to 50 chars inclusive!");
            }
            else { _firstName = value; }
        }
    }  
    private string? _lastName;
    public string? LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }   
            else if (value.Length == 0 || value.Length > 50)
            {
                throw new InvalidInputException("Not within length 1 to 50 chars inclusive!");
            }
            else { _lastName = value; }
        }
    } 
    private string? _displayName;
    public string? DisplayName
    {
        get
        {
            return _displayName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }   
            else if (value.Length == 0 || value.Length > 50)
            {
                throw new InvalidInputException("Not within length 1 to 50 chars inclusive!");
            }
            else { _displayName = value; }
        }
    }

    private string? _profilePic;
    public string? ProfilePic
    {
        get
        {
            return _profilePic;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("Null or empty!");
            }
            else if (value.Length == 0 || value.Length > 50)
            {
                throw new InvalidInputException("Not within the length 1 and 50 inclusive!");
            }
            else
            { _profilePic = value; }
        }
    }
    public override string ToString()                                 
    {
        return $"{ProfilePic}\nProfile ID: {ProfileID} \nUser ID: {UserID} \nName: {FirstName} {LastName}";
    }
}