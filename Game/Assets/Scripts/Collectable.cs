using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collectableValue;
   
    public int offset;
    private float startPosY;
    private bool moveUp;
    // Start is called before the first frame update
    void Start()
    {
       
        moveUp = false;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        move();
    }

    private void move()
    {
        //y movement
        if (moveUp == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1 * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1 * Time.deltaTime);
        }

        //When to go up
        if (transform.position.y >= startPosY)
        {
            moveUp = false;
        }

        if (transform.position.y <= startPosY - offset)
        {
            moveUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.addPlayerScore(collectableValue);
            Destroy(this.gameObject);
        }
    }
}
