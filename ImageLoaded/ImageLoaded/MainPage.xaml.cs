namespace ImageLoaded;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
        ImageLoadedTExt.Text = "Loading";
        TestImage.Loaded -= TestImage_Loaded;
        TestImage.Loaded += TestImage_Loaded;
        if (count % 2 == 0) 
		{
			TestImage.Source = "https://wallpaperaccess.com/full/301001.jpg";
        }
		else
		{
            TestImage.Source = "https://wallpaperaccess.com/l/301001.jpg";
        }
    }

    private async void TestImage_Loaded(object? sender, EventArgs e)
    {
        var res = await TestImage.Source.GetPlatformImageAsync(Handler.MauiContext);
        if (res == null && TestImage.Source != null)
        {
			ImageLoadedTExt.Text = "Loading Success";
		}
		else 
		{
            ImageLoadedTExt.Text = "Loading Failed";
        }
    }
}


