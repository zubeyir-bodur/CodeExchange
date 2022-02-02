CREATE TABLE [User](
	[username] VARCHAR(20) PRIMARY KEY,
	[password] VARCHAR(32)
);

CREATE TABLE [Post](
	[p-id] INT PRIMARY KEY,
	[username] VARCHAR(20),
	[body] VARCHAR(MAX),
	[votes] INT,
	FOREIGN KEY([username]) REFERENCES [User]
		ON DELETE SET NULL
);

CREATE TABLE [Question](
	[p-id] INT PRIMARY KEY,
	[header] VARCHAR(50),
	FOREIGN KEY([p-id]) REFERENCES [Post]
		ON DELETE CASCADE
);

CREATE TABLE [Answer](
	[p-id] INT PRIMARY KEY,
	[q-id] INT,
	FOREIGN KEY([p-id]) REFERENCES [Post]
		ON DELETE CASCADE,
	FOREIGN KEY([q-id]) REFERENCES [Question]([p-id])
		ON DELETE NO ACTION
);

CREATE TABLE [Comment](
	[p-id] INT PRIMARY KEY,
	FOREIGN KEY([p-id]) REFERENCES [Post]
		ON DELETE CASCADE
);

CREATE TABLE [QuestionComment](
	[p-id] INT PRIMARY KEY,
	[q-id] INT,
	FOREIGN KEY([p-id]) REFERENCES [Comment]
		ON DELETE CASCADE,
	FOREIGN KEY([q-id]) REFERENCES [Question]([p-id])
		ON DELETE NO ACTION
);

CREATE TABLE [AnswerComment](
	[p-id] INT PRIMARY KEY,
	[a-id] INT,
	FOREIGN KEY([p-id]) REFERENCES [Comment]
		ON DELETE CASCADE,
	FOREIGN KEY([a-id]) REFERENCES [Answer]([p-id])
		ON DELETE NO ACTION
);