# 📝 ToDo API - Clean Architecture (.NET 8)

API RESTful para gerenciamento de tarefas (ToDos), desenvolvida como parte de um desafio técnico, seguindo boas práticas de arquitetura e qualidade de código.

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- xUnit + Moq (testes)
- Docker
- GitHub Actions (CI/CD)
- Clean Architecture (com Repository + Unit of Work + Application Layer)

---

## ⚙️ Como Rodar Localmente

### Requisitos:
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) (opcional)

### Via terminal:
```bash
git clone https://github.com/rafaelismair/teste-mirante.git
cd teste-mirante
dotnet restore
dotnet build
dotnet run --project ToDoApi.API
