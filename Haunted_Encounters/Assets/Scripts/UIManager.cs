using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI greenPotionText;
    [SerializeField] TextMeshProUGUI redPotionText;
    [SerializeField] TextMeshProUGUI bluePotionText;

    [SerializeField] int GreenPotionCollected;
    [SerializeField] int RedPotionCollected;
    [SerializeField] int BluePotionCollected;
    // Start is called before the first frame update
    void Start()
    {

        GreenPotionCollected = 0;
        RedPotionCollected = 0;
        BluePotionCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar el texto del canvas con las variables

        greenPotionText.text = "" + GreenPotionCollected;
        redPotionText.text = "" + RedPotionCollected;
        bluePotionText.text = "" + BluePotionCollected;
    }

    public void AddGreenPotion()
    {
        GreenPotionCollected++;
    }

    public void AddBluePotion()
    {
        BluePotionCollected++;
    }

    public void AddRedPotion()
    {
        RedPotionCollected++;
    }
}
