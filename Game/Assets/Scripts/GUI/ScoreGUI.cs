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
        guiScore.text = "Score"+ GameManager.getscore();
    }
}
