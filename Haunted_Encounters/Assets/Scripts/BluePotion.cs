using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject UImenu;
        UIManager UIComponent;

        UImenu = GameObject.FindGameObjectWithTag("UI");

        UIComponent = UImenu.GetComponent<UIManager>();

        UIComponent.AddBluePotion();

        Destroy(gameObject);
    }
}
