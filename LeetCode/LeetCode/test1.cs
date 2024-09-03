using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class test1
    {
        public List<User> GetData<T>()
        {
            User user = new User();
            return user.GetData();
        }

        //public T? GetDataNull<T>() where T : class
        //{
        //    User user = new User();
        //    return user.GetData();
        //}

        // 返回非可空类型T
        public T GetUserValue<T>() where T : class, new()
        {

            // 返回一个新的T对象
            return new T();
        }

        public T GetUserValue2<T>() where T : class, new()
        {

            // 返回一个新的T对象
            return default(T);
        }

        // 返回可空类型T?
        public T? GetNullableUserValue<T>() where T : class, new()
        {
            T T1 = new T();
            return new T();
        }

        public T? GetNullableUserValue2<T>() where T : class
        {
            // 返回null
            return default(T);
        }
    }
}
