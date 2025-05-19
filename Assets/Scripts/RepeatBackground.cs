using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatWitdh;
    //float speed;
    void Start()
    {
        startPos = transform.position;
        repeatWitdh = GetComponent<BoxCollider>().size.x / 2;
    }   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWitdh) 
        {
            transform.position = startPos;
        }   
    }
}
