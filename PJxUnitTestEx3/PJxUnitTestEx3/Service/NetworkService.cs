using System.Net.NetworkInformation;
using UniTestEx.Interface;

namespace UniTestEx.Service
{
    public class NetworkService
    {
        private readonly IUserRepository _userRepository;
        public NetworkService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string SendPing()
        {
            var IsUser = _userRepository.IsUser();
            if (IsUser)
                return "成功結果!";
            else
                return "錯誤";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment=true,
                    Ttl=1
                },
                new PingOptions()
                {
                    DontFragment=true,
                    Ttl=1
                },
                 new PingOptions()
                 {
                    DontFragment=true,
                    Ttl=1
                },
            };
            return pingOptions;
        }
    }
}
