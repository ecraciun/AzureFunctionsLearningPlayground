using System;

namespace FunctionsPlayground.Models
{
    public class FoodOrder : FoodOrderRequest
    {
        public FoodOrder()
        {

        }

        public FoodOrder(FoodOrderRequest request)
        {
            ClientId = request.ClientId;
            DesiredFood = request.DesiredFood;
        }

        public Guid OrderId { get; set; }
    }
}