namespace Sesion7_8_9;

public partial class Animal1 : ContentPage
{
	public Animal1()
	{
		InitializeComponent();
	}
    /// <summary>
    /// Método que se encarga de cambiar de ventana al hacer click en el botón.
    /// Es el que va a hacer que al clickar en detalles se nos muestren.
    /// </summary>
    /// <param name="sender">Objeto que activa el evento</param>
    /// <param name="e">Argumentos del evento que ayuda a la funcion</param>
    private void DetallesBTN(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Detalles
        {
            // Navega a la página de detalles y asigna la información del dragón marrón.

            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Marrones",
                Image = "marron2.jpg",
                Description = "Los dragones marrones son un armazón de carne y hueso. Son equilibrados en sus habilidades, " +
                "combinando fuerza y resistencia con una buena capacidad para la maniobra. " +
                "Su versatilidad los convierte en una opción sólida para cualquier jinete.\r\n\r\n" +
                "Poco se sabe realmente de esta raza de dragón, pero una cosa es clara no muestres debilidad ante ellos. " +
                "Como es bien sabido por todos, es mejor no mostrar miedo ante ellos, o podrías acabar chamuscado y reducido a cenizas.\r\n\r\n" +
                " Esto por supuesto aplica a todos los dragones."
            }

        });
    }
}