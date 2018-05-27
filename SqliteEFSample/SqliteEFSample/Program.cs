using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;

using SqliteEFSample.Database;

namespace SqliteEFSample {
    class Program {
        static void Main(string[] args) {

            var connection = DbProviderFactories.GetFactory("System.Data.SQLite").CreateConnection();
            connection.ConnectionString = "Data Source=./app.db";

            using (var context = new MusicGameData(connection)) {

                var elem = from data in context.Models
                           where data.ModelName == "piyo"
                           select data;
                if (elem.Count() == 1) {
                    Console.WriteLine("selected data:" + $"{elem.First().ModelID} {elem.First().ModelName}");
                }

                foreach (var model in context.Models) {
                    Console.WriteLine($"{model.ModelID} {model.ModelName}");
                }
            }

        }
    }
}
