using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarDailyInValid = "Günlük ücret geçersiz";
        public static string BrandDailyInValid = "Marka geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";

        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarListed = "Arabalar listelendi";

        public static string BrandListed = "Markalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";

        public static string ColorUpdated = "renk güncellendi";
        public static string ColorAdded = "renk eklendi";
        public static string ColorDeleted = "renk silindi";
        public static string ColorListed = "renkler listelendi";

        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

       

        public static string RentalListed = "Kiralanan arabalar listelendi";
        public static string RentalAdded = "Araba kiralama işlemi başarıyla Gerçekleşti";
        public static string RentalDeleted = "Araba kiralama işlemi iptal edildi";
        public static string RentalUpdated = "Araba kiralama işlemi güncellendi";
        public static string RentalFailedAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi";
        
        
        
        public static string RentalUndeliveredCar = "Araç henüz teslim edilmedi.";
        public static string RentalNotAvailable = "Kiralama işlemi seçilen tarihler arasında uygun değil.";

        public static string CheckIfImageLimitExceded = "En fazla 5 tane fotoğraf yüklenebilir.";
        public static string CheckIfCarImageNull = "Eğer bir arabaya ait resim yoksa logo göstersin";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz bulunmuyor.";

        public static string UserValidatorPasswordError =
           "Şifre en az 8 karakter uzunluğunda, büyük-küçük harf ve sayı içermelidir.";

        public static string UserAddErrorName = "İsim uzunluğu minimum 3 harften oluşmalıdır.";
        public static string UserAddErrorPassword = "Şifre en az 4, en fazla 16 karakterden oluşmalıdır. Büyük, küçük harf, sayı, şekil içermelidir.";
        public static string UserUpdateError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserPasswordError = "Şifre hatalı.";
        public static string UserLoginSuccessful = "Giriş başarılı.";
        public static string UserEmailAlreadyExists = "Bu email adresine sahip bir kullanıcı zaten bulunuyor.";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt edildi.";
        public static string UserAccessTokenCreatedSuccessful = "Access token başarıyla oluşturuldu.";

        public static string UserAddSuccess = "Kullanıcı başarılı bir şekilde eklendi.";
        public static string UserUpdateSuccess = "Kullanıcı başarılı bir şekilde güncellendi.";
        public static string UserDeleteSuccess = "Kullanıcı başarılı bir şekilde silindi.";
        public static string UserDeleteError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserGetAllSuccess = "Kullanıcı listesi başarılı bir şekilde getirildi.";
        public static string UserGetAllError = "Kullanıcılar getirilemedi, acaba hiç kullanıcı yok mu?";
        public static string UserGetByIdSuccess = "Kullanıcıya başarıyla erişildi.";
        public static string UserGetByIdError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserCheckUserExistsError = "Kullanıcı bulunamadı gibi duruyor.";
        public static string UserNotFoundError = "Kullanıcı bulunamadı";

        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silndi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserListed = "Kullanıcılar listelendi";

        public static string CarImageAdded = "Araç fotoğrafı eklendi.";
        public static string CarImageUpdated = "Araç fotoğrafı güncellendi.";
        public static string CarImageDeleted = "Araç fotoğrafı silindi.";
        public static string CarImageCountOfCarError = "İlgili araca ait fotoğraf adedi maksimum sayıdadır.";

        public static string CanRent = "Araç müsait";
        public static string CantRent = "Araç müsait değil";

        public static string PaymentFailed = "Payment failed.";
        public static string PaymentSuccessful = "Payment Successful.";
        public static string CalculatedPricePerMinute = "Aracın toplam fiyatı hesaplandı.";
        public static string CarNotFound = "Araç bulunamadı.";
    }

}
