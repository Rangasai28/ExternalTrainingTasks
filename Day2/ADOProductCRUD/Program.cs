using System.Text.Json.Serialization;

namespace ADOProductCRUD
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.readUserOption();
        }
       
    }
}
