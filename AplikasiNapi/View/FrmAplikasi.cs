using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AplikasiNapi.Controller;
using AplikasiNapi.Model.Entity;

namespace AplikasiNapi.View
{
    public partial class FrmAplikasi : Form
    {
        // deklarasi objek controller
        private NarapidanaController _controller;

        // deklarasi private variabel/field _addData
        private bool _addData;


        public FrmAplikasi()
        {
            
            InitializeComponent();
            InisialisasiListView();

            // membuat objek controller
            _controller = new NarapidanaController();


            // tampilkan data mahasiwa
            LoadDataNarapidana();

            // atur ulang posisi tombol Simpan dan Batal
            // disamakan dg posisi tombol Tambah dan Perbaiki
            //btnSimpan1.Location = btnTambah1.Location;
            //btnBatal1.Location = btnPerbaiki1.Location;
        }
        private void LoadDataNarapidana()
        {
            // kosongkan data listview Narapidana
            lvwNarapidana.Items.Clear();

            // panggil method GetAll untuk mendapatkan semua data Narapidana
            var list = _controller.GetAll();

            // lakukan perulangan untuk menampilkan data Narapidana ke listview
            foreach (var napi in list)
            {
                var noUrut = lvwNarapidana.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(napi.id_napi);
                item.SubItems.Add(napi.nama_napi);
                item.SubItems.Add(napi.jeniskelamin_napi);
                item.SubItems.Add(napi.tempatlahir_napi);
                item.SubItems.Add(napi.tanggallahir_napi);
                item.SubItems.Add(napi.alamat_napi);
                item.SubItems.Add(napi.notlp_napi);
                item.SubItems.Add(napi.kasus_napi);
                item.SubItems.Add(napi.tgl_masuk);
                item.SubItems.Add(napi.tgl_bebas);

                lvwNarapidana.Items.Add(item);
            }
        }

        // format kolom listview
        private void InisialisasiListView()
        {
            lvwNarapidana.View = System.Windows.Forms.View.Details;
            lvwNarapidana.FullRowSelect = true;
            lvwNarapidana.GridLines = true;

            lvwNarapidana.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwNarapidana.Columns.Add("ID", 30, HorizontalAlignment.Center);
            lvwNarapidana.Columns.Add("Nama", 50, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Jenis Kelamin", 30, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Tempat Lahir", 30, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Tanggal Lahir", 30, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Alamat", 30, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("No. Telepon", 30, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Kasus", 50, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Tanggal Masuk", 80, HorizontalAlignment.Left);
            lvwNarapidana.Columns.Add("Tanggal Bebas", 80, HorizontalAlignment.Left);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah1_Click(object sender, EventArgs e)
        {
            // status untuk operasi tambah atau perbaiki
            _addData = true; // operasi tambah data baru

            // kosongkan isian npm, nama dan alamat
            txtId1.Clear();
            txtNama1.Clear();
            txtJenisKelamin1.Clear();
            txtTempat1.Clear();
            txtTglLahir1.Clear();
            txtAlamat1.Clear();
            txtNoTlp1.Clear();
            txtKasus1.Clear();
            txtTglMasuk1.Clear();
            txtTglBebas1.Clear();

            // fokus ke textbox npm
            txtId1.Focus();

            // sembunyikan btnTambah, btnPerbaiki dan btnHapus
            btnTambah1.Visible = false;
            btnPerbaiki1.Visible = false;
            btnHapus1.Visible = false;

            // tampilkan btnSimpan dan btnBatal
            btnSimpan1.Visible = true;
            btnBatal1.Visible = true;
        }

        private void btnBatal1_Click(object sender, EventArgs e)
        {
            // sembunyikan btnTambah, btnPerbaiki dan btnHapus
            btnTambah1.Visible = true;
            btnPerbaiki1.Visible = true;
            btnHapus1.Visible = true;

            // tampilkan btnSimpan dan btnBatal
            btnSimpan1.Visible = false;
            btnBatal1.Visible = false;

            // kosongkan isian npm, nama dan alamat
            txtId1.Clear();
            txtNama1.Clear();
            txtJenisKelamin1.Clear();
            txtTempat1.Clear();
            txtTglLahir1.Clear();
            txtAlamat1.Clear();
            txtNoTlp1.Clear();
            txtKasus1.Clear();
            txtTglMasuk1.Clear();
            txtTglBebas1.Clear();
        }

        private void btnPerbaiki1_Click(object sender, EventArgs e)
        {
            // cek apakah data Narapidana sudah dipilih
            if (lvwNarapidana.SelectedItems.Count > 0)
            {
                _addData = false;

                // ambil index listview yang di pilih
                var index = lvwNarapidana.SelectedIndices[0];

                var item = lvwNarapidana.Items[index];
                txtId1.Text = item.SubItems[1].Text;
                txtNama1.Text = item.SubItems[2].Text;
                txtJenisKelamin1.Text = item.SubItems[3].Text;
                txtTempat1.Text = item.SubItems[4].Text;
                txtTglLahir1.Text = item.SubItems[5].Text;
                txtAlamat1.Text = item.SubItems[6].Text;
                txtNoTlp1.Text = item.SubItems[7].Text;
                txtKasus1.Text = item.SubItems[8].Text;
                txtTglMasuk1.Text = item.SubItems[9].Text;
                txtTglBebas1.Text = item.SubItems[10].Text;

                // fokus ke textbox npm
                txtId1.Focus();

                // sembunyikan tombol tambah, perbaiki dan hapus
                btnTambah1.Visible = false;
                btnPerbaiki1.Visible = false;
                btnHapus1.Visible = false;

                // tampilkan tombol simpan dan batal
                btnSimpan1.Visible = true;
                btnBatal1.Visible = true;
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Narapidana belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSimpan1_Click(object sender, EventArgs e)
        {
            // membuat objek dari class Narapidana
            var napi = new Narapidana();

            // set nilai property objek Narapidana
            napi.id_napi = txtId1.Text;
            napi.nama_napi = txtNama1.Text;
            napi.jeniskelamin_napi = txtJenisKelamin1.Text;
            napi.tempatlahir_napi = txtTempat1.Text;
            napi.tanggallahir_napi = txtTglLahir1.Text;
            napi.alamat_napi = txtAlamat1.Text;
            napi.notlp_napi = txtNoTlp1.Text;
            napi.kasus_napi = txtKasus1.Text;
            napi.tgl_masuk = txtTglMasuk1.Text;
            napi.tgl_bebas = txtTglBebas1.Text;

            var result = 0;

            if (_addData == true) // tambah data baru, panggil method Save
                result = _controller.Save(napi);
            else // edit data, panggil method Update
                result = _controller.Update(napi);

            if (result > 0) // tambah/edit data berhasil
            {
                // reset inputan dta
                txtId1.Clear();
                txtNama1.Clear();
                txtJenisKelamin1.Clear();
                txtTempat1.Clear();
                txtTglLahir1.Clear();
                txtAlamat1.Clear();
                txtNoTlp1.Clear();
                txtKasus1.Clear();
                txtTglMasuk1.Clear();
                txtTglBebas1.Clear();

                txtId1.Focus();

                // tampilkan kembali tombol tambah, perbaiki dan hapus
                btnTambah1.Visible = true;
                btnPerbaiki1.Visible = true;
                btnHapus1.Visible = true;

                // sembunyikan tombol simpan dan batal
                btnSimpan1.Visible = false;
                btnBatal1.Visible = false;

                // refresh data yang ditampilkan
                LoadDataNarapidana();
            }
        }

        private void btnHapus1_Click(object sender, EventArgs e)
        {
            // cek apakah data Narapidana sudah dipilih
            if (lvwNarapidana.SelectedItems.Count > 0)
            {
                // tampilkan konfirmasi
                var konfirmasi = MessageBox.Show("Apakah data Narapidana ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil index listview yang di pilih
                    var index = lvwNarapidana.SelectedIndices[0];
                    var item = lvwNarapidana.Items[index];

                    // membuat objek dari class Narapidana
                    var napi = new Narapidana();
                    napi.id_napi = item.SubItems[1].Text;

                    var result = _controller.Delete(napi);
                    if (result > 0) LoadDataNarapidana(); // jika hapus berhasil, referesh data Narapidana
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Narapidana belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
