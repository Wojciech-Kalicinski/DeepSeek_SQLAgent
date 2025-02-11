using Microsoft.Extensions.AI;

IChatClient chatClient = new OllamaChatClient("http://localhost:11434", "deepseek-r1");

Console.WriteLine("Enter your prompt:");

var userMessage = Console.ReadLine();

List<ChatMessage> messages =
[
    new(ChatRole.System, "You are an expert in writing SQL queries. Respond ONLY with SQL queries based on the provided database schema."),
    
    // Podział schematu na mniejsze fragmenty
    new(ChatRole.System, "TABLE: SalesLT.Address\nCOLUMNS: AddressID (int, PK), AddressLine1 (nvarchar(60)), AddressLine2 (nvarchar(60)), City (nvarchar(30)), StateProvince (nvarchar(50)), CountryRegion (nvarchar(50)), PostalCode (nvarchar(15)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),
    
    new(ChatRole.System, "TABLE: SalesLT.Customer\nCOLUMNS: CustomerID (int, PK), NameStyle (bit), Title (nvarchar(8)), FirstName (nvarchar(50)), MiddleName (nvarchar(50)), LastName (nvarchar(50)), Suffix (nvarchar(10)), CompanyName (nvarchar(128)), SalesPerson (nvarchar(256)), EmailAddress (nvarchar(50)), Phone (nvarchar(25)), PasswordHash (varchar(128)), PasswordSalt (varchar(10)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),
    
    new(ChatRole.System, "TABLE: SalesLT.CustomerAddress\nCOLUMNS: CustomerID (int, FK), AddressID (int, FK), AddressType (nvarchar(50)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.Product\nCOLUMNS: ProductID (int, PK), Name (nvarchar(50)), ProductNumber (nvarchar(25)), Color (nvarchar(15)), StandardCost (money), ListPrice (money), Size (nvarchar(5)), Weight (decimal(8,2)), ProductCategoryID (int, FK), ProductModelID (int, FK), SellStartDate (datetime), SellEndDate (datetime), DiscontinuedDate (datetime), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.ProductCategory\nCOLUMNS: ProductCategoryID (int, PK), ParentProductCategoryID (int, FK), Name (nvarchar(50)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.ProductDescription\nCOLUMNS: ProductDescriptionID (int, PK), Description (nvarchar(400)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.ProductModel\nCOLUMNS: ProductModelID (int, PK), Name (nvarchar(50)), CatalogDescription (xml), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.ProductModelProductDescription\nCOLUMNS: ProductModelID (int, FK), ProductDescriptionID (int, FK), Culture (nchar(6)), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.SalesOrderDetail\nCOLUMNS: SalesOrderID (int, FK), SalesOrderDetailID (int, PK), OrderQty (smallint), ProductID (int, FK), UnitPrice (money), UnitPriceDiscount (money), LineTotal (computed), rowguid (uniqueidentifier), ModifiedDate (datetime)"),

    new(ChatRole.System, "TABLE: SalesLT.SalesOrderHeader\nCOLUMNS: SalesOrderID (int, PK), RevisionNumber (tinyint), OrderDate (datetime), DueDate (datetime), ShipDate (datetime), Status (tinyint), OnlineOrderFlag (bit), SalesOrderNumber (nvarchar(25)), PurchaseOrderNumber (nvarchar(25)), AccountNumber (nvarchar(15)), CustomerID (int, FK), ShipToAddressID (int, FK), BillToAddressID (int, FK), ShipMethod (nvarchar(50)), SubTotal (money), TaxAmt (money), Freight (money), TotalDue (computed), rowguid (uniqueidentifier), ModifiedDate (datetime)"),
    
    // Przykład zapytania, aby wymusić poprawny format odpowiedzi
    new(ChatRole.System, "Example:\nUser: 'How many categories are there?'\nSQL Query: 'SELECT COUNT(*) FROM SalesLT.ProductCategory;'"),
    
    new(ChatRole.User, userMessage)
];

await foreach (var chunk in chatClient.CompleteStreamingAsync(messages))
{
    Console.Write(chunk.Text);
}
