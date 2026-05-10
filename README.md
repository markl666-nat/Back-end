# Ponos.official — Cat Base Shop (Backend)

ASP.NET Core 8 Web API for the Cat Base Shop e-commerce demo based on
_The Battle Cats_ by PONOS Corporation.

Built as a coursework project for **TUM (Technical University of Moldova)**,
Faculty of Computers, Informatics and Microelectronics, discipline
_Web Technologies_.

## Stack

- **.NET 8** Web API
- **Entity Framework Core 8** with SQL Server provider
- **AutoMapper 13** for DTO ↔ Entity mapping
- **JWT Bearer** authentication via `System.IdentityModel.Tokens.Jwt 8.0.2`
- **Swashbuckle.AspNetCore 6.6.2** for Swagger UI

## Architecture

Three-tier separation per coursework requirements (Lab 3):
BattleCats.Domains       Entities, DTOs, enums, models
BattleCats.DataAccess    DbContext (Product, User, Order), migrations, seed
BattleCats.BusinessLogic Actions / Flows / facade, AutoMapper, JWT services
BattleCats.Api           Controllers, Program.cs, JWT middleware, Swagger

Pattern: **Action (internal, low-level) → Flow (public, interface) →
Facade (BusinessLogic)**. Each domain owns its DbContext and a
matching interface in `Interface/I*.cs`.

## API endpoints

| Method | Route                       | Roles            | Description           |
|--------|-----------------------------|------------------|-----------------------|
| GET    | /api/battleitem/getAll      | public           | List all items        |
| GET    | /api/battleitem/id?id=N     | public           | Single item with stats|
| POST   | /api/battleitem             | Admin, Manager   | Create                |
| PUT    | /api/battleitem             | Admin, Manager   | Update                |
| DELETE | /api/battleitem/id?id=N     | Admin            | Delete                |
| POST   | /api/session/auth           | public           | Login → JWT           |
| GET    | /api/session/status         | public           | Session health-check  |
| POST   | /api/reg                    | public           | Register new user     |
| GET    | /api/user/getAll            | Admin            | List all users        |
| PUT    | /api/user/role              | Admin            | Change user role      |
| DELETE | /api/user/id?id=N           | Admin            | Delete user           |
| GET    | /api/order                  | Admin, Manager   | List orders           |
| GET    | /api/order/{id}             | authenticated    | Get one order         |
| POST   | /api/order                  | authenticated    | Create order          |
| PUT    | /api/order                  | Admin, Manager   | Update order          |
| DELETE | /api/order/{id}             | Admin            | Delete order          |
| GET    | /api/health                 | public           | Health check          |

Protected endpoints expect `Authorization: Bearer <JWT>` header.
Unauthorized → **401**, wrong role → **403**.

## Database

Three EF Core contexts share a single database `BattleCatsDb`:

- **ProductContext** — BattleItem, ItemCategory, BattleItemLore,
  DescriptionAdvanced (Health / Attack / Range stats), ProductImgData
- **UserContext** — UserData with Role enum (User=1, Manager=20, Admin=30)
  and MD5+salt hashed passwords
- **OrderContext** — OrderData, OrderItemData with 1:N relation via
  Fluent API

Demonstrates all relation types:
- **One-to-One** — BattleItem ↔ BattleItemLore ↔ DescriptionAdvanced
- **One-to-Many** — BattleItem → ProductImgData, OrderData → OrderItemData
- **Many-to-One** — BattleItem → ItemCategory

## Seed data

- **19 unique battle items**: 12 Cat Units, 3 Base Upgrades, 2 Buffs,
  2 Gacha Capsules — all with their own images at `/images/cats/`
- **4 categories**, **12 stat sets** for combat units, **19 lore entries**
- **3 test users** with different roles (see frontend README)

Passwords hashed via `PasswordHasher.Hash(password)` =
`MD5(password + "tw_curs2026")`.

## Running locally

Prerequisites:
- .NET 8 SDK
- SQL Server (LocalDB / Express / Developer)

Configure connection string in `BattleCats.Api/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BattleCatsDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Apply migrations (in order matters):
```bash
dotnet ef database update --context ProductContext --project BattleCats.DataAccess
dotnet ef database update --context UserContext    --project BattleCats.DataAccess
dotnet ef database update --context OrderContext   --project BattleCats.DataAccess
```

Run the API:
```bash
cd BattleCats.Api
dotnet run
```

API listens on `http://localhost:5257`. Swagger at `/swagger`.

## JWT testing in Swagger

1. `POST /api/session/auth` with body:
```json
   { "login": "admin", "password": "admin123" }
```
2. Copy the `token` from the response
3. Click **Authorize** 🔓 at the top of Swagger, paste the token
   (no `Bearer ` prefix — Swagger adds it automatically)
4. Now protected endpoints work with the admin role

You can decode the resulting JWT at https://jwt.io to inspect the
claims (`nameid`, `unique_name`, `role`, `exp`, `iss`, `aud`).

## Lab coverage (TUM Web Technologies)

- **Lab 1** — UML diagrams (class, state, component, deployment,
  activity, collaboration). Located in `/Diagrams/` of the original
  Lab 1 report.
- **Lab 3** — Full Business Logic layer with CRUD via API +
  AutoMapper-based entity ↔ DTO mapping.
- **Lab 4** — Microsoft SQL Server + Entity Framework Core
  migrations + seed data with all relation types.
- **Lab 5** — Role-based access control via JWT and
  `[Authorize(Roles=...)]` attribute. Modern equivalent of the
  classical `ActionFilterAttribute` (`AdminMod`) — recommended by
  Microsoft for ASP.NET Core 8.
- **Lab 6** — Integrated final build with the React frontend.

## Frontend

Sister repository: **[Front-end](https://github.com/markl666-nat/Front-end)**
— React + TypeScript + Vite consumer of this API.

## Authors

- **markl666-nat** (Маринский М.)
- **radicq** (Рада Черный)

---

© 2026 Ponos.official — built for TUM coursework defense.