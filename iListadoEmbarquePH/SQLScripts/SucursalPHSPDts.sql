IF object_id('dbo.SucursalPHSPDts') IS not null
	DROP PROCEDURE dbo.SucursalPHSPDts
GO

CREATE PROCEDURE dbo.SucursalPHSPDts

AS
BEGIN
/********************************************************************************
	Objeto: 	SucursalPHSPDts
	Referencia:	2011001-2011081800(1)
	Autor:	 	Armando AS
	Fecha:	 	Agosto 24, 2011
	Apps:	 	iListadoEmbarquePH
	Descripción: 	Obtiene el catálogo de sucursales de la tienda Palacio de Hierro.
	Base de Datos: 	[192.168.46.1].GandhiPH
	Ejemplo(s):		
		  EXEC SucursalPHSPDts
		  		
		 Select * from SucursalPH

*/

SELECT
		IdSucursalPH,Clave,Descripcion,DescripcionCorta
FROM 	SucursalPH
WHERE   Estado = 'A'

END

GRANT EXECUTE ON dbo.SucursalPHSPDts TO PUBLIC
GO




