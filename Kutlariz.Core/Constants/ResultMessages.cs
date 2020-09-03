using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Core.Constants
{
    public static class ResultMessages
    {
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string WrongPassword = "Giriş başarısız. Email ve parolanız uyuşmuyor.";
        public const string LoginLockout = "Çok fazla başarısız giriş denemesinden dolayı işlemleriniz askıya alındı. Lütfen 5 dakika sonra tekrar deneyiniz.";

        public const string LoginSuccess = "Giriş başarılı. Tekrar hoşgeldiniz.";
        public const string LogoutSuccess = "Çıkış başarılı.";
        public const string RegisterSuccess = "Kullanıcı kaydı başarılı. Artık giriş yapabilirsiniz.";

        public const string CreateBirthdaySuccess = "Doğum günü başarıyla oluşturuldu.";
        public const string DeleteBirthdaySuccess = "Doğum günü başarıyla silindi.";
        public const string UpdateBirthdaySuccess = "Doğum günü başarıyla güncellendi.";

        public const string PaymentSuccess = "Siparişiniz alındı. En kısa zamanda tarafınıza dönüş yapılacaktır.";
    }
}
