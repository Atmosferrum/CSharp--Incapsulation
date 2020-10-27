using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Notebook.csv";

            Repository repository = new Repository(path);

            Menu menu = new Menu(repository);

            menu.StartMenu();

            Console.ReadKey();
        }
    }
}

