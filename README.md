# 🛜 Iottu

**Iottu** é um sistema inteligente de localização e controle de motos, desenvolvido como solução para um desafio real enfrentado pela **Mottu**, startup que oferece aluguel de motos e plataforma de entregas para empresas. A proposta surgiu a partir do *Challenge* do curso de **Análise e Desenvolvimento de Sistemas** da **FIAP**, com o objetivo de resolver ineficiências no inventário e gerenciamento da frota de motos distribuída em mais de 100 pátios físicos com plantas não padronizadas.

## 🚀 Solução

O **Iottu** propõe uma solução baseada em **dispositivos IoT embarcados** e comunicação via **rede Wi-Fi em malha**, para estimar com precisão a **localização** das motos dentro dos pátios, além de fornecer um **dashboard interativo** para controle e visualização em tempo real.

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
- `IottuData`: Repositórios e camada de persistência

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

[RM558948] Allan Brito Moreira
[RM558868] Caio Liang 
[RM98276] Levi Magni

