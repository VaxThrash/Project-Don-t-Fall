
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad; // Level à charger

    public GameObject settingsWindow; // Fenêtre des Options
    public GameObject howToPlayWindow; // Fenêtre comment jouer

    // Démarrer la Scene 0   
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Activer la fenetre Settings 
    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    // Désactiver la fenetre Settings
    public void CloseSettingsWindows()
    {
        settingsWindow.SetActive(false);
    }

    // Activer la fenetre HowToPlay    
    public void HowToPlayButton()
    {
        howToPlayWindow.SetActive(true);
    }

    // Désactiver la fenetre HowToPlay 
    public void CloseHowToPlayWindows()
    {
        howToPlayWindow.SetActive(false);
    }
    
    // Quitter Application
    public void QuitGame()
    {
        Application.Quit();
    }
}
