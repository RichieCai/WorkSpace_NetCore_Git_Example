namespace 單例模式
{
    public class Singleton
    {
        private static Singleton instance = null;

        private static readonly object obj = new object();

        public Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new Singleton();

                    }
                }
                return instance;
            }
        }

    }
}