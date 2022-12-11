using System;
using System.Text.RegularExpressions;
internal class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("txt.txt");
        var Reg = new Dictionary<string, Regex>
        {
            ["email"] = new(@"^[\w\-]+@((\w+)|(\w[\w-]+))\.\w+$"),
            ["a"] = new(@"^a$"),
            ["aaaaaa"] = new(@"^a{6}$"),
            ["a aa a"] = new(@"^a aa a$"),
            ["не менее 5"] = new(@"^[\w]{5,}$"),
            ["пользователь"] = new(@"^[A-ЯЁ]|[а-яё]+[\s{3}]+[0-9{2}]+[лет]|[года]|[год]$"),
        };
        foreach (KeyValuePair<string, Regex> kvp in Reg) 
        {
            for (int i = 0; i < input.Length; ++i)
            {
                if (kvp.Value.IsMatch(input[i]))
                    System.Console.WriteLine($"{kvp.Key}: {input[i]}\nстрока:{i + 1}\n");
            }
        }
        var Task2 = new Regex(@"(\s|^)((https://)|(http://)|(ftp://))?(www\.)?([^-\s][\w_-]+\.){1,4}\w+");

        var Text = File.ReadAllText("domens.txt");
        var URLs = Task2.Matches(Text);
        string OutText = "";
        foreach (Match url in URLs)
        {
            OutText += $"{url.Value.Trim()}:{url.Index}\n";
        }
        File.WriteAllText("out.txt", OutText);
        Console.WriteLine(OutText);

        var StreetReg = new Regex(@"^(?:[уУ][лЛ]\.\s+)?(\w+)\,?\s+(?:[дД]\.\s+)?(\d+(?:[\-\/]\d+)?)$");
        var Street = Console.ReadLine();
        if (StreetReg.IsMatch(Street))
        {
            var Groups = StreetReg.Split(Street);
            Console.WriteLine($"Улица: {Groups[1]}\nДом: {Groups[2]}");

        }
        else
        {
            Console.WriteLine("НеTy");
        }
        Console.WriteLine("=======================================");


        string Task1 = "Добро пожаловать в наш магазин, вот наши цены: 1 кг. яблоки - 90 руб., 2 кг. апельсины - 130 руб. Также в ассортименте орехи в следующей фасовке: 0.5 кг. миндаль - 500 руб";
        var Task1Reg = new Regex(@"((?:\d+)?\.?\d+)?\sкг\.\s(\w+)\s\-\s(\d+)\sруб\.?");
        var RawProducts = Task1Reg.Matches(Task1);
        foreach (Match RawProduct in RawProducts)
        {
            foreach (Match ProductString in Task1Reg.Matches(RawProduct.Value))
            {
                var SplitProduct = ProductString.Groups;
                Console.WriteLine($"{SplitProduct[2]} - {Convert.ToDouble(SplitProduct[3].Value) / Convert.ToDouble(SplitProduct[1].Value.Replace('.', ','))} руб/кг");
            }

        }
        Console.WriteLine("=======================================");




    }
}
    
