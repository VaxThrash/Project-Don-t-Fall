using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class B_INTER_DETECT : MonoBehaviour
{
    public GameObject[] blocs; // Liste des blocs Fall Inv Tel
    public BoxCollider2D bc; // Hitbox detect
    
    
    void Start() 
    {
        bc = bc.GetComponent<BoxCollider2D>();
        bc.enabled = true;
    }
    // Si le joueur entre dans le detect > Active le Rigidbody des Blocs dans la liste
    private void OnTriggerEnter2D(Collider2D collision)
    {   
       if (collision.CompareTag("Player"))
        {
            foreach (var collectionBlocs in blocs)                
            {
                Rigidbody2D rb = collectionBlocs.GetComponent<Rigidbody2D>();
                rb.bodyType = RigidbodyType2D.Dynamic;
                // Desactive le trigger detect
                bc.enabled = false;
            }
        }
    }


    // Reactive le trigger detect
    public void ResetDetect()
    {
        bc.enabled = true;
    }
}

