ECHO OFF

REM If Database Already Exists This part will simply fails
sqlcmd -S localhost\sqlexpress -E -Q "CREATE DATABASE ILLUMINATE"

REM Drop Existing Tables
SET folder=.\Clear
for %%f in (%folder%\*.sql) do (
            echo Executing %%~nf
			sqlcmd -S localhost\sqlexpress -E -d illuminate -i %%f
    )
ECHO Tables are Dropped
REM Create Tables Schema
SET folder=.
for %%f in (%folder%\*.sql) do (
            echo Executing %%~nf
			sqlcmd -S localhost\sqlexpress -E -d illuminate -i %%f
    )
	
ECHO Created New Schema

REM Create Static Data
SET folder=.\Data
for %%f in (%folder%\*.sql) do (
            echo Executing %%~nf
			sqlcmd -S localhost\sqlexpress -E -d illuminate -i %%f
    )

ECHO Static Data is Inserted
ECHO Press Anykey to exit
pause
