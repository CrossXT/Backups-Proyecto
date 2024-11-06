using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference Jump;
    [SerializeField] float jumpVerticalVelocity = 10f;

    public Vector3 velocidadConstante = new Vector3(5, 0, 0); // Velocidad constante en X y Z
    private Rigidbody rb;
    private bool isGrounded = false;
    private bool isJumping = false;

    public Material materialGrounded;
    public Material materialNoGrounded;

    public Transform model;

    private Renderer r;

    float currentVerticalVelocity;


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
        rb.velocity = new Vector3(velocidadConstante.x, currentVerticalVelocity, velocidadConstante.z);


        //Salto
        if (Jump.action.WasPressedThisFrame())
            { mustJump = true; }

        currentVerticalVelocity += gravity * Time.deltaTime;
        if (isGrounded)
            { currentVerticalVelocity = 0f; Debug.Log("Stopped " + Time.realtimeSinceStartup); }

        RaycastHit hit;

        if(Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Debug.Log("Hit distance "+ hit.distance);

            if(hit.distance < 0.55f)
            {
                Debug.Log("Grounded");
                r.material = materialGrounded;
            }
            else
            {
                Debug.Log("No grounded");
                r.material = materialNoGrounded;
            }
        }
        else
        {
            Debug.Log("No hit");
            Debug.Log("No grounded");
            r.material = materialNoGrounded;
         }

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
        Debug.Log("Saltar");
        if (isGrounded)
        {
            Debug.Log("Saltar + isGrounded");
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



}
