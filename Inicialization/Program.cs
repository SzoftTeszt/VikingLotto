// See https://aka.ms/new-console-template for more information
using Kozos;

Console.WriteLine("Hello, World!");

using VikingContext context = new VikingContext();

if (!context.LottoSzamok.Any())
{


    var sorok = File.ReadAllLines(@"c:\adat\VikingLottoSzamok.csv");
    //Console.WriteLine(sorok);
    List<Szamok> szamokList = new List<Szamok>();
    foreach (var sor in sorok)
    {
        //Console.WriteLine(sor);
               
        try
        {
            szamokList.Add(new Szamok(sor));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hibás sor: {sor} {ex.Message}");
        }
        
    }
    context.LottoSzamok.AddRange(szamokList);
    context.SaveChanges();
}

Console.WriteLine("A Adattábla tartalma:");

foreach (Szamok huzas in context.LottoSzamok)
{
    Console.WriteLine($"{huzas}");
}