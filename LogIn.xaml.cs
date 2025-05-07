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
}