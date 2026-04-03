
# FilmApi

FilmApi; film, kategori, kisi, yorum ve ozellik yonetimi icin gelistirilmis katmanli bir ASP.NET Core Web API projesidir.

## Neden Bu Proje?

- Katmanli mimari ile sorumluluklari ayirir: `API`, `Application`, `Domain`, `Infrastructure`.
- DTO ve servis yapisi ile controller seviyesinde sade ve okunabilir akis sunar.
- Swagger ile hizli endpoint testine imkan verir.
- EF Core ile SQL Server tarafinda tutarli veri erisimi saglar.

## Teknolojiler

- `.NET 8`
- `ASP.NET Core Web API`
- `Entity Framework Core`
- `SQL Server`
- `AutoMapper`
- `FluentValidation`
- `Swagger / Swashbuckle`

## Mimari

```
FilmApi/
├── FilmApi.API/             # Controller, Program, DI, middleware
├── FilmApi.Application/     # Service abstractions/implementations, DTO, mapper
├── FilmApi.Domain/          # Entity ve domain kurallari
├── FilmApi.Infrastructure/  # DbContext, repository implementasyonlari
├── FilmApi.Models/          # API request modelleri
└── FilmApi.sln
```

## Hemen Basla

1. Projeyi klonla:

```bash
git clone https://github.com/cemrekarabulut/FilmApi.git
cd FilmApi
```

2. Veritabani baglantisini ayarla (`FilmApi.API/appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=FilmApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Migration uygula:

```bash
dotnet ef database update --project FilmApi.Infrastructure --startup-project FilmApi.API
```

4. Uygulamayi calistir:

```bash
dotnet run --project FilmApi.API
```

5. Swagger arayuzune git:

- `https://localhost:xxxx/swagger`

## Ornek Endpointler

| Method | Endpoint | Aciklama |
|---|---|---|
| `GET` | `/api/films` | Tum filmleri listeler |
| `GET` | `/api/films/{id}` | Filme gore detay getirir |
| `POST` | `/api/films` | Yeni film olusturur |
| `PUT` | `/api/films/{id}` | Film gunceller |
| `DELETE` | `/api/films/{id}` | Film siler |

## Projede Yapilan Iyilestirmeler

- Build artifact'lari (`bin/obj`) versiyon kontrolunden cikarildi.
- Depo kokune `.gitignore` eklendi.
- Kod stili standardizasyonu icin `.editorconfig` eklendi.
- `Film.TicketPrice` alaninda EF Core precision konfigrasyonu eklenerek olasi truncation riski giderildi.
- README daha profesyonel ve onboarding odakli hale getirildi.

## Gelistirme Komutlari

```bash
dotnet restore
dotnet build FilmApi.sln
dotnet test
```

> Not: Projede test projesi yoksa `dotnet test` adimi test calistirmadan tamamlanir.
