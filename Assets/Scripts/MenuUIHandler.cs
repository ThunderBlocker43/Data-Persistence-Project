using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField usernameInput;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        GameManager.Instance.username = usernameInput.text;
    }
    
    public void Exit() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
