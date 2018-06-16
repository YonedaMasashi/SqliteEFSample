using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteEFSampleDll.Database {

    public class MusicGameData2 : DbContext {
        public MusicGameData2(DbConnection connection) :
            base(connection, true) {
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MusicGameData>(modelBuilder);
            System.Data.Entity.Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
