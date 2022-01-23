using UnityEngine;
using System.Collections;


public class DZPink : MonoBehaviour
{
    public GameObject[] blocInvisibles; // Array de Blocs Invisibles, etc ...
    public GameObject[] blocsFall; // ..........
    public GameObject[] blocsTelEnter; // ..........
    public GameObject[] blocsTelOut; // ..........
    public GameObject[] blocsIntDetect; // ..........
    public GameObject pinkEye; // "Animation" Eyes
    public Flag fg; // Flag pour désactiver adddeath lorsque le joueur à activé le flag
    public GameObject[] fakeFlag; // Faux drapeau


    B_FALL b_Fall; // Variable pour accéder à la fonction ResetBlocFall, etc ...
    B_INV b_Inv; // ..........
    B_TEL_ENTER b_Tel_Enter; // ..........
    B_TEL_OUT b_Tel_Out; // ..........
    B_INTER_DETECT b_Int_Detect; // ..........
    FakeFlag fake_Flag; // Liste des Faux Drapeau
    

    // Liste les Blocs
    private void Start()
    {
        // Trouves les Blocs INV dans la scène, etc ...
        blocInvisibles = GameObject.FindGameObjectsWithTag("B_INV");
        // ..........
        blocsFall = GameObject.FindGameObjectsWithTag("B_FALL");
        // ..........
        blocsIntDetect = GameObject.FindGameObjectsWithTag("B_INTER_DETECT");
        // ..........
        blocsTelEnter = GameObject.FindGameObjectsWithTag("B_TEL_ENTER");
        // ..........
        blocsTelOut = GameObject.FindGameObjectsWithTag("B_TEL_OUT");
        // Trouve les Faux Drapeau et les listes dans la scène
        fakeFlag =  GameObject.FindGameObjectsWithTag("FakeFlag");
    }

    
    public void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player") && fg.flagActivate == false)
        {
            // Rajoute +1 mort dans le script "Inventory"
            Inventory.instance.AddDeath(1);
            // Affiche l'image RedEye
            StartCoroutine(ActivePinkEye());
            // Place le Player au Spawn
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
            
           // Reset chaque blocs Inv Position + Sprite rendrer
            foreach (var collectionInv in blocInvisibles)                
            {
                // Reset Position + SpriteRenderer des Blocs INV
                B_INV binv = collectionInv.GetComponent<B_INV>();
                binv.ResetBlocInv();
            }

            // Reset chaque blocs Fall Position
            foreach (var collectionFall in blocsFall)
            {
                B_FALL bf = collectionFall.GetComponent<B_FALL>();
                bf.ResetBlocFall();
                //Debug.Log("B_FALL sr: " + bf);
            }

            // Reset chaque blocs Tel Enter
             foreach (var collectionTelEnter in blocsTelEnter)
            {
                B_TEL_ENTER bte = collectionTelEnter.GetComponent<B_TEL_ENTER>();
                bte.ResetBlocTelEnter();
            }

            // Reset chaque blocs Int_Detec HitBox Trigger
             foreach (var collectionTelOut in blocsTelOut)
            {
                B_TEL_OUT bto = collectionTelOut.GetComponent<B_TEL_OUT>();
                bto.ResetBlocTelOut();
            }

            // Reset chaque blocs Int_Detec HitBox Trigger
             foreach (var collectionIntDetect in blocsIntDetect)
            {
                B_INTER_DETECT bid = collectionIntDetect.GetComponent<B_INTER_DETECT>();
                bid.ResetDetect();
            }

            // Reset chaqueFaux Drapeau
            foreach (var collectionFakeFlag in fakeFlag)
            {
                FakeFlag ff = collectionFakeFlag.GetComponent<FakeFlag>();
                ff.ResetFakeFlag();
            }
        }       
    }


    // Affiche l'image PinkEye
    public IEnumerator ActivePinkEye() 
    {
        // Active RedEye
        pinkEye.SetActive(true);
        // Attend 0.70 secondes
        yield return new WaitForSeconds(0.70f);
        // Desactive RedEye
        pinkEye.SetActive(false);
    }
}