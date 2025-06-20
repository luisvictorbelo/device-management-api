# Device Manager API

**Device Manager** é uma API RESTful desenvolvida com **.NET 9**, voltada para o gerenciamento de **clientes**, **dispositivos** e **eventos**, com suporte a autenticação baseada em **JWT** e arquitetura baseada em Clean Archictecture.

## 🚀 Funcionalidades

- ✅ Cadastro e autenticação de usuários com roles (`Admin`, etc.)
- ✅ CRUD de Clientes
- ✅ CRUD de Dispositivos
- ✅ Registro de Eventos
- ✅ Filtro de eventos por período
- ✅ Autenticação com JWT
- ✅ Proteção de rotas por role
- ✅ Integração com Swagger
- ✅ Cobertura de testes com xUnit + Moq

---

## 🧱 Estrutura do Projeto

```
DeviceManager
│
├───
│   ├── DeviceManager.API           # API ASP.NET Core
│   ├── DeviceManager.Application  # Serviços, DTOs e Automapper
│   ├── DeviceManager.Domain       # Entidades e Interfaces
│   └── DeviceManager.Infrastructure # Repositórios e acesso ao banco
│
└── 
    └── DeviceManager.Tests        # Testes unitários com xUnit e Moq
```

---

## 🔧 Tecnologias Utilizadas

- [.NET 9](https://dotnet.microsoft.com/)
- Entity Framework Core
- SQL Server (Docker)
- AutoMapper
- JWT Authentication
- Swagger (Swashbuckle)
- xUnit e Moq

---

## 📦 Executando com Docker

```bash
docker-compose up --build
```

A API estará acessível em:

```
http://localhost:5000
```

A interface Swagger estará em:

```
http://localhost:5000/swagger
```

---

## 🔐 Autenticação JWT no Swagger

1. Crie um usuário usando o endpoint `/api/User` utilizando o perfil "Admin"
2. Gere um token usando o endpoint `/api/Auth/login`
3. Clique em **Authorize** no Swagger
4. Insira o token: `Bearer {seu_token}`

---

## ✅ Variáveis de Ambiente (appsettings.json)

```json
"Jwt": {
  "Key": "sua-chave-super-secreta",
  "Issuer": "DeviceManager",
  "Audience": "DeviceManagerUsers",
  "ExpirationInMinutes": 60
}
```

---

## 🧪 Executando Testes

```bash
dotnet test
```

---

## 👨‍💻 Autor

Desenvolvido por **Luís Belo**

