using UnityEngine;
using System.Collections;


public class DeathZone : MonoBehaviour
{
    //public B_INV b_INV; // Script B_INV
    //public B_FALL b_FALL; // Script B_FALL
    
    public GameObject deathCountRedEye;

    public B_INV[] blocInvTab; // Array des blocs invisible
    public B_FALL[] blocFallTab; // Array des blocs Tombe
    
    // Liste les Blocs
    private void Start()
    {
        deathCountRedEye.SetActive(false);

        //blocInvTab = GameObject.FindGameObjectWithTag("B_INV");
        //blocFallTab = GameObject.FindGameObjectWithTag("B_FALL");
        //blocInvArray= GameObject.FindGameObjectsWithTag("B_INV").GetComponents(typeof(B_INV));
        //blocFallArray= GameObject.FindGameObjectsWithTag("B_FALL").GetComponents(typeof(B_FALL));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
        {
            // Rajoute +1 mort dans le script "Inventory"
            Inventory.instance.AddDeath(1);
            // Affiche l'image RedEye
            StartCoroutine(ActiveRedEye());
            // Place le Player au Spawn
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
                   
            // Remet le(s) Bocl(s) Invisible
            
            /*foreach (B_INV blocInv in blocInvTab)
            {
                blocInv.sprite.color = new Color(1f, 1f, 1f, 0f);
            }*/
            
            
            // Remet le(s) Bocl(s) Fall à sa position original
           
                
        }       
    }

        public IEnumerator ActiveRedEye() // Affiche l'image RedEye

    {
        // Active RedEye
        deathCountRedEye.SetActive(true);
        // Attend 0.70 secondes
        yield return new WaitForSeconds(0.70f);
        // Desactive RedEye
        deathCountRedEye.SetActive(false);
    }
}