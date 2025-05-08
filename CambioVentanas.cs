namespace Sesion7_8_9
{
        /// <summary>
        /// Clase que representa un modelo de datos para una página de contenido.
        /// Hereda de ContentPage para poder ser utilizada en la interfaz de usuario.
        /// Esta clase se utiliza para mostrar la información de un dragón en la página de detalles.
        /// </summary>

        public class CambioVentanas : ContentPage
        {
            /// <summary>
            /// Propiedad que almacena el texto que se mostrará en la página de detalles.
            /// </summary>
            public String Texto { get; set; }
            /// <summary>
            /// Propiedad que almacena la ruta de la imagen que se mostrará en la página de detalles.
            /// </summary>
            public String Image { get; set; }
            /// <summary>
            /// Propiedad que almacena la descripción que se mostrará en la página de detalles.
            /// </summary>
            public String Description { get; set; }

        }
}

