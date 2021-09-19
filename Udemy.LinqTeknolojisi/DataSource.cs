using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.LinqTeknolojisi
{
    public class DataSource
    {
        List<Musteri> musteris;
        public DataSource()
        {
            musteris = new List<Musteri>();
        }

        public List<Musteri> MusteriListe()
        {
            for (int i = 1; i <= 1000; i++)
            {
                Musteri musteri = new Musteri();
                musteri.musteriNo = i;
                musteri.isim = FakeData.NameData.GetFirstName();
                musteri.soyisim = FakeData.NameData.GetSurname();
                musteri.dogumtarih = FakeData.DateTimeData.GetDatetime(new DateTime(1984,01,01),new DateTime(1999,01,01));
                musteri.ulke = FakeData.PlaceData.GetCountry();
                musteri.il = FakeData.PlaceData.GetCity();
                musteri.ilce = FakeData.PlaceData.GetCountry();
                musteri.email=$"{musteri.isim.ToLower()}.{musteri.soyisim.ToLower()}@{FakeData.NetworkData.GetDomain()}";
                musteri.telefonNo = FakeData.PhoneNumberData.GetPhoneNumber();

                musteris.Add(musteri);
            }
            return musteris;

        }
    }
}
