using UnityEngine;

public class PortalChange : MonoBehaviour
{
    public GameObject player; // El contenedor principal del jugador
    public GameObject formaOriginal; // Primer modelo del jugador
    public GameObject formaAlternativa; // Segundo modelo del jugador

    private bool isAlternateForm = false; // Para alternar entre las formas

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que atraviesa el portal tiene la etiqueta Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador atravesó el portal.");
            TogglePlayerForm();
        }
    }


    private void TogglePlayerForm()
    {
        if (isAlternateForm)
        {
            // Si estamos en forma alternativa, volvemos a la forma original
            Debug.Log("Cambiando a la forma original.");
            formaOriginal.SetActive(true);
            formaAlternativa.SetActive(false);
        }
        else
        {
            // Si estamos en forma original, cambiamos a la forma alternativa
            Debug.Log("Cambiando a la forma alternativa.");
            formaOriginal.SetActive(false);
            formaAlternativa.SetActive(true);
        }

        // Cambiar el estado para la próxima vez que pase por el portal
        isAlternateForm = !isAlternateForm;
    }
}

