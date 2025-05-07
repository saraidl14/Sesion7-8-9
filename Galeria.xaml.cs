namespace Sesion7_8_9;

public partial class Galeria : ContentPage
{
    public Galeria()
    {
        InitializeComponent();
    }
    /// <summary>
    /// M�todo que se encarga de cambiar de ventana al hacer click en el bot�n.
    /// Es el que va a hacer que al clickar en detalles se nos muestren.
    /// </summary>
    /// <param name="sender">Objeto que activa el evento</param>
    /// <param name="e">Argumentos del evento que ayuda a la funcion</param>
    private void ButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        // Determinar qu� bot�n fue presionado y navegar a la p�gina correspondiente
        if (button == Button1)
        {
            Navigation.PushAsync(new Animal1
            {
                // Navega a la p�gina de detalles y asigna la informaci�n del drag�n marr�n.
                
            });
        }
        else if (button == Button2)
        {
            Navigation.PushAsync(new Animal2
            {
               
            });
        }
        else if (button == Button3)
        {
            Navigation.PushAsync(new Animal3
            {
                
            });
        }
        else if (button == Button4)
        {
            Navigation.PushAsync(new Animal4
            {
               
            });
        }
        else if (button == Button5)
        {
            Navigation.PushAsync(new Animal5
            {
               
            });
        }
        else if (button == Button6)
        {
            Navigation.PushAsync(new Animal6
            {
                
            });
        }
        else if (button == Button7)
        {
            Navigation.PushAsync(new Animal7
            {
            });
        }
        else if (button == Button8)
        {
            Navigation.PushAsync(new Animal8
            {
            });
        }
    }
}