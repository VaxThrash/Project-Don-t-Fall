using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    //Panel Stting Window
    public GameObject settingsWindow;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //Si appuie sur ECHAP
        if(Input.GetKeyDown(KeyCode.Escape))
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
        //Empêche le Player d'effectuer une action 
        //P_Move.instance.enabled = false;
        //Active le menu Pause (Affiche)
        pauseMenuUI.SetActive(true);
        //Arrête le temps
        Time.timeScale = 0;
        //Changer le statut du jeu
        gameIsPaused = true;
    }

    public void Resume()
    {
        //Réactive les mouvement du Player
        //P_Moves.instance.enabled = true;
        //Désactive le menu Pause
        pauseMenuUI.SetActive(false);
        //Remet le temps
        Time.timeScale = 1;
        //Changer le statut du jeu
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        //Remet la valeur à 1 (mouvement joueur)
        Resume();
        //Charge le MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    //Activer la fenetre Panel Setting Window    
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

//Désactiver la fenetre Panel Setting Window
    public void CloseSettingsWindows()
    {
        settingsWindow.SetActive(false);
    }

//Quitte l'appli
    public void QuitGame()
    {
        Application.Quit();
    }
}