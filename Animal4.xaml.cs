namespace Sesion7_8_9;

public partial class Animal4 : ContentPage
{
	public Animal4()
	{
		InitializeComponent();
	}
    private void DetallesBTN(object sender, EventArgs e)
    {
        /// <summary>
        /// M�todo que se encarga de cambiar de ventana al hacer click en el bot�n.
        /// Es el que va a hacer que al clickar en detalles se nos muestren.
        /// </summary>
        /// <param name="sender">Objeto que activa el evento</param>
        /// <param name="e">Argumentos del evento que ayuda a la funcion</param>
        Navigation.PushAsync(new Detalles
        {
            //Navega a la p�gina de detalles y asigna la informaci�n del drag�n rojo.

            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Rojos",
                Image = "rojo.jpg",
                Description = "Los dragones rojos son los guerreros definitivos, con una fuerza imparable y una naturaleza feroz. " +
                                          "Son dominantes en combate y son temidos por su poder destructivo, " +
                                          "especialmente cuando se trata de misiones que requieren destruir al enemigo.\r\n\r\n" +
                                          "Los dragones rojos son conocidos por su alto temperamento, especialmente los colas de escorpi�n, si por mala fortuna llegas a ofender a uno, te puedes considerar muerto. \r\n\r\n" +
                                          "Es por ello que se debe tener un resp�to m�ximo hacia ellos y nunca mirarle a los ojos. Ice, Slice, Cath, Ghrian y Thoirt son dragones rojos.\r\n\r\n"
            }

        });
    }
}