using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField]
    InputField nameInput;
    public string PlayerName ="";
    
    private void Awake(){

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        PlayerName = nameInput.text;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }   
}
