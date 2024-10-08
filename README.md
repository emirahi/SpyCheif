
# SpyChief

**SpyChief** merkezi bir veri toplama ve analiz platformudur. Proje, bug bounty süreçlerinde toplanan verilerin merkezi bir yerde birleştirilmesini ve daha yönetilebilir hale getirilmesini hedefler. Mevcut sistem, manuel veri ekleme ve servisler aracılığıyla veri birleştirme işlevselliği sağlar. Gelecek özellikler arasında dosya içe aktarma, Shodan desteği ve otomatik veri analiz süreçleri bulunmaktadır.

## Amaç
SpyChief'in amacı, bug bounty araştırmalarında toplanan tüm verilerin tek bir noktada toplanmasını sağlamak ve bu verileri daha görünür, analiz edilebilir ve yönetilebilir hale getirmektir. Proje, ilerleyen süreçlerde dosya import seçenekleri ve veri paylaşım özellikleri ile farklı araçlardan elde edilen çıktıları entegre etme kapasitesine sahip olacaktır.

## Mevcut Özellikler

1. **Manuel Veri Ekleme**: Kullanıcılar verileri manuel olarak sisteme ekleyebilir.
2. **Servisler Aracılığıyla Veri Birleştirme**: Farklı servislerden gelen veriler merkezi bir noktada birleştirilebilir.

## Gelecek Özellikler

1. **JSON, XML, CSV Formatlarından İçe Aktarma**: Farklı veri formatlarından dosya içe aktarma özelliği eklenecek.
2. **Shodan Desteği**: Shodan aracılığıyla veri çekme ve analiz desteği sağlanacak
3. **Arkaplanda Otomatik Veri Analizi**: Veriler arkaplanda otomatik olarak analiz edilecek.
4. **Kullanıcı Giriş Altyapısı**: Sisteme kullanıcı girişi eklenerek yetkilendirme yapılabilecek.
5. **Uygulama İçerisinden Program Kullanımı**: Kullanıcılar uygulama üzerinden araçları yönetebilecek.
3. **Veri Paylaşımı**: Toplanan verilerin diğer kullanıcılarla paylaşımı sağlanacak. 

## Kullanılan Teknolojiler

1. **ASP.NET Core**: Ana backend altyapısı için kullanılır.
2. **RabbitMQ**: Servisler pub/sub deseni ile veri girişi yapabilir
3. **MySQL**: SpyChief için veritabanı yönetimi için kullanılır.
4. **Mongodb**: Servisler için uygulama verilerini içerir.

## Yazılım Mimarisi

- Microservice Architecture
- Onion Architecture

## Tasarım Desenleri

- SOLID
- Mediatr Patern
- Domain Driven Design


