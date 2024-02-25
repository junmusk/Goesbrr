using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using Cinemachine;

public class CMController : MonoBehaviour
{
    CinemachineVirtualCamera vcam;

    public GameObject mainMenu;
    public GameObject gameOverPanel;
    public TMP_Text TMP_Health;
    public TMP_Text TMP_Point;
    public TMP_Text TMP_BestPoint;
    
    public GameObject[] playerPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isPlayerAlive", 1);
        int selectedPlayer = PlayerPrefs.GetInt("selectedPlayer");

        Instantiate(playerPrefabs[selectedPlayer], transform.position, Quaternion.identity);

        Time.timeScale = 1;
        vcam = GetComponent<CinemachineVirtualCamera>();

        vcam.Follow = GameObject.FindWithTag("Player").transform;

        mainMenu.SetActive(false);
        

        PlayerPrefs.SetInt("playerPoint", 0);

        TMP_Health.text = "Health : " + PlayerPrefs.GetInt("playerHealth");
        TMP_Point.text = "Point   : " + PlayerPrefs.GetInt("playerPoint");
        TMP_BestPoint.text = "Best    : " + PlayerPrefs.GetInt("playerBestPoint");

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("r")) SceneManager.LoadSceneAsync(3);
        if(Input.GetKeyDown("escape")) ToggleMenu();
    
        if (PlayerPrefs.GetInt("isPlayerAlive") == 0) ToggleGameOver();

        TMP_Health.text = "Health : " + PlayerPrefs.GetInt("playerHealth");
        TMP_Point.text = "Point   : " + PlayerPrefs.GetInt("playerPoint");
        TMP_BestPoint.text = "Best    : " + PlayerPrefs.GetInt("playerBestPoint");
        
    }

    public void ToggleMenu() {
        if (!mainMenu.activeSelf) {
            mainMenu.SetActive(true);
            PauseGame();
        } else {
            mainMenu.SetActive(false);
            ResumeGame();
        }
    }

    public void ToggleGameOver() {
        if (!gameOverPanel.activeSelf) {
            gameOverPanel.SetActive(true);
            StartCoroutine(PauseGameAfter(0.3f));
        }
    }

    IEnumerator  PauseGameAfter(float duration) {
        yield return new WaitForSeconds(duration);
        PauseGame();
    }

    void PauseGame ()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }

}
