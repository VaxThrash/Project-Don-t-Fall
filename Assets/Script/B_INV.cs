using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_INV : MonoBehaviour
{   
    public SpriteRenderer sprite; // Modifier la couleur du Sprite
    public bool actived; // Bool, si bloc activé oui-non
    
    // Bloc invisible au début
    public void Start() 
    {
        // Bool, bloc activé non
        actived = false;
        // Bloc Invisible
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }
    
    // Fait apparaitre le Bloc quand Player rentre en collision
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Bool, bloc activé oui
            actived = true;
            // Bloc visible
            sprite.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    
    // Fonction Reload Color pour ne pas faire appel à la fonction Start (Jamais refaire appel à Start/Initialization)
    public void ReloadColor()
    {
        // Bool, bloc activé non
        actived = false;
        // Bloc Invisible
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }
}