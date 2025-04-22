# ToDo API

API RESTful para gerenciamento de tarefas.

## Como Rodar

```bash
dotnet build
dotnet run --project ToDoApi.API
```

## Endpoints

- GET /api/tasks
- GET /api/tasks?status=Pending
- POST /api/tasks
- PUT /api/tasks/{id}
- DELETE /api/tasks/{id}

## Docker

```bash
docker build -t todoapi .
docker run -d -p 5000:80 todoapi
```