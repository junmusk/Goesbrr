using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        // SceneManager.LoadSceneAsync(2);
        SceneManager.LoadScene("selectCharacter");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
