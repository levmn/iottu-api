# 🛜 Iottu

**Iottu** é um sistema de localização e controle de motos, desenvolvido como solução para um desafio real enfrentado pela **Mottu**, startup que oferece aluguel de motos e plataforma de entregas para empresas. A proposta surgiu a partir do *Challenge* do curso de **Análise e Desenvolvimento de Sistemas** da **FIAP**, com o objetivo de resolver ineficiências no inventário e gerenciamento da frota de motos distribuída em mais de 100 pátios físicos com plantas não padronizadas.

## 🚀 Solução

**Iottu** propõe uma solução baseada em **dispositivos IoT embarcados** e comunicação via **rede Wi-Fi em malha**, para estimar com precisão a **localização** das motos dentro dos pátios, além de fornecer um **dashboard interativo** para controle e visualização em tempo real.

O sistema permite o cadastro e gerenciamento de:

- Motos
- Tags RFID
- Antenas
- Pátios
- Usuários

## 🧱 Arquitetura

O projeto segue uma arquitetura em camadas, dividida em:

- `IottuApi`: Camada de API (Controllers)
- `IottuBusiness`: Camada de regras de negócio (Services)
- `IottuModel`: Camada de entidades (Models)
- `IottuData`: Repositórios e camada de persistência (Migrations)

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- C# 12
- Entity Framework Core
- Swagger (via Swashbuckle)
- Injeção de Dependência (built-in)
- RESTful APIs

## 📌 Endpoints

A API possui os seguintes recursos disponíveis via HTTP:

- `GET /api/moto`
- `GET /api/tag`
- `GET /api/patio`
- `GET /api/antena`
- `GET /api/usuario`
- `POST`, `PUT`, `DELETE` para todos os recursos acima

## ▶️ Executando a aplicação

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio ou VS Code

### Configuração do Ambiente

O projeto utiliza variáveis de ambiente para configuração. Existem dois arquivos importantes:

- `.env.sample`: Arquivo de exemplo que contém todas as variáveis necessárias com valores padrão
- `.env`: Arquivo real com as configurações do ambiente (não versionado)

Para configurar o ambiente:

1. Copie o arquivo `.env.sample` para `.env`
2. Ajuste os valores no arquivo `.env` de acordo com seu ambiente local

```bash
cp .env.sample .env
```

### Passos para rodar:

```bash
# Restaurar dependências
dotnet restore

# Compilar a solução
dotnet build

# Rodar a API
dotnet run --project IottuApi
```

A API estará disponível por padrão em:  
👉 `http://localhost:5203`

---

## 📄 Exemplo de Requisição

```http
POST /api/moto
Content-Type: application/json

{
  "status": "Ativa",
  "modelo": "Yamaha XTZ",
  "placa": "XYZ-1234",
  "tagId": 1,
  "patioId": 2
}
```

---

## 🧑‍💻 Desenvolvedores

- [RM558948] [Allan Brito Moreira](https://github.com/Allanbm100)
- [RM558868] [Caio Liang](https://github.com/caioliang)
- [RM98276] [Levi Magni](https://github.com/levmn)

