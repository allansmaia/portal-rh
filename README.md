## Sobre o projeto

Portal RH e um sistema de gestao de recursos humanos desenvolvido em C# com .NET 8.
O projeto permite cadastrar funcionarios e departamentos, calcular folha de pagamento, ferias e gerar relatorios.

## Tecnologias

- C# / .NET 8
- xUnit (testes automatizados)
- GitHub Actions (CI/CD)

## Como rodar

### Pre-requisitos
- .NET 8 SDK instalado

### Compilar o projeto
dotnet build

### Rodar os testes
dotnet test

## Estrutura do projeto

- `src/PortalRH/` — codigo de producao (classes, regras de negocio)
- `tests/PortalRH.Tests/` — testes automatizados com xUnit
- `.github/workflows/` — configuracao do GitHub Actions

## CI/CD

Este projeto utiliza GitHub Actions para integracao continua.
A cada Pull Request aberto para a branch `main`, o workflow executa automaticamente:

1. Checkout do codigo
2. Instalacao do .NET 8
3. Build do projeto
4. Execucao dos testes

O merge so e permitido quando todos os testes passam.
