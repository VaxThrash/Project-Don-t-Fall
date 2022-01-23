using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public void LoadMenuMain()
    {
        SceneManager.LoadScene("MainMenu");
    }


    // Pour Skip les credit
    //private void Update() 
    //{
      //  if(Input.GetKeyDown(KeyCode.Escape))
        // {
            // LoadMenuMain();
        // }
    // }
}
