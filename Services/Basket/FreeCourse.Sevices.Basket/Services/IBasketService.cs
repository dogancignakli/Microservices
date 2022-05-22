using System;
using System.Threading.Tasks;
using FreeCourse.Sevices.Basket.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Sevices.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basket); // Yoksa oluşturacak, var ise update edecek.
        Task<Response<bool>> Delete(string userId);
    }
}

