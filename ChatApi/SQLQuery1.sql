create database DB_CHAT;
go
USE DB_CHAT
GO
create table Users(
idUser int primary key identity,
name varchar(255) not null,
password varbinary(255)
)
go
create table Server(
idServer int primary key identity,
name text not null,
photo text not null
)
go
create table Chat(
idChat int primary key identity,
chat text not null,
idUser int,
idServer int
foreign key (idUser) references Users(idUser),
foreign key (idServer) references Server(idServer)
)
go

/*Chat del servidor*/

/*DROP DATABASE DB_CHAT*/

/*Crear usuario*/
create proc sp_create_user(
@Name varchar(255),
@Password varchar(255)
)
as
begin
	insert into Users(name,password) values (@Name, HASHBYTES('SHA1',@Password))
end

/*Buscar usuario*/
create proc sp_search_user(
@Name varchar(255),
@Password varchar(255)
)
as
begin 
	select idUser, name from Users Where name = @Name AND password = HASHBYTES('SHA1',@PASSWORD)
end

/*Crear servidor*/
create proc sp_crete_server(
@Name text
)
as
begin
	insert into Users(name) values (@Name)
end

/*Listar Servidor*/
create proc sp_list_server
as
begin 
	select name, photo from Server
end

/*lISTAR CHAT*/
create proc sp_list_chat(
@IdServer INT 
)
as
begin
	select Users.name, Chat.chat,Server.name from  ((Chat inner join Users on Chat.idUser = Users.idUser)inner join Server on @IdServer  = Server.idServer )  
end

/*CREART CHAT*/
CREATE PROC sp_create_chat(
@Chat text,
@IdUser int,
@IdServer int
)
as
begin
	insert into Chat(chat,idUser,idServer) VALUES(@Chat,@IdUser,@IdServer)
END

EXEC sp_create_user @Name='juan@gmail.com', @Password = '123'

EXEC sp_search_user @Name='juan@gmail.com', @Password = '123'



/*insert into Server(name,photo) values ('react','test.png')
insert into Chat(chat,idUser,idServer) values ('Esto es una prueba ',1,1)

EXEC sp_list_chat @IdServer = 1

drop proc sp_list_chat*/