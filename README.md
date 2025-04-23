# ✅ ToDo API – Clean Architecture com .NET 8

API RESTful para gerenciamento de tarefas (ToDos), construída com foco em boas práticas, arquitetura limpa, testes, CI/CD com GitHub Actions, deploy em Docker Hub e Railway.

---

## 🚀 Demonstração

🔗 Acesse a API pública hospedada na Railway:  
**[https://todo-api-production-77fd.up.railway.app/swagger](https://todo-api-production-77fd.up.railway.app/swagger)**

---

## 🛠️ Tecnologias Utilizadas

- ✅ ASP.NET Core 8.0 (Web API)
- 🧱 Clean Architecture (Domain, Application, Infrastructure, API)
- 🗃️ Entity Framework Core (InMemory)
- 🔄 Unit of Work + Repository Pattern
- 🧪 Testes com xUnit + Moq
- 🐳 Docker + Docker Compose
- 🔁 GitHub Actions (CI)
- ☁️ Railway (Deploy)
- 📦 Docker Hub

---

## 📦 Como rodar localmente

### 🔧 Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) *(opcional)*
- [Git](https://git-scm.com/)

### ▶️ Executar com `dotnet run`

```bash
git clone https://github.com/rafaelismair/teste-mirante.git
cd teste-mirante
dotnet restore
dotnet run --project ToDoApi.API
