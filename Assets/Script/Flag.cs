using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger les scenes

public class Flag : MonoBehaviour
{
    public string sceneNameReset; // Scene a recharger
    public string nextSceneName; // Nom de la scene à charger
    public Inventory inventory; // Script Invenrory pour le TIMER
    public GameObject endPanelUI; // EndPanel
    public Animator fadeSystem; // Animation fondu blanc
    public Animator confettisAnimator; // Panel Confettis
    
    public static bool gameIsPaused = false; // Stop le jeu
    public SpriteRenderer greenFlag; // Drapeau Vert
    public SpriteRenderer redFlag;  // Drapeau Rouge
    //public bool endPanelUIActive = false; // Bool false/true pour désactiver "Left, Right, Space, R, ESC"
    public PauseMenu pM; // Variable PauseMenu
    public bool flagActivate = false; // Pour pas redémarrer le timer une fois le end panel plus actif et si le Player rebouge

    public AudioSource audioSource;
    public AudioClip soundEffect;

   
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }


    // Affiche le drapeau rouge (et masque le vert)
    void Start()
    {
        // Bool FlagActivate False
        flagActivate = false;
        // Désactive le EndPanel
        endPanelUI.SetActive(false);       
        // Drapeau color, REMPLACER PAR ANIMATION
        greenFlag.color = new Color(1f, 1f, 1f, 0f);
        redFlag.color = new Color(1f, 1f, 1f, 1f);
    }


    // Reset Scene si le EndPanel et le PausePanel est false
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && flagActivate == false && pM.pauseMenuActive == false)
        {
            // Charge le nom de la scene ouvert
            SceneManager.LoadScene(sceneNameReset);
            // Remet le temps
            Time.timeScale = 1;
            // Changer le statut du jeu
            gameIsPaused = false;
        }
        
    }


    // Si collision avec le Player alors affiche le drapeau Vert (et masque le rouge)
    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.transform.CompareTag("Player"))
        {
            redFlag.color = new Color(1f, 1f, 1f, 0f);
            greenFlag.color = new Color(1f, 1f, 1f, 1f);
            // Bool FlagActivate True
            flagActivate = true;
            // Stop le jeu
            StartCoroutine(EndPanel());
            // Stop le Timer
            inventory.TimerStop();
            
        }    
    }


    // Stop le jeu
    public IEnumerator EndPanel()
    {   
        // Atend 0.15 secondes
        yield return new WaitForSeconds(0.15f);
        // Active le EndPanel
        endPanelUI.SetActive(true);
        // Arrête le temps
        Time.timeScale = 0;
        // Changer le statut du jeu
        gameIsPaused = true;
        // Démarre l'animation Confettis
        confettisAnimator.enabled = true;
        // Joue le son "Pouet"
        audioSource.PlayOneShot(soundEffect);
        
    }



    public void Retry()
    {
        // Bool FlagActivate False
        flagActivate = false;
        // Charge la scene
        SceneManager.LoadScene(sceneNameReset);
        // Remet le temps
        Time.timeScale = 1;
        // Changer le statut du jeu
        gameIsPaused = false;
    }



    public void LoadMainMenu()
    {
        // Remet la valeur à 1 (pause du jeu/joueur)
        Resume();
        // Charge le MainMenu
        SceneManager.LoadScene("MainMenu");
    }


    // Charge la scene suivante
    public void NextScene()
    {
        // Remet la valeur à 1 (pause du jeu/joueur)
        Resume();
        StartCoroutine(LoadNextScene());
    }


    // Transistion en blanc et charge l'autre scene
    public IEnumerator LoadNextScene()
    {
        Resume();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextSceneName);
    }


    // Remettre les mouvements du Player
    public void Resume()
    {
        // Désactive le EndPanel
        endPanelUI.SetActive(false);
        // Remet le temps
        Time.timeScale = 1;
        // Changer le statut du jeu
        gameIsPaused = false;
    }
}
