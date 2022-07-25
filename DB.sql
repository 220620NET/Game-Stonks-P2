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
	profile_picture VARCHAR(50)
	PRIMARY KEY(profile_id)
);




CREATE TABLE Transactions(
	transaction_id  INT NOT NULL identity primary key, 
    transaction_type VARCHAR(25) NOT NULL CHECK (transaction_type IN (‘Sell’, ‘Buy’)),
    userAccount_id INT NOT NULL FOREIGN KEY REFERENCES Users(user_id), 
    ticker_Symbol VARCHAR(25) NOT NULL FOREIGN KEY REFERENCES Cryto(#####), 
    submission_time DATETIME NOT NULL DEFAULT(GETDATE())
    submission_price NUMERIC
);

CREATE TABLE Accounts(
	user_id FOREIGN KEY REFERENCES Users(user_id),
    account_id identity primary key,
    account_type VARCHAR(50),
    account_name VARCHAR(50),
    account_balance NUMERIC
);
