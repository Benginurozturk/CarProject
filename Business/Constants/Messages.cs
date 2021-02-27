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

        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silndi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserListed = "Kullanıcılar listelendi";

        public static string RentalListed = "Kiralanan arabalar listelendi";
        public static string RentalAdded = "Araba kiralama işlemi başarıyla Gerçekleşti";
        public static string RentalDeleted = "Araba kiralama işlemi iptal edildi";
        public static string RentalUpdated = "Araba kiralama işlemi güncellendi";
        public static string RentalFailedAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi";

        public static string CheckIfImageLimitExceded = "En fazla 5 tane fotoğraf yüklenebilir.";
        public static string CheckIfCarImageNull = "Eğer bir arabaya ait resim yoksa logo göstersin";
    }
}
