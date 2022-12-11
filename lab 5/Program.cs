using System.Text.RegularExpressions;

internal class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("txt.txt");
        var Reg = new Dictionary<string, Regex>();


        Reg["«a»"] = new (@"^a$");
        Reg["«aaaaaa»"] = new(@"^a{6}$"); 
        Reg["«a aa a»"] = new (@"^a aa a$"); 
        Reg["«не менее 5"] = new (@"^[\w]{5,}$");
        Reg["«email"] = new(@"^[\w\-]+@((\w+)|(\w[\w-]+))\.\w+$");


        foreach (KeyValuePair<string, Regex> kvp in Reg) 
        {
            for (int i = 0; i < input.Length; ++i)
            {
                if (kvp.Value.IsMatch(input[i]))
                    System.Console.WriteLine($"проверка {kvp.Key}: {input[i]}\nСтрока:{i + 1}");
                
            }
        }
        
    }
}
    
