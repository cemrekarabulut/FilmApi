<div align="center">

# 🎬 FilmApi

**Film, kişi, kategori ve yorum yönetimi için geliştirilmiş katmanlı ASP.NET Core REST API**

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![AutoMapper](https://img.shields.io/badge/AutoMapper-BE4B48?style=for-the-badge)

</div>

---

## 📐 Mimari

FilmApi, **Clean Architecture** ilkelerine dayalı 4 katmanlı bir yapıya sahiptir:

```
FilmApi/
├── FilmApi.API/             # Controller'lar, Program.cs, DI konfigürasyonu
├── FilmApi.Application/     # Servis soyutlamaları, implementasyonlar, DTO'lar, AutoMapper
├── FilmApi.Domain/          # Entity'ler, domain kuralları, value object'ler
└── FilmApi.Infrastructure/  # DbContext, repository implementasyonları, migration'lar
```

### Katmanlar Arası Bağımlılık

```
API → Application → Domain
Infrastructure → Domain
```

> `Infrastructure`, yalnızca `Domain`'e bağımlıdır. `Application` katmanı `Infrastructure`'ı doğrudan bilmez — bağımlılık DI ile çözülür.

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji | Versiyon | Amaç |
|---|---|---|
| .NET | 8.0 | Runtime |
| ASP.NET Core Web API | 8.0 | HTTP katmanı |
| Entity Framework Core | 8.0 | ORM & migration |
| SQL Server | — | Veritabanı |
| AutoMapper | — | DTO ↔ Entity dönüşümü |
| FluentValidation | — | Model doğrulama |
| Swashbuckle (Swagger) | — | API dokümantasyonu |

---

## 🚀 Hızlı Başlangıç

### Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB veya tam kurulum)

### Kurulum

**1. Projeyi klonla:**

```bash
git clone https://github.com/cemrekarabulut/FilmApi.git
cd FilmApi
```

**2. Bağlantı dizesini ayarla** (`FilmApi.API/appsettings.json`):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=FilmApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**3. Migration'ları uygula:**

```bash
dotnet ef database update --project FilmApi.Infrastructure --startup-project FilmApi.API
```

**4. Uygulamayı başlat:**

```bash
dotnet run --project FilmApi.API
```

**5. Swagger arayüzünü aç:**

```
http://localhost:{PORT}
```

> Swagger, geliştirme modunda kök URL'de (`/`) otomatik olarak açılır.

---

## 📡 API Endpoint Referansı

### 🎬 Film

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/film` | Tüm filmleri listeler |
| `GET` | `/api/film/{id}` | ID'ye göre film getirir |
| `GET` | `/api/film/by-category/{categoryName}` | Kategoriye göre filmleri listeler |
| `POST` | `/api/film` | Yeni film oluşturur |
| `PUT` | `/api/film/{id}` | Film günceller |
| `DELETE` | `/api/film/{id}` | Film siler |

<details>
<summary><b>POST /api/film — Örnek İstek</b></summary>

```json
{
  "filmName": "Inception",
  "ticketPrice": 75.00,
  "imdbRating": 8.8,
  "categoryIds": [1, 3]
}
```

</details>

---

### 👤 Person (Kişi)

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/person` | Tüm kişileri listeler |
| `GET` | `/api/person/{id}` | ID'ye göre kişi getirir |
| `GET` | `/api/person/{id}/films` | Aktörün oynadığı filmleri getirir |
| `GET` | `/api/person/by-feature/{featureName}` | Özelliğe göre kişileri listeler |
| `POST` | `/api/person` | Yeni kişi oluşturur |
| `POST` | `/api/person/{actorId}/add-film/{filmId}` | Aktöre film ekler |
| `PUT` | `/api/person/{id}` | Kişi günceller |
| `DELETE` | `/api/person/{id}` | Kişi siler |

<details>
<summary><b>POST /api/person — Örnek İstek</b></summary>

```json
{
  "nameSurname": "Leonardo DiCaprio",
  "gender": "Male",
  "age": 49,
  "featureId": 1
}
```

> `gender` için geçerli değerler: `Male`, `Female`, `Unknown`

</details>

---

### 🗂️ Category (Kategori)

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/category` | Tüm kategorileri listeler |
| `GET` | `/api/category/with-films` | Kategorileri filmleriyle listeler |
| `GET` | `/api/category/{id}` | ID'ye göre kategori getirir |
| `POST` | `/api/category` | Yeni kategori oluşturur |
| `PUT` | `/api/category/{id}` | Kategori günceller |
| `DELETE` | `/api/category/{id}` | Kategori siler |

---

### 💬 Comment (Yorum)

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/comment` | Tüm yorumları listeler |
| `GET` | `/api/comment/{id}` | ID'ye göre yorum getirir |
| `POST` | `/api/comment` | Yeni yorum oluşturur |
| `PUT` | `/api/comment/{id}` | Yorum günceller |
| `DELETE` | `/api/comment/{id}` | Yorum siler |

---

### ⭐ Feature (Özellik / Meslek)

| Method | Endpoint | Açıklama |
|---|---|---|
| `GET` | `/api/feature` | Tüm özellikleri listeler |
| `GET` | `/api/feature/{id}` | ID'ye göre özellik getirir |
| `POST` | `/api/feature` | Yeni özellik oluşturur |
| `PUT` | `/api/feature/{id}` | Özellik günceller |
| `DELETE` | `/api/feature/{id}` | Özellik siler |

---

## 🗃️ Veri Modeli

```
Film ──── FilmCategories ──── Category
  │
  └──── FilmActors ──── Person ──── Feature
                           │
                        Comment (bağımsız entity)
```

### Önemli İlişkiler

- **Film ↔ Category**: Many-to-many (`FilmCategories` join tablosu)
- **Film ↔ Person**: Many-to-many (`FilmActors` join tablosu)
- **Person → Feature**: Many-to-one (kişinin mesleği/özelliği)
- **Comment**: Bağımsız entity (film'e FK yoktur, iletişim formu niteliğindedir)

### Gender Value Object

`Gender`, enum değil **value object** olarak tasarlanmıştır:

```csharp
// Geçerli değerler
Gender.Male     // "Male"
Gender.Female   // "Female"
Gender.Unknown  // "Unknown"
```

---

## ⚙️ Geliştirme Komutları

```bash
# Bağımlılıkları yükle
dotnet restore

# Derle
dotnet build FilmApi.sln

# Yeni migration oluştur
dotnet ef migrations add <MigrationName> \
  --project FilmApi.Infrastructure \
  --startup-project FilmApi.API

# Migration uygula
dotnet ef database update \
  --project FilmApi.Infrastructure \
  --startup-project FilmApi.API

# Migration geri al
dotnet ef database update <OncekiMigrationAdi> \
  --project FilmApi.Infrastructure \
  --startup-project FilmApi.API
```

---

## 🏗️ Proje Kararları

### Neden `FilmApi.Models` projesi kaldırıldı?
Başlangıçta API request modelleri için ayrı bir proje oluşturulmuştu ancak tüm modeller `[Obsolete]` işaretlenerek `FilmApi.Application/DTOs` altına taşındı. Gereksiz bağımlılık yaratmamak için proje solution'dan çıkarıldı.

### Neden `Person.Job` yerine `Feature.Job` kullanılıyor?
`Person` entity'sinde `Job` adında yedek bir alan bulunmaktaydı. Kişinin mesleği asıl olarak `Feature.Job` üzerinden yönetilmektedir. Servis katmanında tutarsız erişim kritik bug'a yol açıyordu — tüm referanslar `Feature.Job` kullanacak şekilde düzeltildi.

### Neden GetById DTO'ları kaldırıldı?
`GetByIdPersonDto`, `GetByIdCategoryDto` vb. DTO'lar tanımlıydı ancak hiçbir controller veya servis bu türleri kullanmıyordu. `Result*Dto` ailesi her iki ihtiyacı da karşıladığından bu sınıflar kaldırıldı.

---

<div align="center">

Made with ❤️ — ASP.NET Core 8

</div>
