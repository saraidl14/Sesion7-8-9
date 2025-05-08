using System.Collections.ObjectModel;
using System;
using Microsoft.Maui.Controls;
using System.Text.Json; // Para serialización JSON

namespace Sesion7_8_9;

public partial class GaleriaPersonalizable : ContentPage
{
    // Colección observable para mantener los dragones seleccionados
    private ObservableCollection<CambioVentanas> customDragons;

    // Diccionario para mantener la relación entre CheckBox y la información del dragón
    private Dictionary<CheckBox, CambioVentanas> dragonInfo;

    // Clave para almacenar preferencias
    private const string CustomGalleryKey = "CustomGallery";

    public GaleriaPersonalizable()
    {
        InitializeComponent();
        // Inicializar la colección
        customDragons = new ObservableCollection<CambioVentanas>();
        CustomGalleryCollection.ItemsSource = customDragons;

        // Inicializar el diccionario de información de dragones
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
                        Description = "Los dragones marrones son un armazón de carne y hueso. Son equilibrados en sus habilidades, " +
                        "combinando fuerza y resistencia con una buena capacidad para la maniobra. " +
                        "Su versatilidad los convierte en una opción sólida para cualquier jinete."
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
                        "Sus escamas verdes les permiten mezclarse perfectamente entre la vegetación. " +
                        "Son conocidos por su inteligencia táctica y habilidades de sigilo."
                    }
                },
                { DragonRojo, new CambioVentanas
                    {
                        Texto = "Los Dragones Rojos",
                        Image = "rojo2.jpg",
                        Description = "Los dragones rojos son símbolos de poder y dominación. Sus escamas carmesí brillan como metal al rojo vivo. " +
                        "Son criaturas orgullosas, territoriales y feroces en batalla."
                    }
                },
                { DragonNegro, new CambioVentanas
                    {
                        Texto = "Los Dragones Negros",
                        Image = "negro.jpg",
                        Description = "Los dragones negros son criaturas nocturnas y misteriosas. Sus escamas absorbentes de luz les permiten fundirse con las sombras. " +
                        "Son maestros de la magia oscura y tienen una conexión especial con el mundo de los espíritus."
                    }
                },
                { DragonAzul, new CambioVentanas
                    {
                        Texto = "Los Dragones Azules",
                        Image = "azul.jpg",
                        Description = "Los dragones azules tienen afinidad con el agua y el cielo. Sus escamas iridiscentes reflejan todos los tonos del océano. " +
                        "Son excelentes nadadores y voladores, adaptándose perfectamente a entornos acuáticos y aéreos."
                    }
                },
                { DragonDorado, new CambioVentanas
                    {
                        Texto = "Los Dragones Dorados",
                        Image = "dorado.jpg",
                        Description = "Los dragones dorados son los más raros y venerados entre todas las especies. " +
                        "Sus escamas brillan como el oro pulido bajo la luz del sol. " +
                        "Son símbolos de prosperidad, sabiduría y poder benevolente."
                    }
                },
                { DragonDesconocido, new CambioVentanas
                    {
                        Texto = "Dragón Desconocido",
                        Image = "desconocido.jpg",
                        Description = "Este misterioso dragón pertenece a una especie aún no catalogada por los dragonólogos. " +
                        "Sus orígenes son inciertos y sus habilidades son un enigma incluso para los más estudiosos."
                    }
                }
            };

        // Cargar la galería personalizada guardada (si existe)
        LoadSavedGallery();
    }

    // Método para cargar una galería guardada previamente
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
                            // Buscar el dragón correspondiente y marcar su checkbox
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
                // Manejo de errores en caso de problemas con la deserialización
                Console.WriteLine($"Error al cargar la galería: {ex.Message}");
            }
        }
    }

    // Método que se ejecuta cuando cambia el estado de un checkbox de dragón
    private void OnDragonCheckChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && dragonInfo.ContainsKey(checkbox))
        {
            var dragon = dragonInfo[checkbox];

            if (e.Value) // Si el checkbox está marcado
            {
                // Verificar si el dragón ya está en la colección
                if (!customDragons.Any(d => d.Texto == dragon.Texto))
                {
                    customDragons.Add(dragon);
                }
            }
            else // Si el checkbox está desmarcado
            {
                // Buscar y eliminar el dragón de la colección
                var dragonToRemove = customDragons.FirstOrDefault(d => d.Texto == dragon.Texto);
                if (dragonToRemove != null)
                {
                    customDragons.Remove(dragonToRemove);
                }
            }
        }
    }

    // Método para eliminar un dragón de la galería personalizada
    private void OnRemoveDragonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is CambioVentanas dragon)
        {
            // Eliminar el dragón de la colección
            customDragons.Remove(dragon);

            // Desmarcar el checkbox correspondiente
            var checkbox = dragonInfo.FirstOrDefault(x => x.Value.Texto == dragon.Texto).Key;
            if (checkbox != null)
            {
                checkbox.IsChecked = false;
            }
        }
    }

    // Método para ver detalles de un dragón seleccionado
    private void OnDragonSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is CambioVentanas selectedDragon)
        {
            // Determinar a qué página navegar según el dragón seleccionado
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

            // Limpiar la selección para permitir volver a seleccionar el mismo elemento
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    // Método para guardar la galería personalizada
    private void OnSaveGalleryClicked(object sender, EventArgs e)
    {
        try
        {
            // Guardar los nombres de los dragones seleccionados
            var dragonNames = customDragons.Select(d => d.Texto).ToList();

            // Serializar la lista a JSON y guardar en Preferences
            string jsonData = JsonSerializer.Serialize(dragonNames);
            Preferences.Set(CustomGalleryKey, jsonData);

            DisplayAlert("Galería Guardada", "Tu galería personalizada ha sido guardada correctamente.", "OK");
        }
        catch (Exception ex)
        {
            // Manejo de errores en caso de problemas con la serialización o guardado
            DisplayAlert("Error", $"No se pudo guardar la galería: {ex.Message}", "OK");
        }
    }

    // Método para volver a la galería principal
    private void OnVolverClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}