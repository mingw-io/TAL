/*
Date: 2022-05-06
Author: Sergio

Description: SQL Script for TAL Database
             This script will create a new database called TAL if it does not exist.
             It will also create all necessary Tables, Views and Stored Procs.
*/

-- Drop TAL Database
-- Create Database if it does not exist

USE [master]
GO

IF EXISTS (
	SELECT [name] 
		FROM sys.databases 
		WHERE [name] = N'TAL'
)
BEGIN
       DROP DATABASE TAL    -- Everything will be lost !!!!
END

IF DB_ID('TAL') IS NULL
BEGIN

-- Get Data directory

declare @tail int

set @tail = (
  select charindex('\',reverse(physical_name))
  from master.sys.master_files
  where name = 'master'
)

DECLARE @device_directory NVARCHAR(max)
DECLARE @data_directory NVARCHAR(max)
DECLARE @log_directory NVARCHAR(max)

DECLARE @SQL NVARCHAR(max)

select @device_directory = substring(physical_name,1,len(physical_name)-@tail)
from master.sys.master_files
where name = 'master';

SET @data_directory = @device_directory + '\TAL_Data.mdf'
SET @log_directory = @device_directory + '\TAL_Log.ldf'

SET @SQL =
N'CREATE DATABASE [TAL] ON PRIMARY (NAME = N' + N'''' + N'TAL_Data' + N'''' +
N', FILENAME = N' + N'''' + @data_directory + N''''+ N', SIZE = 10)' +
N' LOG ON (NAME = N' + N'''' + N'TAL_Log' + N'''' + N', FILENAME = N' + N'''' +
@log_directory + N'''' + N' , SIZE = 1, FILEGROWTH = 10%)'

EXEC (@SQL)

END
GO