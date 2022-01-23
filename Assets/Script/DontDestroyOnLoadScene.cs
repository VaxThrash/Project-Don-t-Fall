
using UnityEngine;
using UnityEngine. SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
 
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    
    private void Awake()
    {
        // Si plusieurs instance (canevas, player, audio, ....)
        if(instance != null)
        {
            // Détruit les éléments en trop
            foreach (var element in objects)
            {
                Destroy(element);
            }
            
            Debug.Log("+ d'une instance de DontDestroyOnLoadScene supprimé");
            return;
                    
        }
        
        instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    //Méthode pour sortir le Player de DontDestroyOnLaod (pas le chargé 10 fois)
    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects) 
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());    
        }
    }

}