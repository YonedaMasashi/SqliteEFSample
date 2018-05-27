using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqliteEFSample.Database {
    [Table("title")]
    class Title {
        [Column("title_id")]
        public int TitleID { get; set; }

        [Column("model_id")]
        public int ModelID { get; set; }

        [Column("version_id")]
        public decimal VersionNO { get; set; }

        [Column("title_name")]
        public string TitleName { get; set; }

        [Column("running_date")]
        public DateTime RunningDate { get; set; }

        [ForeignKey(nameof(ModelID))] //外部キー列の指定 *プロパティ名を指定する
        public Model Model { get; set; }
    }
}
