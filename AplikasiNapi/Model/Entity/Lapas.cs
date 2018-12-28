using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiNapi.Model.Entity
{
    public class Lapas
    {
        public string id_lapas { get; set; }
        public string nama_napi { get; set; }
        public string tgl_masuk { get; set; }
        public string tgl_bebas { get; set; }
        public string nama_ptugas { get; set; }
        public string id_napi { get; set; }
        public string id_petugas { get; set; }
    }
}
