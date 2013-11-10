use [Illuminate]

DECLARE @identity int;

insert into Category
values (-1,'Dotnet','General Dotnet Framework');
SET @identity = @@identity;
insert into Category
values (@identity,'WCF','Windows Communication Foundation');
insert into Category
values (@identity,'WPF','Windows Presentation Foundation');
insert into Category
values (@identity,'WWF','Windows Workflow Foundation');
insert into Category
values (@identity,'ASP.NET','Active Server Pages in Dotnet');

----------------------------
insert into Category
values (-1,'Java','Java Framework');
SET @identity = @@identity;
insert into Category
values (@identity,'Core Java','Java Basics');
insert into Category
values (@identity,'JSP','Java Server Pages');
insert into Category
values (@identity,'Struts','Struts Framework');

----------------------------
insert into Category
values (-1,'JavaScript','Java Script ');
SET @identity = @@identity;
insert into Category
values (@identity,'Java Scripts Basics','Java Scripts Basics');
insert into Category
values (@identity,'JQuery','Jquery Framework');
insert into Category
values (@identity,'Anguler JS','Anguler JavaScript Framework');


