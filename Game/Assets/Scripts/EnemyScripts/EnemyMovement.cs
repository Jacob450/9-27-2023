using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemy;
    private PlayerMovement player;
    private WallCollider collide;
    public GameObject playerobject;
    public GameObject collider;

    private float baseGravity;
    private float numjump;
    public float movementSpeed;
    public float jumpFowardBoost;
    public float jumpForce;
    private bool canJump;
    private bool isWall;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = playerobject.GetComponent<PlayerMovement>();
        collide = collider.GetComponent<WallCollider>();
        canJump = false;
        isWall = false;
        baseGravity = enemy.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
        jump();
        if (isWall)
        {
            crawl();
        }
    }

    void followPlayer()
    {
        // Lateral Movement
        if (enemy.position.x < player.getplayerposx())
        {
            enemy.velocity = new Vector2(movementSpeed, enemy.velocity.y);
        }

        if (enemy.position.x > player.getplayerposx())
        {
            enemy.velocity = new Vector2(-movementSpeed, enemy.velocity.y);
        }
        // Basic Vertical movement


    }

    void jump()
    {
        if ((enemy.position.y < player.getplayerposy()-1 && canJump == true && collide.getCollide() == true))
        {
           
            
            enemy.velocity = new Vector2(enemy.velocity.x, jumpForce);

            //adds jumpboost speed while in the air
            
        }

    }

    private void crawl()
    {
        


        enemy.velocity = new Vector2(enemy.velocity.x, movementSpeed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            Debug.Log("canJump true");
        }
        //crawling on wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Collision");
            isWall = true;
        }

        collide.setCollide(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
            Debug.Log("canJump False");
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = false;
        }

    }
}
