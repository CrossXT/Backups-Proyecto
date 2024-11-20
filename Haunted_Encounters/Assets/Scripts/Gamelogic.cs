using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamelogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadExit()
    {
        
        #if UNITY_EDITOR

        EditorApplication.isPlaying = false;

        #endif

        Application.Quit();

    }
}
