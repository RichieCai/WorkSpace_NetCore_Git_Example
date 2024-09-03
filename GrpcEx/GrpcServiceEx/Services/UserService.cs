using Grpc.Core;
using GrpcServiceEx.Protos;
using System.ComponentModel.DataAnnotations;

namespace GrpcServiceEx.Services
{
    public class UserService : Protos.UserService.UserServiceBase
    {
        public override Task<UserResult> GetAllName(UserInput request, ServerCallContext context)
        {
            List<UserResult> listData = new List<UserResult>()
            {
                new UserResult(){
                UserId =1,
                UserName = "amy",
                Phone=132213,
                },
                 new UserResult(){
                UserId =2,
                UserName ="tenny",
                Phone=66666,
                },
                  new UserResult(){
                UserId =3,
                UserName = "dianao",
                Phone=777777,
                },
            };


            return Task.FromResult(listData.FirstOrDefault(x=>x.UserId== request.UserId));
        }
    }
}
