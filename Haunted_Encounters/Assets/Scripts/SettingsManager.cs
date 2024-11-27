using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Sliders de Volumen")]
    public Slider generalSlider;
    public Slider effectSlider;
    public Slider musicSlider;

    [Header("Audio Sources")]
    public AudioSource musicAudioSource;
    public AudioSource effectsAudioSource;

    // Claves para PlayerPrefs
    private const string GENERAL_VOLUME_KEY = "GeneralVolume";
    private const string EFFECTS_VOLUME_KEY = "EffectsVolume";
    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    void Start()
    {
        // Cargar configuraciones guardadas o establecer valores predeterminados
        generalSlider.value = PlayerPrefs.GetFloat(GENERAL_VOLUME_KEY, 1f);
        effectSlider.value = PlayerPrefs.GetFloat(EFFECTS_VOLUME_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);

        // Aplicar los valores iniciales al audio
        ApplyVolumes();

        // Asignar los métodos a los eventos onValueChanged de los sliders
        generalSlider.onValueChanged.AddListener(SetGeneralVolume);
        effectSlider.onValueChanged.AddListener(SetEffectsVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    /// <summary>
    /// Aplica los valores de los sliders a los AudioSources.
    /// </summary>
    private void ApplyVolumes()
    {
        SetGeneralVolume(generalSlider.value);
        SetEffectsVolume(effectSlider.value);
        SetMusicVolume(musicSlider.value);
    }

    /// <summary>
    /// Establece el volumen general del juego.
    /// </summary>
    /// <param name="volume">El valor del slider.</param>
    public void SetGeneralVolume(float volume)
    {
        AudioListener.volume = volume; // Cambia el volumen general

        // Actualizar los volúmenes de los AudioSources en función del volumen general
        if (musicAudioSource != null)
            musicAudioSource.volume = musicSlider.value * volume;

        if (effectsAudioSource != null)
            effectsAudioSource.volume = effectSlider.value * volume;

        PlayerPrefs.SetFloat(GENERAL_VOLUME_KEY, volume); // Guarda el valor
        PlayerPrefs.Save(); // Asegura que los cambios se guarden inmediatamente
    }

    /// <summary>
    /// Establece el volumen de la música.
    /// </summary>
    /// <param name="volume">El valor del slider.</param>
    public void SetMusicVolume(float volume)
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.volume = volume * AudioListener.volume; // Multiplica por el volumen general
        }
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume); // Guarda el valor
        PlayerPrefs.Save(); // Asegura que los cambios se guarden inmediatamente
    }

    /// <summary>
    /// Establece el volumen de los efectos de sonido.
    /// </summary>
    /// <param name="volume">El valor del slider.</param>
    public void SetEffectsVolume(float volume)
    {
        if (effectsAudioSource != null)
        {
            effectsAudioSource.volume = volume * AudioListener.volume; // Multiplica por el volumen general
        }
        PlayerPrefs.SetFloat(EFFECTS_VOLUME_KEY, volume); // Guarda el valor
        PlayerPrefs.Save(); // Asegura que los cambios se guarden inmediatamente
    }

    /// <summary>
    /// Restablece todos los volúmenes a sus valores predeterminados.
    /// </summary>
    public void ResetToDefaults()
    {
        float defaultVolume = 1f;

        // Restablecer valores en los sliders
        generalSlider.value = defaultVolume;
        effectSlider.value = defaultVolume;
        musicSlider.value = defaultVolume;

        // Aplicar los valores predeterminados
        ApplyVolumes();

        Debug.Log("Valores de volumen restablecidos a los predeterminados.");
    }
}
