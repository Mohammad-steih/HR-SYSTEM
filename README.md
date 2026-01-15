# 🏢 İnsan Kaynakları Personel Takip Sistemi (HR System)

## 📌 Projenin Amacı
Bu proje, bir işletmedeki çalışanların **personel bilgileri, izin durumları, maaş bilgileri ve performans değerlendirmelerinin**
dijital ortamda yönetilmesini amaçlamaktadır.

Sistem sayesinde insan kaynakları süreçleri daha düzenli, güvenli ve raporlanabilir hale getirilmiştir.  
Proje, **C# WinForms**, **MySQL veritabanı** ve ** katmanlı mimari** kullanılarak geliştirilmiştir.

---

## 🎯 Proje Hedefleri
- Personel bilgilerinin merkezi bir sistemde yönetilmesi  
- Kullanıcı rollerine göre yetkilendirme sağlanması  
- İzin, maaş ve performans işlemlerinin dijitalleştirilmesi  
- Raporlama ve filtreleme yeteneklerinin kazandırılması  
- OOP prensiplerinin uygulamalı olarak kullanılması  

---

## 👥 Kullanıcı Rolleri ve Yetkileri

### 🔑 Yönetici (Admin)
**Tam yetkilidir.**

**Yetkiler:**
- Tüm personel bilgilerini görüntüleme  
- İzin taleplerini onaylama veya reddetme  
- Maaş raporlarını görüntüleme  
- Performans raporlarını inceleme  
- Genel raporlara erişim  

---

### 🧑‍💼 İK Personeli (HR)
**İnsan kaynakları işlemlerini yürütür.**

**Yetkiler:**
- Yeni personel ekleme  
- Personel bilgilerini güncelleme  
- İzin kaydı oluşturma  
- Performans puanı ekleme  
- Maaş bilgilerini düzenleme  

---

### 👤 Normal Kullanıcı (Personel)
**Sınırlı yetkilidir.**

**Yetkiler:**
- Kendi izin taleplerini görüntüleme  
- Yeni izin talebi oluşturma  

---

## 🏗️ Katmanlı Mimari Yapısı

### 🗄️ Veri Erişim Katmanı (DAL)
- MySQL (phpMyAdmin) veritabanı bağlantıları  
- CRUD işlemleri  
- Personel, departman, izin, maaş ,Kullanıcılar ,Performans tabloları  

### ⚙️ İş Katmanı (BLL)
- İş kuralları uygulanır
- Kullanıcı rollerine göre yetkilendirme sağlanması
- Personel eklendiğinde kullanıcı adı ve şifre belirlenir.
- Yıllık izin süresi **30 günü geçemez**    
- Performans puanı belirli aralıkta olmalıdır  

### 🖥️ Sunum Katmanı (UI)
- WinForms arayüzü  
- Rol bazlı erişim kontrolü

### 🧱 Entity Katmanı (Models)

- Projede, veritabanı tablolarını temsil eden **Entity (Model) sınıfları** kullanılmıştır.  
Bu sınıflar, uygulamanın farklı katmanları (UI, BLL, DAL) arasında **veri taşıma (Data Transfer)** amacıyla kullanılmaktadır.
- Entity sınıfları, iş mantığı veya kullanıcı arayüzü içermez; yalnızca veriyi temsil eder.

---

## 🖥️ Uygulama Ekranları

### 🔐 Giriş Ekranı
<img width="744" height="491" alt="Screenshot 2026-01-12 235159" src="https://github.com/user-attachments/assets/b18c63a3-336f-4c7c-8ceb-438677fa5d9a" />

### 🖥️ Ana Ekranı
<img width="1913" height="1017" alt="Screenshot 2026-01-12 235323" src="https://github.com/user-attachments/assets/79bd47c3-f8e7-4667-b9cc-6c65c8b1acb2" />

---

## 🧩 Use-Case Diagram
<img width="1536" height="1024" alt="ChatGPT Image 15 Oca 2026 16_18_15" src="https://github.com/user-attachments/assets/52d411c9-b97e-4ab9-9e14-0505c2118224" />

---

## 📊 Raporlama Örnekleri
- Departman bazlı personel dağılımı  
- İzin raporları (tarih aralığına göre)  
- Maaş raporları (toplam ve ortalama maaş)  
- Performans raporları  

---

## 🧱 OOP Kavramlarının Kullanımı

### 📦 Kullanılan Sınıflar
- Employee  
- Department  
- Leave  
- Salary  
- Performance
- Kullanıcılar
  

### 🧠 OOP İlkeleri
- **Inheritance:** BaseEntity  
- **Encapsulation:** Property kullanımı  
- **Polymorphism:** Rapor servisleri  
- **Interface:** IRepository, IReportService  

---

## 🛠️ Kullanılan Teknolojiler
- C#  
- .NET Framework  
- WinForms  
- MySQL (phpMyAdmin)  
- Visual Studio  
- Katmanlı Mimari  

---

## 🎥 Proje Tanıtım Videosu
📌 Aşağıdaki bağlantıdan projenin çalışma videosuna ulaşabilirsiniz:

👉 **YouTube Video:**  
[https://youtu.be/D5nSv9k7VUo]

---

## 📌 Sonuç
Bu proje, insan kaynakları süreçlerini dijitalleştiren, güvenli ve ölçeklenebilir bir sistem sunmaktadır.  
Akademik gereksinimlere uygun olarak geliştirilmiş ve OOP prensipleri başarıyla uygulanmıştır.
