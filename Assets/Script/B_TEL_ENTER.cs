using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_TEL_ENTER : MonoBehaviour
{   
    //public GameObject player; // Joueur (ralentir la vélocité))
    public GameObject blocTelOut; // Bloc de sortie (relié)
    public Vector3 originalPosition; //Position original
    public Rigidbody2D rb; // "Gravité"
    

    public void Start()
    {
        // Position du Bloc au lancement de la scène
        originalPosition = gameObject.transform.position;
        // Trigger Désactiver
        GetComponent<Collider2D>().isTrigger = false;
        // Varible temporaire pour prendre le RigidBody
        rb = GetComponent<Rigidbody2D>();
        // "Gravité" désactivé           
        rb.bodyType = RigidbodyType2D.Static;
    }


    // Si le joueur touche la Boxcollider
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Active le trigger du B_TEL_OUT
            blocTelOut.GetComponent<BoxCollider2D>().isTrigger = true;
            // Place le Player au B_TEL_OUT
            collision.transform.position = blocTelOut.transform.position;
        }


        // SINON le bloc touche les DZ(rouge, bleu, vert, rose) le bloc s'arrête au bout de 1 secondes
        else if (collision.transform.CompareTag("DZRed") || collision.transform.CompareTag("DZBlue") || collision.transform.CompareTag("DZGreen") || collision.transform.CompareTag("DZPink"))
        {
            StartCoroutine(BlocStop());
        }
    }

    // Si le Player sort du trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Trigger ENTER Désactiver
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    // Attend 1 seconds | Désactive le rigid body (Gravité Off)
    public IEnumerator BlocStop()
    {
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Static;
    }
    

    // Fonction pour Reset le bloc Fall
    public void ResetPositionBlocTelEnter()
    { 
        // Remet le RigidBody en static
        rb.bodyType = RigidbodyType2D.Static;
        // Remet la Rotation du Bloc à "0"
        transform.rotation = Quaternion.identity;
        // Replace le Bloc à sa position Roriginale
        gameObject.transform.position = originalPosition;
    }


    //En attendant de trouver une autre formule avec un "while player is in trigger dont teleport"
    public IEnumerator HitboxOnOff()
    {
        //Désactive la hitbox B_TEL_OUT | Attend 1 Seconde | Active la Hitbox
        blocTelOut.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        blocTelOut.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Fonction pour Reset le bloc Tel Enter
    public void ResetBlocTelEnter()
    { 
        // Remet le RigidBody en static
        rb.bodyType = RigidbodyType2D.Static;
        // Remet la Rotation du Bloc à "0"
        transform.rotation = Quaternion.identity;
        // Replace le Bloc à sa position Roriginale
        gameObject.transform.position = originalPosition;
        // Trigger Désactiver
        GetComponent<Collider2D>().isTrigger = false;
    }
}
