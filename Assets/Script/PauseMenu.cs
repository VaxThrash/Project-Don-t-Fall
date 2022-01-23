using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger les scenes

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public bool pauseMenuActive = false; // Bool false/true pour désactiver "Left, Right, Space, R"
    public GameObject settingsWindow; // Settings Panel
    public GameObject pauseMenuUI; // Pause Panel
    public Flag fg; // Variable Flag
    

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //Si appuie sur ECHAP
        if(Input.GetKeyDown(KeyCode.Escape) && fg.flagActivate == false)
        {
            //Fonction Resume
            if(gameIsPaused)
            {
                Resume();
            }
            //Sinon Fonction Paused
            else
            {
                Paused();
                CloseSettingsWindows();
            }
        }
    }


    void Paused()
    {   
        // Bool Pause Menu TRUE
        pauseMenuActive = true;
        // Active le menu Pause (Affiche)
        pauseMenuUI.SetActive(true);
        // Arrête le temps
        Time.timeScale = 0;
        // Changer le statut du jeu
        gameIsPaused = true;
    }


    public void Resume()
    {
        // Bool Pause Menu FALSE
        pauseMenuActive = false;
        // Désactive le menu Pause
        pauseMenuUI.SetActive(false);
        // Remet le temps
        Time.timeScale = 1;
        // Changer le statut du jeu
        gameIsPaused = false;
    }


    public void LoadMainMenu()
    {
        // Remet la valeur à 1 (mouvement joueur)
        Resume();
        // Charge le MainMenu
        SceneManager.LoadScene("MainMenu");
    }


    // Activer la fenetre Panel Setting Window    
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }


    // Désactiver la fenetre Panel Setting Window
    public void CloseSettingsWindows()
    {
        settingsWindow.SetActive(false);
    }


    // Quitte l'appli
    public void QuitGame()
    {
        Application.Quit();
    }
}