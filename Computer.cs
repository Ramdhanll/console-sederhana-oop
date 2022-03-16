namespace Warnet
{
   class Computer
   {
      public int No { get; set; }
      public string Name { get; set; }
      public int Hour { get; set; }

      public int Price { get; set; }

      public Computer(int No, string Name, int Hour, int Price)
      {
         this.No = No;
         this.Name = Name;
         this.Hour = Hour;
         this.Price = Price;
      }
   }
}