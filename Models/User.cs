using CustomExceptions;
namespace Models;

public class User
{
    public User()                                   // Empty Constructor
    {
        UserID = 0;

        _name = "username";

        _passWord = "passWord";

        _email = "email";
    }
    public int UserID { get; set; }

    private string? _name;                          
    public string? UserName                          // Checks for null or empty name and throws
    {                                               // InvalidInputException for null or empty
        get                                         // same with mssg for invalid length
        {
            return _name;
        } 
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }
            else if(value.Length == 0 || value.Length > 100)           // length adjusted when table created
            {
                throw new InvalidInputException("Not within length 1 to 100 chars inclusive!");
            }
            else
            { _name = value; }
        }
    }
    private string? _passWord;
    public string? PassWord                            // Checks for null or empty password and throws
    {                                                 // InvalidInputException for null or empty
        get                                           // same with mssg for invalid length
        {
            return _passWord;
        } 
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }
            else if(value.Length == 0 || value.Length > 100)            // Length adjusted when table created
            {
                throw new InvalidInputException("Not within length 1 to 100 chars inclusive!");
            }
            else
            { _passWord = value; }
        }
    }
    private string? _email;
    public string? Email                             // Checks for null or empty email and throws
    {                                               // InvalidInputException for null or empty
        get                                         // same with mssg for invalid length
        {
            return _email;
        } 
        set
        {
            if(String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException("It's null or empty");
            }
            else if(value.Length == 0 || value.Length > 100)              // Length adjusted when table created
            {
                throw new InvalidInputException("Not within length 1 to 100 chars inclusive!");
            }
            else
            { _email = value; }
        }
    }
    public override string ToString()                                       // easy way to display some info excluding password
    {
        return $"Id: {UserID} \nUsername: {UserName} \nEmail: {Email}";
    }
}