CREATE PROCEDURE Instances.[spUser_AddProduct]
	@Name nvarchar(50),
	@Description nvarchar(50),
	@ProductImageUris nvarchar(500),
	@ValidSkus nvarchar(100)
AS
	Insert into Instances.[Products] (Name,Description,ProductImageUris,ValidSkus)
	values (@Name,@Description,@ProductImageUris,@ValidSkus)
RETURN 0
