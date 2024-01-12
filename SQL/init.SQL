create table SystemUser (
Id int identity(1,1) primary key,
name varchar(100)
)

create table pedido (
Id int identity(1,1) primary key,
ProductName varchar(100),
UserId int , foreign key (UserId) references Systemuser(id)
)

