using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;

namespace RavenDBTest
{
    class Program
    {
        //kamu jangan marah yaa... antara aku, RavenDB sama dotNET cuma temenan kok...
        //wahai RavenDB, bukannya aku membenci metode aksesmu...
        const string dbname = "myraven";
        const string dburl = "http://localhost:8080/";
        static void Main(string[] args)
        {
            /*
            Buku buku1 = new Buku() { judul = "The Muslim Brotherhood in Egypt : its Rise, Demise, and Resurgence", pengarang = "Mohammad Amien Rais", tahunterbit = 1981 };
            Buku buku2 = new Buku() { judul = "Jomblo : Penderitaan, Nasib, dan Masa Depannya", pengarang = "Dewan Kesepian Jakarta"};
            Buku buku3 = new Buku() { judul = "Jomblo The Next Level!", pengarang = "Dewan Kesepian Jakarta", tahunterbit=2014 };
            Buku buku4 = new Buku() { judul = "Agenda Mendesak Bangsa : Selamatkan Indonesia", pengarang = "Mohammad Amien Rais", tahunterbit = 2008 };
            Buku buku5 = new Buku() { judul = "Negeri 5 Menara", pengarang = "A. Fuadi" };
            Buku buku6 = new Buku() { judul = "Ranah 3 Warna", pengarang = "A. Fuadi" };
            Buku buku7 = new Buku() { judul = "Rantau 1 Muara", pengarang = "A. Fuadi" };
            mahasiswa m1 = new mahasiswa() { nama = "Bangun", alamat = "Bojongsoang", nim = "1103111239" };
             */ 
            //storebuku(buku1);
            //storebuku(buku2);
            //storebuku(buku3);
            //storebuku(buku4);
            //storebuku(buku5);
            //storebuku(buku6);
            //storebuku(buku7);
            //caribukudaripengarang("A. Fuadi");
            //storemhs(m1);
            //Delete("129");
            //List<Buku> p = caribukudaripengarang("Dewan Kesepian Jakarta");
            //caribukudaripengarang("Mohammad Amien Rais");
            string pil = "n";
            while (!pil.Equals("7"))
            {

                Buku b;
                mahasiswa m;
                Console.WriteLine("1. Insert Mahasiswa");
                Console.WriteLine("2. Cari Mahasiswa");
                Console.WriteLine("3. Hapus Mahasiswa");
                Console.WriteLine("4. Insert Buku");
                Console.WriteLine("5. Cari Buku");
                Console.WriteLine("6. Hapus Buku");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Pilihan anda     :");
                pil = Console.ReadLine();
                switch (pil) 
                {
                    case "1":
                        {
                            string namanya="", nimnya="", alamatnya="";
                            Console.WriteLine("Insert Mahasiswa");
                            Console.WriteLine("Nama     :");
                            namanya= Console.ReadLine();
                            Console.WriteLine("NIM      :");
                            nimnya=Console.ReadLine();
                            Console.WriteLine("Alamat   :");
                            alamatnya=Console.ReadLine();
                            m = new mahasiswa() { nama = namanya, nim = nimnya, alamat = alamatnya };
                            storemhs(m);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Cari Mahasiswa");
                            Console.WriteLine("NIM      :");
                            string nim = Console.ReadLine();
                            carimhsdarinim(nim);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Hapus Mahasiswa");
                            Console.WriteLine("NIM      :");
                            string nim = Console.ReadLine();
                            DeleteMhs(nim);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Insert Buku");
                            string judulnya = "", pengarangnya = "", temp="";
                            int tahunterbitnya;
                            Console.WriteLine("Judul        :");
                            judulnya = Console.ReadLine();
                            Console.WriteLine("Pengarang    :");
                            pengarangnya = Console.ReadLine();
                            Console.WriteLine("Tahun Terbit :");
                            temp = Console.ReadLine();
                            int.TryParse(temp, out tahunterbitnya);
                            b = new Buku() { judul=judulnya, pengarang=pengarangnya, tahunterbit=tahunterbitnya};
                            storebuku(b); 
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Cari Buku");
                            Console.WriteLine("Judul        :");
                            string judulnya = Console.ReadLine();
                            caribukudarijudul(judulnya);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Hapus Buku");
                            Console.WriteLine("Judul        :");
                            string judulnya = Console.ReadLine();
                            Deletebuku(judulnya);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                }

            }
            Console.WriteLine("");
            Console.ReadLine();
        }
        static void storebuku(Buku book)
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize()) 
            {
                using (var sesi = ds.OpenSession(dbname)) 
                {
                    sesi.Store(book);
                    sesi.SaveChanges();
                    Console.WriteLine("data buku sudah diinput");
                }
            }
        }
        static void storemhs(mahasiswa mhs)
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    sesi.Store(mhs);
                    sesi.SaveChanges();
                    Console.WriteLine("data mahasiswa sudah diinput");
                }
            }
        }
        static void carimhsdarinim(string nimnya)
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    if (!nimnya.Equals(""))
                    {
                        try
                        {
                            List<mahasiswa> hasilquery = sesi.Query<mahasiswa>().Where(x => x.nim == nimnya).ToList<mahasiswa>();
                            Console.WriteLine();
                            foreach (mahasiswa m in hasilquery)
                            {
                                Console.WriteLine("Nama        : " + m.nama);
                                Console.WriteLine("NIM         : " + m.nim);
                                Console.WriteLine("Alamat      : " + m.alamat);
                            }
                            Console.WriteLine();
                        }
                        catch (Exception exc) 
                        { 
                            Console.WriteLine(exc.Message); 
                        }
                    }
                    else 
                    {
                        Console.WriteLine("NIM nya null");
                    }
                }
            }
        }
        static void caribukudarijudul(string judulnya)
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    List<Buku> hasilquery = sesi.Query<Buku>().Where(x => x.judul == judulnya).ToList<Buku>();
                    Console.WriteLine();
                    foreach (Buku b in hasilquery)
                    {
                        Console.WriteLine("Judul        : " + b.judul);
                        Console.WriteLine("Pengarang    : " + b.pengarang);
                        Console.WriteLine("Tahun Terbit : " + b.tahunterbit);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void caribukudaripengarang(string pengarang) 
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    List<Buku> hasilquery =sesi.Query<Buku>().Where(x => x.pengarang==pengarang).ToList<Buku>();
                    Console.WriteLine();
                    foreach (Buku b in hasilquery)
                    {
                        Console.WriteLine("Judul        : " + b.judul);
                        Console.WriteLine("Pengarang    : " + b.pengarang);
                        Console.WriteLine("Tahun Terbit : " + b.tahunterbit);
                    }
                    Console.WriteLine();
                }
            }
        }
        //kita pake LINQ  ya....
        static void TampilkanSemuaJudul() 
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    var hasil = sesi.Query<Buku>().ToList<Buku>();
                    foreach (Buku x in hasil) 
                    {
                        Console.WriteLine(x.judul);
                    }
                        
                }
            }
        }
        static void DeleteMhs(string nim) 
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    try
                    {
                        mahasiswa[] yangmaudihapus = sesi.Query<mahasiswa>().Where(x => x.nim == nim).ToArray<mahasiswa>() ;
                        sesi.Delete(yangmaudihapus[0]);
                        sesi.SaveChanges();
                        Console.WriteLine("Data Mahasiswa berhasil dihapus");
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }

                }
            }
        }
        static void Deletebuku(String judul) 
        {
            using (var ds = new DocumentStore { Url = dburl }.Initialize())
            {
                using (var sesi = ds.OpenSession(dbname))
                {
                    try
                    {
                        Buku[] yangmaudihapus = sesi.Query<Buku>().Where(x => x.judul == judul).ToArray<Buku>() ;
                        sesi.Delete(yangmaudihapus[0]);
                        sesi.SaveChanges();
                        Console.WriteLine("Data Buku berhasil dihapus");
                    }
                    catch (Exception exc) 
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
            }
        }

    }
    
}
