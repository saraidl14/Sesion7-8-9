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
        /// Método que se encarga de cambiar de ventana al hacer click en el botón.
        /// al clickar en detalles se nos muestren, se nos mostrará la información del dragón azul.
        /// </summary>
        /// param name="sender">Objeto que activa el evento</param>
        /// param name="e">Argumentos del evento que ayuda a la funcion</param>

        Navigation.PushAsync(new Detalles
        {
            // Navega a la página de detalles y asigna la información del dragón azul.

            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Azules",
                Image = "azul2.png",
                Description = "Los dragones azules son rápidos y esquivos. Su capacidad para maniobrar en el aire es sobresaliente, lo que los hace casi invencibles en combates aéreos.\r\n\r\n " +
                "Suelen ser los preferidos para misiones que requieren rapidez y precisión." +
                "Estos son dragones de gran tamaño, también se considera que son los más despiadados de todas las razas. Especialmente el Cola de daga azul, que es el mas raro de ellos. \r\n\r\n" +
                "Las púas de su cola, que tienen forma de cuchillas afiladas podrían destripar a cualquier enemigo con un solo movimiento. Por ello es mejor no acercarse a ningún dragón azul. Estos provienen de la línea Gormfaileas.\r\n\r\n"

            }

        });
    }
}