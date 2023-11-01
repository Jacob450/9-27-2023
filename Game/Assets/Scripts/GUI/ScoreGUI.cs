using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreGui : MonoBehaviour
{
   
    private TMP_Text guiScore;
    
    // Start is called before the first frame update
    void Start()
    {
       
        guiScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore();
        highScore();
    }

    private void highScore()
    {
        if (GameManager.getGameOver() == true)
        {
            guiScore.text = "Your Score was: " + GameManager.getscore() + "\nThe Highest Score was: " + Save.loadScore();
            

        }
    }

    private void currentScore()
    {
        guiScore.text = "Score" + GameManager.getscore();
    }
}
