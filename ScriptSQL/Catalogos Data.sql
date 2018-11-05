USE [BODASDB]
GO

delete [dbo].[Hoteles]
delete [dbo].[Horas]
delete [dbo].[Divisas]
delete [dbo].[Roles]
delete [dbo].[LugaresCeremonia]
delete [dbo].[BackUps]
delete [dbo].[Agencias]
delete [dbo].[Paquetes]
delete [dbo].[Ttoos] 
delete [dbo].[Agendas]
delete [dbo].[Agentes]
delete [dbo].[CategoriasServicios]
delete [dbo].[Comentarios]
delete [dbo].[DiasBloquedo]
delete [dbo].[Divisas]
delete [dbo].[EstadosAgenda]
delete [dbo].[Historial]
delete [dbo].[Horas]
delete [dbo].[Hoteles]
delete [dbo].[LugaresCena]
delete [dbo].[MasterFile]
delete [dbo].[LugaresCeremonia]
delete [dbo].[MasterFileContenido]
delete [dbo].[Paquetes]
delete [dbo].[PaqueteServicio]
delete [dbo].[Roles]
delete [dbo].[Servicios]
delete [dbo].[TiposCeremonia]
delete [dbo].[Ttoos]


truncate table [dbo].[Hoteles]
truncate table [dbo].[Horas]
truncate table [dbo].[Divisas]
truncate table [dbo].[Roles]
truncate table [dbo].[LugaresCeremonia]
truncate table [dbo].[BackUps]
truncate table [dbo].[Agencias]
truncate table [dbo].[Paquetes]
truncate table [dbo].[Ttoos] 
truncate table [dbo].[Agendas]
truncate table [dbo].[Agentes]
truncate table [dbo].[CategoriasServicios]
truncate table [dbo].[Comentarios]
truncate table [dbo].[DiasBloquedo]
truncate table [dbo].[Divisas]
truncate table [dbo].[EstadosAgenda]
truncate table [dbo].[Historial]
truncate table [dbo].[Horas]
truncate table [dbo].[Hoteles]
truncate table [dbo].[LugaresCena]
truncate table [dbo].[MasterFile]
truncate table [dbo].[LugaresCeremonia]
truncate table [dbo].[MasterFileContenido]
truncate table [dbo].[Paquetes]
truncate table [dbo].[PaqueteServicio]
truncate table [dbo].[Roles]
truncate table [dbo].[Servicios]
truncate table [dbo].[TiposCeremonia]
truncate table [dbo].[Ttoos]

select * from  [dbo].[Hoteles]

DBCC CHECKIDENT ([Hoteles], RESEED, 0)


DBCC CHECKIDENT ([Horas], RESEED, 0)
DBCC CHECKIDENT ([Divisas], RESEED, 0)
DBCC CHECKIDENT ([Roles], RESEED, 0)
DBCC CHECKIDENT ([LugaresCeremonia], RESEED, 0)
DBCC CHECKIDENT ([BackUps], RESEED, 0)
DBCC CHECKIDENT ([Agencias], RESEED, 0)
DBCC CHECKIDENT ([Paquetes], RESEED, 0)
DBCC CHECKIDENT ([Ttoos] , RESEED, 0)
DBCC CHECKIDENT ([Agendas], RESEED, 0)
DBCC CHECKIDENT ([Agentes], RESEED, 0)
DBCC CHECKIDENT ([CategoriasServicios], RESEED, 0)
DBCC CHECKIDENT ([Comentarios], RESEED, 0)
DBCC CHECKIDENT ([DiasBloquedo], RESEED, 0)
DBCC CHECKIDENT ([Divisas], RESEED, 0)
DBCC CHECKIDENT ([EstadosAgenda], RESEED, 0)
DBCC CHECKIDENT ([Historial], RESEED, 0)
DBCC CHECKIDENT ([Horas], RESEED, 0)
DBCC CHECKIDENT ([Hoteles], RESEED, 0)
DBCC CHECKIDENT ([LugaresCena], RESEED, 0)
DBCC CHECKIDENT ([MasterFile], RESEED, 0)
DBCC CHECKIDENT ([LugaresCeremonia], RESEED, 0)
DBCC CHECKIDENT ([MasterFileContenido], RESEED, 0)
DBCC CHECKIDENT ([Paquetes], RESEED, 0)
DBCC CHECKIDENT ([PaqueteServicio], RESEED, 0)
DBCC CHECKIDENT ([Roles], RESEED, 0)
DBCC CHECKIDENT ([Servicios], RESEED, 0)
DBCC CHECKIDENT ([TiposCeremonia], RESEED, 0)
DBCC CHECKIDENT ([Ttoos], RESEED, 0)



INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img],[Activo]) VALUES ('Caracol','CA', null,1)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img],[Activo]) VALUES ('Cancun','CU', null,1)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img],[Activo]) VALUES ('Finisterra','FI', null,1)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img],[Activo]) VALUES ('Playacar','PL', null,1)
GO

INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('10:00',1)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('11:00',1)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('12:00',2)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('13:00',2)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('14:00',2)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('15:00',2)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('16:00',3)
INSERT INTO [dbo].[Horas] ([Hora] ,[Tipo])  VALUES    ('17:00',3)


INSERT INTO [dbo].[Divisas]([Clave])  VALUES ('MX')
INSERT INTO [dbo].[Divisas]([Clave])  VALUES ('USD')

INSERT INTO [dbo].[Roles]([Nombre],[Clave]) VALUES ('Administrador' ,'Ad')
INSERT INTO [dbo].[Roles]([Nombre],[Clave]) VALUES ('Gerente' ,'Ge')
INSERT INTO [dbo].[Roles]([Nombre],[Clave]) VALUES ('Ejecutivo' ,'Ej')
INSERT INTO [dbo].[Roles]([Nombre],[Clave]) VALUES ('Coordinador' ,'Co')


INSERT INTO [dbo].[LugaresCeremonia] ([Lugar],[HotelId],[Activo]) VALUES('Lugar 1 Cere' ,1 ,1)
INSERT INTO [dbo].[LugaresCeremonia] ([Lugar],[HotelId],[Activo]) VALUES('Lugar 2 Ceremonia' ,1 ,1)

INSERT INTO [dbo].[TiposCeremonia]([Descripcion],[Activo]) VALUES  ('Tipo UNO Ceremonia',1)
INSERT INTO [dbo].[TiposCeremonia]([Descripcion],[Activo]) VALUES  ('Tipo DOS',1)



INSERT INTO [dbo].[BackUps] ([Lugar],[HotelId] ,[Activo]) VALUES  ('Backup uno',1,1)
INSERT INTO [dbo].[BackUps] ([Lugar],[HotelId] ,[Activo]) VALUES  ('Backup dos',1,1)



INSERT INTO [dbo].[Ttoos] ([Nombre] ,[Activo] ,[HotelId])  VALUES  ('BD' ,1,1)
INSERT INTO [dbo].[Ttoos] ([Nombre] ,[Activo] ,[HotelId])  VALUES  ('TV' ,1,1)

INSERT INTO [dbo].[Agencias]([Nombre],[Correo] ,[Activo],[TtooId]) VALUES ('Agencia uno' ,'correo@agencia.com'  ,1,1)
INSERT INTO [dbo].[Agencias]([Nombre],[Correo] ,[Activo],[TtooId]) VALUES ('Agencia uno' ,'correo@agencia.com'  ,1,1)




INSERT INTO [dbo].[Paquetes] ([Descripcion],[Clave],[Activo]) VALUES ('Paquete uno','AGH',1)
INSERT INTO [dbo].[Paquetes] ([Descripcion],[Clave],[Activo]) VALUES ('Paquete 2','PK2',1)


INSERT INTO [dbo].[LugaresCena]([Lugar],[HotelId],[Activo]) VALUES ('Lugar cena 1', 1  ,1)
INSERT INTO [dbo].[LugaresCena]([Lugar],[HotelId],[Activo]) VALUES ('Lugar cena 2', 1  ,1)

GO