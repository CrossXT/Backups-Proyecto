using UnityEngine;
using Cinemachine;

public class PortalChange : MonoBehaviour
{
    public GameObject player; // El contenedor principal del jugador
    public GameObject formaOriginal; // Primer modelo del jugador
    public GameObject formaAlternativa; // Segundo modelo del jugador

    public CinemachineVirtualCamera cam;

    public bool isAlternateForm = false; // Para alternar entre las formas
    private bool ToggleDone = false;


    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que atraviesa el portal tiene la etiqueta Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador atravesó el portal.");
            if(ToggleDone == false)
            {
                TogglePlayerForm();
            }
            
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
            formaOriginal.transform.position = formaAlternativa.transform.position;
            cam.Follow = formaOriginal.transform;
            cam.LookAt = formaOriginal.transform;

            ToggleDone = true;
            
        }
        else
        {
            // Si estamos en forma original, cambiamos a la forma alternativa
            Debug.Log("Cambiando a la forma alternativa.");
            formaOriginal.SetActive(false);
            formaAlternativa.SetActive(true);
            formaAlternativa.transform.position = formaOriginal.transform.position;
            cam.Follow = formaAlternativa.transform;
            cam.LookAt = formaAlternativa.transform;

            ToggleDone = true;
        }

        // Cambiar el estado para la próxima vez que pase por el portal
        isAlternateForm = !isAlternateForm;
    }
}

