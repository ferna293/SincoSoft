CREATE DATABASE COLEGIO;

USE [COLEGIO];

CREATE TABLE [materias](
	[id] int PRIMARY KEY,
	[name_mat] varchar(100) NOT NULL,
	[descripcion] varchar (200),
)

CREATE TABLE [teacher](
	[id] int PRIMARY KEY,
	[name_teach] varchar(20) NOT NULL,
	[last_name_teach] varchar(20),
	[email] varchar(100),
	[telephone] int,
	[type_documnet] varchar(10),
	[number_document] int,
	[id_mat] int unique NOT NULL,
	CONSTRAINT fk_name_mat FOREIGN KEY ([id_mat]) REFERENCES materias(id) 

)

CREATE TABLE [alumno](
	[id] int PRIMARY KEY,
	[name_alumno] varchar(20) NOT NULL,
	[last_name_alumno] varchar(20),
	[email] varchar(100),
	[type_document] varchar(20),
	[number_document] int,

)

CREATE TABLE [term](
	[id] int PRIMARY KEY NOT NULL,
	[name_term] varchar(20) NOT NULL,
	[description] varchar(20)
)

CREATE TABLE [notas](
	[id_term] int NOT NULL,
	[id_alumno] int NOT NULL,
	[id_mat] int NOT NULL,
	[notes] float NOT NULL,
	CONSTRAINT fk_id_term FOREIGN KEY ([id_term]) REFERENCES term([id]),
	CONSTRAINT fk_id_alumno FOREIGN KEY ([id_alumno]) REFERENCES alumno([id]),
	CONSTRAINT fk_id_mat FOREIGN KEY ([id_mat]) REFERENCES materias([id]),
)

