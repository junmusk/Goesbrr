using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;

    public void Resume() {
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu() {
        
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitGame() {
        print("Quit Game");
        Application.Quit();
    }
}
