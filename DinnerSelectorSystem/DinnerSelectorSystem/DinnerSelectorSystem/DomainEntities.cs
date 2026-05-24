using System;

namespace DinnerSelectorSystem
{
    public class MealRecord
    {
        public string MealId { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string DiningMethod { get; set; }
        public string RestaurantName { get; set; }
        public string TransportMethod { get; set; }
        public float Rating { get; set; }
        public DateTime Timestamp { get; set; }

        // 配合實體店家與 API 擴充的欄位
        public bool IsPhysicalStore { get; set; }
        public string RestaurantId { get; set; }

        public string GetDetails()
        {
            return $"{Timestamp:yyyy/MM/dd} - {RestaurantName} ({Category}) - ${Price}";
        }

        public void UpdateRating(float newRating)
        {
            Rating = newRating;
        }
    }
}