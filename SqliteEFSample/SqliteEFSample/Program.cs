using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;

using SqliteEFSampleDll.Database;

namespace SqliteEFSample {
    class Program {
        static void Main(string[] args) {

            for (int i = 0; i < 10; ++i) {
                using (var connection = DbProviderFactories.GetFactory("System.Data.SQLite").CreateConnection()) {
                    //long index = i % 2;
                    long index = 0;
                    if (i >= 5) {
                        index = 1;
                    }
                    connection.ConnectionString = "Data Source=./app" + index + ".db";

                    if (i < 5) {
                        using (var context = new MusicGameData(connection)) {
                            var sw = new System.Diagnostics.Stopwatch();
                            sw.Start();
                            string cond = "piyo";
                            var elem = from data in context.Models
                                       where data.ModelName == cond
                                       select data;
                            if (elem.Count() == 1) {
                                //Console.WriteLine("selected data:" + $"{elem.First().ModelID} {elem.First().ModelName}");
                            }

                            foreach (var model in context.Models) {
                                //Console.WriteLine($"{model.ModelID} {model.ModelName}");
                            }
                            sw.Stop();
                            TimeSpan ts = sw.Elapsed;
                            Console.WriteLine($"　{connection.ConnectionString} :  {ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
                        }
                    } else {
                        using (var context = new MusicGameData2(connection)) {
                            var sw = new System.Diagnostics.Stopwatch();
                            sw.Start();
                            string cond = "piyo";
                            var elem = from data in context.Models
                                       where data.ModelName == cond
                                       select data;
                            if (elem.Count() == 1) {
                                //Console.WriteLine("selected data:" + $"{elem.First().ModelID} {elem.First().ModelName}");
                            }

                            foreach (var model in context.Models) {
                                //Console.WriteLine($"{model.ModelID} {model.ModelName}");
                            }
                            sw.Stop();
                            TimeSpan ts = sw.Elapsed;
                            Console.WriteLine($"　{connection.ConnectionString} :  {ts.Hours}時間 {ts.Minutes}分 {ts.Seconds}秒 {ts.Milliseconds}ミリ秒");
                        }
                    }
                }
            }
        }
    }
}
