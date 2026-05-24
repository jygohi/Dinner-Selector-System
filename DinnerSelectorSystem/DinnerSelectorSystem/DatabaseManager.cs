using System;

namespace DinnerSelectorSystem
{
    public class DatabaseManager
    {
        private string dbPath;
        private bool isConnected;

        public DatabaseManager()
        {
            // 預設資料庫路徑設定
            dbPath = "DinnerDatabase.db3";
        }

        public void Connect()
        {
            // 未來實作 SQLite 連線邏輯
            isConnected = true;
        }

        public void Disconnect()
        {
            isConnected = false;
        }

        // 對應 UML 中的 executeUpdate，我們設計一個專門儲存紀錄的方法
        public bool SaveMealRecord(MealRecord record)
        {
            try
            {
                // 這裡未來會替換成 INSERT INTO 的 SQL 語法
                Console.WriteLine($"[模擬儲存] 已將 {record.RestaurantName} 寫入資料庫！");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"儲存失敗: {ex.Message}");
                return false;
            }
        }
    }
}