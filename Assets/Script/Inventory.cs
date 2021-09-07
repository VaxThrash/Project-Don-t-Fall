using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int deathCount;

    public Text deathCountText;
    public static Inventory instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un Inventory dans la scène");
            return;
        }
        
        instance = this;

    }


    // Ajoute + 1 dans le compteur
    public void AddDeath(int count)
    {
        deathCount += count;
        // Affiche le NB de MORT et Transform le Int en Text
        deathCountText.text = deathCount.ToString(); 
    }
}