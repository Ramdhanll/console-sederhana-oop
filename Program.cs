namespace Warnet
{
   class Program
   {
      public static int rentalPricePerHour = 3000;
      public static List<Computer> computerActive = new List<Computer>();

      public static void Main(string[] args)
      {
         bool isContinue = true;

         Console.Clear();
         while (isContinue)
         {

            Console.WriteLine($"------------------------------------------------");
            Console.WriteLine($"\tKASIR WARNET XYZ PER JAM  @{rentalPricePerHour}");
            Console.WriteLine($"------------------------------------------------\n");

            Console.WriteLine($"[1] Lihat komputer aktif");
            Console.WriteLine($"[2] Sewa komputer per jam");
            Console.WriteLine($"[3] Edit komputer aktif");
            Console.WriteLine($"[4] Hapus komputer aktif");
            Console.WriteLine($"[5] Ganti harga per jam");
            Console.WriteLine($"[6] Exit");


            int userInput;
            Console.Write("\nMasukan pilihan: ");
            while (!Int32.TryParse(Console.ReadLine(), out userInput))
               Console.Write("Invalid input! Masukan pilihan berupa angka: ");

            switch (userInput)
            {
               case 1:
                  Console.Clear();
                  Console.WriteLine($"-------------------------------------------------------------------------");
                  Console.WriteLine($"{"KOMPUTER AKTIF",43}");
                  Console.WriteLine($"-------------------------------------------------------------------------\n");
                  DisplayComputerActive();
                  break;
               case 2:
                  DisplayRentalComputer();
                  break;
               case 3:
                  Console.Clear();
                  Console.WriteLine($"-------------------------------------------------------------------------");
                  Console.WriteLine($"{"EDIT KOMPUTER AKTIF",47}");
                  Console.WriteLine($"-------------------------------------------------------------------------");

                  DisplayEditComputer();
                  break;
               case 4:
                  Console.Clear();
                  Console.WriteLine($"-------------------------------------------------------------------------");
                  Console.WriteLine($"{"HAPUS KOMPUTER AKTIF",47}");
                  Console.WriteLine($"-------------------------------------------------------------------------");
                  DisplayDeleteComputer();
                  break;
               case 5:
                  DisplayChangePricePerHour();
                  break;
               case 6:
                  return;
               default:
                  Console.WriteLine($"Pilihan tidak tersedia!");
                  break;
            }

            isContinue = Utils.GetYesOrNo("Apakah anda ingin melanjutkan?");
            Console.Clear();
         }
      }

      public static void DisplayComputerActive()
      {
         if (computerActive.Count == 0)
         {
            Console.WriteLine($"===================== TIDAK ADA KOMPUTER YANG AKTIF =====================");
         }
         else
         {
            Console.WriteLine($"| {"No Computer",-13}| { "Pengguna",-15}| {"Jam Sewa",-15}| {"Total Biaya",-15}|");
            foreach (var computer in computerActive)
            {
               Console.WriteLine($"| {computer.No,-13}| {computer.Name,-15}| {computer.Hour + " Jam",-15}| {computer.Price,-15}|");
            }
         }

      }

      public static void DisplayRentalComputer()
      {
         string? Name;
         int No, Hour;

         Console.Clear();
         Console.WriteLine($"------------------------------------------------");
         Console.WriteLine($"\tSEWA KOMPUTER BIAYA PER JAM {rentalPricePerHour}");
         Console.WriteLine($"------------------------------------------------\n");

         Console.Write("Masukan No Komputer \t: ");
         while (!Int32.TryParse(Console.ReadLine(), out No))
            Console.Write("Invalid input! Masukan No komputer berupa angka: ");

         Console.Write("Masukan Nama Pengguna \t: ");
         Name = Console.ReadLine();

         Console.Write("Masukan Jam Sewa \t: ");
         while (!Int32.TryParse(Console.ReadLine(), out Hour))
            Console.Write("Invalid input! Masukan jam sewa berupa angka: ");

         Console.WriteLine($"\n---- DETAIL PAYMENT ----");
         Console.WriteLine($"| Nama Pengguna\t => {Name}");
         Console.WriteLine($"| No Komputer\t => {No}");
         Console.WriteLine($"| Jam Sewa\t => {Hour}");
         Console.WriteLine($"| Biaya\t\t => Rp. {CalculatePrice(Hour)}");

         bool save = Utils.GetYesOrNo("Yakin ingin menyimpan data?");

         if (save)
         {
            computerActive.Add(new Computer(No, Name, Hour, CalculatePrice(Hour)));
            Console.WriteLine($"*** Data berhasil disimpan ***");

         }
         else if (save)
         {
            Console.WriteLine($"tidak disimpan");
            Console.WriteLine($"Data tidak disimpan");
         }
      }

      public static void DisplayChangePricePerHour()
      {
         Console.Clear();
         Console.WriteLine($"-------------------------------------------------------------------------");
         Console.WriteLine($"{"GANTI HARGA SEWA PER JAM",43}");
         Console.WriteLine($"-------------------------------------------------------------------------\n");

         int Price;

         Console.Write($"Ganti harga sewa menjadi: ");
         while (!Int32.TryParse(Console.ReadLine(), out Price))
            Console.Write("Invalid input! Masukan harga berupa angka: ");

         rentalPricePerHour = Price;

         foreach (var computer in computerActive)
         {
            computer.Price = CalculatePrice(computer.Hour);
         }
      }

      public static void DisplayEditComputer()
      {
         string? Name;
         int No, Hour;

         DisplayComputerActive();

         if (computerActive.Count != 0)
         {
            Console.Write("\nPilih No Komputer yang ingin di edit \t: ");
            while (!Int32.TryParse(Console.ReadLine(), out No))
               Console.Write("Invalid input! Masukan No komputer berupa angka: ");

            int index = computerActive.FindLastIndex(c => c.No == No);
            if (index != -1)
            {
               Console.Write("Masukan No Komputer \t: ");
               while (!Int32.TryParse(Console.ReadLine(), out No))
                  Console.Write("Invalid input! Masukan no komputer berupa angka: ");

               Console.Write("Masukan Nama Pengguna \t: ");
               Name = Console.ReadLine();

               Console.Write("Masukan Jam Sewa \t: ");
               while (!Int32.TryParse(Console.ReadLine(), out Hour))
                  Console.Write("Invalid input! Masukan jam sewa berupa angka: ");

               Console.WriteLine($"\n---- DETAIL EDIT ----");
               Console.WriteLine($"| Nama Pengguna\t => {computerActive[index].Name} => {Name}");
               Console.WriteLine($"| No Komputer\t => {computerActive[index].No} => {No}");
               Console.WriteLine($"| Jam Sewa\t => {computerActive[index].Hour} => {Hour}");
               Console.WriteLine($"| Biaya\t\t => Rp. {computerActive[index].Price = CalculatePrice(Hour)} => Rp. {CalculatePrice(Hour)}");

               bool save = Utils.GetYesOrNo("Yakin ingin mengubah data?");

               if (save)
               {
                  computerActive[index].No = No;
                  computerActive[index].Name = Name;
                  computerActive[index].Hour = Hour;
                  computerActive[index].Price = CalculatePrice(Hour);

                  Console.WriteLine($"*** Data berhasil diubah ***");

               }
               else if (save)
               {
                  Console.WriteLine($"tidak disimpan");
                  Console.WriteLine($"Data tidak diubah");
               }
            }
            else
            {
               Console.WriteLine($"Komputer dengan No: {No} tidak dapat ditemukan");
            }
         }
      }

      public static void DisplayDeleteComputer()
      {
         int No;
         DisplayComputerActive();

         if (computerActive.Count != 0)
         {
            Console.Write("\nPilih No Komputer yang ingin di edit \t: ");
            while (!Int32.TryParse(Console.ReadLine(), out No))
               Console.Write("Invalid input! Masukan No komputer berupa angka: ");

            int index = computerActive.FindLastIndex(c => c.No == No);

            if (index != -1)
            {
               bool isDelete = Utils.GetYesOrNo("Apakah yakin ingin menghapus?");

               if (isDelete)
               {
                  computerActive.RemoveAt(index);
                  Console.WriteLine($"***Komputer berhasil dihapus***");

               }
               else
               {
                  Console.WriteLine($"***Data tidak jadi dihapus***");
               }

            }
            else
            {
               Console.WriteLine($"***Komputer dengan No: {No} tidak dapat ditemukan***");
            }
         }
      }
      public static int CalculatePrice(int Hour)
      {
         return Hour * rentalPricePerHour;
      }
   }
}