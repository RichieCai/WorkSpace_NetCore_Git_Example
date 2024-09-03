using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 範例1.Input;
using 範例1.Model;
using 範例1.Models;
using 範例1.Repository;

namespace 範例1.Service
{
    public class ZoomService
    {
        public ZoomService()
        {
        }

        public List<T> getData<T>(InputData i,T t)
        {
            var result = ZoomRepository.getdata<T>(t);
            var Newresult = from x in result
                            select CopyProperties<T>(x);
            return Newresult.ToList();
        }

        public List<Dog> getData2(InputData i, Dog t)
        {
            var result = ZoomRepository.getdata<Dog>(t).Cast<Dog>().ToList();
            var Newresult = (from x in result
                            select new { 
                            name=x.name,
                            age= result.Where(x=>x.age>300).ToList(),
                            
                            }).ToList();
            //return Newresult.ToList();
            return null;
        }



        private T CopyProperties<T>(object source)
        {
            var destination = Activator.CreateInstance<T>();
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = typeof(T).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
                if (destinationProperty != null)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }

            return destination;
        }



    }
}
