using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 範例1.Model;
using 範例1.Models;

namespace 範例1.Repository
{
    public class ZoomRepository
    {
        public static List<object> getdata<T>(T t)
        {
            List <T> listResult=new List<T>();
            switch (t)
            {
                case Dog:
                    return getDog().Cast<object>().ToList();
                    break;

                case Bird:
                    return getBird().Cast<object>().ToList();
                    break;

            }
            return null;
        }

        public static List<Dog> getDog()
        {
            return new List<Dog>()
            {
                new Dog()
                {
                    name="小黃",
                    age=5,
                    call="旺旺",
                    run=15,
                },
                new Dog()
                {
                    name="小黑",
                    age=7,
                    call="旺!!!",
                    run=33,
                },
                 new Dog()
                {
                    name="小白",
                    age=11,
                    call="旺~~~~~!!",
                    run=23,
                }
                , new Dog()
                {
                    name="小藍",
                    age=2,
                    call="旺旺旺旺旺旺",
                    run=22,
                }
            };
        }


        public static List<Bird> getBird()
        {
            return new List<Bird>()
            {
                new Bird()
                {
                Name="藍藍",
                Age=5,
                Fly=15
                },
                new Bird()
                {
                Name="藍鵲",
                Age=7,
                Fly=22
                },
                new Bird()
                {
                Name="小天藍",
                Age=15,
                Fly=23
                },
            };
        }
    }
}
