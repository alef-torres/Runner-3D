using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;

    void Start()
    {
        GameController.SaveData();
        score.text = GameController.namePlayer + " Score: " + GameController.score.ToString();
        highScore.text = "HighScore is " + GameController.highScore.ToString() + " of " + GameController.nameHighScore;
        Invoke(nameof(GoMenu), 5f);
    }

    void Update()
    {
        
    }

    void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
