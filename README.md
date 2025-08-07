
# 📽️ FilmApi – Film Bilgi ve Yönetim Sistemi

**FilmApi**, film bilgilerini yönetmek ve erişmek için geliştirilmiş bir RESTful Web API uygulamasıdır. Bu API üzerinden film adı, açıklaması, türü, oyuncuları ve yapım yılı gibi bilgiler sorgulanabilir, eklenebilir, güncellenebilir veya silinebilir. 

---

## 🚀 Özellikler
- Film listesi görüntüleme
- Yeni film ekleme
- Film bilgisi güncelleme
- Film silme
- Oyuncu, yönetmen, tür gibi özelliklerle ilişkili veri yönetimi
- DTO (Data Transfer Object) katmanı ile veri taşımada ayrıştırılmış yapı
- Katmanlı mimari (Domain, Application, Infrastructure, API)

---

## 🧱 Kullanılan Teknolojiler

| Teknoloji        | Açıklama                     |
|------------------|------------------------------|
| .NET 8           | Backend geliştirme           |
| ASP.NET Core Web API | RESTful servis altyapısı     |
| Entity Framework Core | ORM & veri erişimi        |
| SQL Server       | Veritabanı yönetimi          |
| AutoMapper       | DTO ↔ Entity dönüşümleri     |
| Swagger (Swashbuckle) | API dokümantasyonu       |
| C#               | Backend dili                 |

---

## 📁 Proje Yapısı

```
FilmApi/
├── API/                # Sunucu giriş noktası (Controller'lar burada)
├── Application/        # Servis katmanı ve DTO'lar
├── Domain/             # Entity sınıfları
├── Infrastructure/     # Veri erişimi ve DB context
├── FilmApi.sln         # Çözüm dosyası
```

---

## ⚙️ Kurulum ve Çalıştırma

> 💡 Geliştirme ortamı: Visual Studio 2022 veya VS Code + .NET 8 SDK

1. **Projeyi klonla:**
   ```bash
   git clone https://github.com/kullaniciAdi/FilmApi.git
   cd FilmApi
   ```

2. **Veritabanını ayarla:**
   - `appsettings.json` içinde `ConnectionStrings` kısmını kendi veritabanına göre düzenle.
   - Migration ve veritabanı oluştur:
     ```bash
     dotnet ef database update
     ```

3. **Projeyi çalıştır:**
   ```bash
   dotnet run --project FilmApi.API
   ```

4. **Swagger ile test et:**
   - Tarayıcıda `https://localhost:5001/swagger` adresine git.  
   - API endpoint’lerini burada test edebilirsin.

---

## 📌 Örnek Endpoint'ler

| Endpoint             | Yöntem | Açıklama           |
|----------------------|--------|--------------------|
| `/api/films`         | GET    | Tüm filmleri getir |
| `/api/films/{id}`    | GET    | Belirli film        |
| `/api/films`         | POST   | Yeni film ekle      |
| `/api/films/{id}`    | PUT    | Film güncelle       |
| `/api/films/{id}`    | DELETE | Film sil            |

---


