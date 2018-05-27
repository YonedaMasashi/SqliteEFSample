using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Common;
using SQLite.CodeFirst;

namespace SqliteEFSample.Database {

    class MusicGameData : DbContext {
        public MusicGameData(DbConnection connection) :
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
