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

    float currentVerticalVelocity;


    private PlayerMovement inputActions;



    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        Jump.action.Enable();

    }
    // Update is called once per frame

    const float gravity = -10f;
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
            { currentVerticalVelocity = 0f; }
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
