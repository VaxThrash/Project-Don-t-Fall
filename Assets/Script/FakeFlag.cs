using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFlag : MonoBehaviour
{
    void Start() 
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    // Rend drapeau invisible
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Bloc visible
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }     
    } 

    public void ResetFakeFlag()
    { 
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
