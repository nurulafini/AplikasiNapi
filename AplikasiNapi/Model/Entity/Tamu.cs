using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikasiNapi.Model.Entity
{
    public class Tamu
    {
        public string id_tamu { get; set; }
        public string nama_tamu { get; set; }
        public string jeniskelamin_tamu { get; set; }
        public string alamat_tamu { get; set; }
        public string notlp_tamu { get; set; }
    }
}
