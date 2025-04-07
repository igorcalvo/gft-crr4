# CashFlow POC - gft-crr4
Sistema de fluxo de caixa com consolidação diária, categorização e visualização de entradas e saídas, além de um painel de controle de tarefas (Hangfire).

### Arquitetura

![image](https://github.com/user-attachments/assets/a9761daf-94d5-4279-94a7-e40a090bb503)

![image](https://github.com/user-attachments/assets/96f6a2d8-5152-40e5-b4da-756a10834a47)

### Funcionalidades principais

- CRUD de **Entradas (Entries)** com tipo (crédito/débito), valor e contraparte
- Cadastro de **Contrapartes** envolvidas nas transações
- Consolidação diária do saldo
- Agendamento automático de consolidações via **Hangfire**
- Dashboard do Hangfire acessível para execução manual de tarefas
- API com documentação via Swagger

### Como rodar localmente
#### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQLite](https://www.sqlite.org/download.html) (opcional, pois o arquivo `.db` será gerado automaticamente)

#### Passos

1. Clone o repositório:

```bash
git clone https://github.com/igorcalvo/gft-crr4.git
cd gft-crr4
```

2. Restaure os pacotes e compile:

```bash
dotnet restore
dotnet build
```

3. Rode as migrações para criar o banco SQLite:
```bash
cd CashFlow.API
dotnet ef database update --project CashFlow.Infrastructure
```

4. Inicie a API:
```bash
dotnet run --project CashFlow.API.csproj
```

5. Acesse:
Swagger: [https://localhost:7207/swagger/index.html](https://localhost:7207/swagger/index.html])
Dashboard do [Hangfire: http://localhost:7207/hangfire](http://localhost:7207/hangfire)

### Estrutura da Solução

- CashFlow.Domain: Entidades de domínio e enums
- CashFlow.Infrastructure: Entity Framework, configurações e repositórios
- CashFlow.Core: Lógica de negócios e serviços como ConsolidationService
- CashFlow.API: Ponto de entrada do projeto, configurações de Swagger, Hangfire, AutoMapper, etc.
- CashFlow.Tests: Com testes unitários dos serviços

### Hangfire: Agendador de Tarefas

O Hangfire é utilizado para:

- Agendar tarefas recorrentes (como AddConsolidation() todos os dias à meia-noite)
- Executar tarefas sob demanda através do painel web
- Monitorar e rastrear falhas de jobs com persistência no banco de dados

Isso garante que a consolidação do fluxo de caixa seja feita automaticamente sem intervenção manual.

### TODO
- Logs não foram adicionados
- Authorização nas controllers
- Talvez uma infraestrutura utilizando mensageria fosse melhor, dado a natureza do problema
- Mais testes unitários
- Outra API para rodar apenas o Hangfire para melhor segregação
- DTOs e Mappings para outras entidades, como Counterparty

### Migrations
```powershell
CashFlow.API>

# Add
dotnet ef migrations add InitialCreate --project ../CashFlow.Infrastructure --startup-project . --output-dir ../CashFlow.Infrastructure/Migrations

# Remove
dotnet ef migrations remove --project ../CashFlow.Infrastructure --startup-project .

# Update
dotnet ef database update
```

