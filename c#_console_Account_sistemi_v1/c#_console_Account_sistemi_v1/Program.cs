using System; // Sistem kütüphanesini projeye dahil eder
using System.Collections.Generic; // Generic koleksiyonları kullanabilmemizi sağlar
using System.Threading; // Thread.Sleep için gerekli

namespace HesapSistemi // Proje adını Türkçeye çevirdik
{
    class Program
    {
        // Kullanıcıları saklayan liste, program çalıştığı sürece kullanıcı verilerini RAM'de tutar
        static List<Kullanici> kullanicilar = new List<Kullanici>();

        static void Main(string[] args) // Programın başlangıç noktasıdır, uygulama buradan çalışmaya başlar
        {
            // Açılış ekranı
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n==============================");
            Console.WriteLine(" The Crew Account Panel v1.0 Yükleniyor...");
            Console.WriteLine(" Geliştirici: Emirhan Vardar");
            Console.WriteLine("==============================\n");
            Console.ResetColor();
            Thread.Sleep(5000); // 5 saniyelik yükleme efekti
            Console.Clear();

            while (true) // Sonsuz döngü, kullanıcı çıkış yapana kadar menüyü tekrar gösterir
            {
                Console.WriteLine("1- Kayıt Ol\n2- Giriş Yap\n3- Çıkış\n4- Kullanıcıları Listele\n5- Tüm Kullanıcıları Sil"); // Genişletilmiş menü
               
                string secim = Console.ReadLine(); // Kullanıcının seçimini alıyoruz

                if (secim == "1")
                {
                    KayitOl(); // Kayıt fonksiyonunu çağırıyoruz
                }
                else if (secim == "2")
                {
                    GirisYap(); // Giriş fonksiyonunu çağırıyoruz
                }
                else if (secim == "3")
                {
                    break; // Programdan çıkış yapılıyor
                }
                else if (secim == "4")
                {
                    KullanicilariListele(); // Kayıtlı kullanıcıları listeler
                }
                else if (secim == "5")
                {
                    KullanicilariTemizle(); // Tüm kullanıcıları siler
                }
                else
                {
                    Console.WriteLine("Geçersiz seçenek! Tekrar deneyin."); // Hatalı giriş yapıldığında uyarı veriliyor
                }
            }
        }

        static void KayitOl() // static: nesne oluşturmadan çalışan metottur, void: geriye değer döndürmez
        {
            Console.Write("Kullanıcı adı girin: "); // Kullanıcı adı alınıyor
            string kullaniciAdi = Console.ReadLine();

            // Aynı kullanıcı adıyla kayıt var mı kontrol edilir
            foreach (var kullanici in kullanicilar)
            {
                if (kullanici.KullaniciAdi == kullaniciAdi)
                {
                    Console.WriteLine("Bu kullanıcı adı zaten alınmış!");
                    return;
                }
            }

            Console.Write("Şifre girin: "); // Şifre alınıyor
            string sifre = Console.ReadLine();

            // Şifre uzunluğu kontrolü
            if (sifre.Length < 6)
            {
                Console.WriteLine("Şifre en az 6 karakter olmalı!");
                return;
            }

            // Yeni kullanıcı nesnesi oluşturulup listeye ekleniyor
            kullanicilar.Add(new Kullanici(kullaniciAdi, sifre));
            Console.WriteLine("Kullanıcı başarıyla kaydedildi!");
        }

        static void GirisYap() // static ve void yukarıdakiyle aynı anlamlara gelir
        {
            Console.Write("Kullanıcı adı girin: "); // Kullanıcı adı alınıyor
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre girin: "); // Şifre alınıyor
            string sifre = Console.ReadLine();

            // Liste içerisindeki her bir kullanıcıyı kontrol eder
            foreach (var kullanici in kullanicilar)
            {
                // Giriş bilgileri doğruysa başarılı mesajı gösterilir
                if (kullanici.KullaniciAdi == kullaniciAdi && kullanici.Sifre == sifre)
                {
                    Console.WriteLine("Giriş başarılı! Hoş geldin, " + kullaniciAdi);
                    return; // Metottan çıkılır
                }
            }

            Console.WriteLine("Geçersiz kullanıcı adı veya şifre!"); // Hatalı giriş mesajı
        }

        static void KullanicilariListele() // Kayıtlı kullanıcıları listeler
        {
            if (kullanicilar.Count == 0)
            {
                Console.WriteLine("Hiç kullanıcı kaydı bulunamadı.");
                return;
            }

            Console.WriteLine("Kayıtlı kullanıcılar:");
            foreach (var kullanici in kullanicilar)
            {
                Console.WriteLine("- " + kullanici.KullaniciAdi);
            }
        }

        static void KullanicilariTemizle() // Tüm kullanıcıları siler
        {
            kullanicilar.Clear();
            Console.WriteLine("Tüm kullanıcılar silindi!");
        }
    }

    class Kullanici // Kullanıcı sınıfı, veri modeli gibi düşünülebilir
    {
        public string KullaniciAdi { get; } // Sadece okunabilir bir özellik, dışarıdan değiştirilemez
        public string Sifre { get; } // Aynı şekilde, şifre de korumaya alınmış durumda

        // Yapıcı metot (constructor): Yeni bir nesne oluştururken çalışır
        public Kullanici(string kullaniciAdi, string sifre)
        {
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
        }
    }
}
