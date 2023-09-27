using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;

    public float movementSpeed;
    public float jumpforce;
    public float jumpFowardBoost;

    private float baseGravity;
    private float inputHorizontal;

    private int numjump;
    
    private bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        //set to 2 so that you cannot jump in mid air as soon as the game starts
        numjump = 2;

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
        
        
        player.velocity = new Vector2((movementSpeed * inputHorizontal) , player.velocity.y);
        
        
    }

    private void jump()
    {
        player.gravityScale = baseGravity;
        if (Input.GetKeyDown(KeyCode.Space) && numjump == 0)
        {
            numjump = 1;
            player.velocity = new Vector2(player.velocity.x  , jumpforce);

            movementSpeed = movementSpeed + jumpFowardBoost;
        }

        if (player.velocity.y < 0)
        {
            Debug.Log("Negative velocity");
            isFalling = true;

        }

        if(isFalling )
        {
            player.gravityScale = baseGravity + 5;
            isFalling = false;
        }
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(numjump == 1 && collision.gameObject.CompareTag("Floor"))
        {
            movementSpeed = movementSpeed - jumpFowardBoost;
            
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            numjump = 0;
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

}
