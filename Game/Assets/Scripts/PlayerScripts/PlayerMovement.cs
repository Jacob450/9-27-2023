using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public GameObject cam; 

    public float movementSpeed;
    public float jumpforce;
    public float jumpFowardBoost;

    private float baseGravity;
    private float inputHorizontal;
    private float inputVertical;

    private int numjump;
    private bool canJump;
    private bool isJumping;
    private bool isWall;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GetComponent<Rigidbody2D>();
        //set to 2 so that you cannot jump in mid air as soon as the game starts
        canJump = false;
        isWall = false;
        baseGravity = player.gravityScale;
    }
    
    // Update is called once per frame
    void Update()
    {
        moveplayer();
        jump();
        if(isWall)
        {
            crawl();
        }
        
    }
    
    private void moveplayer()
    {
        //returns -1 left
        //0 not moving
        // 1 right
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        
        player.velocity = new Vector2((movementSpeed * inputHorizontal) , player.velocity.y);
       
        
    }

    private void jump()
    {
        player.gravityScale = baseGravity;
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            isJumping = true;
            movementSpeed += jumpFowardBoost;
            player.velocity = new Vector2(player.velocity.x  , jumpforce);

            //adds jumpbppst speed while in the air
           // movementSpeed += jumpFowardBoost;
        }
        

    }

    private void crawl()
    {
        inputVertical = Input.GetAxisRaw("Vertical");


        player.velocity = new Vector2(player.velocity.x, movementSpeed * inputVertical);
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //removes jumpboost speed when hitting the floor
        if(isJumping == true && collision.gameObject.CompareTag("Floor"))
        {
            movementSpeed -=  jumpFowardBoost;
            isJumping=false;
        }
        //crawling on wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Wall Collision");
           isWall = true;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy (collision.gameObject);
        }
        if (collision.gameObject.CompareTag("OB"))
        {
            SceneManager.LoadScene("SampleScene");
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            isWall = false;
        }

    }



    public float getplayerposx()
    {
        return player.position.x; 
    }
    public float getplayerposy()
    {  
        return player.position.y;
    }
}
