using Microsoft.Maui.Graphics.Converters;

namespace Sesion7_8_9;

public partial class Configuracion : ContentPage
{
    // Propiedades para almacenar las selecciones actuales
    private string selectedBackgroundColor = "#FFFFFF";
    private string selectedTextColor = "#000000";
    private int selectedFontSize = 18;
    private string selectedFontFamily = "Default";

    // Conversor de colores para pasar de string a Color
    private readonly ColorTypeConverter colorConverter = new ColorTypeConverter();

    public Configuracion()
    {
        InitializeComponent();
        LoadSettings();
        UpdatePreview();
    }

    private void LoadSettings()
    {
        // Cargar configuración guardada o usar valores predeterminados
        selectedBackgroundColor = Preferences.Default.Get("BackgroundColor", "#FFFFFF");
        selectedTextColor = Preferences.Default.Get("TextColor", "#000000");
        selectedFontSize = Preferences.Default.Get("FontSize", 18);
        selectedFontFamily = Preferences.Default.Get("FontFamily", "Default");
    }

    private void UpdatePreview()
    {
        // Actualizar el texto de vista previa con las configuraciones actuales
        PreviewLabel.TextColor = (Color)colorConverter.ConvertFromInvariantString(selectedTextColor);
        PreviewLabel.FontSize = selectedFontSize;
        PreviewLabel.FontFamily = selectedFontFamily;

        // Actualizar el fondo del Frame que contiene la vista previa
        PreviewLabel.BackgroundColor = (Color)colorConverter.ConvertFromInvariantString(selectedBackgroundColor);
    }

    private void OnBackgroundColorClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            selectedBackgroundColor = button.ClassId;
            UpdatePreview();
        }
    }

    private void OnTextColorClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            selectedTextColor = button.ClassId;
            UpdatePreview();
        }
    }

    private void OnFontSizeClicked(object sender, EventArgs e)
    {
        if (sender is Button button && int.TryParse(button.ClassId, out int size))
        {
            selectedFontSize = size;
            UpdatePreview();
        }
    }

    private void OnFontFamilyClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            selectedFontFamily = button.ClassId;
            UpdatePreview();
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Guardar las configuraciones en las preferencias
        Preferences.Default.Set("BackgroundColor", selectedBackgroundColor);
        Preferences.Default.Set("TextColor", selectedTextColor);
        Preferences.Default.Set("FontSize", selectedFontSize);
        Preferences.Default.Set("FontFamily", selectedFontFamily);

        // Mostrar mensaje de confirmación
        await DisplayAlert("Configuración", "Configuración guardada correctamente", "OK");

        // Regresar a la página principal después de guardar
        await Navigation.PopAsync();
    }

    private void OnResetClicked(object sender, EventArgs e)
    {
        // Restablecer valores predeterminados
        selectedBackgroundColor = "#FFFFFF";
        selectedTextColor = "#000000";
        selectedFontSize = 18;
        selectedFontFamily = "Default";

        UpdatePreview();
    }
}