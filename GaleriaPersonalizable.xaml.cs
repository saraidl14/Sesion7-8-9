using System.Collections.ObjectModel;
using System;
using Microsoft.Maui.Controls;
using System.Text.Json; // Para serializaci�n JSON

namespace Sesion7_8_9;

public partial class GaleriaPersonalizable : ContentPage
{
    // Colecci�n observable para mantener los dragones seleccionados
    private ObservableCollection<CambioVentanas> customDragons;

    // Diccionario para mantener la relaci�n entre CheckBox y la informaci�n del drag�n
    private Dictionary<CheckBox, CambioVentanas> dragonInfo;

    // Clave para almacenar preferencias
    private const string CustomGalleryKey = "CustomGallery";

    public GaleriaPersonalizable()
    {
        InitializeComponent();
        // Inicializar la colecci�n
        customDragons = new ObservableCollection<CambioVentanas>();
        CustomGalleryCollection.ItemsSource = customDragons;

        // Inicializar el diccionario de informaci�n de dragones
        InitializeDragonInfo();
    }

    private void InitializeDragonInfo()
    {
        dragonInfo = new Dictionary<CheckBox, CambioVentanas>
            {
                { DragonMarron, new CambioVentanas
                    {
                        Texto = "Los Dragones Marrones",
                        Image = "marron.jpg",
                        Description = "Los dragones marrones son un armaz�n de carne y hueso. Son equilibrados en sus habilidades, " +
                        "combinando fuerza y resistencia con una buena capacidad para la maniobra. " +
                        "Su versatilidad los convierte en una opci�n s�lida para cualquier jinete."
                    }
                },
                { DragonNaranja, new CambioVentanas
                    {
                        Texto = "Los Dragones Naranjas",
                        Image = "naranja.jpg",
                        Description = "Los dragones naranjas son extremadamente letales, conocidos por su capacidad para atacar con ferocidad. " +
                        "Su color vibrante refleja su naturaleza agresiva y su aptitud para misiones ofensivas, donde la fuerza bruta es esencial."
                    }
                },
                { DragonVerde, new CambioVentanas
                    {
                        Texto = "Los Dragones Verdes",
                        Image = "verde.jpg",
                        Description = "Los dragones verdes son maestros del camuflaje natural y habitan en bosques densos. " +
                        "Sus escamas verdes les permiten mezclarse perfectamente entre la vegetaci�n. " +
                        "Son conocidos por su inteligencia t�ctica y habilidades de sigilo."
                    }
                },
                { DragonRojo, new CambioVentanas
                    {
                        Texto = "Los Dragones Rojos",
                        Image = "rojo2.jpg",
                        Description = "Los dragones rojos son s�mbolos de poder y dominaci�n. Sus escamas carmes� brillan como metal al rojo vivo. " +
                        "Son criaturas orgullosas, territoriales y feroces en batalla."
                    }
                },
                { DragonNegro, new CambioVentanas
                    {
                        Texto = "Los Dragones Negros",
                        Image = "negro.jpg",
                        Description = "Los dragones negros son criaturas nocturnas y misteriosas. Sus escamas absorbentes de luz les permiten fundirse con las sombras. " +
                        "Son maestros de la magia oscura y tienen una conexi�n especial con el mundo de los esp�ritus."
                    }
                },
                { DragonAzul, new CambioVentanas
                    {
                        Texto = "Los Dragones Azules",
                        Image = "azul.jpg",
                        Description = "Los dragones azules tienen afinidad con el agua y el cielo. Sus escamas iridiscentes reflejan todos los tonos del oc�ano. " +
                        "Son excelentes nadadores y voladores, adapt�ndose perfectamente a entornos acu�ticos y a�reos."
                    }
                },
                { DragonDorado, new CambioVentanas
                    {
                        Texto = "Los Dragones Dorados",
                        Image = "dorado.jpg",
                        Description = "Los dragones dorados son los m�s raros y venerados entre todas las especies. " +
                        "Sus escamas brillan como el oro pulido bajo la luz del sol. " +
                        "Son s�mbolos de prosperidad, sabidur�a y poder benevolente."
                    }
                },
                { DragonDesconocido, new CambioVentanas
                    {
                        Texto = "Drag�n Desconocido",
                        Image = "desconocido.jpg",
                        Description = "Este misterioso drag�n pertenece a una especie a�n no catalogada por los dragon�logos. " +
                        "Sus or�genes son inciertos y sus habilidades son un enigma incluso para los m�s estudiosos."
                    }
                }
            };

        // Cargar la galer�a personalizada guardada (si existe)
        LoadSavedGallery();
    }

    // M�todo para cargar una galer�a guardada previamente
    private void LoadSavedGallery()
    {
        // Utilizar Preferences API en lugar de Application.Current.Properties
        if (Preferences.ContainsKey(CustomGalleryKey))
        {
            try
            {
                string jsonData = Preferences.Get(CustomGalleryKey, string.Empty);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var savedGalleryData = JsonSerializer.Deserialize<List<string>>(jsonData);
                    if (savedGalleryData != null)
                    {
                        foreach (var dragonName in savedGalleryData)
                        {
                            // Buscar el drag�n correspondiente y marcar su checkbox
                            var checkbox = dragonInfo.Keys.FirstOrDefault(cb =>
                                dragonInfo[cb].Texto.Contains(dragonName));

                            if (checkbox != null)
                            {
                                checkbox.IsChecked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de problemas con la deserializaci�n
                Console.WriteLine($"Error al cargar la galer�a: {ex.Message}");
            }
        }
    }

    // M�todo que se ejecuta cuando cambia el estado de un checkbox de drag�n
    private void OnDragonCheckChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && dragonInfo.ContainsKey(checkbox))
        {
            var dragon = dragonInfo[checkbox];

            if (e.Value) // Si el checkbox est� marcado
            {
                // Verificar si el drag�n ya est� en la colecci�n
                if (!customDragons.Any(d => d.Texto == dragon.Texto))
                {
                    customDragons.Add(dragon);
                }
            }
            else // Si el checkbox est� desmarcado
            {
                // Buscar y eliminar el drag�n de la colecci�n
                var dragonToRemove = customDragons.FirstOrDefault(d => d.Texto == dragon.Texto);
                if (dragonToRemove != null)
                {
                    customDragons.Remove(dragonToRemove);
                }
            }
        }
    }

    // M�todo para eliminar un drag�n de la galer�a personalizada
    private void OnRemoveDragonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is CambioVentanas dragon)
        {
            // Eliminar el drag�n de la colecci�n
            customDragons.Remove(dragon);

            // Desmarcar el checkbox correspondiente
            var checkbox = dragonInfo.FirstOrDefault(x => x.Value.Texto == dragon.Texto).Key;
            if (checkbox != null)
            {
                checkbox.IsChecked = false;
            }
        }
    }

    // M�todo para ver detalles de un drag�n seleccionado
    private void OnDragonSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is CambioVentanas selectedDragon)
        {
            // Determinar a qu� p�gina navegar seg�n el drag�n seleccionado
            string dragonType = selectedDragon.Texto;

            Page destinationPage = null;

            if (dragonType.Contains("Marrones"))
                destinationPage = new Animal1 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Naranjas"))
                destinationPage = new Animal2 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Verdes"))
                destinationPage = new Animal3 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Rojos"))
                destinationPage = new Animal4 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Negros"))
                destinationPage = new Animal5 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Azules"))
                destinationPage = new Animal6 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Dorados"))
                destinationPage = new Animal7 { BindingContext = selectedDragon };
            else if (dragonType.Contains("Desconocido"))
                destinationPage = new Animal8 { BindingContext = selectedDragon };

            if (destinationPage != null)
            {
                Navigation.PushAsync(destinationPage);
            }

            // Limpiar la selecci�n para permitir volver a seleccionar el mismo elemento
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    // M�todo para guardar la galer�a personalizada
    private void OnSaveGalleryClicked(object sender, EventArgs e)
    {
        try
        {
            // Guardar los nombres de los dragones seleccionados
            var dragonNames = customDragons.Select(d => d.Texto).ToList();

            // Serializar la lista a JSON y guardar en Preferences
            string jsonData = JsonSerializer.Serialize(dragonNames);
            Preferences.Set(CustomGalleryKey, jsonData);

            DisplayAlert("Galer�a Guardada", "Tu galer�a personalizada ha sido guardada correctamente.", "OK");
        }
        catch (Exception ex)
        {
            // Manejo de errores en caso de problemas con la serializaci�n o guardado
            DisplayAlert("Error", $"No se pudo guardar la galer�a: {ex.Message}", "OK");
        }
    }

    // M�todo para volver a la galer�a principal
    private void OnVolverClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}