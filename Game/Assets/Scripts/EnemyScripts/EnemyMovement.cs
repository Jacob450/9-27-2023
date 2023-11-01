using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemy;
    private Rigidbody2D enemyEgg;
    public GameObject egg;

    private float baseGravity;
    private float numjump;
    public float movementSpeed;
    public float eggForce;
    
    public float jumpForce;
    private bool canJump;
    private bool thrown;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
       
        thrown = false;
        canJump = true;
        
        baseGravity = enemy.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        jump();
        enemyThrowEgg();
        
    }
    private void enemyThrowEgg()
    {
       
        if (enemy.position.x - GameManager.getPlayerPosX() < 2 && thrown == false)
        {
            GameObject spawnedEgg = Instantiate(egg);
            spawnedEgg.transform.position = transform.position;
            enemyEgg = spawnedEgg.GetComponent<Rigidbody2D>();

            enemyEgg.velocity = new Vector2(enemyEgg.velocity.x, enemyEgg.velocity.y * eggForce);
            thrown = true;
        }
    }

    void followPlayer()
    {
        // Lateral Movement
        

        if (enemy.position.x > GameManager.getPlayerPosX() )
        {
            enemy.velocity = new Vector2(-movementSpeed, enemy.velocity.y);
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        // Basic Vertical movement


    }

    void jump()
    {
        if (canJump == true )
        {
           
            
            enemy.velocity = new Vector2(enemy.velocity.x, jumpForce);

            canJump = false;
            
        }

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
           
        }
        
       
      
    }

    
}
