using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // El Canvas del menú de pausa
    private bool isPaused = false; // Verifica si el juego está pausado

    void Update()
    {
        // Si se presiona la tecla Escape, alterna la pausa usando Time.unscaledTime
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("LevelSelection");
        }
        else if(Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("Settings");
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Restablece el tiempo a velocidad normal
        isPaused = false;
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Asegura que el tiempo se restablezca antes de salir
        SceneManager.LoadScene("Menu"); // Carga la escena del menú principal
    }
}
