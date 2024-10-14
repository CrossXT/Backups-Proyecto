using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference jump;

    public Vector3 velocidadConstante = new Vector3(5, 0, 0); // Velocidad constante en X y Z
    private Rigidbody rb;
    public float fuerzaSalto = 5f;
    private bool puedeSaltar = true;

    //private PlayerInputActions inputActions;


    void Awake()
    {
        //inputActions = new PlayerInputActions();
        //inputActions.Player.Jump.performed += _ => Saltar();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        jump.action.Enable();

    }
    // Update is called once per frame
    void Update()
    {
        // 1) Conseguir que avance a una
        //    velocidad constante

        rb.velocity = new Vector3(velocidadConstante.x, rb.velocity.y, velocidadConstante.z);

        // 2) Conseguir que responda a la
        //    tecla deseada iniciando el salto

        // 3) Conseguir que se aplique gravedad
        //    para que el salto funcione de manera
        //    automática

        // !!4) Conseguir que el personaje
        //    no se meta dentro del terreno
    }
    void OnDisable()
    {
        jump.action.Disable();
    }

}
