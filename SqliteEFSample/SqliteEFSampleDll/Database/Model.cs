using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqliteEFSampleDll.Database {

    [Table("model")] //テーブル名
    public class Model {
        [Key] //主キー列の宣言
        [Column("model_id")] //列名
        public int ModelID { get; set; }

        [Column("model_name")]
        public string ModelName { get; set; }
    }
}
