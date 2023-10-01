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
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = playerobject.GetComponent<PlayerMovement>();
        collide = collider.GetComponent<WallCollider>();

        numjump = 2;
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
        if ((enemy.position.y < player.getplayerposy()-1 && numjump == 0 && collide.getCollide() == true))
        {
           
            numjump = 1;
            enemy.velocity = new Vector2(enemy.velocity.x, jumpForce);

            //adds jumpboost speed while in the air
            movementSpeed = movementSpeed + jumpFowardBoost;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //removes jumpboost seed when hitting the floor
        if (numjump == 1 && collision.gameObject.CompareTag("Floor") )
        {
            movementSpeed = movementSpeed - jumpFowardBoost;

        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            numjump = 0;
        }
        collide.setCollide(false);
    }
}
