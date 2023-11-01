using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject OverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkGameOver();
    }

    public void checkGameOver()
    {
        if(GameManager.getGameOver() == true)
        {
            Save.saveScore(GameManager.getscore());
            
            OverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void restartGame()
    {
        GameManager.setPlayerScore(0);
        Time.timeScale = 1f;
        OverScreen.SetActive(false);
        GameManager.setGameOver(false);
        SceneManager.LoadScene("SampleScene");
        
    }
    public void quit()
    {
        Application.Quit();
    }
}
