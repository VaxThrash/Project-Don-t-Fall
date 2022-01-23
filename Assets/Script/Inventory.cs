using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int deathCount;
    public Text deathCountText;
    public Text deathCountEndText; // Affiche le Conut Death à la fin du niveau
    public static Inventory instance;

    public Animator animatorChrono; // Animation chrono

    public Text timerMinutes; // Variable Minutes
    public Text timerSeconds; // Variable Secondes
    public Text timerSeconds100; // Variable Milisecondes   
    public Text timerMinutesEnd; // Variable Minutes (End)
    public Text timerSecondsEnd; // Variable Secondes (End)
    public Text timerSeconds100End; // Variable Milisecondes (End) 

    private float startTime; // Contient les numéros (ex : 01:52:21)
    public float stopTime; // Contient les numéros une fois le chrono stoppé
    private float timerTime; // 

    public bool isRunning = false; // Chrono désactivé
    public PauseMenu pM; // Variable PauseMenu
    public Flag fg; // Variable Flag


    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un Inventory dans la scène");
            // Animation du chrono stoppé
            animatorChrono.enabled = false;  
            return;
        }
        
        instance = this;

    }

    void start() 
    {

    }

    // Update le nombre de Count + Active le timer
    public void Update() 
    {
        // initialize le temps ?
        timerTime = stopTime + (Time.time - startTime);
        // Calcul des minutes
        int minutesInt = (int)timerTime / 60;
        //Calcul des seconds % = modulo
        int secondsInt = (int)timerTime % 60;
        //Calcul des miliseconds 
        int seconds100Int = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));
        
        //Affiche le End Time Text
        timerMinutesEnd.text = timerMinutes.text.ToString();
        timerSecondsEnd.text = timerSeconds.text.ToString();
        timerSeconds100End.text = timerSeconds100.text.ToString();


        // Affiche le End DeathCount Text
        deathCountEndText.text = deathCount.ToString();    

        // Lance le timer 
        if (isRunning)
        {
            //Affiche les Minutes
            timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
            //Affiche les Secondes
            timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString(); 
            //Affiche les Milisecondes
            timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
        }

        //Si le joueur appuie sur espace, gauche, droite Sauf si End Panel & PausePanel activé
        if (Input.GetKeyDown("space") && fg.flagActivate == false && pM.pauseMenuActive == false)
        {
            // Lance le Chrono & Animation
            TimerStart();
        }  

        else if (Input.GetKeyDown("left") && fg.flagActivate == false && pM.pauseMenuActive == false)
        {
            TimerStart();
        }

        else if (Input.GetKeyDown("right") && fg.flagActivate == false && pM.pauseMenuActive == false)
        {
            TimerStart();
        }
    }


    // Ajoute + 1 dans le compteur
    public void AddDeath(int count)
    {
        deathCount += count;
        // Affiche le NB de MORT et Transform le Int en Text
        deathCountText.text = deathCount.ToString(); 
    }


    // Fonction démarrer chrono
    public void TimerStart()
    {
        if (!isRunning)
        {
            // Variable Running = Vraie
            isRunning = true;
            // Démarre le chrono
            startTime = Time.time;
            // Joue l' animation du chrono
            animatorChrono.enabled = true;
        }
    }

    // Fonction stopper chrono
    public void TimerStop()
    {
        if (isRunning)
        {
            // Variable Running = faux
            isRunning = false;
            // Arrête le timer
            stopTime = Time.time;
            // Arrète l'animation (sur la position actuelle de l'animation "freeze) 
            animatorChrono.enabled = false;
        }
    }

}