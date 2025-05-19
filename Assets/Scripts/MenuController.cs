using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TMP_InputField inputField;
    void Start()
    {
        
    }

    public void StartGame() 
    {
        if (inputField.text.Length > 0) 
        {
            GameController.namePlayer = inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
