using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public GameObject gameoverPanel;


    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }
    
    public void GameOver()
    {
        gameoverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
