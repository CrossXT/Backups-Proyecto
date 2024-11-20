 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public Button Start;
    public Button Settings;
    public Button Exit;
    // Start is called before the first frame update


    private void OnEnable()
    {
        Start.onClick.AddListener(OnButtonStartClick);
        Settings.onClick.AddListener(OnButtonSettingsClick);
        Exit.onClick.AddListener(OnButtonExitClick);

    }

    private void OnDisable()
    {
        Start.onClick.RemoveListener(OnButtonStartClick);
        Settings.onClick.RemoveListener(OnButtonStartClick);
        Exit.onClick.RemoveListener(OnButtonStartClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnButtonStartClick()
    {
        SceneManager.LoadScene("Level1");
    }
    void OnButtonSettingsClick()
    {
        SceneManager.LoadScene("Settings");
    }
    void OnButtonExitClick()
    {
        #if UNITY_EDITOR
        
        EditorApplication.isPlaying = false;
        #endif

        Application.Quit();

    }
}
