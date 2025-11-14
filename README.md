# Agenda de Tarefas

Aplicativo web ASP.NET Core MVC para gerenciamento de tarefas como projeto do curso FDevs 2025 - Upper

---

## Tecnologias

- ASP.NET Core MVC 7  
- Entity Framework Core  
- SQL Server  
- Bootstrap 5  
- C#  

---

## Requisitos

Antes de rodar o projeto, é necessário ter:

- [.NET SDK 7.x] 
- SQL Server
- Visual Studio 2022 ou VS Code  
- Git (opcional, para clonar o repositório)  

---

## Instalação

1. Clone o repositório:

git clone https://github.com/RafaDiogoJ/Trilha-do-Desenvolvedor-BackEnd-Agenda.git

2. Restaure os pacotes NuGet:

dotnet restore


3. Configure a string de conexão no `appsettings.json`:

"ConnectionStrings": {
"DataBase": "Server=SEU_SERVIDOR_SQL;Database=BancoAgenda;Trusted_Connection=True;TrustServerCertificate=True"
}


4. Crie o banco de dados e aplique migrations (caso ainda não tenha):

dotnet ef migrations add Inicial
dotnet ef database update


5. Execute o projeto


## Funcionalidades

- Ver, Adicionar, editar e excluir tarefas

- Marcar tarefas como concluídas

- Exibir tarefas do dia com status de conclusão

- Mensagem quando todas as tarefas do dia forem concluídas
