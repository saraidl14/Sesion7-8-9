namespace Sesion7_8_9;

public partial class LogIn : ContentPage
{
	public LogIn()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Verificar si la contrase�a es 12345678
        if (PasswordEntry.Text == "12345678")
        {
            Application.Current.MainPage = new AppShell();
            // Navegar a la p�gina principal
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            // Mostrar mensaje de error si la contrase�a es incorrecta
            await DisplayAlert("Error de acceso", "Contrase�a incorrecta. Int�ntelo de nuevo.", "OK");
        }
    }
}