
    1 # API de Oficina Mecânica - Sistema de Orçamentos
    2
    3 Esta é uma API desenvolvida em **.NET 10** para gerenciar orçamentos de uma oficina mecânica. O sistema permite o
      cadastro de orçamentos vinculados a clientes e veículos, realizando o cálculo automático de totais e persistindo
      os dados em um banco de dados **MySQL**.
    4
    5 ## Tecnologias Utilizadas
    6
    7 *   **Linguagem:** C#
    8 *   **Framework:** .NET 10 (ASP.NET Core API)
    9 *   **ORM:** Entity Framework Core
   10 *   **Banco de Dados:** MySQL (via Pomelo EntityFrameworkCore)
   11 *   **Documentação:** Swagger/OpenAPI
   12
   13 ##  Requisitos de Negócio Implementados
   14
   15 - [x] Cadastro de orçamento com Cliente e Veículo.
   16 - [x] Validação de itens obrigatórios (descrição, quantidade > 0, valor > 0).
   17 - [x] Cálculo automático do total do orçamento e subtotal por item.
   18 - [x] Retorno de mensagens de erro claras para dados inválidos.
   20
   21 ##  Configuração e Instalação
   22
   23 ### 1. Pré-requisitos
   24 *   [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.
   25 *   Servidor [MySQL](https://www.mysql.com/) rodando localmente ou remotamente.
   26
   27 ### 2. Configurar o Banco de Dados
   28 No arquivo `appsettings.json`, ajuste a sua string de conexão:
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=3306;Database=Teste_MySQL;User=root;Password=@Password;"
  }

   1
   2 ### 3. Rodar a Aplicação
   3 Navegue até a pasta do projeto e execute:
  dotnet restore
  dotnet run

   1 *A API está configurada para criar o banco de dados e as tabelas automaticamente na primeira execução
     (`db.Database.EnsureCreated()`).*
   2
   3 ##  Endpoints
   4
   5 ### **POST** `/orcamento`
   6 Cadastra um novo orçamento no sistema.
   7
   8 **Exemplo de Body (JSON):**
  {
    "clienteId": 10,
    "veiculoId": 25,
    "itens": [
      {
        "descricao": "Troca de óleo",
        "quantidade": 1,
        "valorUnitario": 120.00
      },
      {
        "descricao": "Filtro de óleo",
        "quantidade": 1,
        "valorUnitario": 45.00
   1
   4
   5 ## 🧪 Como Testar (Curl)
  curl -X POST https://localhost:7120/orcamento \
  -H "Content-Type: application/json" \
  -d '{
    "clienteId": 10,
    "veiculoId": 25,
    "itens": [{"descricao": "Serviço Teste", "quantidade": 1, "valorUnitario": 50.0}]
  }'
