using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 抽象工廠3.Factory;
using 抽象工廠3.Input;
using 抽象工廠3.Interface;
using 抽象工廠3.Model;
using 抽象工廠3.Models;
using 抽象工廠3.Repository;

namespace 抽象工廠3.Service
{
    public class ZoomServiceManager 
    {
        public ZoomServiceManager ()
        {
        }

        public List<T> getData<T>(InputData input) where T : class
        {
            var factory = GetFactory<T>();
            var result = ZoomRepository.getdata<T>(input);
            var Newresult = from x in result
                            select CreateAnimalWithCommonProperties<T>(factory, x);

            foreach (var item in Newresult)
            {
                // 处理各自类的逻辑
            }

            return Newresult.ToList();
        }

        private IAnimalFactory<T> GetFactory<T>() where T : class
        {
            if (typeof(T) == typeof(Dog))
            {
                return new DogFactory() as IAnimalFactory<T>;
            }
            else if (typeof(T) == typeof(Bird))
            {
                return new BirdFactory() as IAnimalFactory<T>;
            }
            else
            {
                throw new NotSupportedException("Unsupported animal type");
            }
        }

        private T CreateAnimalWithCommonProperties<T>(IAnimalFactory<T> factory, object source) where T : class
        {
            var animal = factory.CreateAnimal();
            // 复制共同属性
            if (animal is Dog dog && source is Dog dogSource)
            {
                dog.name = dogSource.name;
                dog.age = dogSource.age;
                dog.run = dogSource.run;
                dog.call = dogSource.call;
            }
            else if (animal is Bird bird && source is Bird birdSource)
            {
                bird.Name = birdSource.Name;
                bird.Age = birdSource.Age;
                bird.Fly = birdSource.Fly;
            }
            return animal;
        }
    }
}
