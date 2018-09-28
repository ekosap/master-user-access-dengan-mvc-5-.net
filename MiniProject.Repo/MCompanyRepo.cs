using MiniProject.Model;
using MiniProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Repo
{
    public class MCompanyRepo
    {
        public static List<MCompanyVM> get()
        {
            List<MCompanyVM> data = new List<MCompanyVM>();
            using (AppEntities db = new AppEntities())
            {
                data = db.m_company
                    .Select(x => new MCompanyVM()
                    {
                        id = x.id,
                        name = x.name
                    })
                    .ToList();
            }
            return data;
        }
    }
}
