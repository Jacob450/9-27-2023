using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;


    public float movementSpeed;
    public float playerMovementSpeed;
    public float jumpforce;
    public float cameraPosY;
    public double MaxStamina;

    private double stamina;
    private float baseGravity;
    private float inputHorizontal;
    private float inputVertical;
  
    private bool canJump;
    private bool buttonDown;
   
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager.setGameOver(false);
        GameManager.setPlayerSpeed(movementSpeed);
        player = GetComponent<Rigidbody2D>();
        //set to 2 so that you cannot jump in mid air as soon as the game starts
        canJump = true;
        baseGravity = player.gravityScale;

        
    }
    
    // Update is called once per frame
    void Update()
    {
        moveplayer();
        jump();
        
    }
    
    private void moveplayer()
    {
        //returns -1 left
        //0 not moving
        // 1 right
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        
        player.velocity = new Vector2( (movementSpeed) , player.velocity.y);
        if(inputHorizontal == 1)
        {
            player.velocity = new Vector2((movementSpeed)+playerMovementSpeed, player.velocity.y);
        }
        if (inputHorizontal == -1)
        {
            player.velocity = new Vector2((movementSpeed) - playerMovementSpeed, player.velocity.y);
        }
        GameManager.setPlayerPos(player.position.x,player.position.y);
    }

    private void jump()
    {
        
        
        player.gravityScale = baseGravity;
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true || buttonDown == true)
        {            
            player.velocity = new Vector2(player.velocity.x  , jumpforce);  
            
            canJump = false;
            buttonDown = true;           
        }
       
        if (Input.GetKeyUp(KeyCode.Space))
        {
            buttonDown = false;
        }
    }

    
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy (collision.gameObject);
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OB"))
        {
            GameManager.setGameOver(true);
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
