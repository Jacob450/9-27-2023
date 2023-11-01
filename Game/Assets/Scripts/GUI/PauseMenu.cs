using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public GameObject backround;
    private bool paused;
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        pause();
    }

    private void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            GameManager.setGameOver(false);
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
            backround.transform.position = new Vector2(GameManager.getPlayerPosX(), GameManager.getPlayerPosY());
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            GameManager.setGameOver(true);
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1f;
        }
    }

    
}
