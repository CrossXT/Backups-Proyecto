using UnityEngine;
using UnityEngine.InputSystem;

public class BatFloatController : MonoBehaviour
{
    public float floatAmplitude = 0.5f;  // Altura de la flotación
    public float floatSpeed = 2f;        // Velocidad de la flotación
    public float moveSpeed = 2f;         // Velocidad al ascender/descender con las teclas
    public float forwardSpeed = 5f;      // Velocidad constante hacia adelante en el eje Z

    private Vector3 startPosition;
    private float floatOffset;
    private BatControls batControls;
    private float verticalInput = 0f;    // Variable para almacenar la entrada vertical

    private void Awake()
    {
        // Inicializar los controles
        batControls = new BatControls();

        // Asignar acciones de entrada a las teclas de flecha
        batControls.Gameplay.UpArrow.performed += ctx => verticalInput = 1f;
        batControls.Gameplay.DownArrow.performed += ctx => verticalInput = -1f;
        batControls.Gameplay.UpArrow.canceled += ctx => verticalInput = 0f;
        batControls.Gameplay.DownArrow.canceled += ctx => verticalInput = 0f;
    }

    private void OnEnable()
    {
        batControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        batControls.Gameplay.Disable();
    }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento de flotación senoidal en Y
        floatOffset = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + floatOffset, transform.position.z);

        // Movimiento vertical basado en la entrada
        transform.position += Vector3.up * verticalInput * moveSpeed;

        // Movimiento constante hacia adelante en el eje Z
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;

        
    }
}
