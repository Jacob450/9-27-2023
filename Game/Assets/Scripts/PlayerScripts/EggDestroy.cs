using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    private bool playerExit;
    private bool enemyExit;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerExit = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyExit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && playerExit == true)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.addPlayerScore(1);
        }
        if (collision.gameObject.CompareTag("Player") && enemyExit == true)
        {
            GameManager.setGameOver(true);
        }

    }
}
