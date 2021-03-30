CREATE DATABASE BookStoresDb

Drop table Users

create table Users(UserId int primary key identity(1,1), Name varchar(50), Email varchar(50), Password varchar(50))

select * from Users

insert into Users values('Pratiksha','pratikshahatwar@gmail.com','abc')

select * from Users

insert into Users values('Mahesh','mahesh@gmail.com','xyz')

select * from Users

create table Book(BookId int primary key identity(1,1), BookName varchar(50),BookAutherName varchar(50) , BookPrice int ,BookImage varchar(50), BookDescription varchar(50),BookQuantity int)

select * from Book

insert into Book values('Java','Jhon',100,'xyz','abc',5)

select * from Book

insert into Book values('C#','Mahesh',200,'dgh','yuj',3)

select * from Book

Drop table Cart

create table Cart(CartId int primary key identity(1,1), BookId int foreign key references Book(BookId), UserId int foreign key references Users(UserId) , BookQuanity int)

select * from Cart

insert into Cart values(1,1,50)

select * from Cart

insert into Cart values(2,2,75)

select * from Cart

select * from Users

create procedure AddUsers
(
@Name varchar(50),
@Email varchar(50),
@Password varchar(50)
)
as
begin try
insert into Users(Name,Email,Password) values(@Name,@Email,@Password)
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute AddUsers 'Rupali','mhhg@gg','vbn'

select * from Users

DROP PROCEDURE AddUsers;  
GO   

create procedure GetAllUsers
as
begin try
select * from Users
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute GetAllUsers

select * from Users

select * from Book

create procedure AddBook
(
@BookName varchar(50),
@BookAutherName varchar(50),
@BookPrice int,
@BookImage varchar(50),
@BookDescription varchar(50),
@BookQuantity int
)
as
begin try
insert into Book(BookName,BookAutherName,BookPrice,BookImage,BookDescription,BookQuantity) values (@BookName,@BookAutherName,@BookPrice,@BookImage,@BookDescription,@BookQuantity)
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute AddBook '.net','naresh',120,'hghjjjmk','jhhg',5

select * from Book

create procedure GetAllBook
as
begin try
select * from Book
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute GetAllBook

create procedure sp_update_book
(
@BookId int,
@BookName varchar(50),
@BookAutherName varchar(50),
@BookPrice int,
@BookImage varchar(50),
@BookDescription varchar(50),
@BookQuantity int
)
as
begin try
if exists(select * from Book where BookId = @BookId)
update Book set BookName = @BookName,
                BookAutherName = @BookAutherName,
				BookPrice =@BookPrice, 
				BookImage = @BookImage,
				BookDescription = @BookDescription,
				BookQuantity = @BookQuantity
		  where BookId = @BookId
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute sp_update_book 1,'kkkk','lkj',200,'ghkj','hjhg',6

select * from Book

create procedure sp_delete_book
@BookId int
as
begin try
delete from Book  
    where BookId = @BookId 
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute sp_delete_book 2

create procedure spAddCart
(
@BookId int,
@UserId int,
@BookQuantity int
)
as
begin try
insert into Cart(BookId,UserId,BookQuanity) values (@BookId,@UserId,@BookQuantity)
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute spAddCart 1,1,12

select * from Cart

create procedure spUpdateCart
(
@CartId int,
@BookId int,
@UserId int,
@BookQuantity int
)
as 
begin try
if exists(select * from Cart where CartId = @CartId)
update Cart set BookId = BookId,
                UserId = UserId,
				BookQuanity = @BookQuantity
		  where CartId = @CartId
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute spUpdateCart 1,1,1,60

select * from Cart

create procedure spDeleteCart
(
@CartId int
)
as
begin try
delete from Cart
       where CartId = @CartId
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute spDeleteCart 1

select * from Cart

create procedure spGetAllCart
as
begin try
select Cart.BookQuanity,Users.Name,Users.Email,Users.Password,Book.BookName,Book.BookAutherName,Book.BookPrice,Book.BookImage,Book.BookDescription,Book.BookQuantity
from ((Cart 
INNER JOIN Users ON Cart.UserId = Users.UserId)
INNER JOIN Book ON Cart.BookId = Book.BookId)
end try
begin catch
SELECT ERROR_NUMBER() AS ErrorNumber,ERROR_PROCEDURE() AS ErrorProcedure, ERROR_MESSAGE() AS ErrorMessage;
end catch

execute spGetAllCart