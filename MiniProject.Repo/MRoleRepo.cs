using MiniProject.Model;
using MiniProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Repo
{
    public class MRoleRepo
    {
        public static List<MRoleVM> get()
        {
            var data = new List<MRoleVM>();
            using (AppEntities db = new AppEntities())
            {
                data = db.m_role.Select(x => new MRoleVM()
                {
                    id = x.id,
                    code = x.code,
                    name = x.name,
                    createdBy = x.created_by,
                    createdDate = x.created_date,
                    isActive = x.is_active
                }).ToList();
            }
            return data;
        }

        public static bool insert(MMenuAccessVM model)
        {
            bool result = false;
            using (AppEntities db = new AppEntities())
            {
                foreach (var item in model.listMenuId)
                {
                    var data = new m_menu_access()
                    {
                        m_role_id = model.role.id,
                        created_by = 2,
                        is_active = true,
                        created_date = DateTime.Now,
                        m_menu_id = item
                    };
                    db.m_menu_access.Add(data);
                }
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }

        public static bool update(MMenuAccessVM model)
        {
            bool result = false;
            using (AppEntities db = new AppEntities())
            {
                var dataMenu = db.m_menu_access.Where(x => x.m_role_id == model.role.id);
                db.m_menu_access.RemoveRange(dataMenu);
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                    throw;
                }
                //memasukan idMenu Baru
                foreach (var item in model.listMenuId)
                {
                    m_menu_access data = new m_menu_access() {
                        m_role_id=model.role.id,
                        m_menu_id = item,
                        created_by = 2,
                        created_date = DateTime.Now,
                        is_active = true
                    };
                    db.m_menu_access.Add(data);
                }
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {

                    throw;
                }

            }
            return result;
        }

        public static MMenuAccessVM getByIdRole(int id)
        {
            var data = new MMenuAccessVM();
            using (AppEntities db = new AppEntities())
            {
                var roleAccess = db.m_role.Select(x => new MRoleVM()
                {
                    id = x.id,
                    name = x.name,
                    code = x.code,
                    createdBy = x.created_by,
                    description = x.description
                })
                .Where(x => x.id == id)
                .FirstOrDefault();
                //ambil data menu dengan role id diatas
                var menuList = db.m_menu_access
                    .Where(x => x.m_role_id == id)
                    .Select(x => new MMenuVM()
                    {
                        id = x.m_menu_id,
                        name = x.m_menu.name,
                        is_active = x.is_active,
                        updated_by = x.updated_by,
                        updated_date = x.updated_date
                    }).ToList();
                //memasukan ke alamat yg telah disiapkan
                data.role = roleAccess;
                data.listMenu = menuList;
            }
            return data;
        }
    }
}
