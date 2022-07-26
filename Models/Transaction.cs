using CustomExceptions;

namespace Models;

public class Transaction
{
    public Transaction()
    {
        TransactionID = 0;
        AccountID = 0;
        _transactionType = transType.Buy;
        _transactionValue = 0;
        _transactionTime = DateTime.Now;
        _cryptoRate = 0;
        _cryptoAmount = 0;
    }
    public int TransactionID;
    public int AccountID;
    public enum transType {Sell, Buy}
    private transType _transactionType;
    public transType TransactionType
    {
        get
        {
            return _transactionType;
        }
        set
        {
            if (Enum.IsDefined(typeof(transType),value)){ _transactionType = value; }
            else 
            {
                throw new InvalidInputException("Not a valid transaction type!");
            }
        }
    }
    private double _transactionValue;
    public double TransactionValue
    {
        get
        {
            return _transactionValue;
        }
        set
        {
            if (value <= 0)
            {
                throw new InvalidInputException("Cannot have a negative or zero value in transaction!");
            }
            else { _transactionValue = value; }
        }
    }
    private DateTime _transactionTime;
    public DateTime TransactionTime
    {
        get
        {
            return _transactionTime;
        }
        set
        {
            _transactionTime = value;
        }
    }
    private double _cryptoRate;
    public double CryptoRate
    {
        get
        {
            return _cryptoRate;
        }
        set
        {
            if (value <= 0)
            {
                throw new InvalidInputException("Cannot have a negative or zero Cryptocurrency rate in transaction!");
            }
            else { _cryptoRate = value; }
        }
    }
    private double _cryptoAmount;
    public double CryptoAmount
    {
        get
        {
            return _cryptoAmount;
        }
        set
        {
            if (value <= 0)
            {
                throw new InvalidInputException("Cannot have a negative or zero amount of Cryptocurrency in transaction!");
            }
            else { _cryptoAmount = value; }
        }
    }
    public override string ToString()
    {
        return $"Transaction ID: {TransactionID} \nAccount ID: {AccountID} \nTransaction Type: {_transactionType} \nTransactoin Value: {_transactionValue} \nTansaction Time: {_transactionTime} \nCryptocurrency Rate: {_cryptoRate} \nCryptocurrency Amount: {_cryptoAmount}";
    }
}