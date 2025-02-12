using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Microsoft.Maui.Hosting;


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
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5237/") });
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
