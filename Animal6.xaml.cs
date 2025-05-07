namespace Sesion7_8_9;

public partial class Animal6 : ContentPage
{
	public Animal6()
	{
		InitializeComponent();
	}

    private void DetallesBTN(object sender, EventArgs e)
    {
        /// <summary>
        /// M�todo que se encarga de cambiar de ventana al hacer click en el bot�n.
        /// al clickar en detalles se nos muestren, se nos mostrar� la informaci�n del drag�n azul.
        /// </summary>
        /// param name="sender">Objeto que activa el evento</param>
        /// param name="e">Argumentos del evento que ayuda a la funcion</param>

        Navigation.PushAsync(new Detalles
        {
            // Navega a la p�gina de detalles y asigna la informaci�n del drag�n azul.

            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Azules",
                Image = "azul2.png",
                Description = "Los dragones azules son r�pidos y esquivos. Su capacidad para maniobrar en el aire es sobresaliente, lo que los hace casi invencibles en combates a�reos.\r\n\r\n " +
                "Suelen ser los preferidos para misiones que requieren rapidez y precisi�n." +
                "Estos son dragones de gran tama�o, tambi�n se considera que son los m�s despiadados de todas las razas. Especialmente el Cola de daga azul, que es el mas raro de ellos. \r\n\r\n" +
                "Las p�as de su cola, que tienen forma de cuchillas afiladas podr�an destripar a cualquier enemigo con un solo movimiento. Por ello es mejor no acercarse a ning�n drag�n azul. Estos provienen de la l�nea Gormfaileas.\r\n\r\n"

            }

        });
    }
}