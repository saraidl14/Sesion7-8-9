namespace Sesion7_8_9;

public partial class Galeria : ContentPage
{
	public Galeria()
	{
		InitializeComponent();
	}
    private void ButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Detalles
        {
            // Navega a la p�gina de detalles y asigna la informaci�n del drag�n marr�n.

            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Marrones",
                Image = "marron2.png",
                Description = "Los dragones marrones son un armaz�n de carne y hueso. Son equilibrados en sus habilidades, " +
               "combinando fuerza y resistencia con una buena capacidad para la maniobra. " +
               "Su versatilidad los convierte en una opci�n s�lida para cualquier jinete.\r\n\r\n" +
               "Poco se sabe realmente de esta raza de drag�n, pero una cosa es clara no muestres debilidad ante ellos. " +
               "Como es bien sabido por todos, es mejor no mostrar miedo ante ellos, o podr�as acabar chamuscado y reducido a cenizas.\r\n\r\n" +
               " Esto por supuesto aplica a todos los dragones."
            }

        });
    }
}