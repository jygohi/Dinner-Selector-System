using System;
using Microsoft.Maui.Controls;

namespace DinnerSelectorSystem
{
    public partial class MealLogUI : ContentPage
    {
        // 宣告 DatabaseManager
        private DatabaseManager _dbManager;

        // 對應 UML 中的私有變數 (實務上這些值通常直接從 XAML 的 TextBox/ComboBox 取得，
        // 但為了符合你的架構，我們在這裡宣告它們作為暫存或綁定對象)
        private string inputCategory;
        private int inputPrice;
        private string inputMethod;
        private string inputStoreName;
        private float inputRating;
        private bool isPhysicalStore;
        private string selectedPlaceId;

        public MealLogUI()
        {
            InitializeComponent();
            _dbManager = new DatabaseManager();
        }

        // 對應 UML: validateInput(): Boolean
        private bool ValidateInput()
        {
            // 這裡假設從畫面元件取得值 (例如: inputStoreName = StoreNameEntry.Text)
            // 這裡寫死測試值，實作時請替換成畫面元件的值
            inputStoreName = "八方雲集";
            inputPrice = 120;
            inputCategory = "麵食";

            if (string.IsNullOrWhiteSpace(inputStoreName))
            {
                DisplayAlert("錯誤", "請輸入餐廳名稱", "確定");
                return false;
            }

            if (inputPrice <= 0)
            {
                DisplayAlert("錯誤", "請輸入有效的價格", "確定");
                return false;
            }

            return true;
        }

        // 對應 UML: clearForm(): void
        private void ClearForm()
        {
            inputStoreName = string.Empty;
            inputPrice = 0;
            inputCategory = string.Empty;
            // (清空畫面元件的值，例如 StoreNameEntry.Text = "";)
        }

        // 對應 UML: submitLog(): void
        private async void SubmitLog(object sender, EventArgs e)
        {
            // 1. 驗證輸入
            if (!ValidateInput())
            {
                return;
            }

            // 2. 將資料打包進 MealRecord 物件
            MealRecord newRecord = new MealRecord
            {
                MealId = Guid.NewGuid().ToString(), // 自動產生唯一 ID
                RestaurantName = inputStoreName,
                Price = inputPrice,
                Category = inputCategory,
                DiningMethod = inputMethod,
                Rating = inputRating,
                IsPhysicalStore = isPhysicalStore,
                RestaurantId = selectedPlaceId,
                Timestamp = DateTime.Now
            };

            // 3. 呼叫 DatabaseManager 寫入資料庫
            _dbManager.Connect();
            bool isSuccess = _dbManager.SaveMealRecord(newRecord);
            _dbManager.Disconnect();

            // 4. 根據結果通知使用者
            if (isSuccess)
            {
                await DisplayAlert("成功", "餐點紀錄已成功儲存！", "太棒了");
                ClearForm();
            }
            else
            {
                await DisplayAlert("失敗", "儲存時發生錯誤，請重試。", "確定");
            }
        }
    }
}