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

    //float currentVerticalVelocity;


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

        if(Physics.Raycast(transform.position, -Vector3.up, out hit))
        {


            if(hit.distance < 0.55f)
            {

                r.material = materialGrounded;
            }
            else
            {
  
                r.material = materialNoGrounded;
            }
        }
        else
        {

            r.material = materialNoGrounded;
        }

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
            mustJump = false;
            Saltar(); 
        }
    }


    void Saltar()
    {
        //&& jumpCount == 1
        if (CurrentEffect == 1)
        {
            Debug.Log("Saltar + efecto de pocion");
            rb.AddForce(Vector3.up * jumpVerticalVelocity, ForceMode.Impulse);
            isGrounded = false; // Deshabilitar el salto hasta que vuelva a estar en el suelo
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain")) // Comparar tag para que salte una vez
        {
            isGrounded = true;
        }
    }
    void OnDisable()
    {
        Jump.action.Disable();
    }

    public void PotionInventory()
    {
        GameObject UImenu;
        UIManager UIComponent;

        UImenu = GameObject.FindGameObjectWithTag("UI");

        UIComponent = UImenu.GetComponent<UIManager>();


        Debug.Log("Entrando en el inventario" + UIComponent.GreenPotionCollected);
        if(UseGreenPotion.action.WasPressedThisFrame() && UIComponent.GreenPotionCollected > 0)
        {
            Debug.Log("Entrando en pocion verde");
            //el player tiene pociones verdes y aplicaria su respectivo efecto
            CurrentEffect = 1;
            

            UIComponent.RemoveGreenPotion();
        }
        else if(UseBluePotion.action.WasPressedThisFrame() && UIComponent.BluePotionCollected > 0)
        {
            //el player tiene pociones azules y aplicaria su efecto

            UIComponent.RemoveBluePotion();
        }
        else if(UseRedPotion.action.WasPressedThisFrame() && UIComponent.RedPotionCollected > 0)
        {
            //el player tiene pociones rojas y aplicaria su efecto

            UIComponent.RemoveRedPotion();
        }
    }


}
