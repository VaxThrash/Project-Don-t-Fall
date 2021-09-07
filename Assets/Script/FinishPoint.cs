using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public SpriteRenderer greenFlag;
    public SpriteRenderer redFlag;
    // Start is called before the first frame update
    void Start()
    {
        greenFlag.color = new Color(1f, 1f, 1f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            greenFlag.color = new Color(1f, 1f, 1f, 1f);
            Destroy(redFlag); 
        }
    }

    
}
