using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var Partners = getAllPartnersFromCSV();

            First(Partners);
            Console.ReadKey();

            Second(Partners);
            Console.ReadKey();

            Third(Partners);
            Console.ReadKey();

            Four(Partners);
            Console.ReadKey();

            Five(Partners);
            Console.ReadKey();
        }

        static void First(List<Partner> partners)
        {
            Console.WriteLine($"1.- Cantidad total de socios: {partners.Count}");
        }

        static void Second(List<Partner> partners)
        {
            Console.WriteLine($"2.- Edad promedio de socios de Racing: {partners.Where(i => i.Team == "Racing").Average(i => i.Age)}");
        }

        static void Third(List<Partner> partners)
        {
            Console.WriteLine($"3.- Top 100 socios casados con estudios Universitarios:");
            var top100 = partners.Where(i => i.MaritalStatus == "Casado" && i.Studies == "Universitario").Take(100).OrderBy(i => i.Age).ToList();

            for (int i = 0; i < top100.Count; i++)
            {
                Console.WriteLine(i.ToString() + '\t' + top100[i].OnlyNameAgeTeam);
            }
        }

        static void Four(List<Partner> partners)
        {
            var topFiveNamesOfRiverTeam = partners.Where(i => i.Team == "River")
                                          .GroupBy(i => i.Name)
                                          .Select(group => new
                                          {
                                              Name = group.Key,
                                              Count = group.Count()
                                          })
                                          .OrderByDescending(i => i.Count)
                                          .Take(5)
                                          .ToList();
            Console.WriteLine("Top 5 de nombres en comun en equipo de River:");

            for (int i = 0; i < topFiveNamesOfRiverTeam.Count; i++)
            {
                Console.WriteLine($"Nombre: {topFiveNamesOfRiverTeam[i].Name}");
            }
        }

        static void Five(List<Partner> partners)
        {
            var result = partners.GroupBy(i => i.Team)
                        .Select(group => new
                        {
                            Team = group.Key,
                            Count = group.Count(),
                            AvgAge = group.Average(i => i.Age),
                            MinAge = group.Min(i => i.Age),
                            MaxAge = group.Max(i => i.Age)
                        })
                        .OrderByDescending(i => i.Count)
                        .ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine($"Equipo:{result[i].Team} \t\tCantidad:{result[i].Count} \tEdad promedio:{result[i].AvgAge} \tMinima edad:{result[i].MinAge} \tMaxima edad:{result[i].MaxAge}");
            }
        }

        static List<Partner> getAllPartnersFromCSV()
        {
            var result = new List<Partner>();
            var source = new StreamReader(Directory.GetCurrentDirectory() + "\\Source\\socios.csv").ReadToEnd();
            var db = source.Split(';', '\n');

            for (int i = 0; i < db.Length && i != db.Length - 1; i += 5)
            {
                result.Add(new Partner
                {
                    Name = db[i].Trim(),
                    Age = Convert.ToInt32(db[i + 1]),
                    Team = db[i + 2].Trim(),
                    MaritalStatus = db[i + 3].Trim(),
                    Studies = db[i + 4].Trim()
                });
            }
            return result;
        }
    }
}
