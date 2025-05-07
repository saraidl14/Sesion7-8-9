namespace Sesion7_8_9;

public partial class Animal2 : ContentPage
{
	public Animal2()
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
            //Navega a la p�gina de detalles y asigna la informaci�n del drag�n naranja.
            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Naranjas",
                Image = "naranja2.png",
                Description = "Los dragones naranjas son extremadamente letales, conocidos por su capacidad para atacar con ferocidad. " +
                                            "Su color vibrante refleja su naturaleza agresiva y su aptitud para misiones ofensivas, donde la fuerza bruta es esencial.\r\n\r\n" +
                                            "Son los m�s peligrosos de todos, son impredecibles y no se detendr�n ante nada para lograr sus objetivos." +
                                            "Estos son los m�s impredecibles y suponen un gran riesgo. Su tono puede variar much�simo desde el tono albaricoque hasta la zanahoria. \r\n\r\n" +
                                            "Se cree que los Esbens del Norte fueron el lugar de eclosi�n antes de la unificaci�n, aunque su naturaleza impredecible hace que elijan nuevos valles en el mismo rango. Estos provienen de la la l�nea Fhaicorain, Clady, Baide, Light  y Glane pertenecen a esta raza.\r\n\r\n"

            }

        });
    }
}