namespace DinnerSelectorSystem;

public partial class MainPage : ContentPage //class FindMealUI
{
    private bool isLoading = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSystemRecommendClicked(object sender, EventArgs e)
    {
        await DisplayAlert("系統推薦", "準備切換至條件設定介面", "確定");
    }

    private async void OnRandomPickClicked(object sender, EventArgs e)
    {
        isLoading = true;
        LoadingOverlay.IsVisible = true; // 進度條
        await Task.Delay(2500); // 等待時間2.5秒

        isLoading = false;
        LoadingOverlay.IsVisible = false;

        await DisplayAlert("挑選完成", "已隨機為您抽中一家餐廳！", "去看看");
    }
}