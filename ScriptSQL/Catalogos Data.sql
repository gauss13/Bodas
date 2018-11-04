USE [BODASDB]
GO

--truncate table [dbo].[Hoteles]

INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img]) VALUES ('Caracol','CA', null)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img]) VALUES ('Cancun','CU', null)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img]) VALUES ('Finisterra','FI', null)
INSERT INTO [dbo].[Hoteles]([Nombre],[Clave],[Img]) VALUES ('Playacar','PL', null)
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


INSERT INTO [dbo].[LugaresCeremonia] ([Lugar],[HotelId],[Activo])
     VALUES('Lu Cere' ,1 ,1)


INSERT INTO [dbo].[TiposCeremonia]([Descripcion],[Activo]) VALUES  ('Tipo UNO',1)
INSERT INTO [dbo].[TiposCeremonia]([Descripcion],[Activo]) VALUES  ('Tipo DOS',1)



INSERT INTO [dbo].[BackUps] ([Lugar],[HotelId] ,[Activo])
     VALUES  ('Backup uno',1,1)


	 INSERT INTO [dbo].[Agencias]
           ([Nombre]
           ,[Correo]
           ,[Activo])
     VALUES
           ('Agencia uno'
           ,'correo@agencia.com'
           ,1)




INSERT INTO [dbo].[Paquetes]
           ([Descripcion]
           ,[Clave]
           ,[Activo])
     VALUES
           ('Paquete uno'
           ,'AGH'
           ,1)



GO