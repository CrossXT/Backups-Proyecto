using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionSpawn : MonoBehaviour
{
    float timer;
    public GameObject[] Potions;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int PotionsRandomizer = Random.Range(0, Potions.Length); 

        var position = new Vector3(-1, 7, Random.Range(48, 60));

        if (timer > 3) 
        {
            Instantiate(Potions[PotionsRandomizer], position, Quaternion.identity);
            timer = 0;
        }

    }


}
