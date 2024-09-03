namespace testModel.Models
{
    public class showdata
    {
        List<Show> data = new List<Show>();
        public showdata()
        {
            data.Add(new Show()
            {
                userId = 1,
                id = 5,
                title = "laboriosam mollitia et enim quasi adipisci quia provident illum",
                completed = false
            });

            data.Add(new Show()
            {
                userId = 2,
                id = 6,
                title = "qui ullam ratione quibusdam voluptatem quia omnis",
                completed = false
            });
            data.Add(new Show()
            {
                userId = 3,
                id = 6,
                title = "illo expedita consequatur quia in",
                completed = false
            });
        }

        public List<Show> getData()
        {
            return data;
        }
    }
}
