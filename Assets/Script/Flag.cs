using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public SpriteRenderer greenFlag;
    public SpriteRenderer redFlag;
    
    public Animator animatorChrono;
  
    
    //public GameObject chonoBar;
    void Start()
    {
        greenFlag.color = new Color(1f, 1f, 1f, 0f);
        redFlag.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            redFlag.color = new Color(1f, 1f, 1f, 0f);
            greenFlag.color = new Color(1f, 1f, 1f, 1f);
            StopChrono();
        }    
    }

    public void StopChrono()
    {
        //playingChrono = false;
        animatorChrono.enabled = false;
    }
}
