using UnityEngine;

public class PedraGambiarra : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        
    }
}
