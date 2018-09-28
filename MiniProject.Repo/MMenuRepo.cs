using MiniProject.Model;
using MiniProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Repo
{
    public class MMenuRepo
    {
        public static List<MMenuVM> get()
        {
            List<MMenuVM> data = new List<MMenuVM>();
            using (AppEntities db = new AppEntities())
            {
                data = db.m_menu
                    .Select(x => new MMenuVM()
                    {
                        id = x.id,
                        name = x.name
                    })
                    .ToList();
            }
            return data;
        }

        public static List<MMenuAccessVM> getId(int id)
        {
            var data = new List<MMenuAccessVM>();
            using (AppEntities db = new AppEntities())
            {
                data = db.m_menu_access
                    .Where(x => x.m_role_id == id && x.is_active == true)
                    .Select(x => new MMenuAccessVM()
                {
                    m_menu_id = x.m_menu_id
                })
                
                .ToList();
            }
            return data;
        }
    }
}
