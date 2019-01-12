using System;

namespace FunctionsPlayground.Models
{
    public class FoodOrderRequest
    {
        public Guid ClientId { get; set; }
        public RestaurantRecipes DesiredFood { get; set; }
    }
}