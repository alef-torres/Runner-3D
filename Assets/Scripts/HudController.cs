using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    
    public TextMeshProUGUI score;
    //public TextMeshProUGUI highScore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score != null) 
        {
            score.text = "Score: " + GameController.score.ToString();
        }
    }
}
