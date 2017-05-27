using SuperXamarin.PCL.Service;
using System;
using System.Threading.Tasks;

namespace SuperXamarin.SuperConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                // Do any async anything you need here without worry
                var api = new APIService("", "");
                var character = await api.GetCharacters("Daredevil");
                Console.Write(character);
            }).GetAwaiter().GetResult();

        }
    }
}
