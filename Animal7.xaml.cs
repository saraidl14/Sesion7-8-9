namespace Sesion7_8_9;

public partial class Animal7 : ContentPage
{
	public Animal7()
	{
		InitializeComponent();
	}
    /// <summary>
    /// Permite cambiar de ventana al hacer click en el botón.
    /// Muestra los detalles del dragón dorado.
    /// Método que se encarga de cambiar de ventana al hacer click en el botón.
    /// </summary>
    /// param name="sender">Objeto que activa el evento 
    /// param name="e">Argumentos del evento que ayuda a la funcion
    private void DetallesBTN(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Detalles
        {
            // Navega a la página de detalles y asigna la información del dragón dorado.
            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Dorados",
                Image = "dorado.png",
                Description = "Los dragones dorados destacan por su velocidad y agilidad. \r\n\r\n" +
                "Son más pequeños en comparación con otros tipos, pero compensan con su capacidad para maniobras rápidas y evasivas. Son astutos y pueden superar a sus oponentes con destreza en lugar de fuerza.\r\n\r\n"

            }

        });
    }
}