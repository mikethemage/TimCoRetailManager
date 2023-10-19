CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int
AS
Begin
	set nocount on;

	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable, ProductImage
	From dbo.Product
	Where Id=@Id
end
