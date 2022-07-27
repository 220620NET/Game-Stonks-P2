CREATE TABLE Wallet (
	wallet_id INT IDENTITY, 
    PRIMARY KEY (wallet_id)
);

CREATE TABLE Crytocurrency (
	cryptocurrency_id INT IDENTITY, 
    PRIMARY KEY (cryptocurrency_id)
);

CREATE TABLE Users (
	user_id INT IDENTITY,
	email NVARCHAR(100) UNIQUE NOT NULL,
	password NVARCHAR(100) NOT NULL,
	PRIMARY KEY (user_id)
);

CREATE TABLE Profiles (
	profile_id INT IDENTITY,
	user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
	first_name NVARCHAR(50) NOT NULL,
	last_name NVARCHAR(50) NOT NULL,
	display_name NVARCHAR(50) NOT NULL,
	profile_picture NVARCHAR(50),
	PRIMARY KEY (profile_id)
);

CREATE TABLE Accounts (
	account_id INT IDENTITY,
    user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
    account_type NVARCHAR(50) NOT NULL CHECK (account_type IN ('Savings', 'Investment')),
    account_name NVARCHAR(50),
    account_balance DECIMAL(15,15) NOT NULL,
    PRIMARY KEY (account_id)
);

--Still need the table for the bank/crypto setup before this table is ready to be added in db
CREATE TABLE Transactions (
	transaction_id INT IDENTITY, 
    account_id INT NOT NULL FOREIGN KEY REFERENCES Accounts(account_id),
    transaction_type NVARCHAR(25) NOT NULL CHECK (transaction_type IN ('Sell', 'Buy')),
    ticker_symbol NVARCHAR(25) NOT NULL FOREIGN KEY REFERENCES Crytocurrency(cryptocurrency_id), 
    transaction_value DECIMAL(15,15) NOT NULL,
    transaction_time DATETIME NOT NULL DEFAULT (GETDATE()),
    crypto_rate DECIMAL(15,15) NOT NULL,
    crypto_amount DECIMAL(15,15) NOT NULL,
    PRIMARY KEY (transaction_id)
);


