using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 設計模式5.Service
{
    public class AnimalService
    {
        public AnimalService()
        { 
        }
        public list<T> a1<T>(Input input) where T : calss, IZoom
        {

            var sourceAll = user.getdata<T>(input);
            var SourceMatch = user.getdata2<T>(input);
            foreach (var m in SourceMatch)
            {
                var Newresult = sourceAll.Where(x => x.age == m.age)
    
                      select(k => new
                      {
                          k = k,
                          sum = sum + 1
                      }).ToList()
    
         }

        }
    }
}
