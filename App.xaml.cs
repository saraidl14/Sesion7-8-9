namespace Sesion7_8_9
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //COMO MAUI PONE POR DEFECTO LA PRIMERA CONTENT PAGE, HE TENIDO QUE FORZAR Y PONER QUE LA PRIMERA QUE SE INICIE SEA EL LOGIN
            MainPage = new LogIn();
        }
    }
}
