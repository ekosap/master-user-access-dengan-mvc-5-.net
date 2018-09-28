using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.ViewModel
{
    public class MEmployeeVM
    {
        public int id { get; set; }
        public string employee_number { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<int> m_company_id { get; set; }
        public string email { get; set; }
        public bool is_active { get; set; }
        public int created_by { get; set; }
        public System.DateTime created_date { get; set; }
        public Nullable<int> updated_by { get; set; }
        public Nullable<System.DateTime> updated_date { get; set; }
        public string company { get; set; }
        public string fullName { get; set; }
        public MUserVM listUser { get; set; }
    }
}
