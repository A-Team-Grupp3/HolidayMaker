using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayMakerGrupp2.Models.Database;

/*
Bara ett förslag på hur man kan göra async-anrop istället för att få en snabbare server
där inte anrop blockerar varandra.

Jag tycker att en sådan här klass ska vara statisk men jag kanske har missat något och då får
man gärna förklara för mig varför den inte bör vara det :)


*/

namespace HolidayMakerGrupp2.Services 
{
 public static class LoveService 
 {
  public async static Task<IEnumerable<Example>> Get() 
  {
   // Använd using-statement för att stänga databas-kopplingen så fort data hämtas
   using (var ctx = new HolidayMakerGrupp2Context()) 
   {
    return await ctx.Examples.AsAsyncEnumerable()
   }
  }
 }
}