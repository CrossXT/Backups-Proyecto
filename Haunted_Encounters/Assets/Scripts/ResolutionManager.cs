using UnityEngine;
using TMPro; // Importar el namespace de TextMeshPro
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Usar TMP_Dropdown en lugar de Dropdown
    public Toggle fullscreenToggle;

    private Resolution[] resolutions; // Lista de resoluciones disponibles
    private int currentResolutionIndex;

    void Start()
    {
        // Obtener todas las resoluciones soportadas
        resolutions = Screen.resolutions;

        // Limpiar opciones previas del Dropdown
        resolutionDropdown.ClearOptions();

        // Crear una lista de resoluciones como cadenas
        var options = new System.Collections.Generic.List<string>();
        currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} x {resolutions[i].height} @ {resolutions[i].refreshRate}Hz";
            options.Add(option);

            // Detectar la resolución actual
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        // Agregar opciones al TMP_Dropdown
        resolutionDropdown.AddOptions(options);

        // Asignar eventos
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);

        // Cargar configuraciones guardadas
        LoadSettings();
    }

    // Cambiar resolución al seleccionar una opción del Dropdown
    public void SetResolution(int index)
    {
        Resolution selectedResolution = resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen, selectedResolution.refreshRate);
        PlayerPrefs.SetInt("ResolutionIndex", index); // Guardar la selección
    }

    // Cambiar el estado de pantalla completa
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0); // Guardar el estado
    }

    // Cargar configuraciones guardadas
    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            int savedIndex = PlayerPrefs.GetInt("ResolutionIndex");
            if (savedIndex >= 0 && savedIndex < resolutions.Length)
            {
                currentResolutionIndex = savedIndex;
                resolutionDropdown.value = currentResolutionIndex;
                resolutionDropdown.RefreshShownValue();
                SetResolution(currentResolutionIndex);
            }
        }

        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            fullscreenToggle.isOn = isFullscreen;
            Screen.fullScreen = isFullscreen;
        }
        else
        {
            // Si no hay configuraciones guardadas, usar los valores iniciales
            fullscreenToggle.isOn = Screen.fullScreen;
        }
    }
}
