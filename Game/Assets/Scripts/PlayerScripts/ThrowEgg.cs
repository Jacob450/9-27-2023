using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowEgg : MonoBehaviour
{
    public GameObject egg;
    private Rigidbody2D rb;

    public float boostX;
    public float boostY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEgg();
        moveegg();
    }
    private void moveegg()
    {
        //Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
    private void spawnEgg()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameManager.getGameOver() == false)
        {
            GameObject spawnedEgg = Instantiate(egg);
            spawnedEgg.transform.position = transform.position;
            rb = spawnedEgg.GetComponent<Rigidbody2D>();

            
            
            //gets mouse position and converts to worldSpace
            Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

           //Debug.Log(mousePosition.origin.x - transform.position.x);
            
            rb.velocity = new Vector2 ((mousePosition.origin.x - transform.position.x) * boostX , (mousePosition.origin.y - transform.position.y) * boostY);
            //Debug.Log("Clicked");
        }
        
    }

   
}
