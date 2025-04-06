# gft-crr4

## Migrations
```powershell
CashFlow.API>

# Add
dotnet ef migrations add InitialCreate --project ../CashFlow.Infrastructure --startup-project . --output-dir ../CashFlow.Infrastructure/Migrations

# Remove
dotnet ef migrations remove --project ../CashFlow.Infrastructure --startup-project .

# Update
dotnet ef database update
```
