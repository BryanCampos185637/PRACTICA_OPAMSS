USE [PracticaOpamss]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarEmpleado]    Script Date: 30/07/2021 12:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EliminarEmpleado]
@EmpleadoId BIGINT 
AS
BEGIN
	UPDATE Empleadoes SET Estado='DES' WHERE EmpleadoId= @EmpleadoId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarEmpleado]    Script Date: 30/07/2021 12:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------
-----------------------------------------------------------------------
CREATE procedure [dbo].[sp_GuardarEmpleado]
@CargoId as bigint,
@Nombre as varchar(200),
@Apellido as varchar(200),
@Edad as int,
@FechaNacimiento as date
as
begin
	insert into Empleadoes(CargoId,Nombre,Apellido,Edad,FechaNacimiento,Estado) 
	values(@CargoId, @Nombre,@Apellido,@Edad,@FechaNacimiento,'ACT')
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ListarEmpleados]    Script Date: 30/07/2021 12:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_ListarEmpleados]
@filtro VARCHAR(100)
AS
BEGIN
IF(@filtro is not null OR @filtro='')--si el parametro viene diferente de null entonces hacemos el listado con el filtro
	SELECT * FROM Empleadoes WHERE Estado = 'ACT' AND Nombre like '%'+@filtro+'%' 
ELSE --si no solo ejecutamos una consulta sin condicion
	SELECT * FROM Empleadoes WHERE Estado='ACT' ORDER BY Nombre ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarEmpleado]    Script Date: 30/07/2021 12:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarEmpleado]
@EmpleadoId as bigint,
@CargoId as bigint,
@Nombre as varchar(200),
@Apellido as varchar(200),
@Edad as int,
@FechaNacimiento as date
as
begin
	UPDATE Empleadoes SET CargoId=@CargoId, 
						  Nombre=@Nombre, 
					      Apellido=@Apellido,
						  Edad=@Edad,
						  FechaNacimiento=@FechaNacimiento
	WHERE EmpleadoId = @EmpleadoId
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerPorId]    Script Date: 30/07/2021 12:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-----------------------------------------------------------------------
-----------------------------------------------------------------------
create PROCEDURE [dbo].[sp_ObtenerPorId]
@EmpleadoId as bigint
AS
BEGIN
	SELECT * FROM Empleadoes WHERE EmpleadoId=@EmpleadoId;
END
GO
