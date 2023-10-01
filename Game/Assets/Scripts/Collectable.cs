using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collectableValue;
    public GameObject playerObject;
    private PlayerScore gameScore;

    
    // Start is called before the first frame update
    void Start()
    {
        gameScore = playerObject.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameScore.setPlayerScore(collectableValue);
            Destroy(this.gameObject);
        }
    }
}
