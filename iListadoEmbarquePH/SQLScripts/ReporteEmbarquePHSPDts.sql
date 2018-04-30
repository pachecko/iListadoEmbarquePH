IF object_id('dbo.ReporteEmbarquePHSPDts') IS not null
	DROP PROCEDURE dbo.ReporteEmbarquePHSPDts
GO

CREATE PROCEDURE dbo.ReporteEmbarquePHSPDts
(
	@IdSucursalPH INT,	
	@IdCaja		INT,
	@Pedido NVARCHAR(10)
)
AS
BEGIN
/********************************************************************************
	Objeto: 	ReporteEmbarquePHSPDts
	Referencia:	2011001-2011081800(1)
	Autor:	 	Armando AS, Roberto YA
	Fecha:	 	Agosto 24, 2011
	Apps:	 	iListadoEmbarquePH
	Descripción: 	Obtiene el catálogo de sucursales de la tienda Palacio de Hierro.
	Base de Datos: 	[192.168.46.1].GandhiPH
	Ejemplo(s):		
		  EXEC ReporteEmbarquePHSPDts 1,1,12345
		  EXEC ReporteEmbarquePHSPDts 1,1,3
	
	--------MODIFICACIONES--------------------
	------------------------------------------
	Objeto:			EmbarquePHSPI
	Referencia:		2011003-2012012300(1)
	Fecha/Hora:		23-ene-2012 12:35
	Autor:			Drummer
	Motivo:			Se ralizo un ajuste en la consulta de los datos, debido a que el titulo venia null.
	------------------------------------------------------------
	Objeto:			EmbarquePHSPI
	Referencia:		2011002-2011100700(1)
	Fecha/Hora:		07-oct-2011 17:47
	Autor:			Drummer
	Motivo:			Se relación será por SKU, ya que es el dato que estará dentro del archivo de texto
					generado por la colectora.
					Cambio solicitado por Arturo Ovando, 07-oct-2011
	------------------------------------------------------------
		  								
*/
		
		SELECT DISTINCT --Idcaja, Pedido, ClaveProveedorPH, IdsucursalPH, 
					--top 10 
					('*' + CodigoBarras + '*') as CodigoBarras,
					LEFT(a.Descripcion1,30) as Titulo, 
					e.Piezas, ('*' + RTrim(e.CBGandhi) + '*') as CBGandhi
		 FROM 
		 (
			 SELECT Idcaja, Pedido, ClaveProveedorPH, IdsucursalPH,
				CodigoBarras, count(CodigoBarras) as Piezas, ag.SKU as CBGandhi, ag.Articulo as Articulo
			 FROM EmbarquePH e 
				LEFT JOIN PHArticuloGandhi ag ON (LTRIM(RTRIM(ag.SKU)) = LTRIM(RTRIM(e.CodigoBarras)))	-- 2011002-2011100700(1)
			 WHERE e.IdSucursalPH = @IdSucursalPH AND e.Idcaja = @IdCaja and e.Pedido = @Pedido 
			 GROUP BY Idcaja, Pedido, ClaveProveedorPH, IdsucursalPH, CodigoBarras, ag.SKU, ag.Articulo
		 ) e
		 LEFT JOIN art a ON LTRIM(RTRIM(e.Articulo)) = LTRIM(RTRIM(a.Articulo)) 
		 ORDER BY Titulo
		 
END

GRANT EXECUTE ON dbo.ReporteEmbarquePHSPDts TO PUBLIC
GO

