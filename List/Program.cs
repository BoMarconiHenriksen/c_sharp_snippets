using System;
using System.Collections.Generic;

namespace List
{
  class Program
  {
    static void Main(string[] args)
    {
      var basic = new Basic();
      basic.Hello();


      var presidents = new List<string>
      {
        "Jimmy Carter",
        "Ronald Reagan",
        "George HW Bush",
        "George W Bush"
      };

      presidents.Add("Barak Obama");

      foreach (string president in presidents)
        Console.WriteLine(president);

    }
  }
}
