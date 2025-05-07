namespace Sesion7_8_9;

public partial class Animal8 : ContentPage
{
	public Animal8()
	{
		InitializeComponent();
	}
    private void DetallesBTN(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Detalles
        {
            // Navega a la p�gina de detalles y asigna la informaci�n del drag�n desconocido.
            BindingContext = new CambioVentanas
            {
                Texto = "Los Dragones Desconocidos",
                Image = "desconocido.png",
                Description = "Hay un tipo de dragones del que no se sabe nada pues se cre�an extintos, unos con un linaje especial." +
                "Hay dragones cuyo color y habilidades espec�ficas no se conocen, lo que los convierte en un misterio. " +
                "Estos dragones pueden poseer habilidades �nicas que a�n no han sido descubiertas o reveladas.\r\n\r\n" +
                "Se los conoce como Iridos y no tienen un color como tal."

            }

        });
    }
}