using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameManager
{
    static private float playerpositionX;
    static private float playerpositionY;

    static private int playerScore;
    static private float playerSpeed;
    static private bool gameover;







    //Gameover functions==================================
    static public void setGameOver(bool g)
    {
        gameover = g;
    }

    static public bool getGameOver()
    {
        return gameover;
    }




    //Player Attributes===================================
    static public void setPlayerSpeed(float s)
    {
        playerSpeed = s;
    }

    static public float getPlayerSpeed()
    {
        return playerSpeed;
    }

   
  
    //playerScore Functions==================================
    static public int getscore()
    {
        return playerScore;
    }

    static public void setPlayerScore(int val)
    {
        playerScore = val;

    }
    static public void addPlayerScore(int val)
    {
        playerScore += val;
        
    }

    //playerPosition Functions===============================
    static public void setPlayerPos(float x, float y)
    {
        playerpositionX = x;
        playerpositionY = y;
    }

    static public float getPlayerPosX() { 
        return playerpositionX;
    }

    static public float getPlayerPosY()
    {
        return playerpositionY;
    }
}
