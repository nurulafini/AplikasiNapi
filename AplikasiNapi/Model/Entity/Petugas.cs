using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiNapi.Model.Entity
{
    public class Petugas
    {
        public string id_petugas { get; set; }
        public string nama_petugas { get; set; }
        public string jeniskelamin_petugas { get; set; }
        public string tempatlahir_petugas { get; set; }
        public string tanggallahir_petugas { get; set; }
        public string alamat_petugas { get; set; }
        public string notlp_petugas { get; set; }
        public string id_tamu { get; set; }
    }
}
