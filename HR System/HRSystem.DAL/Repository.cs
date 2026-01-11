using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Entities;
using MySql.Data.MySqlClient;

namespace HRSystem.DAL
{
    public class Repository<T> where T : BaseEntity, new()
    {
        protected MySqlConnection _connection;

        public Repository()
        {
            _connection = new MySqlConnection(
                "Server=172.21.54.253;Database=26_132430122;User ID=26_132430122;Password=İnif123.;"
            );
        }

        public virtual List<T> GetAll()
        {
            // مؤقتاً نرجّع قائمة فاضية
            // (إحنا أصلاً عاملين CRUD في Repos المتخصصة)
            return new List<T>();
        }

        public virtual void Add(T entity)
        {
            // التنفيذ موجود في Repos المتخصصة
        }

        public virtual void Update(T entity)
        {
        }

        public virtual void Delete(int id)
        {
        }
    }
}
