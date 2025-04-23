# DesafioMiranteinfo
Desafio Gestão de tarefas
# ToDo API

## Como rodar

1. Clonar o repositório
2. Executar o comando:
   ```bash
   executar a partir do Visual Studio pelo botão run http ou no console pelo Docker descrito abaixo no Buikd Docker
   ```
3. Acessar a documentação no navegador:
   ```
   https://localhost:5001/swagger
   ```
## Funcionalidades
- Criar, listar, atualizar e excluir tarefas
- Filtrar por status e data de vencimento

## Tecnologias
- .NET 8
- Entity Framework Core (InMemory)
- Padrões Repository e Unit of Work
- Swagger para documentação
- Injeção de dependência

## Build no Docker
1. Executar no terminal no diretorio do projeto
docker-compose up --build
2. Acessar no Browse
http://localhost:5000/swagger

## Executar o Test
1. Executar o comando:
```bash
entrar no diretorio ToDoApi.Tests
dotnet test
