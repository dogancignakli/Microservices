using System;
using System.Text.Json;
using System.Threading.Tasks;
using FreeCourse.Sevices.Basket.Dtos;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Sevices.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found.", 404);

        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDatabase().StringGetAsync(userId); // userId olarak atılan keye sahip bi value var mı?

            if (String.IsNullOrEmpty(existBasket))
                return Response<BasketDto>.Fail("Basket not found.", 404);

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);

        }   

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basket)
        {
            var status = await _redisService.GetDatabase().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
            
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save.", 500);
        }
    }
}

