using ClassLibraryCountries;
using ClassLibraryExceptions;
using ClassLibraryStringAndIntegerExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppLINQAtMedium
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Make own static int function -
            Func<int, int> sqaure = x => x * x;
            Func<int, int, int> substract = (x, y) => x - y;

            Console.WriteLine(sqaure(3));
            Console.WriteLine(substract(7, 5));

            var sayHello = "Hi";
            Console.WriteLine(sayHello.Shout());
            Console.WriteLine(sayHello.DoubleShout());
            Console.WriteLine(5.Kwadraat());

            var c1 = new Country(1, "Belgium", "Europe");
            var c2 = new Country(2, "Chile", "South America");
            var c3 = new Country(3, "Brazil", "South America");

            // Anonymous object!!!
            var land1 = new { Name = "Belgium", Capital = "Brussels" };
            var land2 = new { Name = "USA", Capital = "New York" };
            var land3 = new { Name = "Spain", Capital = "Madrid", Language = "Spanish" };

            // Create List "normal" and "Anonymous"
            // IEnumerable <Country> countries= new List<Country>(){c1, c2, c3 };
            // Anonymous types and var keyword
            var countries = new List<Country>() { c1, c2, c3 };

            //Method syntax
            var southAmericaCountries = countries.Where(c => c.Continent == "South America").OrderBy(c => c.Name);

            // query syntax
            /* var */
            southAmericaCountries = from c in countries
                                    where c.Continent == "South America"
                                    orderby c.Name
                                    select c
                                    ;
            foreach (var item in countries)
            {
                Console.WriteLine("All countries: " + item.Name);
            }
            foreach (var item in southAmericaCountries)
            {
                Console.WriteLine("All southAmericaCountries: " + item.Name);
            }

            // Ananymous array!!!
            var landen = new[] { land1, land2 /*, land3*/ };

            //foreach (var land in landen)
            foreach (var land in new[] { land1, land2 /*, land3*/ })
            {
                Console.WriteLine("Ananymous object: " + land.Name + "\t - " + land.Capital);
            }

            //Exception on Class method
            try
            {
                Country.MyMethod("En nu komt de fout - countryClassMethode");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + "**********");
            }

            //Exception on instance method
            try
            {
                Country c = new Country(9, "Blabla", "Dinges");
                c.MyMethod("komt van countryInstanceMethode");
            }
            catch (MyException ee)
            {
                Console.WriteLine(ee.Message + Environment.NewLine + "**********");
            }
        }
    }
}

//https://blog.quadiontech.com/5-c-features-that-will-help-you-to-understand-linq-bca495cd3fb8