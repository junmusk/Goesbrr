using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Reload() {
        SceneManager.LoadSceneAsync(3);
        // gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu() {
        
        SceneManager.LoadSceneAsync(0);
    }

}
