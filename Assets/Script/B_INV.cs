using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_INV : MonoBehaviour
{   
    public SpriteRenderer sprite; // Modifier la couleur du Sprite
    public Vector3 originalPosition; //Position original
    public Rigidbody2D rb; // "Gravité"
    
    
    // Bloc invisible au début + Position & Rigidbody Static
    public void Start() 
    {
         // Position du Bloc au lancement de la scène
        originalPosition = gameObject.transform.position;
        // Bloc Invisible
        sprite.color = new Color(1f, 1f, 1f, 0f);
        // Varible temporaire pour prendre le RigidBody
        rb = GetComponent<Rigidbody2D>();
        // "Gravité" désactivé           
        rb.bodyType = RigidbodyType2D.Static;
    }
    
    
    // Fait apparaitre le Bloc quand Player rentre en collision (!Not Trigger!)
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Bloc visible
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }     
    }
   

   // SI le bloc entre dans les DZ(rouge, bleu, vert, rose) le bloc s'arrête au bout de 1 secondes (Trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("DZRed") || collision.transform.CompareTag("DZBlue") || collision.transform.CompareTag("DZGreen") || collision.transform.CompareTag("DZPink"))
        {
            StartCoroutine(BlocStop());
        }
    }
    
    // Stop le bloc 
    public IEnumerator BlocStop()
    {
        // Attend 1 seconds | Désactive le rigid body (Gravité Off)
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Static;
    }
   
    // Fonction pour Reset le bloc Inv
    public void ResetBlocInv()
    { 
        // Remet le RigidBody en static
        rb.bodyType = RigidbodyType2D.Static;
        // Remet la Rotation du Bloc à "0"
        transform.rotation = Quaternion.identity;
        // Replace le Bloc à sa position Roriginale
        gameObject.transform.position = originalPosition;
        // Bloc Invisible
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }
}