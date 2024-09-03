namespace WebRestfulApiEx.Controllers
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public User()
        {

        }
        public List<User> getData()
        {
            List<User> listUser = new List<User>();
            User user1 = new User()
            {
                id = 1,
                name = "toke",
                title = "MY FIREST 1",
                body = " et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut u"
            };
            User user2 = new User()
            {
                id = 2,
                name = "merry",
                title = "MY TWO",
                body = "  sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat bl"
            };
            User user3 = new User()
            {
                id = 3,
                name = "amy",
                title = "MY THREE",
                body = " ad\nvoluptatem doloribus vel accusantium quis pariatur"
            };
            User user4 = new User()
            {
                id = 4,
                name = "jessica",
                title = "my foure",
                body = " scipit\nsusct cum\nreprehenderit molestiae ut u"
            };
            User user5 = new User()
            {
                id = 5,
                name = "jessica",
                title = "my five",
                body = " et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprelestiae ut u"
            };
            User user6 = new User()
            {
                id = 6,
                name = "jessica",
                title = "my six",
                body = " um\nreprehenderit molestiae ut u"
            };
            listUser.Add(user1);
            listUser.Add(user2);
            listUser.Add(user3);
            listUser.Add(user4);
            listUser.Add(user5);
            listUser.Add(user6);
            return listUser;
        }
    }

}
