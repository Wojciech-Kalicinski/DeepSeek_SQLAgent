SQL Query Generator using Ollama and .NET 9
📌 Overview
This project is a .NET 9 console application that generates SQL queries based on natural language prompts using Ollama and the Microsoft.Extensions.AI library. It supports simple SQL queries but may sometimes produce incorrect results.

🛠 Technologies Used
.NET 9
Ollama (local LLM inference)
Microsoft.Extensions.AI (prerelease)
C#
⚙️ Installation & Setup
1️⃣ Install .NET 9
Make sure you have .NET 9 installed. If not, download it from:
🔗 https://dotnet.microsoft.com/en-us/download/dotnet/9.0

2️⃣ Install Ollama
Ollama is required to run the local AI model.

🔹 Windows:
Download Ollama from the official site:
🔗 https://ollama.com/download
Run the installer and follow the on-screen instructions.
 
ollama serve
3️⃣ Run the Application
Clone this repository and navigate to the project folder:

🚀 Usage
Start the console application.
You can add Your own database schema.
Enter a prompt (e.g., "How many customers are there.").
The AI will generate an SQL query based on the database schema.
Copy and execute the query in your SQL environment.

⚠️ Limitations
Works best with simple SQL queries.
May produce incorrect or non-optimized SQL.
Does not validate if the query will execute correctly.

🔧 Future Improvements
Improve query validation.
Add support for more SQL dialects.
Enhance error handling.
