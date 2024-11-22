using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference Jump;
    [SerializeField] InputActionReference UseGreenPotion;
    [SerializeField] InputActionReference UseRedPotion;
    [SerializeField] InputActionReference UseBluePotion;

    [SerializeField] float jumpVerticalVelocity = 10f;

    public Vector3 velocidadConstante = new Vector3(5, 0, 0); // Velocidad constante en X y Z
    private Rigidbody rb;
    private bool isGrounded = false;

    public Material materialGrounded;
    public Material materialNoGrounded;

    public Transform model;

    private Renderer r;

    private int effectTimer = 10;

    private int CurrentEffect = -1;

    private int jumpCount;

    private IEnumerator GreenPotionEffectTimer()
    {
        yield return new WaitForSeconds(effectTimer);
        CurrentEffect = -1; // Desactivar el efecto
        Debug.Log("Efecto de la Poción Verde Finalizado");
    }


    private PlayerMovement inputActions;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        r = model.GetComponent<Renderer>();
    }

    void OnEnable()
    {
        Jump.action.Enable();
        UseGreenPotion.action.Enable(); 
        UseRedPotion.action.Enable();
        UseBluePotion.action.Enable();

    }
    // Update is called once per frame

    const float gravity = -20f;
    bool mustJump = false;
    void Update()
    {
        //Velocidad Constante
        float currentVerticalVelocityQueNoQuieroCambiarlaCoponDivino = rb.velocity.y;
        rb.velocity = new Vector3(velocidadConstante.x, currentVerticalVelocityQueNoQuieroCambiarlaCoponDivino, velocidadConstante.z);


        //Salto
        if (Jump.action.WasPressedThisFrame())
            { mustJump = true; }

        //currentVerticalVelocity += gravity * Time.deltaTime;
        //if (isGrounded)
        //    { currentVerticalVelocity = 0f; Debug.Log("Stopped " + Time.realtimeSinceStartup); }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
    
            

            if (hit.distance < 0.55f)
            {
                SceneManager.LoadScene("Level1");
            }
        }
        else
        {

            r.material = materialNoGrounded;
        }


        PotionInventory();

    }

    private void FixedUpdate()
    {

        if (mustJump)
        {
            Debug.Log("---");

            mustJump = false;
            // Permitir saltar según el estado del jugador
            Debug.Log(isGrounded);
            Debug.Log(CurrentEffect);
            Debug.Log(jumpCount);

            if (isGrounded || (CurrentEffect == 1 && jumpCount < 2))
            {
                Saltar();

            }
        }
    }


    void Saltar()
    {
        // Realizar un salto y reducir el contador de saltos
        jumpCount = 0;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset vertical velocity to avoid accumulated forces
        rb.AddForce(Vector3.up * jumpVerticalVelocity, ForceMode.Impulse);

        Debug.Log("Saltar: JumpCount = " + jumpCount);

        if(!isGrounded)
        {
            jumpCount = 2;
        }
        else
        {
            jumpCount = 1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
            jumpCount = 0; // Reiniciar el contador de saltos al tocar el suelo
        }
        else
        {
            isGrounded = false;
        }
    }
    void OnDisable()
    {
        Jump.action.Disable();
        UseGreenPotion.action.Disable();
        UseRedPotion.action.Disable();
        UseBluePotion.action.Disable();
    }

    public void PotionInventory()
    {
        GameObject UImenu;
        UIManager UIComponent;

        UImenu = GameObject.FindGameObjectWithTag("UI");
        UIComponent = UImenu.GetComponent<UIManager>();


        if (UseGreenPotion.action.WasPressedThisFrame() && UIComponent.GreenPotionCollected > 0)
        {
            Debug.Log("Poción Verde Activada: Doble Salto Habilitado");
            CurrentEffect = 1;
            jumpCount = 0;
            UIComponent.RemoveGreenPotion();
            StartCoroutine(GreenPotionEffectTimer());
        }
        else if (UseBluePotion.action.WasPressedThisFrame() && UIComponent.BluePotionCollected > 0)
        {
            //el player tiene pociones azules y aplicaria su efecto

            UIComponent.RemoveBluePotion();
        }
        else if (UseRedPotion.action.WasPressedThisFrame() && UIComponent.RedPotionCollected > 0)
        {
            //el player tiene pociones rojas y aplicaria su efecto

            UIComponent.RemoveRedPotion();
        }
    }
}
