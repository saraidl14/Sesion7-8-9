namespace Sesion7_8_9
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

       private void OnClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Galeria");
        }
    }

}
