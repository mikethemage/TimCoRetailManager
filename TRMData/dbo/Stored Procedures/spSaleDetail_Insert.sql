﻿CREATE PROCEDURE [dbo].[spSaleDetail_Insert]
	@SaleId int,
	@ProductId int,
	@Quantity int,
	@PurchasePrice money,
	@Tax money
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO SaleDetail (SaleId, ProductId, Quantity, PurchasePrice, Tax)
	Values (@SaleId, @ProductId, @Quantity, @PurchasePrice, @Tax);
END
