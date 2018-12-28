using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using AplikasiNapi.Model.Entity;
using AplikasiNapi.Model.Repository;
using AplikasiNapi.Model.Context;

namespace AplikasiNapi.Controller
{
    public class NarapidanaController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private NarapidanaRepository _repository;

        /// <summary>
        /// Method untuk menampilkan data Narapidana berdasarkan id_napi
        /// </summary>
        /// <param name="id_napi"></param>
        /// <returns></returns>
        public Narapidana GetById_napi(string id_napi)
        {
            // deklarasi objek Narapidana
            Narapidana napi = null;

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                _repository = new NarapidanaRepository(context);
                napi = _repository.GetById_napi(id_napi);
            }

            return napi;
        }

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Narapidana> GetByNama_napi(string nama_napi)
        {
            // membuat objek collection
            var list = new List<Narapidana>();

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new NarapidanaRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.GetByNama_napi(nama_napi);
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

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new NarapidanaRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.GetAll();
            }

            return list;
        }

        public int Save(Narapidana obj)
        {
            var result = 0;

            // cek nilai id_napi yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(obj.id_napi))
            {
                MessageBox.Show("id_napi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nilai nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(obj.nama_napi))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new NarapidanaRepository(context);

                // panggil method Save yang ada di dalam class repository
                result = _repository.Save(obj);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Narapidana berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Narapidana gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(Narapidana obj)
        {
            var result = 0;

            // cek nilai id_napi yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(obj.id_napi))
            {
                MessageBox.Show("id_napi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // cek nilai nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(obj.nama_napi))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new NarapidanaRepository(context);

                // panggil method Update yang ada di dalam class repository
                result = _repository.Update(obj);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Narapidana berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Narapidana gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Narapidana obj)
        {
            var result = 0;

            // cek nilai id_napi yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(obj.id_napi))
            {
                MessageBox.Show("id_napi harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (var context = new DbContext())
            {
                // membuat objek dari class repository
                _repository = new NarapidanaRepository(context);

                // panggil method Delete yang ada di dalam class repository
                result = _repository.Delete(obj);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Narapidana berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Narapidana gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
