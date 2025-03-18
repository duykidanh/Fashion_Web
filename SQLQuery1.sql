USE [QLBanDoThoiTrang]

DECLARE @sql NVARCHAR(MAX) = N'';

-- Generate SQL to drop all foreign key constraints
SELECT @sql += 'ALTER TABLE [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '] DROP CONSTRAINT [' + CONSTRAINT_NAME + '];' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY';

-- Execute the generated SQL
EXEC sp_executesql @sql;

DECLARE @sql NVARCHAR(MAX) = N'';

-- Generate SQL to drop all tables
SELECT @sql += 'DROP TABLE [' + TABLE_SCHEMA + '].[' + TABLE_NAME + '];' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

-- Execute the generated SQL
EXEC sp_executesql @sql;

USE master;
ALTER DATABASE [QLBanDoThoiTrang] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [QLBanDoThoiTrang];