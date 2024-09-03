using Grpc.Core;
using GrpcServiceEx.Protos;
namespace GrpcServiceEx.Services
{
    public class ProductService : Protos.ProductService.ProductServiceBase
    {
        public override Task<ProductResult> Get(ProductInput request, ServerCallContext context)
        {
            List<ProductResult> listData = new List<ProductResult>()
            {
                new ProductResult(){
                ProductId =111,
                ProductName = "iphone",
                Price=132213,
                Quailty=300
                },
                 new ProductResult(){
                ProductId =222,
                ProductName = "samsum",
                Price=56784,
                Quailty=200
                },
                  new ProductResult(){
                ProductId =333,
                ProductName = "sony",
                Price=97846,
                Quailty=120
                },
            };


            return Task.FromResult(listData.FirstOrDefault(x => x.ProductId == request.ProductId));
        }
    }
}
