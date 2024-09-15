using Test0912.Models;

namespace Test0912.Services.IService
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
