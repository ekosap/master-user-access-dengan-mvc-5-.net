using MiniProject.Model;
using MiniProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Repo
{
    public class MEmployeeRepo
    {
        public static List<MEmployeeVM> get()
        {
            List<MEmployeeVM> data = new List<MEmployeeVM>();
            using (AppEntities db = new AppEntities())
            {
                data = db.m_employee
                    .Include("m_company")
                    .Select(x => new MEmployeeVM()
                    {
                        id = x.id,
                        first_name = x.first_name,
                        last_name = x.last_name,
                        company = x.m_company.name,
                        fullName = x.first_name + " " + x.last_name
                    })
                    .ToList();
            }
            return data;
        }
        public static MEmployeeVM getDataById(int id)
        {
            MEmployeeVM hasil = new MEmployeeVM();
            using (AppEntities db = new AppEntities())
            {
                hasil = db.m_employee
                    .Include("m_company")
                    .Select(x => new MEmployeeVM()
                    {
                        id = x.id,
                        company = x.m_company.name
                    })
                .Where(x => x.id == id)
                .FirstOrDefault();
            }
            return hasil;
        }
        public static List<MEmployeeVM> getDataNonUser()
        {
            List<MEmployeeVM> data = new List<MEmployeeVM>();
            using (AppEntities db = new AppEntities())
            {
                var query = from listEmployee in db.m_employee
                            join user in db.m_user on listEmployee.id equals user.m_employee_id into listKar

                            from t in listKar.DefaultIfEmpty()
                            where t == null
                            select new MEmployeeVM { id = listEmployee.id, fullName = listEmployee.first_name + " " + listEmployee.last_name };
                data = query.ToList();
            }
            return data;
            }
    }
}