IF EXISTS (SELECT name FROM sysobjects
   WHERE name = 'EmbarquePHSPI' AND type = 'P')
   DROP PROCEDURE EmbarquePHSPI
GO

CREATE PROCEDURE EmbarquePHSPI 
(
	  @CodigoBarras NVARCHAR(13)
	 ,@Pedido NVARCHAR(10)
	 ,@IdCaja INT
     ,@ClaveProveedorPH INT
     ,@IdSucursalPH INT
)
AS

BEGIN
/*	
	------------------------------------------------------------		
	Objeto:			EmbarquePHSPI
	Referencia:		2011001-2011081800(1)
	Fecha/Hora:		24/ago/2011
	Autor:			Armando AS
	Proyecto:		ListadoEmbarquePH		
	Motivo:			Agrega registro en la tabla EmbarquePH.
	------------------------------------------------------------	
	
	--EXEC EmbarquePHSPI '000100022332','12345',15068,1
	EXEC EmbarquePHSPI '000100022332','12345',1,15068,1

	--------MODIFICACIONES--------------------
	------------------------------------------
	Objeto:			EmbarquePHSPI
	Referencia:		2011002-2011100700(1)
	Fecha/Hora:		07-oct-2011 17:47
	Autor:			Drummer
	Motivo:			La busqueda se realizará por SKU, ya que es el dato que estará dentro del archivo de texto
					generado por la colectora.
					Cambio solicitado por Arturo Ovando, 07-oct-2011
	------------------------------------------------------------
*/
	DECLARE @Error 	int,
			@Existe	int

	-- antes de insertar, busca su relación con los datos de Palacio de Hierro
	-- en caso de no encontrar, retorna cero

	-- 2011002-2011100700(1)
	-- La busqueda será a través del SKU
	-- SELECT @Existe = Count(*) FROM PHArticuloGandhi WHERE Articulo = @CodigoBarras
	SELECT @Existe = Count(*) FROM PHArticuloGandhi WHERE SKU = @CodigoBarras
	IF (@Existe = 0)
	BEGIN
		RETURN 0
	END

	-- agrega el registro para la lista de embarque
	INSERT INTO EmbarquePH (
			CodigoBarras,
       		Pedido,
       		IdCaja,
       		ClaveProveedorPH,
       		IdSucursalPH
    		)
    VALUES (
        	@CodigoBarras,
	       	@Pedido,
	       	@IdCaja,
	       	@ClaveProveedorPH,
	       	@IdSucursalPH
	    	)
    
    SELECT @Error = @@Error

	IF (@Error = 0)
	BEGIN
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN -1
	END

END

GO 

GRANT EXEC ON EmbarquePHSPI TO PUBLIC
GO


