using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{  //magic string strigleri ayrı ayrı yazmak bu standart olması için constants(sabit) da topladık
    public static class Messages //static verirsek onu newlemeyiz her yerde direk Mssages. şeklinde kullanabilir
    {
        public static string CarNameInvalited = "Araba ismi geçersiz";
        public static string Listed ="Listeleme işlemi başarılı";
        public static string MainteanceTime="Sistem bakımda";
        public static string Added="Kayıt işlemi başarılı";
        public static string Updated="Güncelleme işlemi başarılı";
        public static string Deleted="Silme işlemi başarılı";
        public static string AddedError= "Kayıt işlemi başarısız";
        public static string UpdatedError = "Güncelleme işlemi başarısız";
        public static string DeletedError = "Silme işlemi başarısız";
    }
}
