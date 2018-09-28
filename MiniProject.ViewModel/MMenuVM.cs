using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.ViewModel
{
    public class MMenuVM
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string controller { get; set; }
        public Nullable<int> parent_id { get; set; }
        public bool is_active { get; set; }
        public int created_by { get; set; }
        public System.DateTime created_date { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
    }
}
