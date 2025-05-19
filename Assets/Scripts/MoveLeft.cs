using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    void Start()
    {
        if (CompareTag("Obstacle"))
        {
            Destroy(this.gameObject, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameOver) 
        {
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
        }
    }
}
