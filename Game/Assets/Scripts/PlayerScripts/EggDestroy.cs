using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            GameManager.addPlayerScore(1);
        }
    }
}
