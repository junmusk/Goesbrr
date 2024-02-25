using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class selectCharacter : MonoBehaviour
{

    [SerializeField] TMP_Text TMP_BestPoint;

    void Start() {
        int BestPoint = PlayerPrefs.GetInt("playerBestPoint");

        TMP_BestPoint.text = BestPoint + "";
    }

   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
        // SceneManager.LoadSceneAsync(Scene.Loading);

    }

    public void PlayAsDom() {
        
        PlayerPrefs.SetInt("selectedPlayer", 0);
        SceneManager.LoadSceneAsync(3);
    }

    public void PlayAsKelly() {
        
        PlayerPrefs.SetInt("selectedPlayer", 1);
        SceneManager.LoadSceneAsync(3);
    }

    public void PlayAsJacob() {
        
        PlayerPrefs.SetInt("selectedPlayer", 2);
        SceneManager.LoadSceneAsync(3);
    }
}
