using Microsoft.Extensions.Logging;

namespace MauiBlazorApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

#if ANDROID
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.2.2:7108/") });
#elif IOS
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://127.0.0.1:7108/") });
#else
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7108/") });
#endif

        builder.Services.AddHttpClient();
        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddBlazoredLocalStorage();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
