CREATE SCHEMA P2;

CREATE TABLE Users (
	user_id INT IDENTITY,
	email VARCHAR(100) UNIQUE NOT NULL,
	password VARCHAR(100) NOT NULL,
	PRIMARY KEY (user_id)
);

CREATE TABLE Profiles (
	profile_id INT IDENTITY,
	user_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id),
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL,
	display_name VARCHAR(50) NOT NULL,
	profile_picture VARCHAR(50),
	PRIMARY KEY (profile_id)
);

CREATE TABLE Accounts (
	account_id INT IDENTITY,
    user_id VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Users(user_id),
    account_type VARCHAR(50) NOT NULL CHECK (account_type IN ('Savings', 'Investment')),
    account_name VARCHAR(50),
    account_balance NUMERIC NOT NULL,
    PRIMARY KEY (account_id)
);

CREATE TABLE Transactions (
	transaction_id INT IDENTITY, 
    account_id INT NOT NULL FOREIGN KEY REFERENCES Accounts(account_id),
    transaction_type VARCHAR(25) NOT NULL CHECK (transaction_type IN ('Sell', 'Buy')),
    ticker_symbol VARCHAR(25) NOT NULL FOREIGN KEY REFERENCES Cryto(#####), 
    transaction_value DECIMAL(15,15) NOT NULL,
    transaction_time DATETIME NOT NULL DEFAULT(GETDATE()),
    crypto_rate DECIMAL(15,15) NOT NULL,
    crypto_amount DECIMAL(15,15) NOT NULL,
    PRIMARY KEY (transaction_id)
);


