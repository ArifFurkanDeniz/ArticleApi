# ArticleApi

- Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?

UnitOfWork: Tek bir db context üzerinde yapılacak tüm db transaction'larını aynı anda gerçekleştirmeyi sağlar, 
böylece işlem sırasında hata olması durumunda bütünlük sağlanmış olur.

Repository: Tüm database işlemleri bu desen üzerinden kullanılarak türetilir, bu da işlemlerin hem tek noktadan 
hem de belirli bir düzen içinde kalmasını sağlar.

DTO: Bir çok nedeni vardır fakat bu projede en önemli etkisi database'deki herhangi alanın adı değişse bile apiden 
çıkan veya apiye gelen modellerde bir değişikliğe neden olunmaz.

DI: Bağımlılıkları ortadan kaldırır bu da projenin ileriye dönük gelişiminde kolaylık sağlar.

BLL: Tüm süreçsel işler bu katmanda yapılarak okunabilirlik arttırılır ve süreç ile ilgili bir değişiklik olacağı zaman 
sadece bu katman ile değişiklik yapılması yeterli olur.

EntityFramework: Database'i birbiri ile ilişkili objelere modelleyerek programcının database'i daha kolay kullanmasına yardımcı olur.

- Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?

Evet hepsi ile oldu,

.Net Core: Çalıştığım şirkette çnet core uygulamalar ile çalışıyorum. Hem api kısmında hem de mvc kısmında tecrübem oldu. 
Klasik .net ile daha önceden bir çok projede görev aldım.

EntityFramework: Db first ve code first şeklinde daha önce bir çok deneyimim oldu.

SeriLog: .Net core ile birlikte kullanmaya başladığım kütüphane, log4net'in alternatifi olarak görüyorum.

Jwt token: Api yazarken token oluşturma işlerimi bunu kullanarak yapıyorum. .Net core ile kullanmaya başladım.

Swagger: Api projelerinde test ve döküman sorununu büyük ölçüde ortadan kaldırıyor ayrıca client için swagger editor sayesinde 
çalışacak kodları üretmesi büyük kolaylık sağlıyor.

- Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?

Kullancı tablosu ve yönetimi eklenebilirdi.
Cache mekanizması ekleneiblirdi.

- Eklemek istediğiniz bir yorumunuz var mı?

Apiye login olmak için appsettings dosyasında UserName ve Password adlarında kullanıcı ve şifre bilgileri mevcuttur.
