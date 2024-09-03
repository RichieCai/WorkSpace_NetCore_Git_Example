namespace 抽象類別基本用法
{
    public abstract class Person
    {
        public string _Name;
        public int _Age;
        public abstract string Area { get; set; }
        public Person() 
        { }
        public Person(string Name, int Age)
        {
            this._Name = Name;
            this._Age = Age;
        }
        public abstract void eat();
        public abstract string Jump();
        public void action()
        {
            Console.WriteLine(@$"我是Person跑起來Name:{this._Name},年齡{this._Age}");
        }

        public abstract string Skill();
    }
}