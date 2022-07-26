using CustomExceptions;

namespace Models;

public class Account
{
    public Account()
    {
        AccountID = 0;
        UserID = 0;
        _accountType = accType.Investment;
        _accountName = "";
        _accountBalance = 0;
    }
    public int AccountID {get; set;}
    public int UserID {get; set;}
    public enum accType {Savings, Investment};
    private accType _accountType;
    public accType AccountType
    {
        get
        {
            return _accountType;
        }
        set
        {
            if (Enum.IsDefined(typeof(accType),value)){ _accountType = value; }
            else 
            {
                throw new InvalidInputException("Not a valid account type!");
            }
        }
    }
    private string? _accountName;
    public string? AccountName
    {
        get
        {
            return _accountName;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidInputException();
            }
            else if (value.Length == 0 || value.Length > 50)
            {
                throw new InvalidInputException("Length of account name is not between 1 and 50 chars inclusive!");
            }
            else { _accountName = value; }
        }
    }
    private int _accountBalance;
    public int AccountBalance
    {
        get
        {
            return _accountBalance;
        }
        set
        {
            _accountBalance = value;
        }
    }
    public override string ToString()
    {
        return $"Acount ID: {AccountID} \nUser ID: {UserID} \nAccount Name: {AccountName} \nAccount Type: {AccountType} \nBalance: {AccountBalance}";
    }
}