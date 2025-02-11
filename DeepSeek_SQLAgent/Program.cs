using Microsoft.Extensions.AI;

IChatClient chatClient = new OllamaChatClient("http://localhost:11434", "deepseek-r1");

Console.WriteLine("Enter your prompt:");

var userMessage = Console.ReadLine();

List<ChatMessage> messages =
[
    new(ChatRole.System, "You are an expert in writing SQL queries. Respond ONLY with SQL queries based on the provided database schema."),
    new(ChatRole.System, "Database Schema:\nCREATE TABLE SalesLT.ProductCategory(\n ProductCategoryID INT PRIMARY KEY,\n Name NVARCHAR(100) NOT NULL\n);"),
    new(ChatRole.System, "Example:\nUser: 'How many categories are there?'\nSQL Query: 'SELECT COUNT(*) FROM SalesLT.ProductCategory;'"),
     
];

await foreach (var chunk in chatClient.CompleteStreamingAsync(messages))
{
    Console.Write(chunk.Text);
}


 

 