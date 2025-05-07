using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace Sesion7_8_9;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Verificar si la contraseña es 12345678
        if (PasswordEntry.Text == "12345678")
        {
            Application.Current.MainPage = new AppShell();
            // Navegar a la página principal
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            // Mostrar mensaje de error si la contraseña es incorrecta
            await DisplayAlert("Error de acceso", "Contraseña incorrecta. Inténtelo de nuevo.", "OK");
        }
    }
    private async void ClickHuella(object sender, EventArgs e)
    {
        
        var request = new AuthenticationRequestConfiguration("Autenticacion", " Autenticacion por Huella"); //aqui configuramos la peticion
        var result = await CrossFingerprint.Current.AuthenticateAsync(request); //aqui solicitamos el resultado para que haga lo anterior
        if (result.Authenticated)
        {
            await DisplayAlert("Autenticado", "Se ha autenticado correctamente", "Cancelar");

            //Codigo si se autentica
        }
        else
        {
            await DisplayAlert("Fallo de Autenticacion", "No se ha autenticado correctamente!", "Cancelar");
        }
    }
}