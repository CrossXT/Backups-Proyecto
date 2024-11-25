using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    void Start()
    {
        // Cargar configuraciones guardadas
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1.0f);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Cambiar volumen global
        PlayerPrefs.SetFloat("Volume", volume); // Guardar
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0); // Guardar
    }

    public void ResetToDefaults()
    {
        SetVolume(1.0f); // Volumen predeterminado
        SetFullscreen(true); // Pantalla completa predeterminada

        volumeSlider.value = 1.0f;
        fullscreenToggle.isOn = true;

        Debug.Log("Valores restablecidos a predeterminados.");
    }

}
