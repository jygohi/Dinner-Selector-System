namespace DinnerSelectorSystem;

public partial class HistoryBrowseUI : ContentPage
{
    public HistoryBrowseUI()
    {
        InitializeComponent(); // 這行很重要，不能刪掉或註解掉喔！
    }

    // 加入這個按鈕點擊的對應函式
    private async void OnAddRecordClicked(object sender, EventArgs e)
    {
        // 暫時先用彈窗測試按鈕有沒有反應
        await DisplayAlert("新增", "準備跳出紀錄介面", "確定");
    }
}