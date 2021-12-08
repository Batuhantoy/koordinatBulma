using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Threading;

namespace kordinatbulma
{
    class APİ
    {
        public static string koordinatıbul(string yer)
        {
            string apikey ="";
            string boylam;
            string enlem;
            string sonuc;

            /*Google Maps'e lokasyon ve API key bilgilerini içeren bir query string gönderecegiz*/
            string Spath = "http://maps.google.com/maps/geo?q=" + yer + "&output=csv&key=" + apikey;

            /*Web sayfasına erişim için bir web client nesnesi oluşturuyoruz*/
            WebClient WebCli = new WebClient();

            /*Spath değişkenindeki URL içeriğini yani sorgunun sonucunu virgullerden ayırarak bir array içerisine atıyoruz*/
            string[] SonuclarKumesi = WebCli.DownloadString(Spath).ToString().Split(',');

            /*Sadece arrayin 2. ve 3. elemanlarını kullanmamızın nedeni 2. ve 3. elemanlarda boylam ve enlem değerlerinin
            0. ve 1. elemanlarda lokasyonun bulunup bulunmadığı durum parametrelerinin yer almasıdır.*/
            boylam = SonuclarKumesi.GetValue(2).ToString();
            enlem = SonuclarKumesi.GetValue(3).ToString();

            sonuc = "Enlem  : " + enlem + "\n" + "Boylam: " + boylam;

            return sonuc;
            
        }
    }
}
