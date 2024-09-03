namespace WebRedisEx.ViewModels
{
    public class ShowVM<T> where T : class
    {
        public string Method { get; set; }

        public T Data { get; set; }
    }
}
