namespace Warnet
{
   class Utils
   {
      public static bool GetYesOrNo(string message)
      {
         Console.Write($"\n{message} (y/n) : ");
         string? pilihanUser = Console.ReadLine();

         while (pilihanUser != "y" && pilihanUser != "n")
         {
            Console.WriteLine($"Pilihan anda bukan y atau n");

            Console.Write($"\n{message} (y/n) : ");
            pilihanUser = Console.ReadLine();
         }



         return pilihanUser.Equals("y");
      }
   }
}