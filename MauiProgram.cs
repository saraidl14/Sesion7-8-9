using Microsoft.Extensions.Logging;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Sesion7_8_9;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Nunito-Italic-VariableFont_wght.ttf", "Nunito");
            });


#if  ANDROID
		builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);

#endif

        return builder.Build();
	}
}