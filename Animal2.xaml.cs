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
        /// Método que se encarga de cambiar de ventana al hacer click en el botón.
        /// Es el que va a hacer que al clickar en detalles se nos muestren.
        /// </summary>
        /// <param name="sender">Objeto que activa el evento</param>
        /// <param name="e">Argumentos del evento que ayuda a la funcion</param>
        Navigation.PushAsync(new Detalles
        {
            //Navega a la página de detalles y asigna la información del dragón naranja.
            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Naranjas",
                Image = "naranja2.png",
                Description = "Los dragones naranjas son extremadamente letales, conocidos por su capacidad para atacar con ferocidad. " +
                                            "Su color vibrante refleja su naturaleza agresiva y su aptitud para misiones ofensivas, donde la fuerza bruta es esencial.\r\n\r\n" +
                                            "Son los más peligrosos de todos, son impredecibles y no se detendrán ante nada para lograr sus objetivos." +
                                            "Estos son los más impredecibles y suponen un gran riesgo. Su tono puede variar muchísimo desde el tono albaricoque hasta la zanahoria. \r\n\r\n" +
                                            "Se cree que los Esbens del Norte fueron el lugar de eclosión antes de la unificación, aunque su naturaleza impredecible hace que elijan nuevos valles en el mismo rango. Estos provienen de la la línea Fhaicorain, Clady, Baide, Light  y Glane pertenecen a esta raza.\r\n\r\n"

            }

        });
    }
}