using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    public string sceneNameReset;
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.R))
        {
           SceneManager.LoadScene(sceneNameReset);
        }

    }

}