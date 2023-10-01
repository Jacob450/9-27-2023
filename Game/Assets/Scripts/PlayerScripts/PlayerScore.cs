using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }

    public int getscore()
    {
        return playerScore;
    }

    public void setPlayerScore(int val) 
    { 
        playerScore += val;
        Debug.Log(playerScore);
    }
}
