using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemy;
   
    private float baseGravity;
    private float numjump;
    public float movementSpeed;
    
    public float jumpForce;
    private bool canJump;
    private bool isWall;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        
        
        canJump = true;
        
        baseGravity = enemy.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        jump();
        
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
