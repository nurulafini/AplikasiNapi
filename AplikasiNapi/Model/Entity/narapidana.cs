using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiNapi.Model.Entity
{
    public class Narapidana
    {
        public string id_napi { get; set; }
        public string nama_napi { get; set; }
        public string jeniskelamin_napi { get; set; }
        public string tempatlahir_napi { get; set; }
        public string tanggallahir_napi { get; set; }
        public string alamat_napi { get; set; }
        public string notlp_napi { get; set; }
        public string kasus_napi { get; set; }
        public string tgl_masuk { get; set; }
        public string tgl_bebas { get; set; }
    }
}
