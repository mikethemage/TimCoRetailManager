CREATE PROCEDURE [dbo].[spSale_Lookup]
	@CashierId nvarchar(128),
	@SaleDate datetime2
AS
Begin
	set nocount on;

	SELECT Id 
	from dbo.Sale
	Where CashierId = @CashierId and SaleDate = @SaleDate;
end
