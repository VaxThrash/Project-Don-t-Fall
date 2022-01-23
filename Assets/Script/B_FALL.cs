using System.Collections; // Pour Coroutine
using System.Collections.Generic;
using UnityEngine;


public class B_FALL : MonoBehaviour
{

    public GameObject objectToFall; //Bloc FALL (lui-même)
    public Vector3 originalPosition; //Position original
    public Rigidbody2D rb; // "Gravité"
    //public bool actived; // Bloc activé oui-non


    // Start is called before the first frame update
    public void Start()
    {
        // Position du Bloc au lancement de la scène
        originalPosition = gameObject.transform.position;
        // Bloc activé non
        //actived = false; 
        
        // Varible temporaire pour prendre le RigidBody
        rb = GetComponent<Rigidbody2D>();
        // "Gravité" désactivé           
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Replace le bloc à sa Position originale + rotation + rigidbody statique  
    void Update()
    {   

    }

    // Appel la fonction blocFalling SI le joueur rentre dans le trigger | SINON le bloc touche les DZ(rouge, bleu, vert, rose) le bloc s'arrête au bout de 1 secondes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(BlocFalling());
        }

        else

            if (collision.transform.CompareTag("DZRed") || collision.transform.CompareTag("DZBlue") || collision.transform.CompareTag("DZGreen") || collision.transform.CompareTag("DZPink"))
            {
                StartCoroutine(BlocStop());
            }
    }
 

    public IEnumerator BlocFalling()
    {    
        // Attend 0.60 seconds | Active le RigidBody (Gravité On)
        yield return new WaitForSeconds(0.60f);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public IEnumerator BlocStop()
    {
        // Attend 1 seconds | Désactive le rigid body (Gravité Off)
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Static;
    }


    // Fonction pour Reset le bloc Fall (Position)
    public void ResetBlocFall()
    { 
        // Remet le RigidBody en static
        rb.bodyType = RigidbodyType2D.Static;
        // Remet la Rotation du Bloc à "0"
        transform.rotation = Quaternion.identity;
        // Replace le Bloc à sa position Roriginale
        gameObject.transform.position = originalPosition;
    }
}
