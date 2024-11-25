using System.Collections;
using UnityEngine;

public class CubeJumpRotation : MonoBehaviour
{
    public float jumpForce = 5f;  // Fuerza del salto
    public float rotationSpeed = 5f;  // Velocidad de la rotaci�n

    private Rigidbody rb;
    private bool isGrounded = false;
    public Transform visuals;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        // Detectar salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAndRotateZ(); // Llama a la rotaci�n sobre el eje z
        }
    }

    private void JumpAndRotateZ()
    {
        // Aplicar salto
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

        // Iniciar la rotaci�n
        StartCoroutine(RotateCubeZ());
    }

    private IEnumerator RotateCubeZ()
    {
        isGrounded = false;

        // Calcular el �ngulo objetivo en el eje z
        Quaternion startRotation = visuals.localRotation;
        startRotation = Quaternion.identity;
        Quaternion endRotation = Quaternion.Euler(90, visuals.eulerAngles.y, visuals.eulerAngles.z);

        float t = 0;
       
        while (t < 1f)
        {
            t += Time.deltaTime * rotationSpeed; // Interpolaci�n suave
            visuals.localRotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }

        // Asegurarse de llegar exactamente al �ngulo objetivo
        visuals.localRotation = endRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar si el cubo toca el suelo
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }
}
