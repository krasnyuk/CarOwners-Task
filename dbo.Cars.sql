CREATE TABLE [dbo].[Table]
(
	[CarId] INT NOT NULL PRIMARY KEY, 
    [Brand] NCHAR(50) NOT NULL, 
    [Model] NVARCHAR(50) NOT NULL, 
    [CarTypeId] INT NOT NULL, 
    [Price] DECIMAL(18, 3) NOT NULL, 
    [ManufactureYear] DATETIME NOT NULL
)
