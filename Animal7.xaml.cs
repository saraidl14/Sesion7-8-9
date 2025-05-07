namespace Sesion7_8_9;

public partial class Animal7 : ContentPage
{
	public Animal7()
	{
		InitializeComponent();
	}
    /// <summary>
    /// Permite cambiar de ventana al hacer click en el bot�n.
    /// Muestra los detalles del drag�n dorado.
    /// M�todo que se encarga de cambiar de ventana al hacer click en el bot�n.
    /// </summary>
    /// param name="sender">Objeto que activa el evento 
    /// param name="e">Argumentos del evento que ayuda a la funcion
    private void DetallesBTN(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Detalles
        {
            // Navega a la p�gina de detalles y asigna la informaci�n del drag�n dorado.
            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Dorados",
                Image = "dorado.png",
                Description = "Los dragones dorados destacan por su velocidad y agilidad. \r\n\r\n" +
                "Son m�s peque�os en comparaci�n con otros tipos, pero compensan con su capacidad para maniobras r�pidas y evasivas. Son astutos y pueden superar a sus oponentes con destreza en lugar de fuerza.\r\n\r\n"

            }

        });
    }
}