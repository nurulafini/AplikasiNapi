using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using AplikasiNapi.Model.Context;
using AplikasiNapi.Model.Entity;

namespace AplikasiNapi.Model.Repository
{
    /// <summary>
    /// Class repository berisi perintah untuk menjalankan operasi CRUD
    /// </summary>
    public class NarapidanaRepository
    {
        // deklarsi objek DbContext
        private DbContext _context;

        // constructor
        public NarapidanaRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method untuk menampilkan data narapidana berdasarkan id_napi
        /// </summary>
        /// <param nama_napi="id_napi"></param>
        /// <returns></returns>
        public Narapidana GetById_napi(string id_napi)
        {
            // deklarasi objek narapidana
            Narapidana napi = null;

            var sql = @"select id_napi, nama_napi, jeniskelamin_napi, tempatlahir_napi, tanggallahir_napi, alamat_napi, notlp_napi, kasus_napi, tgl_masuk, tgl_bebas 
                        from narapidana 
                        where id_napi = @id_napi";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // set nilai parameter @npm
                cmd.Parameters.AddWithValue("@id_napi", id_napi);

                // membuat objek dtr (data reader) menggunakan blok using, untuk menampung hasil perintah SELECT
                using (var dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari hasil query
                    if (dtr.Read()) // jika data mahasiswa ditemukan
                    {
                        // membuat objek dari class Mahasiswa
                        napi = new Narapidana();

                        // set nilai property objek mahasiswa
                        napi.id_napi = dtr["id_napi"].ToString();
                        napi.nama_napi = Convert.ToString(dtr["nama_napi"]);
                        napi.jeniskelamin_napi = dtr["jeniskelamin_napi"].ToString();
                        napi.tempatlahir_napi = dtr["tempatlahir_napi"].ToString();
                        napi.tanggallahir_napi = dtr["tanggallahir_napi"].ToString();
                        napi.alamat_napi = dtr["alamat_napi"].ToString();
                        napi.notlp_napi = dtr["notlp_napi"].ToString();
                        napi.kasus_napi = dtr["kasus_napi"].ToString();
                        napi.tgl_masuk = dtr["tgl_masuk"].ToString();
                        napi.tgl_bebas = dtr["tgl_bebas"].ToString();
                    }
                }
            }

            return napi;
        }

        /// <summary>
        /// Method untuk menampilkan data narapidana berdasarkan pencarian nama
        /// </summary>
        /// <param nama_napi="nama_napi"></param>
        /// <returns></returns>
        public List<Narapidana> GetByNama_napi(string nama_napi)
        {
            // membuat objek collection
            var list = new List<Narapidana>();

            var sql = @"select id_napi, nama_napi, jeniskelamin_napi, tempatlahir_napi, tanggallahir_napi, alamat_napi, notlp_napi, kasus_napi, tgl_masuk, tgl_bebas 
                        from narapidana 
                        where nama_napi like @nama_napi
                        order by nama_napi";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // set nilai parameter @nama
                cmd.Parameters.AddWithValue("@nama_napi", "%" + nama_napi + "%");

                // membuat objek dtr (data reader) menggunakan blok using, untuk menampung hasil perintah SELECT
                using (var dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari hasil query
                    while (dtr.Read())
                    {
                        // membuat objek dari class Mahasiswa
                        var napi = new Narapidana();

                        // set nilai property objek mahasiswa
                        napi.id_napi = dtr["id_napi"].ToString();
                        napi.nama_napi = Convert.ToString(dtr["nama_napi"]);
                        napi.jeniskelamin_napi = dtr["jeniskelamin_napi"].ToString();
                        napi.tempatlahir_napi = dtr["tempatlahir_napi"].ToString();
                        napi.tanggallahir_napi = dtr["tanggallahir_napi"].ToString();
                        napi.alamat_napi = dtr["alamat_napi"].ToString();
                        napi.notlp_napi = dtr["notlp_napi"].ToString();
                        napi.kasus_napi = dtr["kasus_napi"].ToString();
                        napi.tgl_masuk = dtr["tgl_masuk"].ToString();
                        napi.tgl_bebas = dtr["tgl_bebas"].ToString();

                        // tambahkan objek mahasiswa ke dalam collection
                        list.Add(napi);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Method untuk menampilkan semua data mahasiwa
        /// </summary>
        /// <returns></returns>
        public List<Narapidana> GetAll()
        {
            // membuat objek collection
            var list = new List<Narapidana>();

            var sql = @"select id_napi, nama_napi, jeniskelamin_napi, tempatlahir_napi, tanggallahir_napi, alamat_napi, notlp_napi, kasus_napi, tgl_masuk, tgl_bebas
                        from narapidana 
                        order by nama_napi";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // membuat objek dtr (data reader) menggunakan blok using, untuk menampung hasil perintah SELECT
                using (var dtr = cmd.ExecuteReader())
                {
                    // panggil method Read untuk mendapatkan baris dari hasil query
                    while (dtr.Read())
                    {
                        // membuat objek dari class Mahasiswa
                        var napi = new Narapidana();

                        napi.id_napi = dtr["id_napi"].ToString();
                        napi.nama_napi = Convert.ToString(dtr["nama_napi"]);
                        napi.jeniskelamin_napi = dtr["jeniskelamin_napi"].ToString();
                        napi.tempatlahir_napi = dtr["tempatlahir_napi"].ToString();
                        napi.tanggallahir_napi = dtr["tanggallahir_napi"].ToString();
                        napi.alamat_napi = dtr["alamat_napi"].ToString();
                        napi.notlp_napi = dtr["notlp_napi"].ToString();
                        napi.kasus_napi = dtr["kasus_napi"].ToString();
                        napi.tgl_masuk = dtr["tgl_masuk"].ToString();
                        napi.tgl_bebas = dtr["tgl_bebas"].ToString();

                        // tambahkan objek mahasiswa ke dalam collection
                        list.Add(napi);
                    }
                }
            }

            return list;
        }

        public int Save(Narapidana obj)
        {
            var result = 0;

            var sql = @"insert into narapidana (id_napi, nama_napi, jeniskelamin_napi, tempatlahir_napi, tanggallahir_napi, alamat_napi, notlp_napi, kasus_napi, tgl_masuk, tgl_bebas)
                        values (@id_napi, @nama_napi, @jeniskelamin_napi, @tempatlahir_napi, @tanggallahir_napi, @alamat_napi, @notlp_napi, @kasus_napi, @tgl_masuk, @tgl_bebas)";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // set nilai parameter @npm, @nama dan @alamat
                cmd.Parameters.AddWithValue("@id_napi", obj.id_napi);
                cmd.Parameters.AddWithValue("@nama_napi", obj.nama_napi);
                cmd.Parameters.AddWithValue("@jeniskelamin_napi", obj.jeniskelamin_napi);
                cmd.Parameters.AddWithValue("@tempatlahir_napi", obj.tempatlahir_napi);
                cmd.Parameters.AddWithValue("@tanggallahir_napi", obj.tanggallahir_napi);
                cmd.Parameters.AddWithValue("@alamat_napi", obj.alamat_napi);
                cmd.Parameters.AddWithValue("@notlp_napi", obj.notlp_napi);
                cmd.Parameters.AddWithValue("@kasus_napi", obj.kasus_napi);
                cmd.Parameters.AddWithValue("@tgl_masuk", obj.tgl_masuk);
                cmd.Parameters.AddWithValue("@tgl_bebas", obj.tgl_bebas);

                // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Update(Narapidana obj)
        {
            var result = 0;

            var sql = @"update narapidana set nama_napi = @nama_napi, jeniskelamin_napi = @jeniskelamin_napi, tempatlahir_napi = @tempatlahir_napi, tanggallahir_napi = @tanggallahir_napi, alamat_napi = @alamat_napi, notlp_napi = @notlp_napi, kasus_napi = @kasus_napi, tgl_masuk = @tgl_masuk, tgl_bebas = @tgl_bebas
                        where id_napi = @id_napi";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // set nilai parameter @npm, @nama dan @alamat
                cmd.Parameters.AddWithValue("@nama_napi", obj.nama_napi);
                cmd.Parameters.AddWithValue("@jeniskelamin_napi", obj.jeniskelamin_napi);
                cmd.Parameters.AddWithValue("@tempatlahir_napi", obj.tempatlahir_napi);
                cmd.Parameters.AddWithValue("@tanggallahir_napi", obj.tanggallahir_napi);
                cmd.Parameters.AddWithValue("@alamat_napi", obj.alamat_napi);
                cmd.Parameters.AddWithValue("@notlp_napi", obj.notlp_napi);
                cmd.Parameters.AddWithValue("@kasus_napi", obj.kasus_napi);
                cmd.Parameters.AddWithValue("@tgl_masuk", obj.tgl_masuk);
                cmd.Parameters.AddWithValue("@tgl_bebas", obj.tgl_bebas);
                cmd.Parameters.AddWithValue("@id_napi", obj.id_napi);

                // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }

        public int Delete(Narapidana obj)
        {
            var result = 0;

            var sql = @"delete from narapidana
                        where id_napi = @id_napi";

            // membuat objek command menggunakan blok using
            using (var cmd = new OleDbCommand(sql, _context.Conn))
            {
                // set nilai parameter @npm
                cmd.Parameters.AddWithValue("@id_napi", obj.id_napi);

                // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                result = cmd.ExecuteNonQuery();
            }

            return result;
        }
    }
}
