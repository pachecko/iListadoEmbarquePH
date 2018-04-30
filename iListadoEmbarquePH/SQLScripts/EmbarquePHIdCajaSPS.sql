
IF EXISTS (SELECT name FROM sysobjects
           WHERE name = 'EmbarquePHIdCajaSPS' AND type = 'P')
   DROP PROCEDURE EmbarquePHIdCajaSPS
GO

CREATE PROCEDURE [dbo].[EmbarquePHIdCajaSPS]
(
	@Pedido NVARCHAR(10),
	@IdSucursalPH Int
)
AS
BEGIN
/*	
	------------------------------------------------------------	
	 Name:			EmbarquePHIdCajaSPS
	 Referencia:	2011001-2011081800(1)
	 Fecha/Hora:	24/ago/2011
	 Autor:			Armando AS
	 Motivo:		Obtiene el valor de la nueva caja para el pedido y sucursal dados.
	------------------------------------------------------------
	select * from EmbarquePH
	
	declare @ResultIdCaja int
	--EXEC @ResultIdCaja = EmbarquePHIdCajaSPS '1000', 1
	EXEC EmbarquePHIdCajaSPS 
	select @ResultIdCaja
	
	EXEC EmbarquePHSPI '12345',15068,1,'000217788801'
	EXEC EmbarquePHSPI 'PH12345',15068,1,'000217788801'
		
*/	

	DECLARE @ValorIdCaja INT, @ExistePedido INT
	
	SET @ValorIdCaja = 0
	
	
	--SELECT @ExistePedido = Count(IdEmbarquePH) FROM EmbarquePH
	--WHERE Pedido = @Pedido AND IdSucursalPH = @IdSucursalPH
	
	
	--IF (@ExistePedido > 0)
	--BEGIN	
		SELECT @ValorIdCaja = COALESCE(Max(Idcaja),0) 
		FROM EmbarquePH
		WHERE Pedido = @Pedido AND IdSucursalPH = @IdSucursalPH
	
		IF (@ValorIdCaja > 0)
		BEGIN
			SET @ValorIdCaja = @ValorIdCaja + 1		
		END
		ELSE
		BEGIN
			SET @ValorIdCaja = 1		
		END
		
	--END
	
	--UPDATE EmbarquePH SET  IdCaja = @ValorIdCaja
	--WHERE		Pedido			= @Pedido 
	--		AND IdSucursalPH	= @IdSucursalPH
	--		AND IdCaja			= 0 
			
	RETURN @ValorIdCaja
	--SELECT @ValorIdCaja
			 	 
END
GO

GRANT EXEC ON EmbarquePHIdCajaSPS TO PUBLIC
GO
