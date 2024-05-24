using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADODisconnectedArchDemo
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


