USE [illuminate];

declare @temptable table(
	id int identity(1,1),
	name varchar(20)
);

insert into @temptable
select table_name from information_schema.tables;

DECLARE @count int;
DECLARE @maxCount int;
DECLARE @tableName varchar(20)

select @maxCount = count(*) from @tempTable;

set @count = 1;

while (@count <= @maxCount)
begin 
	select @tableName = name from @temptable where id = @count;
	print @tableName;
	exec('delete from ' + @tableName);
	DBCC CHECKIDENT(@tableName, RESEED, 1)
	SET @count = @count + 1;
end 
