using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.LinqTeknolojisi
{
    class Program
    {

        static bool FuncDelegateKullanimi1(Musteri musteri)
        {
            if (musteri.isim[0]=='A')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool PredicateDelegate(Musteri m)
        {
            if (m.dogumtarih.Year>1990)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void ActionDelegate(Musteri m)
        {
            Console.WriteLine(m.isim + " " + m.soyisim);
        }


        static void Main(string[] args)
        {
            DataSource ds = new DataSource();
            List<Musteri> musteriliste = ds.MusteriListe();


            #region LinQ İnceleme ve Ödevler

            //1: Müşteri listesinde ismi A ile başlayan soyisminin içinde E olan ve doğum yılı 1985 den büyük olan kayıtları getirin.

            var linQAlistirma1 = from I in musteriliste where I.isim.StartsWith("A") && I.soyisim.Contains("e") && I.dogumtarih.Year > 1985 select I;
            var LinQAlistirmasi2 = musteriliste.Where(I => I.isim.StartsWith("A") && I.soyisim.Contains("e") && I.dogumtarih.Year > 1985);

            Console.WriteLine(linQAlistirma1.Count());

            #endregion

            #region Action Delegate

            Action<Musteri> action = new Action<Musteri>(ActionDelegate);
            musteriliste.ForEach(action);

            musteriliste.ForEach(new Action<Musteri>(ActionDelegate));

            musteriliste.ForEach(delegate (Musteri m) { Console.WriteLine(m.isim + " " + m.soyisim); });

            musteriliste.ForEach((Musteri m) => { Console.WriteLine(m.isim + " " + m.soyisim); });

            musteriliste.ForEach((m) => { Console.WriteLine(m.isim + " " + m.soyisim); });

            musteriliste.ForEach((Musteri m) => { Console.WriteLine(m.isim + " " + m.soyisim); });


            #endregion

            #region LinQ Predicate Delegate

            Predicate<Musteri> predicate = new Predicate<Musteri>(PredicateDelegate);

            var delegatekullanimi1 = musteriliste.FindAll(predicate);

            var delegatekullanimi2 = musteriliste.FindAll(new Predicate<Musteri>(PredicateDelegate));

            var delegatekullanimi3 = musteriliste.FindAll(delegate (Musteri m) { return m.dogumtarih.Year > 1990; });

            var delegatekullanimi4=musteriliste.FindAll((Musteri m)=> { return m.dogumtarih.Year > 1990; });

            var delegatekullanimi5 = musteriliste.FindAll((m) => { return m.dogumtarih.Year > 1990; });

            var delegatekullanimi6 = musteriliste.FindAll( m => m.dogumtarih.Year > 1990);

            #endregion

            #region LinQ Sorgularında Delegate Kullanmı =>

            var delegateKullanimi1 = musteriliste.Where(I => I.isim.StartsWith("A"));
            Func<Musteri, bool> funcdelegate1 = new Func<Musteri, bool>(FuncDelegateKullanimi1);

            var delegateKullanimi2= musteriliste.Where(funcdelegate1);

            delegateKullanimi2 = musteriliste.Where(FuncDelegateKullanimi1);

            var delegateKullanimi3 = musteriliste.Where(new Func<Musteri, bool>(FuncDelegateKullanimi1));

            var delegateKullanimi4 = musteriliste.Where(delegate (Musteri m) { return m.isim[0] == 'A' ? true : false; });

            var delegateKullanimi5 = musteriliste.Where((Musteri m) => { return m.isim[0] == 'A' ? true : false; });

            var delegateKullanimi6 = musteriliste.Where((m)=> { return m.isim[0] == 'A' ? true : false; });

            var delegateKullanimi7 = musteriliste.Where(m => m.isim[0]=='A');
            #endregion

            #region Alıştırmalar

            //1: Müşteriler içerisinde ülke değeri A ile başlayan müşterileri bulun.

            int alistirma1 = musteriliste.Where(I => I.ulke.StartsWith("A")).Count();
            Console.WriteLine(alistirma1);

            //2: Müşteriler listesi içinde isminde B harfi ve ülke değerinin içinde A harfi geçenlerin listesi

            var alistirma2 = musteriliste.Where(I => I.isim.Contains("b") && I.ulke.Contains("a")).Count();

            //3: Müşteri listesi içerisinden doğum yılı 1990 dan büyük olan ve isminin içerisinde A olam müşterileri

            var alistirma3 = (from I in musteriliste where I.isim.Contains("a") && I.dogumtarih.Year > 1990 select I);

            //4:  Müşteri listesi içerisinden doğum yılı 1990 dan büyük olan veya isminin içerisinde A olam müşterileri

            var alistirma4 = (from I in musteriliste where I.isim.Contains("a") || I.dogumtarih.Year > 1990 select I);

            #endregion

            #region Linq Sorgulama Çeşitleri

            //1. Yol

            int toplamdeger1 =musteriliste.Where(I => I.isim.StartsWith("A")).Count();


            //Müşteri liste içerisinde I olarak gezindim. Her müşterinin adı A ile başlıyorsa I yı bana geri getir. (Bu bize koleksiyon döner)
            //Count ile toplamını aldık tekrardan.
            var toplamdeger2 = (from I in musteriliste where I.isim.StartsWith("A") select I);
            int toplammusteriadet = toplamdeger2.Count();
            #endregion

            #region Başlarken

            int bulunantoplam = 0;
            for (int i = 0; i < musteriliste.Count; i++)
            {
                //Müşteri listenin i. elemanının isminin 0. karakterini sorgulayan if yapısı
                if (musteriliste[i].isim[0]=='A')
                {
                    bulunantoplam++;
                }

            }

            Console.WriteLine("Liste içerisinde ismi A ile başlayan kişi sayısı: " + bulunantoplam );
            Console.WriteLine(musteriliste.Count);

            bulunantoplam = 0;
            //Linq teknolojisi ile  yukarda yazdığımız kodun aynısı bir satırda
            bulunantoplam = musteriliste.Where(i => i.isim.StartsWith("A")).Count();

            Console.WriteLine(bulunantoplam);

            Console.ReadLine();
         
            #endregion
        }
    }
}
