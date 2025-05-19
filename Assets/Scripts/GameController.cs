using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed;
    public static float TimeToSpawn;
    public static float score;
    public static float highScore;
    public static bool gameOver;
    public static string namePlayer = "Runner";
    public static string nameHighScore = "Player HighScore";

    public static void LoadData() 
    {
        GameController.highScore = PlayerPrefs.GetFloat("highScore", 0f);
        GameController.nameHighScore = PlayerPrefs.GetString("nameHighScore", "Runner");
    }

    public static void SaveData() 
    {
        if (GameController.score > GameController.highScore) 
        {
            PlayerPrefs.SetFloat("highScore", GameController.score);
            PlayerPrefs.SetString("nameHighScore", GameController.namePlayer);
            GameController.highScore = GameController.score;
            GameController.nameHighScore = GameController.namePlayer;
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        StartGame(); 
    }

    private void StartGame() 
    {
        GameController.LoadData();
        GameController.speed = 10f;
        GameController.TimeToSpawn = 8f;
        GameController.score = 0;
        GameController.gameOver = false;
        InvokeRepeating(nameof(ChangeDificult), 1f, 5f);
    }

    private void ChangeDificult() 
    {
        GameController.speed += 0.5f; //aceleraçao obst e background
        GameController.TimeToSpawn = Mathf.Clamp(GameController.TimeToSpawn - 1f, 2f, 8f); //tempo spawn obst 
        if (!GameController.gameOver) 
        {
            GameController.score += 5;
        }
    }
}
