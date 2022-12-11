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

        var Text3 = File.ReadAllText("Лабораторная работа 5 - testData.xml");
        var point5 =new Regex (@"^[A-ЯЁ]|[а-яё]+[\s{3}]+[0-9{2}]+[лет]|[года]|[год]$");
        var values = point5.Matches(Text3);
        Console.WriteLine(values);
    }
}
    
