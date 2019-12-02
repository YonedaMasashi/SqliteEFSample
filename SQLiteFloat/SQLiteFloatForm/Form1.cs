using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace SQLiteFloatForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string db_file = "Test.db";

        // データベース作成
        private void button1_Click(object sender, EventArgs e) {
            System.IO.File.Delete(db_file);

            // コネクションを開いてテーブル作成して閉じる  
            using (var conn = new SQLiteConnection("Data Source=" + db_file)) {
                conn.Open();
                using (SQLiteCommand command = conn.CreateCommand()) {
                    command.CommandText = "create table Sample(Id INTEGER  PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER, Float REAL)";
                    command.ExecuteNonQuery();
                }

                conn.Close();
            }
        }


        // データベース接続
        private void button2_Click(object sender, EventArgs e) {

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + db_file)) {
                try {
                    conn.Open();
                    MessageBox.Show("Connection Success", "Connection Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception exception) {
                    MessageBox.Show(exception.Message, "Connection Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // データの追加

        private void button3_Click(object sender, EventArgs e) {

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + db_file)) {
                conn.Open();
                using (SQLiteTransaction trans = conn.BeginTransaction()) {
                    SQLiteCommand cmd = conn.CreateCommand();

                    // インサート
                    cmd.CommandText = "INSERT INTO Sample (Name, Age, Float) VALUES (@Name, @Age, @Float)";

                    // パラメータセット
                    cmd.Parameters.Add("Name", System.Data.DbType.String);
                    cmd.Parameters.Add("Age", System.Data.DbType.Int64);
                    cmd.Parameters.Add("Float", System.Data.DbType.Decimal);

                    // データ追加
                    double dValue = 0.1234567890123456789012345;
                    cmd.Parameters["Name"].Value = "佐藤";
                    cmd.Parameters["Age"].Value = 32;
                    cmd.Parameters["Float"].Value = dValue;
                    cmd.ExecuteNonQuery();

                    dValue = 0.5678901234567890123456789;
                    cmd.Parameters["Name"].Value = "斉藤";
                    cmd.Parameters["Age"].Value = 24;
                    cmd.Parameters["Float"].Value = 0.5678901234567890123456789;
                    cmd.ExecuteNonQuery();

                    // コミット
                    trans.Commit();
                }
            }
        }

        // データの取得
        private void button4_Click(object sender, EventArgs e) {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + db_file)) {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Sample";
                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                    string message = "Id,Name,Age,Float\n";

                    while (reader.Read()) {
                        //message += reader["Id"].ToString() + "," + reader.["Float"].ToString() +"\n";
                        message += reader["Id"].ToString() + "," + reader.GetDecimal(3).ToString("G17") + "\n";
                    }

                    MessageBox.Show(message);
                }
                conn.Close();
            }
        }
    }
}