using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Data;
using System.Data.OleDb;

namespace AplikasiNapi.Model.Context
{
    /// <summary>
    /// Class DbContext digunakan untuk membuat koneksi ke database dan menjalankan perintah SQL
    /// </summary>
    public class DbContext : IDisposable
    {
        // deklarasi private variabel / field
        private OleDbConnection _conn;

        // deklarasi property Conn (connection), untuk menyimpan objek koneksi
        public OleDbConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        /// <summary>
        /// Method untuk melakukan koneksi ke database
        /// </summary>
        /// <returns></returns>
        private OleDbConnection GetOpenConnection()
        {
            var dbName = Directory.GetCurrentDirectory() + "\\DbNapi.mdb";
            var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", dbName);

            var conn = new OleDbConnection(connectionString);
            conn.Open();

            return conn;
        }

        /// <summary>
        /// Method ini digunakan untuk menghapus objek koneksi dari memory ketika sudah tidak digunakan
        /// </summary>
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
