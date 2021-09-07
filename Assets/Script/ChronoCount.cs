using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Utilise UI

public class ChronoCount : MonoBehaviour
{
    Text text; // Reférence au Text (00:00:00)

    float theTime; // Variable Nombre
    public float speed = 1; // Changer la vitesse d'écoulement du chrono

    bool playingChrono; // Chrono Activé Oui/Non 

    //bool stopChrono;

    public Animator chronoBar;

    public BoxCollider2D boxCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        // Affiche le text
        text = GetComponent<Text>();   
        // Empêche l'animation de se jouer
        chronoBar.enabled = false;
    }

    // Update is called once per frame
    void Update()   
    {
        // Si variable playingChrono = true, lance le script
        if (playingChrono == true)
        {
            // 
            theTime += Time.deltaTime * speed;
            //Format Millisecondes
            //string milliseconds = Mathf.Floor(theTime % 99).ToString("00");
            
            // Affiche les secondes "format 60" - ToString = Affiche le format int en format strin (text)
            string seconds = Mathf.Floor(theTime % 60).ToString("00");
            // Affiche les minutes après écoulement des 60 secondes (60 * 60 = 3600)
            string minutes = Mathf.Floor((theTime % 3600)/60).ToString("00");
            // Affiche Minutes : secondes (01:56)
            text.text = minutes + " : " + seconds; 
        }

        //Si le joueur appuie sur n'importe quelle touche
        if (Input.GetKeyDown("space") || Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            // Lance le Chrono & Animation
            StartChrono();
        }

    }
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            StopChrono();
        }    
    }
    public void StartChrono() // Passe le Chrono en True > Start Chrono
    {   
        // Lance 
        playingChrono = true;   
        // Joue l' animation
        chronoBar.enabled = true;
    }

    public void StopChrono() // Passe le Chrono en False > Stop Chrono
    {
        // Ne pas continuer le chrono mais laisser vissible le "dernier" temps
        //text = GetComponent<Text>();
        playingChrono = false;
        // Arrète l'animation (sur la position actuelle de l'animation "freeze) 
        chronoBar.enabled = false;
        //?Time.timeScale = 0
    }
}
