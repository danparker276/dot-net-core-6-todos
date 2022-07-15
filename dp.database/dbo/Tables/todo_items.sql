CREATE TABLE [dbo].[todo_items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Todo_list_id] INT NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT GETUTCDATE(), 
    [Description] NVARCHAR(MAX) NULL, 
    [Status] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_todo_items_todo_lists] FOREIGN KEY (Todo_list_id) REFERENCES todo_lists([Id])
)
