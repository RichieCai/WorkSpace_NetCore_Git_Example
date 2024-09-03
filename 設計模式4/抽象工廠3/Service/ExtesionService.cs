using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠3.Model;
using 抽象工廠3.Models;

namespace 抽象工廠3.Service
{
    internal static class ExtesionService
    {

        public static T ConvertToModel<S, T>(this S input, Action<S, T> specialMapper = null) where T : new()
        {
            T result = new T();
            foreach (var item in typeof(T).GetProperties())
            {
                var value = typeof(S).GetProperty(item.Name)?.GetValue(input);
                if (value is null)
                {
                    continue;
                }
                item.SetValue(result, value);
            }
            specialMapper?.Invoke(input, result);
            return result;
        }

    }
}
