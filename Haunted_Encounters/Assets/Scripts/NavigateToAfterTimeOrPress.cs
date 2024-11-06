using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    bool pasarScene = false;

    [SerializeField] InputActionReference SkipScene;

    private void Awake()
    {
        Invoke("NavigateToNextScreen", 4.0f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        SkipScene.action.Enable();
    }
    private void OnDisable()
    {
        SkipScene.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(SkipScene.action.WasPressedThisFrame())
        {
            pasarScene = true;
        }
        

        if(pasarScene == true) 
        {
            NavigateToNextScreen();
        }
    }

    void NavigateToNextScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
