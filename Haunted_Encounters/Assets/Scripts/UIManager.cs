using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI greenPotionText;
    [SerializeField] TextMeshProUGUI redPotionText;
    [SerializeField] TextMeshProUGUI bluePotionText;

     public int GreenPotionCollected;
     public int RedPotionCollected;
     public int BluePotionCollected;
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

    public void RemoveGreenPotion()
    {
        GreenPotionCollected--;

        if(GreenPotionCollected < 0 )
        {
            GreenPotionCollected = 0;
        }
    }

    public void AddBluePotion()
    {
        BluePotionCollected++;
    }

    public void RemoveBluePotion()
    {
        BluePotionCollected--;

        if (BluePotionCollected < 0)
        {
            BluePotionCollected = 0;
        }
    }

    public void AddRedPotion()
    {
        RedPotionCollected++;
    }

    public void RemoveRedPotion()
    {
        RedPotionCollected--;

        if (RedPotionCollected < 0)
        {
            RedPotionCollected = 0;
        }
    }
}
