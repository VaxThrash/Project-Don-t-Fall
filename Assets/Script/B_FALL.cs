using System.Collections; // Pour Coroutine
using System.Collections.Generic;
using UnityEngine;


public class B_FALL : MonoBehaviour
{

    public GameObject objectToFall;
    public Rigidbody2D rb; // "Gravité"
    public bool actived; // Bloc activé oui-non

    Vector3 originalPos; // Position original du bloc



    // Start is called before the first frame update
    public void Start()
    {
        // Position original
        //originalPos = gameObject.transform.position;
        // Bloc activé non
        actived = false; 
        rb = GetComponent<Rigidbody2D>();
        // "Gravité" désactivé           
        rb.bodyType = RigidbodyType2D.Static;
    }
        // Appel la fonction blocFalling si le joueur rentre dans le trigger
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(BlocFalling());
        }

            else

                if (collision.transform.CompareTag("DeathZone"))
                {
                    StartCoroutine(BlocStop());
                }
    }

    public IEnumerator BlocFalling()
    {
        // Bloc activé oui
        actived = true; 
        
        // Attend 0.40 seconds | Active le RigidBody (Gravité On)
        yield return new WaitForSeconds(0.40f);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public IEnumerator BlocStop()
    {
        // Attend 1 seconds | Désactive le rigid body (Gravité Off)
        yield return new WaitForSeconds(1f);
        rb.bodyType = RigidbodyType2D.Static;
    }
}
